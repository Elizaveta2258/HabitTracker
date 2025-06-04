namespace трекер_привычек
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtHabit = new System.Windows.Forms.TextBox();
            this.btnAddHabit = new System.Windows.Forms.Button();
            this.btnGoToForm3 = new System.Windows.Forms.Button();
            this.btnGoToForm5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(89, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(568, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Добавьте привычку, которую будете выполнять";
            // 
            // txtHabit
            // 
            this.txtHabit.Location = new System.Drawing.Point(266, 171);
            this.txtHabit.Multiline = true;
            this.txtHabit.Name = "txtHabit";
            this.txtHabit.Size = new System.Drawing.Size(206, 69);
            this.txtHabit.TabIndex = 1;
            // 
            // btnAddHabit
            // 
            this.btnAddHabit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddHabit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddHabit.Location = new System.Drawing.Point(305, 282);
            this.btnAddHabit.Name = "btnAddHabit";
            this.btnAddHabit.Size = new System.Drawing.Size(119, 52);
            this.btnAddHabit.TabIndex = 2;
            this.btnAddHabit.Text = "Добавить";
            this.btnAddHabit.UseVisualStyleBackColor = false;
            this.btnAddHabit.Click += new System.EventHandler(this.btnAddHabit_Click);
            // 
            // btnGoToForm3
            // 
            this.btnGoToForm3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnGoToForm3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGoToForm3.Location = new System.Drawing.Point(662, 382);
            this.btnGoToForm3.Name = "btnGoToForm3";
            this.btnGoToForm3.Size = new System.Drawing.Size(126, 56);
            this.btnGoToForm3.TabIndex = 3;
            this.btnGoToForm3.Text = "Отметить привычку";
            this.btnGoToForm3.UseVisualStyleBackColor = false;
            this.btnGoToForm3.Click += new System.EventHandler(this.btnGoToForm3_Click);
            // 
            // btnGoToForm5
            // 
            this.btnGoToForm5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnGoToForm5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGoToForm5.Location = new System.Drawing.Point(12, 382);
            this.btnGoToForm5.Name = "btnGoToForm5";
            this.btnGoToForm5.Size = new System.Drawing.Size(118, 56);
            this.btnGoToForm5.TabIndex = 4;
            this.btnGoToForm5.Text = "Статистика";
            this.btnGoToForm5.UseVisualStyleBackColor = false;
            this.btnGoToForm5.Click += new System.EventHandler(this.btnGoToForm5_Click_1);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGoToForm5);
            this.Controls.Add(this.btnGoToForm3);
            this.Controls.Add(this.btnAddHabit);
            this.Controls.Add(this.txtHabit);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHabit;
        private System.Windows.Forms.Button btnAddHabit;
        private System.Windows.Forms.Button btnGoToForm3;
        private System.Windows.Forms.Button btnGoToForm5;
    }
}