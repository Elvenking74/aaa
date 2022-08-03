namespace proj1
{
    partial class Form1
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
            this.btn1_1 = new System.Windows.Forms.Button();
            this.btn1_2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn1_1
            // 
            this.btn1_1.Location = new System.Drawing.Point(13, 13);
            this.btn1_1.Name = "btn1_1";
            this.btn1_1.Size = new System.Drawing.Size(230, 259);
            this.btn1_1.TabIndex = 0;
            this.btn1_1.Text = "Administracija";
            this.btn1_1.UseVisualStyleBackColor = true;
            this.btn1_1.Click += new System.EventHandler(this.btn1_1_Click);
            // 
            // btn1_2
            // 
            this.btn1_2.Location = new System.Drawing.Point(249, 13);
            this.btn1_2.Name = "btn1_2";
            this.btn1_2.Size = new System.Drawing.Size(230, 259);
            this.btn1_2.TabIndex = 1;
            this.btn1_2.Text = "Kupac";
            this.btn1_2.UseVisualStyleBackColor = true;
            this.btn1_2.Click += new System.EventHandler(this.btn1_2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 281);
            this.Controls.Add(this.btn1_2);
            this.Controls.Add(this.btn1_1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn1_1;
        private System.Windows.Forms.Button btn1_2;
    }
}

