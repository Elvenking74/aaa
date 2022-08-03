namespace proj1
{
    partial class FKupac
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.txt21_2 = new System.Windows.Forms.TextBox();
            this.txt21_1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btn21_1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.txt21_2);
            this.groupBox2.Controls.Add(this.txt21_1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(52, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 180);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(229, 117);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(93, 17);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.TabStop = false;
            this.checkBox3.Text = "Prikaži lozinku";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // txt21_2
            // 
            this.txt21_2.Location = new System.Drawing.Point(122, 117);
            this.txt21_2.Name = "txt21_2";
            this.txt21_2.PasswordChar = '*';
            this.txt21_2.Size = new System.Drawing.Size(100, 20);
            this.txt21_2.TabIndex = 2;
            // 
            // txt21_1
            // 
            this.txt21_1.Location = new System.Drawing.Point(122, 59);
            this.txt21_1.Name = "txt21_1";
            this.txt21_1.Size = new System.Drawing.Size(100, 20);
            this.txt21_1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(119, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Lozinka";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(119, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Korisničko ime";
            // 
            // btn21_1
            // 
            this.btn21_1.Location = new System.Drawing.Point(312, 286);
            this.btn21_1.Name = "btn21_1";
            this.btn21_1.Size = new System.Drawing.Size(125, 50);
            this.btn21_1.TabIndex = 5;
            this.btn21_1.Text = "Prijavi se";
            this.btn21_1.UseVisualStyleBackColor = true;
            this.btn21_1.Click += new System.EventHandler(this.btn21_1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(425, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "Uloguj se";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FKupac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 352);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn21_1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FKupac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FKupac";
            this.Load += new System.EventHandler(this.FKupac_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TextBox txt21_2;
        private System.Windows.Forms.TextBox txt21_1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn21_1;
        private System.Windows.Forms.Button button1;
    }
}