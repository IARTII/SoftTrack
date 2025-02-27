namespace SoftTrack
{
    partial class main_window
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
            splitContainer1 = new SplitContainer();
            label1 = new Label();
            textBoxSearch = new TextBox();
            report_button = new Button();
            change_button = new Button();
            delete_button = new Button();
            add_button = new Button();
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            таблицыToolStripMenuItem = new ToolStripMenuItem();
            постоянныеКлиентыToolStripMenuItem = new ToolStripMenuItem();
            клиентыToolStripMenuItem = new ToolStripMenuItem();
            программноеОбеспечениеToolStripMenuItem = new ToolStripMenuItem();
            создателиПрограммногоОбеспеченияToolStripMenuItem = new ToolStripMenuItem();
            поддержкаToolStripMenuItem = new ToolStripMenuItem();
            архивToolStripMenuItem = new ToolStripMenuItem();
            процедурыИФункцииToolStripMenuItem = new ToolStripMenuItem();
            измененияСтоимостиПОToolStripMenuItem = new ToolStripMenuItem();
            количествоКлиентовКоторымПредстоитОбновитьУказанноеПОВБлижайшиеДваМесяцаToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(12, 38);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(textBoxSearch);
            splitContainer1.Panel1.Controls.Add(report_button);
            splitContainer1.Panel1.Controls.Add(change_button);
            splitContainer1.Panel1.Controls.Add(delete_button);
            splitContainer1.Panel1.Controls.Add(add_button);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            splitContainer1.Size = new Size(1149, 400);
            splitContainer1.SplitterDistance = 182;
            splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 171);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 4;
            label1.Text = "Поиск:";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(3, 194);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(176, 27);
            textBoxSearch.TabIndex = 3;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // report_button
            // 
            report_button.Location = new Point(3, 350);
            report_button.Name = "report_button";
            report_button.Size = new Size(176, 47);
            report_button.TabIndex = 3;
            report_button.Text = "Отчеты";
            report_button.UseVisualStyleBackColor = true;
            report_button.Click += report_button_Click;
            // 
            // change_button
            // 
            change_button.Location = new Point(3, 56);
            change_button.Name = "change_button";
            change_button.Size = new Size(176, 47);
            change_button.TabIndex = 2;
            change_button.Text = "Изменить";
            change_button.UseVisualStyleBackColor = true;
            change_button.Click += change_button_Click;
            // 
            // delete_button
            // 
            delete_button.Location = new Point(3, 109);
            delete_button.Name = "delete_button";
            delete_button.Size = new Size(176, 47);
            delete_button.TabIndex = 1;
            delete_button.Text = "Удалить";
            delete_button.UseVisualStyleBackColor = true;
            delete_button.Click += delete_button_Click;
            // 
            // add_button
            // 
            add_button.Location = new Point(3, 3);
            add_button.Name = "add_button";
            add_button.Size = new Size(176, 47);
            add_button.TabIndex = 0;
            add_button.Text = "Добавить";
            add_button.UseVisualStyleBackColor = true;
            add_button.Click += add_button_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(957, 397);
            dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { таблицыToolStripMenuItem, процедурыИФункцииToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1181, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // таблицыToolStripMenuItem
            // 
            таблицыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { постоянныеКлиентыToolStripMenuItem, клиентыToolStripMenuItem, программноеОбеспечениеToolStripMenuItem, создателиПрограммногоОбеспеченияToolStripMenuItem, поддержкаToolStripMenuItem, архивToolStripMenuItem });
            таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            таблицыToolStripMenuItem.Size = new Size(85, 24);
            таблицыToolStripMenuItem.Text = "Таблицы";
            // 
            // постоянныеКлиентыToolStripMenuItem
            // 
            постоянныеКлиентыToolStripMenuItem.Name = "постоянныеКлиентыToolStripMenuItem";
            постоянныеКлиентыToolStripMenuItem.Size = new Size(369, 26);
            постоянныеКлиентыToolStripMenuItem.Text = "Постоянные клиенты";
            постоянныеКлиентыToolStripMenuItem.Click += постоянныеКлиентыToolStripMenuItem_Click;
            // 
            // клиентыToolStripMenuItem
            // 
            клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            клиентыToolStripMenuItem.Size = new Size(369, 26);
            клиентыToolStripMenuItem.Text = "Клиенты";
            клиентыToolStripMenuItem.Click += клиентыToolStripMenuItem_Click;
            // 
            // программноеОбеспечениеToolStripMenuItem
            // 
            программноеОбеспечениеToolStripMenuItem.Name = "программноеОбеспечениеToolStripMenuItem";
            программноеОбеспечениеToolStripMenuItem.Size = new Size(369, 26);
            программноеОбеспечениеToolStripMenuItem.Text = "Программное обеспечение";
            программноеОбеспечениеToolStripMenuItem.Click += программноеОбеспечениеToolStripMenuItem_Click;
            // 
            // создателиПрограммногоОбеспеченияToolStripMenuItem
            // 
            создателиПрограммногоОбеспеченияToolStripMenuItem.Name = "создателиПрограммногоОбеспеченияToolStripMenuItem";
            создателиПрограммногоОбеспеченияToolStripMenuItem.Size = new Size(369, 26);
            создателиПрограммногоОбеспеченияToolStripMenuItem.Text = "Создатели программного обеспечения";
            создателиПрограммногоОбеспеченияToolStripMenuItem.Click += создателиПрограммногоОбеспеченияToolStripMenuItem_Click;
            // 
            // поддержкаToolStripMenuItem
            // 
            поддержкаToolStripMenuItem.Name = "поддержкаToolStripMenuItem";
            поддержкаToolStripMenuItem.Size = new Size(369, 26);
            поддержкаToolStripMenuItem.Text = "Поддержка";
            поддержкаToolStripMenuItem.Click += поддержкаToolStripMenuItem_Click;
            // 
            // архивToolStripMenuItem
            // 
            архивToolStripMenuItem.Name = "архивToolStripMenuItem";
            архивToolStripMenuItem.Size = new Size(369, 26);
            архивToolStripMenuItem.Text = "Архив";
            архивToolStripMenuItem.Click += архивToolStripMenuItem_Click;
            // 
            // процедурыИФункцииToolStripMenuItem
            // 
            процедурыИФункцииToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { измененияСтоимостиПОToolStripMenuItem, количествоКлиентовКоторымПредстоитОбновитьУказанноеПОВБлижайшиеДваМесяцаToolStripMenuItem });
            процедурыИФункцииToolStripMenuItem.Name = "процедурыИФункцииToolStripMenuItem";
            процедурыИФункцииToolStripMenuItem.Size = new Size(181, 24);
            процедурыИФункцииToolStripMenuItem.Text = "Процедуры и функции";
            // 
            // измененияСтоимостиПОToolStripMenuItem
            // 
            измененияСтоимостиПОToolStripMenuItem.Name = "измененияСтоимостиПОToolStripMenuItem";
            измененияСтоимостиПОToolStripMenuItem.Size = new Size(743, 26);
            измененияСтоимостиПОToolStripMenuItem.Text = "Изменения стоимости ПО";
            измененияСтоимостиПОToolStripMenuItem.Click += измененияСтоимостиПОToolStripMenuItem_Click;
            // 
            // количествоКлиентовКоторымПредстоитОбновитьУказанноеПОВБлижайшиеДваМесяцаToolStripMenuItem
            // 
            количествоКлиентовКоторымПредстоитОбновитьУказанноеПОВБлижайшиеДваМесяцаToolStripMenuItem.Name = "количествоКлиентовКоторымПредстоитОбновитьУказанноеПОВБлижайшиеДваМесяцаToolStripMenuItem";
            количествоКлиентовКоторымПредстоитОбновитьУказанноеПОВБлижайшиеДваМесяцаToolStripMenuItem.Size = new Size(743, 26);
            количествоКлиентовКоторымПредстоитОбновитьУказанноеПОВБлижайшиеДваМесяцаToolStripMenuItem.Text = "Количество клиентов, которым предстоит обновить указанное ПО в ближайшие два месяца.";
            количествоКлиентовКоторымПредстоитОбновитьУказанноеПОВБлижайшиеДваМесяцаToolStripMenuItem.Click += количествоКлиентовКоторымПредстоитОбновитьУказанноеПОВБлижайшиеДваМесяцаToolStripMenuItem_Click;
            // 
            // main_window
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1181, 493);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "main_window";
            Text = "main_window";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private SplitContainer splitContainer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem таблицыToolStripMenuItem;
        private ToolStripMenuItem клиентыToolStripMenuItem;
        private ToolStripMenuItem программноеОбеспечениеToolStripMenuItem;
        private ToolStripMenuItem создателиПрограммногоОбеспеченияToolStripMenuItem;
        private ToolStripMenuItem поддержкаToolStripMenuItem;
        private DataGridView dataGridView1;
        private Button add_button;
        private Button change_button;
        private Button delete_button;
        private Button report_button;
        private TextBox textBoxSearch;
        private Label label1;
        private ToolStripMenuItem архивToolStripMenuItem;
        private ToolStripMenuItem постоянныеКлиентыToolStripMenuItem;
        private ToolStripMenuItem процедурыИФункцииToolStripMenuItem;
        private ToolStripMenuItem измененияСтоимостиПОToolStripMenuItem;
        private ToolStripMenuItem количествоКлиентовКоторымПредстоитОбновитьУказанноеПОВБлижайшиеДваМесяцаToolStripMenuItem;
    }
}
