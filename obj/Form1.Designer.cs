namespace laba2
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
            this.FSW = new System.IO.FileSystemWatcher();
            this.TB1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.FSW)).BeginInit();
            this.SuspendLayout();
            // 
            // FSW
            // 
            this.FSW.EnableRaisingEvents = true;
            this.FSW.Filter = "*.txt";
            this.FSW.IncludeSubdirectories = true;
            this.FSW.Path = "C:\\Users\\User\\source\\repos\\C#\\2 kurs\\2\\SourceDir";
            this.FSW.SynchronizingObject = this;
            this.FSW.Changed += new System.IO.FileSystemEventHandler(this.FSW_Changed);
            this.FSW.Created += new System.IO.FileSystemEventHandler(this.FSW_Created);
            this.FSW.Deleted += new System.IO.FileSystemEventHandler(this.FSW_Deleted);
            this.FSW.Renamed += new System.IO.RenamedEventHandler(this.FSW_Renamed);
            // 
            // TB1
            // 
            this.TB1.Location = new System.Drawing.Point(12, 12);
            this.TB1.Multiline = true;
            this.TB1.Name = "TB1";
            this.TB1.ReadOnly = true;
            this.TB1.Size = new System.Drawing.Size(752, 401);
            this.TB1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TB1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.FSW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher FSW;
        private System.Windows.Forms.TextBox TB1;
    }
}

