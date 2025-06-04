namespace трекер_привычек
{
    partial class Form3
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
            this.panelHabits = new System.Windows.Forms.Panel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnbac = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelHabits
            // 
            this.panelHabits.AutoScroll = true;
            this.panelHabits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHabits.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panelHabits.Location = new System.Drawing.Point(12, 219);
            this.panelHabits.Name = "panelHabits";
            this.panelHabits.Size = new System.Drawing.Size(753, 177);
            this.panelHabits.TabIndex = 0;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(4, 1);
            this.monthCalendar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.monthCalendar1.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            // 
            // btnbac
            // 
            this.btnbac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnbac.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnbac.ForeColor = System.Drawing.Color.Black;
            this.btnbac.Location = new System.Drawing.Point(12, 402);
            this.btnbac.Name = "btnbac";
            this.btnbac.Size = new System.Drawing.Size(131, 49);
            this.btnbac.TabIndex = 2;
            this.btnbac.Text = "Обратно ";
            this.btnbac.UseVisualStyleBackColor = false;
            this.btnbac.Click += new System.EventHandler(this.btnbac_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnbac);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.panelHabits);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHabits;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnbac;
    }
}