namespace kursowoi
{
    partial class Form4
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
            this.status = new System.Windows.Forms.StatusStrip();
            this.status_text = new System.Windows.Forms.ToolStripStatusLabel();
            this.encode = new System.Windows.Forms.Button();
            this.code = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedtext = new System.Windows.Forms.RichTextBox();
            this.message = new System.Windows.Forms.RichTextBox();
            this.check = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.test = new System.Windows.Forms.Button();
            this.progr = new System.Windows.Forms.ProgressBar();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_text});
            this.status.Location = new System.Drawing.Point(0, 377);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(490, 22);
            this.status.TabIndex = 18;
            this.status.Text = "statusStrip1";
            // 
            // status_text
            // 
            this.status_text.Name = "status_text";
            this.status_text.Size = new System.Drawing.Size(0, 17);
            // 
            // encode
            // 
            this.encode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.encode.Location = new System.Drawing.Point(330, 108);
            this.encode.Name = "encode";
            this.encode.Size = new System.Drawing.Size(138, 23);
            this.encode.TabIndex = 17;
            this.encode.Text = "Расшифровать";
            this.encode.UseVisualStyleBackColor = true;
            this.encode.Click += new System.EventHandler(this.encode_Click);
            // 
            // code
            // 
            this.code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.code.Enabled = false;
            this.code.Location = new System.Drawing.Point(330, 68);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(138, 23);
            this.code.TabIndex = 16;
            this.code.Text = "Зашифровать";
            this.code.UseVisualStyleBackColor = true;
            this.code.Click += new System.EventHandler(this.code_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Текст, в который будет помещено скрытое сообщение";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Секретное сообщение";
            // 
            // maskedtext
            // 
            this.maskedtext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedtext.Location = new System.Drawing.Point(12, 175);
            this.maskedtext.Name = "maskedtext";
            this.maskedtext.Size = new System.Drawing.Size(466, 147);
            this.maskedtext.TabIndex = 13;
            this.maskedtext.Text = "";
            this.maskedtext.TextChanged += new System.EventHandler(this.maskedtext_TextChanged);
            // 
            // message
            // 
            this.message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.message.Location = new System.Drawing.Point(12, 30);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(286, 96);
            this.message.TabIndex = 12;
            this.message.Text = "";
            this.message.TextChanged += new System.EventHandler(this.message_TextChanged);
            // 
            // check
            // 
            this.check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.check.Location = new System.Drawing.Point(330, 28);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(138, 23);
            this.check.TabIndex = 11;
            this.check.Text = "Проверка вместимости";
            this.check.UseVisualStyleBackColor = true;
            this.check.Click += new System.EventHandler(this.check_Click);
            // 
            // load
            // 
            this.load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.load.Location = new System.Drawing.Point(289, 329);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(106, 23);
            this.load.TabIndex = 21;
            this.load.Text = "Загрузить текст";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.save.Location = new System.Drawing.Point(107, 329);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(99, 23);
            this.save.TabIndex = 20;
            this.save.Text = "Сохранить текст";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // test
            // 
            this.test.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.test.Location = new System.Drawing.Point(330, 144);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(138, 23);
            this.test.TabIndex = 19;
            this.test.Text = "Двоичный вид";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // progr
            // 
            this.progr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progr.Location = new System.Drawing.Point(16, 351);
            this.progr.Name = "progr";
            this.progr.Size = new System.Drawing.Size(466, 23);
            this.progr.Step = 1;
            this.progr.TabIndex = 23;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 399);
            this.Controls.Add(this.progr);
            this.Controls.Add(this.status);
            this.Controls.Add(this.encode);
            this.Controls.Add(this.code);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedtext);
            this.Controls.Add(this.message);
            this.Controls.Add(this.check);
            this.Controls.Add(this.load);
            this.Controls.Add(this.save);
            this.Controls.Add(this.test);
            this.MinimumSize = new System.Drawing.Size(506, 437);
            this.Name = "Form4";
            this.Text = "Алгоритм \"цвета\"";
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel status_text;
        private System.Windows.Forms.Button encode;
        private System.Windows.Forms.Button code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox maskedtext;
        private System.Windows.Forms.RichTextBox message;
        private System.Windows.Forms.Button check;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.ProgressBar progr;
    }
}