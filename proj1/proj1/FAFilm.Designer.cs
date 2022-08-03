namespace proj1
{
    partial class FAFilm
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
            this.txt3_1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt3_2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt3_4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt3_3 = new System.Windows.Forms.TextBox();
            this.btn3_1 = new System.Windows.Forms.Button();
            this.cb3_1 = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txt3_1
            // 
            this.txt3_1.Location = new System.Drawing.Point(123, 29);
            this.txt3_1.Name = "txt3_1";
            this.txt3_1.Size = new System.Drawing.Size(100, 20);
            this.txt3_1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naziv Filma";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Žanr";
            // 
            // txt3_2
            // 
            this.txt3_2.Location = new System.Drawing.Point(123, 59);
            this.txt3_2.Name = "txt3_2";
            this.txt3_2.Size = new System.Drawing.Size(100, 20);
            this.txt3_2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Granica Godina";
            // 
            // txt3_4
            // 
            this.txt3_4.Location = new System.Drawing.Point(123, 119);
            this.txt3_4.Name = "txt3_4";
            this.txt3_4.Size = new System.Drawing.Size(100, 20);
            this.txt3_4.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Dužina";
            // 
            // txt3_3
            // 
            this.txt3_3.Location = new System.Drawing.Point(123, 89);
            this.txt3_3.Name = "txt3_3";
            this.txt3_3.Size = new System.Drawing.Size(100, 20);
            this.txt3_3.TabIndex = 4;
            // 
            // btn3_1
            // 
            this.btn3_1.Location = new System.Drawing.Point(41, 194);
            this.btn3_1.Name = "btn3_1";
            this.btn3_1.Size = new System.Drawing.Size(182, 50);
            this.btn3_1.TabIndex = 8;
            this.btn3_1.Text = "Dodaj Fim";
            this.btn3_1.UseVisualStyleBackColor = true;
            this.btn3_1.Click += new System.EventHandler(this.btn3_1_Click);
            // 
            // cb3_1
            // 
            this.cb3_1.AutoSize = true;
            this.cb3_1.Checked = true;
            this.cb3_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb3_1.Location = new System.Drawing.Point(92, 149);
            this.cb3_1.Name = "cb3_1";
            this.cb3_1.Size = new System.Drawing.Size(131, 17);
            this.cb3_1.TabIndex = 9;
            this.cb3_1.TabStop = false;
            this.cb3_1.Text = "Automatski očisti tekst";
            this.cb3_1.UseVisualStyleBackColor = true;
            this.cb3_1.CheckedChanged += new System.EventHandler(this.cb3_1_CheckedChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(266, 29);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(282, 147);
            this.listBox1.TabIndex = 10;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 50);
            this.button1.TabIndex = 11;
            this.button1.Text = "Obriši";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(411, 194);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 50);
            this.button2.TabIndex = 12;
            this.button2.Text = "Prikaži";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(608, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Granica Godina";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(693, 126);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(608, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Dužina";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(693, 96);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(608, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Žanr";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(693, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(608, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Naziv Filma";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(693, 36);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(611, 194);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 50);
            this.button3.TabIndex = 21;
            this.button3.Text = "Potvrdi Izmene";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(689, 291);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 17);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "Isključi Potvrde";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FAFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 320);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cb3_1);
            this.Controls.Add(this.btn3_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt3_4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt3_3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt3_2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt3_1);
            this.Name = "FAFilm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FAFilm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FAFilm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FAFilm_FormClosed);
            this.Load += new System.EventHandler(this.FAFilm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt3_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt3_2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt3_4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt3_3;
        private System.Windows.Forms.Button btn3_1;
        private System.Windows.Forms.CheckBox cb3_1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}