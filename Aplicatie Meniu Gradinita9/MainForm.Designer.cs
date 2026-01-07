namespace Aplicatie_Meniu_Gradinita9
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel4 = new Panel();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            licenta_btn = new Label();
            exit_btn = new Label();
            panel5 = new Panel();
            button1 = new Button();
            dataToday_lbl = new Label();
            label5 = new Label();
            logout_btn = new Button();
            micDejun_btn = new Button();
            pranz_btn = new Button();
            gustare_btn = new Button();
            echivalente_btn = new Button();
            anchetaAlimentara_btn = new Button();
            totalNutrienti_btn = new Button();
            meniulZilei_btn = new Button();
            necesaralimente_btn = new Button();
            listaproduse_btn = new Button();
            pictureBox2 = new PictureBox();
            panelContainer = new Panel();
            graficeNutrienti_btn = new Button();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(33, 11, 97);
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(pictureBox3);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(licenta_btn);
            panel4.Controls.Add(exit_btn);
            panel4.Dock = DockStyle.Top;
            panel4.ForeColor = Color.White;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1100, 35);
            panel4.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(11, 8);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(16, 16);
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(39, 6);
            label1.Name = "label1";
            label1.Size = new Size(201, 18);
            label1.TabIndex = 1;
            label1.Text = "Aplicație calcul meniu grădiniță";
            // 
            // licenta_btn
            // 
            licenta_btn.AutoSize = true;
            licenta_btn.Cursor = Cursors.Hand;
            licenta_btn.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            licenta_btn.Image = (Image)resources.GetObject("licenta_btn.Image");
            licenta_btn.ImageAlign = ContentAlignment.MiddleLeft;
            licenta_btn.Location = new Point(962, 8);
            licenta_btn.Name = "licenta_btn";
            licenta_btn.Size = new Size(78, 18);
            licenta_btn.TabIndex = 0;
            licenta_btn.Text = "     Licență";
            licenta_btn.Click += licenta_btn_Click;
            // 
            // exit_btn
            // 
            exit_btn.AutoSize = true;
            exit_btn.Cursor = Cursors.Hand;
            exit_btn.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exit_btn.Location = new Point(1070, 8);
            exit_btn.Name = "exit_btn";
            exit_btn.Size = new Size(17, 18);
            exit_btn.TabIndex = 0;
            exit_btn.Text = "X";
            exit_btn.Click += exit_btn_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(33, 11, 97);
            panel5.Controls.Add(button1);
            panel5.Controls.Add(dataToday_lbl);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(logout_btn);
            panel5.Controls.Add(micDejun_btn);
            panel5.Controls.Add(pranz_btn);
            panel5.Controls.Add(gustare_btn);
            panel5.Controls.Add(echivalente_btn);
            panel5.Controls.Add(anchetaAlimentara_btn);
            panel5.Controls.Add(totalNutrienti_btn);
            panel5.Controls.Add(meniulZilei_btn);
            panel5.Controls.Add(necesaralimente_btn);
            panel5.Controls.Add(listaproduse_btn);
            panel5.Controls.Add(pictureBox2);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 35);
            panel5.Name = "panel5";
            panel5.Size = new Size(225, 585);
            panel5.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(33, 11, 97);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Image = Properties.Resources.meniuri;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(12, 420);
            button1.Name = "button1";
            button1.Size = new Size(200, 30);
            button1.TabIndex = 2;
            button1.Text = "Grafice Nutrienți";
            button1.UseVisualStyleBackColor = false;
            button1.Click += graficeNutrienti_btn_Click;
            // 
            // dataToday_lbl
            // 
            dataToday_lbl.AutoSize = true;
            dataToday_lbl.BackColor = Color.FromArgb(33, 11, 97);
            dataToday_lbl.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataToday_lbl.ForeColor = Color.White;
            dataToday_lbl.Location = new Point(69, 144);
            dataToday_lbl.Name = "dataToday_lbl";
            dataToday_lbl.Size = new Size(15, 16);
            dataToday_lbl.TabIndex = 4;
            dataToday_lbl.Text = "?";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(93, 550);
            label5.Name = "label5";
            label5.Size = new Size(48, 19);
            label5.TabIndex = 4;
            label5.Text = "Ieșire";
            // 
            // logout_btn
            // 
            logout_btn.Cursor = Cursors.Hand;
            logout_btn.FlatAppearance.BorderSize = 0;
            logout_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            logout_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            logout_btn.FlatStyle = FlatStyle.Flat;
            logout_btn.ForeColor = Color.White;
            logout_btn.Image = Properties.Resources.logout;
            logout_btn.Location = new Point(42, 538);
            logout_btn.Name = "logout_btn";
            logout_btn.Size = new Size(45, 45);
            logout_btn.TabIndex = 3;
            logout_btn.UseVisualStyleBackColor = true;
            logout_btn.Click += logout_btn_Click;
            // 
            // micDejun_btn
            // 
            micDejun_btn.BackColor = Color.FromArgb(33, 11, 97);
            micDejun_btn.Cursor = Cursors.Hand;
            micDejun_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            micDejun_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            micDejun_btn.FlatStyle = FlatStyle.Flat;
            micDejun_btn.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            micDejun_btn.Image = Properties.Resources.meniuri;
            micDejun_btn.ImageAlign = ContentAlignment.MiddleLeft;
            micDejun_btn.Location = new Point(12, 240);
            micDejun_btn.Name = "micDejun_btn";
            micDejun_btn.Size = new Size(200, 30);
            micDejun_btn.TabIndex = 2;
            micDejun_btn.Text = "Mic Dejun";
            micDejun_btn.UseVisualStyleBackColor = false;
            micDejun_btn.Click += micDejun_btn_Click;
            // 
            // pranz_btn
            // 
            pranz_btn.BackColor = Color.FromArgb(33, 11, 97);
            pranz_btn.Cursor = Cursors.Hand;
            pranz_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            pranz_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            pranz_btn.FlatStyle = FlatStyle.Flat;
            pranz_btn.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pranz_btn.Image = Properties.Resources.meniuri;
            pranz_btn.ImageAlign = ContentAlignment.MiddleLeft;
            pranz_btn.Location = new Point(12, 276);
            pranz_btn.Name = "pranz_btn";
            pranz_btn.Size = new Size(200, 30);
            pranz_btn.TabIndex = 2;
            pranz_btn.Text = "Prânz";
            pranz_btn.UseVisualStyleBackColor = false;
            pranz_btn.Click += pranz_btn_Click;
            // 
            // gustare_btn
            // 
            gustare_btn.BackColor = Color.FromArgb(33, 11, 97);
            gustare_btn.Cursor = Cursors.Hand;
            gustare_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            gustare_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            gustare_btn.FlatStyle = FlatStyle.Flat;
            gustare_btn.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gustare_btn.Image = Properties.Resources.meniuri;
            gustare_btn.ImageAlign = ContentAlignment.MiddleLeft;
            gustare_btn.Location = new Point(12, 312);
            gustare_btn.Name = "gustare_btn";
            gustare_btn.Size = new Size(200, 30);
            gustare_btn.TabIndex = 2;
            gustare_btn.Text = "Gustare";
            gustare_btn.UseVisualStyleBackColor = false;
            gustare_btn.Click += gustare_btn_Click;
            // 
            // echivalente_btn
            // 
            echivalente_btn.BackColor = Color.FromArgb(33, 11, 97);
            echivalente_btn.Cursor = Cursors.Hand;
            echivalente_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            echivalente_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            echivalente_btn.FlatStyle = FlatStyle.Flat;
            echivalente_btn.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            echivalente_btn.Image = Properties.Resources.meniuri;
            echivalente_btn.ImageAlign = ContentAlignment.MiddleLeft;
            echivalente_btn.Location = new Point(12, 492);
            echivalente_btn.Name = "echivalente_btn";
            echivalente_btn.Size = new Size(200, 30);
            echivalente_btn.TabIndex = 2;
            echivalente_btn.Text = "Echivalențe Alimente";
            echivalente_btn.UseVisualStyleBackColor = false;
            echivalente_btn.Click += echivalente_btn_Click;
            // 
            // anchetaAlimentara_btn
            // 
            anchetaAlimentara_btn.BackColor = Color.FromArgb(33, 11, 97);
            anchetaAlimentara_btn.Cursor = Cursors.Hand;
            anchetaAlimentara_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            anchetaAlimentara_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            anchetaAlimentara_btn.FlatStyle = FlatStyle.Flat;
            anchetaAlimentara_btn.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            anchetaAlimentara_btn.Image = Properties.Resources.meniuri;
            anchetaAlimentara_btn.ImageAlign = ContentAlignment.MiddleLeft;
            anchetaAlimentara_btn.Location = new Point(12, 456);
            anchetaAlimentara_btn.Name = "anchetaAlimentara_btn";
            anchetaAlimentara_btn.Size = new Size(200, 30);
            anchetaAlimentara_btn.TabIndex = 2;
            anchetaAlimentara_btn.Text = "Anchetă Alimentară";
            anchetaAlimentara_btn.UseVisualStyleBackColor = false;
            anchetaAlimentara_btn.Click += anchetaAlimentara_btn_Click;
            // 
            // totalNutrienti_btn
            // 
            totalNutrienti_btn.BackColor = Color.FromArgb(33, 11, 97);
            totalNutrienti_btn.Cursor = Cursors.Hand;
            totalNutrienti_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            totalNutrienti_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            totalNutrienti_btn.FlatStyle = FlatStyle.Flat;
            totalNutrienti_btn.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            totalNutrienti_btn.Image = Properties.Resources.meniuri;
            totalNutrienti_btn.ImageAlign = ContentAlignment.MiddleLeft;
            totalNutrienti_btn.Location = new Point(12, 384);
            totalNutrienti_btn.Name = "totalNutrienti_btn";
            totalNutrienti_btn.Size = new Size(200, 30);
            totalNutrienti_btn.TabIndex = 2;
            totalNutrienti_btn.Text = "Total Nutrienți";
            totalNutrienti_btn.UseVisualStyleBackColor = false;
            totalNutrienti_btn.Click += totalNutrienti_btn_Click;
            // 
            // meniulZilei_btn
            // 
            meniulZilei_btn.BackColor = Color.FromArgb(33, 11, 97);
            meniulZilei_btn.Cursor = Cursors.Hand;
            meniulZilei_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            meniulZilei_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            meniulZilei_btn.FlatStyle = FlatStyle.Flat;
            meniulZilei_btn.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            meniulZilei_btn.Image = Properties.Resources.meniuri;
            meniulZilei_btn.ImageAlign = ContentAlignment.MiddleLeft;
            meniulZilei_btn.Location = new Point(12, 348);
            meniulZilei_btn.Name = "meniulZilei_btn";
            meniulZilei_btn.Size = new Size(200, 30);
            meniulZilei_btn.TabIndex = 2;
            meniulZilei_btn.Text = "Meniul Zilei";
            meniulZilei_btn.UseVisualStyleBackColor = false;
            meniulZilei_btn.Click += meniulZilei_btn_Click;
            // 
            // necesaralimente_btn
            // 
            necesaralimente_btn.BackColor = Color.FromArgb(33, 11, 97);
            necesaralimente_btn.Cursor = Cursors.Hand;
            necesaralimente_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            necesaralimente_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            necesaralimente_btn.FlatStyle = FlatStyle.Flat;
            necesaralimente_btn.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            necesaralimente_btn.Image = Properties.Resources.necesaralimente;
            necesaralimente_btn.ImageAlign = ContentAlignment.MiddleLeft;
            necesaralimente_btn.Location = new Point(12, 205);
            necesaralimente_btn.Name = "necesaralimente_btn";
            necesaralimente_btn.Size = new Size(200, 30);
            necesaralimente_btn.TabIndex = 2;
            necesaralimente_btn.Text = "Necesar Alimente";
            necesaralimente_btn.UseVisualStyleBackColor = false;
            necesaralimente_btn.Click += necesaralimente_btn_Click;
            // 
            // listaproduse_btn
            // 
            listaproduse_btn.BackColor = Color.FromArgb(33, 11, 97);
            listaproduse_btn.Cursor = Cursors.Hand;
            listaproduse_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            listaproduse_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            listaproduse_btn.FlatStyle = FlatStyle.Flat;
            listaproduse_btn.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listaproduse_btn.Image = Properties.Resources.produse;
            listaproduse_btn.ImageAlign = ContentAlignment.MiddleLeft;
            listaproduse_btn.Location = new Point(12, 170);
            listaproduse_btn.Name = "listaproduse_btn";
            listaproduse_btn.Size = new Size(200, 30);
            listaproduse_btn.TabIndex = 2;
            listaproduse_btn.Text = "Listă Produse";
            listaproduse_btn.UseVisualStyleBackColor = false;
            listaproduse_btn.Click += listaproduse_btn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.G_M;
            pictureBox2.Location = new Point(55, 13);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(120, 120);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // panelContainer
            // 
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(225, 35);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(875, 585);
            panelContainer.TabIndex = 2;
            // 
            // graficeNutrienti_btn
            // 
            graficeNutrienti_btn.BackColor = Color.FromArgb(33, 11, 97);
            graficeNutrienti_btn.Cursor = Cursors.Hand;
            graficeNutrienti_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            graficeNutrienti_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            graficeNutrienti_btn.FlatStyle = FlatStyle.Flat;
            graficeNutrienti_btn.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            graficeNutrienti_btn.Image = Properties.Resources.meniuri;
            graficeNutrienti_btn.ImageAlign = ContentAlignment.MiddleLeft;
            graficeNutrienti_btn.Location = new Point(12, 493);
            graficeNutrienti_btn.Name = "graficeNutrienti_btn";
            graficeNutrienti_btn.Size = new Size(200, 30);
            graficeNutrienti_btn.TabIndex = 2;
            graficeNutrienti_btn.Text = "Grafice Nutrienti";
            graficeNutrienti_btn.UseVisualStyleBackColor = false;
            graficeNutrienti_btn.Click += graficeNutrienti_btn_Click;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1100, 620);
            Controls.Add(panelContainer);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += MainForm_Load;
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button gustare_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button meniu_btn;
        private System.Windows.Forms.Panel panel3;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label exit_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button listaproduse_btn;
        private System.Windows.Forms.Button necesaralimente_btn;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Label label5;
      
        
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label dataToday_lbl;
        private Button pranz_btn;
        private Button meniulZilei_btn;
        private Button micDejun_btn;
        private Button totalNutrienti_btn;
        private Button anchetaAlimentara_btn;
        private Button graficeNutrienti_btn;
        private Button button1;
        private Label licenta_btn;
        private Button echivalente_btn;
    }
}