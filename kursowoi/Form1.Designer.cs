namespace kursowoi
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.select = new System.Windows.Forms.Button();
            this.AlgoritmList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // select
            // 
            this.select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.select.Location = new System.Drawing.Point(319, 34);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(75, 23);
            this.select.TabIndex = 0;
            this.select.Text = "выбрать";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // AlgoritmList
            // 
            this.AlgoritmList.FormattingEnabled = true;
            this.AlgoritmList.Items.AddRange(new object[] {
            "алгоритм \"замена пробелов\"",
            "алгоритм \"разные раскладки\"",
            "алгоритм \"цвета\"",
            "остальное"});
            this.AlgoritmList.Location = new System.Drawing.Point(45, 37);
            this.AlgoritmList.Name = "AlgoritmList";
            this.AlgoritmList.Size = new System.Drawing.Size(179, 21);
            this.AlgoritmList.TabIndex = 1;
            this.AlgoritmList.Text = "алгоритм \"замена пробелов\"";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите алгоритм";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 82);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AlgoritmList);
            this.Controls.Add(this.select);
            this.MaximumSize = new System.Drawing.Size(436, 120);
            this.MinimumSize = new System.Drawing.Size(436, 120);
            this.Name = "Form1";
            this.Text = "стеганографическое скрытие информации";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button select;
        private System.Windows.Forms.ComboBox AlgoritmList;
        private System.Windows.Forms.Label label1;
    }
}

