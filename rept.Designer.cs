namespace SoftTrack
{
    partial class rept
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(303, 74);
            button1.TabIndex = 0;
            button1.Text = "Список клиентов, программному обеспечению которых предстоит обновление";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 92);
            button2.Name = "button2";
            button2.Size = new Size(303, 74);
            button2.TabIndex = 1;
            button2.Text = "Сводка реализованного программного обеспечения";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(12, 172);
            button3.Name = "button3";
            button3.Size = new Size(303, 74);
            button3.TabIndex = 2;
            button3.Text = "Общий список ПО с количеством продаж и производителей с количеством ПО у каждого";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 252);
            button4.Name = "button4";
            button4.Size = new Size(303, 74);
            button4.TabIndex = 3;
            button4.Text = "Количество дней от покупки ПО до его обновления";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // rept
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 336);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "rept";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}