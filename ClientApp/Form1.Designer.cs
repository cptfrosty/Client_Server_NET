
namespace ClientApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "...",
            "апвы"}, 1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Папка 1", 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Папка 2", 1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Файл 1", 0);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Файл 2", 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lv_directory = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tb_address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ts_next = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_paste = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.button5 = new System.Windows.Forms.Button();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_directory
            // 
            this.lv_directory.HideSelection = false;
            this.lv_directory.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lv_directory.LargeImageList = this.imageList1;
            this.lv_directory.Location = new System.Drawing.Point(12, 94);
            this.lv_directory.Margin = new System.Windows.Forms.Padding(10);
            this.lv_directory.Name = "lv_directory";
            this.lv_directory.Size = new System.Drawing.Size(644, 344);
            this.lv_directory.SmallImageList = this.imageList1;
            this.lv_directory.TabIndex = 0;
            this.lv_directory.UseCompatibleStateImageBehavior = false;
            this.lv_directory.View = System.Windows.Forms.View.Tile;
            this.lv_directory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Explorer_MouseClick);
            this.lv_directory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lv_directory_MouseDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "file.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(697, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Отключить службу";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(697, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(186, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Включить службу";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tb_address
            // 
            this.tb_address.Location = new System.Drawing.Point(101, 12);
            this.tb_address.Name = "tb_address";
            this.tb_address.Size = new System.Drawing.Size(172, 20);
            this.tb_address.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Адрес сервера:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Порт:";
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(320, 12);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(74, 20);
            this.tb_port.TabIndex = 6;
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(47, 68);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(520, 20);
            this.tb_path.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(573, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Перейти";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Путь:";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(410, 10);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(131, 23);
            this.btn_connect.TabIndex = 11;
            this.btn_connect.Text = "Подключиться";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.OnConnectClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(747, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "FILE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(805, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "СИЛА";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_next,
            this.ts_paste,
            this.ts_copy,
            this.ts_delete,
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 136);
            // 
            // ts_next
            // 
            this.ts_next.Name = "ts_next";
            this.ts_next.Size = new System.Drawing.Size(180, 22);
            this.ts_next.Text = "Перейти";
            // 
            // ts_paste
            // 
            this.ts_paste.Enabled = false;
            this.ts_paste.Name = "ts_paste";
            this.ts_paste.Size = new System.Drawing.Size(180, 22);
            this.ts_paste.Text = "Вставить";
            // 
            // ts_copy
            // 
            this.ts_copy.Name = "ts_copy";
            this.ts_copy.Size = new System.Drawing.Size(180, 22);
            this.ts_copy.Text = "Копировать";
            // 
            // ts_delete
            // 
            this.ts_delete.Name = "ts_delete";
            this.ts_delete.Size = new System.Drawing.Size(180, 22);
            this.ts_delete.Text = "Удалить";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(547, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(131, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Отключиться";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Переместить";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_address);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lv_directory);
            this.Name = "Form1";
            this.Text = "FTP Клиент";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_directory;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tb_address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ts_next;
        private System.Windows.Forms.ToolStripMenuItem ts_paste;
        private System.Windows.Forms.ToolStripMenuItem ts_copy;
        private System.Windows.Forms.ToolStripMenuItem ts_delete;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

