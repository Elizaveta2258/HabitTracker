namespace трекер_привычек
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
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.textBox_pas = new System.Windows.Forms.TextBox();
            this.vhod = new System.Windows.Forms.Button();
            this.registr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_log
            // 
            this.textBox_log.Location = new System.Drawing.Point(302, 230);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.Size = new System.Drawing.Size(169, 55);
            this.textBox_log.TabIndex = 0;
            // 
            // textBox_pas
            // 
            this.textBox_pas.Location = new System.Drawing.Point(302, 74);
            this.textBox_pas.Multiline = true;
            this.textBox_pas.Name = "textBox_pas";
            this.textBox_pas.Size = new System.Drawing.Size(169, 55);
            this.textBox_pas.TabIndex = 1;
            // 
            // vhod
            // 
            this.vhod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.vhod.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vhod.Location = new System.Drawing.Point(324, 362);
            this.vhod.Name = "vhod";
            this.vhod.Size = new System.Drawing.Size(120, 52);
            this.vhod.TabIndex = 2;
            this.vhod.Text = "Войти";
            this.vhod.UseVisualStyleBackColor = false;
            this.vhod.Click += new System.EventHandler(this.vhod_Click);
            // 
            // registr
            // 
            this.registr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.registr.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registr.Location = new System.Drawing.Point(662, 387);
            this.registr.Name = "registr";
            this.registr.Size = new System.Drawing.Size(126, 51);
            this.registr.TabIndex = 3;
            this.registr.Text = "Регистрация";
            this.registr.UseVisualStyleBackColor = false;
            this.registr.Click += new System.EventHandler(this.registr_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(343, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(325, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пароль";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.registr);
            this.Controls.Add(this.vhod);
            this.Controls.Add(this.textBox_pas);
            this.Controls.Add(this.textBox_log);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.TextBox textBox_pas;
        private System.Windows.Forms.Button vhod;
        private System.Windows.Forms.Button registr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

