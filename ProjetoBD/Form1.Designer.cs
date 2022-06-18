namespace ProjetoBD
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
            this.Nome_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Id_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Email_textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Morada_textbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Salario_textbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Sup_textbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tel_textbox = new System.Windows.Forms.TextBox();
            this.Data_inicio = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Data_fim = new System.Windows.Forms.DateTimePicker();
            this.Cargo_Box = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Categoria_textbox = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SSN_textbox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.NIF_textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Nome_textbox
            // 
            this.Nome_textbox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Nome_textbox.Location = new System.Drawing.Point(281, 40);
            this.Nome_textbox.Name = "Nome_textbox";
            this.Nome_textbox.Size = new System.Drawing.Size(385, 22);
            this.Nome_textbox.TabIndex = 1;
            this.Nome_textbox.Text = "\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Id_textbox
            // 
            this.Id_textbox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Id_textbox.Location = new System.Drawing.Point(477, 105);
            this.Id_textbox.Name = "Id_textbox";
            this.Id_textbox.Size = new System.Drawing.Size(189, 22);
            this.Id_textbox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "E-mail";
            // 
            // Email_textbox
            // 
            this.Email_textbox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Email_textbox.Location = new System.Drawing.Point(281, 105);
            this.Email_textbox.Name = "Email_textbox";
            this.Email_textbox.Size = new System.Drawing.Size(185, 22);
            this.Email_textbox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(478, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Morada";
            // 
            // Morada_textbox
            // 
            this.Morada_textbox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Morada_textbox.Location = new System.Drawing.Point(477, 170);
            this.Morada_textbox.Name = "Morada_textbox";
            this.Morada_textbox.Size = new System.Drawing.Size(189, 22);
            this.Morada_textbox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(282, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Salário";
            // 
            // Salario_textbox
            // 
            this.Salario_textbox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Salario_textbox.Location = new System.Drawing.Point(281, 237);
            this.Salario_textbox.Name = "Salario_textbox";
            this.Salario_textbox.Size = new System.Drawing.Size(185, 22);
            this.Salario_textbox.TabIndex = 13;
            this.Salario_textbox.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(478, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "ID do superior";
            // 
            // Sup_textbox
            // 
            this.Sup_textbox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Sup_textbox.Location = new System.Drawing.Point(477, 237);
            this.Sup_textbox.Name = "Sup_textbox";
            this.Sup_textbox.Size = new System.Drawing.Size(189, 22);
            this.Sup_textbox.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(282, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Nº Telemóvel";
            // 
            // tel_textbox
            // 
            this.tel_textbox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tel_textbox.Location = new System.Drawing.Point(281, 172);
            this.tel_textbox.Name = "tel_textbox";
            this.tel_textbox.Size = new System.Drawing.Size(185, 22);
            this.tel_textbox.TabIndex = 9;
            // 
            // Data_inicio
            // 
            this.Data_inicio.Location = new System.Drawing.Point(417, 405);
            this.Data_inicio.Name = "Data_inicio";
            this.Data_inicio.Size = new System.Drawing.Size(207, 22);
            this.Data_inicio.TabIndex = 15;
            this.Data_inicio.Value = new System.DateTime(2022, 6, 14, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(282, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Data de Início:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(282, 447);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Data de Fim:";
            // 
            // Data_fim
            // 
            this.Data_fim.Location = new System.Drawing.Point(417, 447);
            this.Data_fim.Name = "Data_fim";
            this.Data_fim.Size = new System.Drawing.Size(207, 22);
            this.Data_fim.TabIndex = 17;
            this.Data_fim.Value = new System.DateTime(2022, 6, 14, 0, 0, 0, 0);
            // 
            // Cargo_Box
            // 
            this.Cargo_Box.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Cargo_Box.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Cargo_Box.Location = new System.Drawing.Point(281, 304);
            this.Cargo_Box.Name = "Cargo_Box";
            this.Cargo_Box.Size = new System.Drawing.Size(185, 24);
            this.Cargo_Box.Sorted = true;
            this.Cargo_Box.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(282, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Cargo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Enabled = false;
            this.label11.Location = new System.Drawing.Point(282, 350);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "Categoria";
            this.label11.Visible = false;
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // Categoria_textbox
            // 
            this.Categoria_textbox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Categoria_textbox.Enabled = false;
            this.Categoria_textbox.Location = new System.Drawing.Point(281, 372);
            this.Categoria_textbox.Name = "Categoria_textbox";
            this.Categoria_textbox.Size = new System.Drawing.Size(185, 22);
            this.Categoria_textbox.TabIndex = 21;
            this.Categoria_textbox.Visible = false;
            this.Categoria_textbox.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 18);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(263, 324);
            this.listBox1.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Enabled = false;
            this.label12.Location = new System.Drawing.Point(477, 284);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 16);
            this.label12.TabIndex = 27;
            this.label12.Text = "SSN";
            this.label12.Visible = false;
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // SSN_textbox
            // 
            this.SSN_textbox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.SSN_textbox.Enabled = false;
            this.SSN_textbox.Location = new System.Drawing.Point(476, 306);
            this.SSN_textbox.Name = "SSN_textbox";
            this.SSN_textbox.Size = new System.Drawing.Size(185, 22);
            this.SSN_textbox.TabIndex = 26;
            this.SSN_textbox.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Enabled = false;
            this.label13.Location = new System.Drawing.Point(477, 350);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 16);
            this.label13.TabIndex = 29;
            this.label13.Text = "NIF";
            this.label13.Visible = false;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // NIF_textbox
            // 
            this.NIF_textbox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.NIF_textbox.Enabled = false;
            this.NIF_textbox.Location = new System.Drawing.Point(476, 372);
            this.NIF_textbox.Name = "NIF_textbox";
            this.NIF_textbox.Size = new System.Drawing.Size(185, 22);
            this.NIF_textbox.TabIndex = 28;
            this.NIF_textbox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1030, 480);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.NIF_textbox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.SSN_textbox);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Categoria_textbox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Cargo_Box);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Data_fim);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Data_inicio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Salario_textbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Sup_textbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tel_textbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Morada_textbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Email_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Id_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Nome_textbox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mercado";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Nome_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Id_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Email_textbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Morada_textbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Salario_textbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Sup_textbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tel_textbox;
        private System.Windows.Forms.DateTimePicker Data_inicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker Data_fim;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Categoria_textbox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox SSN_textbox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox NIF_textbox;
        private System.Windows.Forms.ComboBox Cargo_Box;
    }
}

