namespace proj1
{
    partial class FAdministracija
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
            this.btn2_1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn2_3 = new System.Windows.Forms.Button();
            this.btn2_2 = new System.Windows.Forms.Button();
            this.btn2_4 = new System.Windows.Forms.Button();
            this.btn2_5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn2_1
            // 
            this.btn2_1.Location = new System.Drawing.Point(100, 42);
            this.btn2_1.Name = "btn2_1";
            this.btn2_1.Size = new System.Drawing.Size(135, 75);
            this.btn2_1.TabIndex = 1;
            this.btn2_1.Text = "Filmovi";
            this.btn2_1.UseVisualStyleBackColor = true;
            this.btn2_1.Click += new System.EventHandler(this.btn2_1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Location = new System.Drawing.Point(31, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 28);
            this.button1.TabIndex = 1;
            this.button1.TabStop = false;
            this.button1.Text = "---";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn2_3
            // 
            this.btn2_3.Location = new System.Drawing.Point(100, 272);
            this.btn2_3.Name = "btn2_3";
            this.btn2_3.Size = new System.Drawing.Size(135, 75);
            this.btn2_3.TabIndex = 4;
            this.btn2_3.Text = "Projekcije";
            this.btn2_3.UseVisualStyleBackColor = true;
            this.btn2_3.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn2_2
            // 
            this.btn2_2.Location = new System.Drawing.Point(275, 42);
            this.btn2_2.Name = "btn2_2";
            this.btn2_2.Size = new System.Drawing.Size(135, 75);
            this.btn2_2.TabIndex = 2;
            this.btn2_2.Text = "Sale";
            this.btn2_2.UseVisualStyleBackColor = true;
            this.btn2_2.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn2_4
            // 
            this.btn2_4.Location = new System.Drawing.Point(275, 272);
            this.btn2_4.Name = "btn2_4";
            this.btn2_4.Size = new System.Drawing.Size(135, 75);
            this.btn2_4.TabIndex = 5;
            this.btn2_4.Text = "Kupci";
            this.btn2_4.UseVisualStyleBackColor = true;
            this.btn2_4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn2_5
            // 
            this.btn2_5.Location = new System.Drawing.Point(100, 157);
            this.btn2_5.Name = "btn2_5";
            this.btn2_5.Size = new System.Drawing.Size(310, 75);
            this.btn2_5.TabIndex = 3;
            this.btn2_5.Text = "Rezervacije";
            this.btn2_5.UseVisualStyleBackColor = true;
            this.btn2_5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(0, -17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(75, 417);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(435, -48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 514);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // FAdministracija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 391);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn2_5);
            this.Controls.Add(this.btn2_4);
            this.Controls.Add(this.btn2_2);
            this.Controls.Add(this.btn2_3);
            this.Controls.Add(this.btn2_1);
            this.Name = "FAdministracija";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Administracija";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FAdministracija_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FAdministracija_FormClosed);
            this.Load += new System.EventHandler(this.FAdministracija_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn2_1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn2_3;
        private System.Windows.Forms.Button btn2_2;
        private System.Windows.Forms.Button btn2_4;
        private System.Windows.Forms.Button btn2_5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}