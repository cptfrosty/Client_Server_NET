using System;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitContextMenuStrip(); //Инициализация ContextMenuStrip
            lv_directory.Items.Clear();
        }

        /*Событийный метод отрабатывает, когда нажато по элементу*/
        private void Explorer_MouseClick(object sender, MouseEventArgs e)
        {
            //Отображение контекстного меню
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = lv_directory.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Items[3].Enabled = true; //3 - удалить
                    contextMenuStrip1.Items[1].Enabled = false; //1 - вставить
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            else if(e.Button == MouseButtons.Left)
            {
                ListViewItem item = (ListViewItem)lv_directory.FocusedItem;
                Server.NextPath(item.Text);
                ShowPath();
            }
        }

        private void lv_directory_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (String.IsNullOrEmpty(Server.pathCopy))
                {
                    contextMenuStrip1.Items[1].Enabled = false; //1 - вставить
                    contextMenuStrip1.Items[4].Enabled = false; //4 - переместить
                }
                else
                {
                    contextMenuStrip1.Items[1].Enabled = true; //1 - вставить
                    contextMenuStrip1.Items[4].Enabled = true; //4 - переместить
                }

                contextMenuStrip1.Items[3].Enabled = false; //3 - удалить
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void OnConnectClick(object sender, EventArgs e)
        {
            Server.Connect(tb_address.Text, int.Parse(tb_port.Text));
            if (Server.isConnect)
            {
                ShowPath();
            }
            else
            {
                MessageBox.Show("Ошибка подключения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowPath()
        {
            string[] folders = null;
            string[] files = null;
            tb_path.Text = Server.CurrentPath;

            Server.GetInfoPath(ref files, ref folders);

            lv_directory.Items.Clear();

            //Кнопка папки для возврата назад
            ListViewItem backFolder = new ListViewItem("..");
            backFolder.ImageIndex = 1;
            lv_directory.Items.Add(backFolder);

            //Заполнение папок
            for(int i = 0; i < folders.Length-1; i++)
            {
                ListViewItem item = new ListViewItem(folders[i]);
                item.ImageIndex = 1;
                lv_directory.Items.Add(item);
            }

            //Заполнение файлов
            for(int i = 0; i < files.Length-1; i++)
            {
                ListViewItem item = new ListViewItem(files[i]);
                item.ImageIndex = 0;
                lv_directory.Items.Add(item);
            }
        }

        #region Описание ContextMenuStrip
        private void InitContextMenuStrip()
        {
            //Переход в следующую папку
            ToolStripMenuItem next = new ToolStripMenuItem("Перейти");
            //Вставить скопированный элемент в данную папку
            ToolStripMenuItem paste = new ToolStripMenuItem("Вставить");
            //Скопировать элемент или папку
            ToolStripMenuItem copy = new ToolStripMenuItem("Копировать");
            //Удалить элемент или папку
            ToolStripMenuItem delete = new ToolStripMenuItem("Удалить");
            //Удалить элемент или папку
            ToolStripMenuItem move = new ToolStripMenuItem("Переместить");

            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.AddRange(new[]
            {
                next, paste, copy, delete, move
            });

            next.Click += Next_Click;
            paste.Click += Paste_Click;
            copy.Click += Copy_Click;
            delete.Click += Delete_Click;
            move.Click += Move_Click; ;
        }

        private void Move_Click(object sender, EventArgs e)
        {
            Server.pathPaste = Server.CurrentPath;
            MessageBox.Show(Server.PasteMove());

            Server.pathPaste = "";
            Server.pathCopy = "";
            Server.namePaste = "";
            ShowPath();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            string nameItem = lv_directory.FocusedItem.Text;
            Server.NextPath(nameItem);
            ShowPath();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string nameFile = lv_directory.FocusedItem.Text;
            DialogResult dialogResult = 
                MessageBox.Show($"Вы действительно хотите удалить? {nameFile}", "Удаление",
                MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(Server.DeleteFile(nameFile));
                ShowPath();
            }  
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            Server.pathCopy = Server.CurrentPath;
            Server.namePaste = lv_directory.FocusedItem.Text;

            MessageBox.Show($"Файл {lv_directory.FocusedItem.Text} скопирован");
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            /*Защита от ошибок передачи пустых полей на сервер 
             *уже предусмотренна*/
            MessageBox.Show("Функционал не реализован");
            /*Server.pathPaste = Server.CurrentPath;
            MessageBox.Show(Server.PasteCopy());

            Server.pathPaste = "";
            Server.pathCopy = "";
            Server.namePaste = "";
            ShowPath();*/
        }

        #endregion

    }
}
