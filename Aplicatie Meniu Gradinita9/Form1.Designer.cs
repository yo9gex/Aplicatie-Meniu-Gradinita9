namespace Aplicatie_Meniu_Gradinita9
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            signup_button = new Button();
            label5 = new Label();
            exit = new Label();
            label2 = new Label();
            label3 = new Label();
            login_username = new TextBox();
            label4 = new Label();
            login_password = new TextBox();
            login_button = new Button();
            show_password = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(75, 8, 138);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(signup_button);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Left;
            panel1.ForeColor = Color.MidnightBlue;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(184, 400);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.G_M;
            pictureBox1.Location = new Point(32, 50);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // signup_button
            // 
            signup_button.BackColor = Color.FromArgb(33, 11, 97);
            signup_button.Cursor = Cursors.Hand;
            signup_button.FlatAppearance.BorderSize = 0;
            signup_button.FlatAppearance.MouseDownBackColor = Color.Purple;
            signup_button.FlatAppearance.MouseOverBackColor = Color.Purple;
            signup_button.FlatStyle = FlatStyle.Flat;
            signup_button.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signup_button.ForeColor = Color.White;
            signup_button.Location = new Point(34, 353);
            signup_button.Name = "signup_button";
            signup_button.Size = new Size(113, 23);
            signup_button.TabIndex = 8;
            signup_button.Text = "CREARE CONT";
            signup_button.UseVisualStyleBackColor = false;
            signup_button.Click += signup_button_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(41, 319);
            label5.Name = "label5";
            label5.Size = new Size(98, 16);
            label5.TabIndex = 7;
            label5.Text = "Înregistrează-te";
            // 
            // exit
            // 
            exit.AutoSize = true;
            exit.Cursor = Cursors.Hand;
            exit.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exit.Location = new Point(553, 9);
            exit.Name = "exit";
            exit.Size = new Size(17, 18);
            exit.TabIndex = 1;
            exit.Text = "X";
            exit.Click += exit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(230, 45);
            label2.Name = "label2";
            label2.Size = new Size(113, 24);
            label2.TabIndex = 2;
            label2.Text = "Logare Cont";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(230, 115);
            label3.Name = "label3";
            label3.Size = new Size(62, 16);
            label3.TabIndex = 3;
            label3.Text = "Utilizator:";
            // 
            // login_username
            // 
            login_username.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_username.Location = new Point(233, 134);
            login_username.Multiline = true;
            login_username.Name = "login_username";
            login_username.Size = new Size(261, 30);
            login_username.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(230, 198);
            label4.Name = "label4";
            label4.Size = new Size(101, 16);
            label4.TabIndex = 3;
            label4.Text = "Parolă utilizator:";
            label4.Click += label4_Click;
            // 
            // login_password
            // 
            login_password.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_password.Location = new Point(233, 217);
            login_password.Multiline = true;
            login_password.Name = "login_password";
            login_password.PasswordChar = '*';
            login_password.Size = new Size(261, 30);
            login_password.TabIndex = 4;
            login_password.TextChanged += textBox2_TextChanged;
            // 
            // login_button
            // 
            login_button.BackColor = Color.FromArgb(33, 11, 97);
            login_button.Cursor = Cursors.Hand;
            login_button.FlatAppearance.BorderSize = 0;
            login_button.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            login_button.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            login_button.FlatStyle = FlatStyle.Flat;
            login_button.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_button.ForeColor = Color.White;
            login_button.Location = new Point(230, 290);
            login_button.Name = "login_button";
            login_button.Size = new Size(75, 23);
            login_button.TabIndex = 5;
            login_button.Text = "LOGARE";
            login_button.UseVisualStyleBackColor = false;
            login_button.Click += login_button_Click;
            // 
            // show_password
            // 
            show_password.AutoSize = true;
            show_password.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            show_password.Location = new Point(410, 253);
            show_password.Name = "show_password";
            show_password.Size = new Size(91, 18);
            show_password.TabIndex = 6;
            show_password.Text = "Arată parola";
            show_password.UseVisualStyleBackColor = true;
            show_password.CheckedChanged += show_password_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(575, 400);
            Controls.Add(show_password);
            Controls.Add(login_button);
            Controls.Add(login_password);
            Controls.Add(login_username);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(exit);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox login_username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox login_password;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.CheckBox show_password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button signup_button;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

