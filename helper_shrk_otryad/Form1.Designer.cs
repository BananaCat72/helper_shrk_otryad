namespace helper_shrk_otryad
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            обновитьToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabelFilePath = new ToolStripStatusLabel();
            panel1 = new Panel();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            radioButtonWhale = new RadioButton();
            radioButtonFlyingfish = new RadioButton();
            radioButtonDolphin = new RadioButton();
            label1 = new Label();
            buttonChooseFile = new Button();
            buttonPodchet = new Button();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Teal;
            menuStrip1.Items.AddRange(new ToolStripItem[] { справкаToolStripMenuItem, оПрограммеToolStripMenuItem, обновитьToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(624, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            справкаToolStripMenuItem.ForeColor = Color.White;
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(66, 20);
            справкаToolStripMenuItem.Text = "Справка";
            справкаToolStripMenuItem.Click += справкаToolStripMenuItem_Click;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            оПрограммеToolStripMenuItem.ForeColor = Color.White;
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(95, 20);
            оПрограммеToolStripMenuItem.Text = "О программе";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
            // 
            // обновитьToolStripMenuItem
            // 
            обновитьToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            обновитьToolStripMenuItem.ForeColor = Color.White;
            обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            обновитьToolStripMenuItem.Size = new Size(76, 20);
            обновитьToolStripMenuItem.Text = "Обновить";
            обновитьToolStripMenuItem.Click += обновитьToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.Teal;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabelFilePath });
            statusStrip1.Location = new Point(0, 374);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(624, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripStatusLabel1.ForeColor = Color.White;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(37, 17);
            toolStripStatusLabel1.Text = "Путь:";
            // 
            // toolStripStatusLabelFilePath
            // 
            toolStripStatusLabelFilePath.ForeColor = Color.White;
            toolStripStatusLabelFilePath.Name = "toolStripStatusLabelFilePath";
            toolStripStatusLabelFilePath.Size = new Size(59, 17);
            toolStripStatusLabelFilePath.Text = "не указан";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightCyan;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(204, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(409, 315);
            panel1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(18, 45);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(181, 248);
            textBox1.TabIndex = 4;
            textBox1.Text = "морские вылазки, лагерные патрули, лекции";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(211, 45);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(181, 248);
            textBox2.TabIndex = 3;
            textBox2.Text = "сказки, игры";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DarkSlateGray;
            label2.Location = new Point(141, 14);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 2;
            label2.Text = "ВЫВОД ДАННЫХ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightCyan;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(radioButtonWhale);
            panel2.Controls.Add(radioButtonFlyingfish);
            panel2.Controls.Add(radioButtonDolphin);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(16, 41);
            panel2.Name = "panel2";
            panel2.Size = new Size(172, 142);
            panel2.TabIndex = 3;
            // 
            // radioButtonWhale
            // 
            radioButtonWhale.AutoSize = true;
            radioButtonWhale.BackColor = Color.Transparent;
            radioButtonWhale.Location = new Point(20, 99);
            radioButtonWhale.Name = "radioButtonWhale";
            radioButtonWhale.Size = new Size(53, 21);
            radioButtonWhale.TabIndex = 2;
            radioButtonWhale.Text = "Киты";
            radioButtonWhale.UseVisualStyleBackColor = false;
            // 
            // radioButtonFlyingfish
            // 
            radioButtonFlyingfish.AutoSize = true;
            radioButtonFlyingfish.BackColor = Color.Transparent;
            radioButtonFlyingfish.Location = new Point(20, 72);
            radioButtonFlyingfish.Name = "radioButtonFlyingfish";
            radioButtonFlyingfish.Size = new Size(110, 21);
            radioButtonFlyingfish.TabIndex = 1;
            radioButtonFlyingfish.Text = "Летучие рыбы";
            radioButtonFlyingfish.UseVisualStyleBackColor = false;
            // 
            // radioButtonDolphin
            // 
            radioButtonDolphin.AutoSize = true;
            radioButtonDolphin.BackColor = Color.Transparent;
            radioButtonDolphin.Checked = true;
            radioButtonDolphin.Location = new Point(20, 45);
            radioButtonDolphin.Name = "radioButtonDolphin";
            radioButtonDolphin.Size = new Size(90, 21);
            radioButtonDolphin.TabIndex = 0;
            radioButtonDolphin.TabStop = true;
            radioButtonDolphin.Text = "Дельфины";
            radioButtonDolphin.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkSlateGray;
            label1.Location = new Point(34, 14);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 0;
            label1.Text = "ВЫБОР ОТРЯДА";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonChooseFile
            // 
            buttonChooseFile.BackColor = Color.DarkCyan;
            buttonChooseFile.ForeColor = Color.White;
            buttonChooseFile.Location = new Point(16, 287);
            buttonChooseFile.Name = "buttonChooseFile";
            buttonChooseFile.Size = new Size(172, 32);
            buttonChooseFile.TabIndex = 0;
            buttonChooseFile.Text = "Выбрать файл";
            buttonChooseFile.UseVisualStyleBackColor = false;
            buttonChooseFile.Click += buttonChooseFile_Click;
            // 
            // buttonPodchet
            // 
            buttonPodchet.BackColor = Color.DarkCyan;
            buttonPodchet.ForeColor = Color.White;
            buttonPodchet.Location = new Point(16, 324);
            buttonPodchet.Name = "buttonPodchet";
            buttonPodchet.Size = new Size(172, 32);
            buttonPodchet.TabIndex = 4;
            buttonPodchet.Text = "Начать подсчет";
            buttonPodchet.UseVisualStyleBackColor = false;
            buttonPodchet.Click += buttonPodchet_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(624, 396);
            Controls.Add(buttonPodchet);
            Controls.Add(buttonChooseFile);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximumSize = new Size(640, 435);
            MinimumSize = new Size(640, 435);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Помощник главе отряда | ШРК";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStripMenuItem обновитьToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private Panel panel1;
        private Panel panel2;
        private RadioButton radioButtonDolphin;
        private Label label1;
        private Button buttonChooseFile;
        private TextBox textBox2;
        private Label label2;
        private RadioButton radioButtonFlyingfish;
        private Button buttonPodchet;
        private TextBox textBox1;
        private RadioButton radioButtonWhale;
        protected ToolStripStatusLabel toolStripStatusLabelFilePath;
    }
}