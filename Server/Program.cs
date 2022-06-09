using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        const int port = 8888;
        //TcpListener - Прослушивает подключения от TCP-клиентов сети.
        static TcpListener listener;
        static void Main(string[] args)
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                Console.WriteLine("Ожидание подключений...");

                while (true)
                {
                    //Принятие запроса на подключение
                    TcpClient client = listener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(client);

                    // создаем новый поток для обслуживания нового клиента
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }
    }

    class ClientObject
    {
        public TcpClient client;

        public string path = @"C:\";
        public ClientObject(TcpClient tcpClient)
        {
            client = tcpClient;
            DirectoryInfo dirInfo = new DirectoryInfo(path);
        }

        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[64]; // буфер для получаемых данных
                while (true)
                {
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();

                    Console.WriteLine(message);

                    // отправляем обратно сообщение
                    if (message.IndexOf("|") == -1) //Если не прислали с доп.инфой
                    {
                        message = message.Substring(message.IndexOf(':') + 1).Trim();
                    }
                    message = Command(message);
                    data = Encoding.Unicode.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }

        public string Command(string value)
        {
            string res = "";

            string[] commands = value.Split('|');

            switch (commands[0])
            {
                case "getPath":
                    res = GetCurrentPath();
                    break;
                case "getFolders":
                    res = GetSubdirectories();
                    if (String.IsNullOrEmpty(res))
                        res = " ";
                    break;
                case "getFiles":
                    res = GetFiles();
                    if (String.IsNullOrEmpty(res))
                        res = " ";
                    break;
                case "back":
                    BackPath();
                    res = path;
                    break;
                case "deleteFile":
                    DeleteFile(value, ref res);
                    break;
                case "move":
                    if (commands.Length >= 3)
                        res = Move(commands[1], commands[2], commands[3]);
                    else
                        res = "Неверно передан запрос серверу";
                    break;
                case "copy":
                    if (commands.Length >= 3)
                        res = Copy(commands[1], commands[2], commands[3]);
                    else
                        res = "Неверно передан запрос серверу";
                    break;
                default:
                    res = NextPath(value);
                    break;
            }

            return res;
        }

        public string NextPath(string value)
        {
            if (Directory.Exists(path + value))
            {
                path += "/" + value;
                return path;
            }

            return "Такого каталога не существует";
        }

        public string GetCurrentPath()
        {
            return path;
        }

        public string GetSubdirectories()
        {
            string res = "";
            string[] dirs = Directory.GetDirectories(path + "/");
            foreach (string str in dirs)
            {
                string newStr = str.Replace(path, "");
                res += $"{newStr}\n";
            }

            return res;
        }

        public string GetFiles()
        {
            string res = "";

            foreach (string str in Directory.GetFiles(path))
            {
                string newStr = str.Replace(path, "");
                res += $"{newStr}\n";
            }

            return res;
        }

        public void BackPath()
        {
            path = Directory.GetParent(path).ToString();
        }

        public void DeleteFile(string pathFile, ref string message)
        {
            try
            {
                pathFile = pathFile.Substring(pathFile.IndexOf('|') + 1).Trim();
                FileInfo file = new FileInfo(pathFile);
                DirectoryInfo dir = new DirectoryInfo(pathFile);
                if (file.Exists)
                {
                    file.Delete();
                    message = "Файл удалён";
                }else if (dir.Exists)
                {
                    Directory.Delete(pathFile, true);
                    message = "Папка удалёна";
                }
                else
                {
                    message = "Данный элемент отсутствует";
                }
            }
            catch (Exception ex)
            {
                message = ex.ToString();
            }
        }

        public string Copy(string pathFromCopy, string pathToCopy, string name)
        {
            string result = "";
            if (File.Exists(pathFromCopy + name))
            {
                if (Directory.Exists(pathToCopy))
                {
                    File.Copy(pathFromCopy + name, pathToCopy + name);
                    result = "Файл успешно скопирован";
                }
                else
                {
                    result = "Неверный путь конечного копирования";
                }
            }
            else 
            {
                //Берём исходную папку
                DirectoryInfo dir_inf = new DirectoryInfo(pathFromCopy);

                foreach (DirectoryInfo dir in dir_inf.GetDirectories())
                {
                    //Если директории не существует, то создаём
                    if (!Directory.Exists(pathToCopy + name))
                    {
                        Directory.CreateDirectory(pathToCopy + name);
                    }

                    //Перебор рекурсией подпапок
                    Copy(dir.FullName, pathToCopy, name);
                }


                foreach (string file in Directory.GetFiles(pathFromCopy))
                {
                    string filik = file.Substring(file.LastIndexOf('\\'), file.Length - file.LastIndexOf('\\'));
                    File.Copy(file, pathToCopy + filik, true);
                }
                /*DirectoryInfo dir = new DirectoryInfo(pathFromCopy + name);
                dir.MoveTo(pathToCopy + name);*/
                result = "Папка успешно скопирована";
            }
            return result;
        }

        public string Move(string pathFromMove, string pathToMove, string name)
        {
            string result = "";
            if (File.Exists(pathFromMove + name))
            {
                if (Directory.Exists(pathToMove))
                {
                    File.Move(pathFromMove + name, pathToMove + name);
                    result = "Файл успешно перемещён";
                }
                else
                {
                    result = "Неверный путь конечного перемещения";
                }
            }
            else if (Directory.Exists(pathFromMove + name))
            {
                if (Directory.Exists(pathToMove))
                {
                    DirectoryInfo dir = new DirectoryInfo(pathFromMove + name);
                    dir.MoveTo(pathToMove + name);
                    result = "Папка успешно перемещёна";
                }
                else
                {
                    result = "Неверный путь конечного копирования";
                }
            }
            else
            {
                result = "Невозможно переместить папку/файл";
            }
            return result;
        }
    }
}
