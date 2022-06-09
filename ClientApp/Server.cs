using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    class Server
    {
        public static string pathCopy = ""; //Откуда копировать
        public static string pathPaste = ""; //Куда копировать
        public static string namePaste = ""; //Название папки/файла

        //Команда текущего расположения в директории
        const string commandGetPath = "getPath";
        //Команда получения папок в текущей директории
        const string commandGetFolders = "getFolders";
        //Команда получения файлов в текущей директории
        const string commandGetFiles = "getFiles";
        //Вернуться назад по директории
        const string commandBack = "back";
        //Удалить файл
        const string commandDeleteFile = "deleteFile|";
        //Переместить файл/папку
        const string commandMove = "move|";
        //Копировать файл/папку
        const string commandCopy = "copy|";

        public static bool isConnect = false;
        public static string CurrentPath {
            get
            {
                return GetPath();
            }
        }
        private static NetworkStream stream;
        public static bool Connect(string address, int port)
        {
            try
            {
                TcpClient client = new TcpClient(address, port);
                stream = client.GetStream();
                isConnect = true;
            }
            catch (Exception ex)
            {
                isConnect = false;
            }

            return isConnect;
        }

        public static void NextPath(string value)
        {
            if (value == "..") value = commandBack;

            byte[] command = Encoding.Unicode.GetBytes(value);
            //Передача команды
            stream.Write(command, 0, command.Length);

            byte[] data = new byte[64]; //Буфер для получаемых данных
            StringBuilder builderPath = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                builderPath.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);
        }

        /// <summary>
        /// Информация о файлах и папках в директории
        /// </summary>
        /// <param name="files">файлы в директории</param>
        /// <param name="folders">папки в директории</param>
        public static void GetInfoPath(ref string[] files, ref string[] folders)
        {
            byte[] commandFolders = Encoding.Unicode.GetBytes(commandGetFolders);
            byte[] commandFiles = Encoding.Unicode.GetBytes(commandGetFiles);
            StringBuilder builderFolders = new StringBuilder();
            StringBuilder builderFiles = new StringBuilder();
            try
            {

                //Получение папок
                stream.Write(commandFolders, 0, commandFolders.Length);

                byte[] dataFolders = new byte[64]; //Буфер для получаемых данных
                int bytes = 0;
                do
                {
                    bytes = stream.Read(dataFolders, 0, dataFolders.Length);
                    string nameFolder = Encoding.Unicode.GetString(dataFolders, 0, bytes);

                    builderFolders.Append(nameFolder);

                    if (builderFolders.ToString() == "") break; //Если файлы не были найдены
                }
                while (stream.DataAvailable);

                //Получение файлов
                stream.Write(commandFiles, 0, commandFiles.Length);

                byte[] dataFiles = new byte[64]; //Буфер для получаемых данных
                bytes = 0;
                do
                {
                    bytes = stream.Read(dataFiles, 0, dataFiles.Length);
                    builderFiles.Append(Encoding.Unicode.GetString(dataFiles, 0, bytes));

                    if (builderFiles.ToString() == "") break; //Если файлы не были найдены
                }
                while (stream.DataAvailable);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            files = builderFiles.ToString().Split('\n');
            folders = builderFolders.ToString().Split('\n');
        }

        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <param name="nameFile">Путь к файлу</param>
        public static string DeleteFile(string nameFile)
        {
            byte[] commandDelete = Encoding.Unicode.GetBytes
                (commandDeleteFile + GetPath() + nameFile);

            stream.Write(commandDelete, 0, commandDelete.Length);

            byte[] data = new byte[64]; //Буфер для получаемых данных
            StringBuilder builderPath = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                builderPath.Append(Encoding.Unicode.GetString(data, 0, bytes));

            } while (stream.DataAvailable);

            return builderPath.ToString();
        }

        public static string PasteMove()
        {
            byte[] command = Encoding.Unicode.GetBytes
               (commandMove + pathCopy + "|" + pathPaste + "|" + namePaste);
            stream.Write(command, 0, command.Length);

            byte[] data = new byte[64]; //Буфер для получаемых данных
            StringBuilder builderPath = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                builderPath.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);

            return builderPath.ToString();
        }

        public static string PasteCopy()
        {
            byte[] command = Encoding.Unicode.GetBytes
               (commandCopy + pathCopy + "|" + pathPaste + "|" + namePaste);
            stream.Write(command, 0, command.Length);

            byte[] data = new byte[64]; //Буфер для получаемых данных
            StringBuilder builderPath = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                builderPath.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);

            return builderPath.ToString();
        }

        private static string GetPath()
        {
            byte[] commandPath= Encoding.Unicode.GetBytes(commandGetPath);
            stream.Write(commandPath, 0, commandPath.Length);

            byte[] data = new byte[64]; //Буфер для получаемых данных
            StringBuilder builderPath = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                builderPath.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);

            string result = builderPath.ToString().Replace("//", "\\");

            return result;
        }

    }
}
