namespace Aplicatie_Meniu_Gradinita9
{
    partial class Oua
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            dateBazaProduseOua_panel = new Panel();
            BazaDateDerivate_lbl = new Label();
            dataOua = new DataGridView();
            oua_lbl = new Label();
            numeProdus_txt = new TextBox();
            scz_txt = new TextBox();
            proteine_txt = new TextBox();
            lipide_txt = new TextBox();
            glucide_txt = new TextBox();
            calorii_txt = new TextBox();
            produsId_lbl = new Label();
            label1 = new Label();
            calorii_lbl = new Label();
            label2 = new Label();
            scz_lbl = new Label();
            label4 = new Label();
            label3 = new Label();
            status_txt = new ComboBox();
            add_btn = new Button();
            actualizare_btn = new Button();
            sterge_btn = new Button();
            clear_btn = new Button();
            parametriiProdus_panel = new Panel();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label12 = new Label();
            label14 = new Label();
            label13 = new Label();
            label11 = new Label();
            label6 = new Label();
            label7 = new Label();
            label5 = new Label();
            protVeg_txt = new TextBox();
            lipideVeg_txt = new TextBox();
            protAnimal_txt = new TextBox();
            grup1_txt = new TextBox();
            calciu_txt = new TextBox();
            lipideAnimal_txt = new TextBox();
            fier_txt = new TextBox();
            coef1_txt = new TextBox();
            grup2_txt = new TextBox();
            coef2_txt = new TextBox();
            dateBazaProduseOua_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataOua).BeginInit();
            parametriiProdus_panel.SuspendLayout();
            SuspendLayout();
            // 
            // dateBazaProduseOua_panel
            // 
            dateBazaProduseOua_panel.BackColor = SystemColors.ButtonHighlight;
            dateBazaProduseOua_panel.BorderStyle = BorderStyle.FixedSingle;
            dateBazaProduseOua_panel.Controls.Add(BazaDateDerivate_lbl);
            dateBazaProduseOua_panel.Controls.Add(dataOua);
            dateBazaProduseOua_panel.Controls.Add(oua_lbl);
            dateBazaProduseOua_panel.Location = new Point(25, 29);
            dateBazaProduseOua_panel.Name = "dateBazaProduseOua_panel";
            dateBazaProduseOua_panel.Size = new Size(824, 261);
            dateBazaProduseOua_panel.TabIndex = 2;
            // 
            // BazaDateDerivate_lbl
            // 
            BazaDateDerivate_lbl.AutoSize = true;
            BazaDateDerivate_lbl.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BazaDateDerivate_lbl.ForeColor = Color.Black;
            BazaDateDerivate_lbl.Location = new Point(20, 17);
            BazaDateDerivate_lbl.Name = "BazaDateDerivate_lbl";
            BazaDateDerivate_lbl.Size = new Size(0, 19);
            BazaDateDerivate_lbl.TabIndex = 0;
            // 
            // dataOua
            // 
            dataOua.AllowUserToAddRows = false;
            dataOua.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataOua.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataOua.BackgroundColor = Color.FromArgb(184, 163, 232);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(33, 11, 97);
            dataGridViewCellStyle2.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataOua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataOua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Yellow;
            dataGridViewCellStyle3.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataOua.DefaultCellStyle = dataGridViewCellStyle3;
            dataOua.EnableHeadersVisualStyles = false;
            dataOua.Location = new Point(26, 39);
            dataOua.Name = "dataOua";
            dataOua.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataOua.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataOua.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.Blue;
            dataGridViewCellStyle5.SelectionForeColor = Color.LightGray;
            dataOua.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataOua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataOua.Size = new Size(778, 209);
            dataOua.TabIndex = 1;
            dataOua.CellClick += dataOua_CellClick;
            dataOua.CellEnter += dataOua_CellClick;
            // 
            // oua_lbl
            // 
            oua_lbl.AutoSize = true;
            oua_lbl.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            oua_lbl.ForeColor = Color.Black;
            oua_lbl.Location = new Point(26, 12);
            oua_lbl.Name = "oua_lbl";
            oua_lbl.Size = new Size(49, 24);
            oua_lbl.TabIndex = 0;
            oua_lbl.Text = "Oua";
            // 
            // numeProdus_txt
            // 
            numeProdus_txt.ForeColor = Color.Black;
            numeProdus_txt.Location = new Point(124, 24);
            numeProdus_txt.Name = "numeProdus_txt";
            numeProdus_txt.Size = new Size(195, 23);
            numeProdus_txt.TabIndex = 2;
            // 
            // scz_txt
            // 
            scz_txt.Location = new Point(460, 25);
            scz_txt.Name = "scz_txt";
            scz_txt.Size = new Size(75, 23);
            scz_txt.TabIndex = 2;
            // 
            // proteine_txt
            // 
            proteine_txt.Location = new Point(112, 66);
            proteine_txt.Name = "proteine_txt";
            proteine_txt.Size = new Size(75, 23);
            proteine_txt.TabIndex = 2;
            // 
            // lipide_txt
            // 
            lipide_txt.Location = new Point(112, 110);
            lipide_txt.Name = "lipide_txt";
            lipide_txt.Size = new Size(75, 23);
            lipide_txt.TabIndex = 2;
            // 
            // glucide_txt
            // 
            glucide_txt.Location = new Point(112, 150);
            glucide_txt.Name = "glucide_txt";
            glucide_txt.Size = new Size(75, 23);
            glucide_txt.TabIndex = 2;
            // 
            // calorii_txt
            // 
            calorii_txt.Location = new Point(112, 196);
            calorii_txt.Name = "calorii_txt";
            calorii_txt.Size = new Size(75, 23);
            calorii_txt.TabIndex = 2;
            // 
            // produsId_lbl
            // 
            produsId_lbl.AutoSize = true;
            produsId_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            produsId_lbl.ForeColor = Color.Black;
            produsId_lbl.Location = new Point(9, 24);
            produsId_lbl.Name = "produsId_lbl";
            produsId_lbl.Size = new Size(108, 20);
            produsId_lbl.TabIndex = 0;
            produsId_lbl.Text = "Nume produs:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(9, 66);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 1;
            label1.Text = "Proteine:";
            // 
            // calorii_lbl
            // 
            calorii_lbl.AutoSize = true;
            calorii_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            calorii_lbl.ForeColor = Color.Black;
            calorii_lbl.Location = new Point(9, 196);
            calorii_lbl.Name = "calorii_lbl";
            calorii_lbl.Size = new Size(56, 20);
            calorii_lbl.TabIndex = 1;
            calorii_lbl.Text = "Calorii:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(9, 110);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 1;
            label2.Text = "Lipide:";
            // 
            // scz_lbl
            // 
            scz_lbl.AutoSize = true;
            scz_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            scz_lbl.ForeColor = Color.Black;
            scz_lbl.Location = new Point(345, 23);
            scz_lbl.Name = "scz_lbl";
            scz_lbl.Size = new Size(94, 20);
            scz_lbl.TabIndex = 3;
            scz_lbl.Text = "Scazamant:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(602, 149);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 3;
            label4.Text = "Status:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(9, 150);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 3;
            label3.Text = "Glucide:";
            // 
            // status_txt
            // 
            status_txt.FormattingEnabled = true;
            status_txt.Items.AddRange(new object[] { "Alege", "Nu aleg" });
            status_txt.Location = new Point(693, 147);
            status_txt.Name = "status_txt";
            status_txt.Size = new Size(121, 23);
            status_txt.TabIndex = 4;
            // 
            // add_btn
            // 
            add_btn.BackColor = Color.FromArgb(33, 11, 97);
            add_btn.Cursor = Cursors.Hand;
            add_btn.FlatAppearance.BorderSize = 0;
            add_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            add_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            add_btn.FlatStyle = FlatStyle.Flat;
            add_btn.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            add_btn.ForeColor = Color.White;
            add_btn.Location = new Point(449, 194);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(75, 30);
            add_btn.TabIndex = 8;
            add_btn.Text = "Adauga";
            add_btn.UseVisualStyleBackColor = false;
            add_btn.Click += add_btn_Click;
            // 
            // actualizare_btn
            // 
            actualizare_btn.BackColor = Color.FromArgb(33, 11, 97);
            actualizare_btn.Cursor = Cursors.Hand;
            actualizare_btn.FlatAppearance.BorderSize = 0;
            actualizare_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            actualizare_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            actualizare_btn.FlatStyle = FlatStyle.Flat;
            actualizare_btn.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            actualizare_btn.ForeColor = Color.White;
            actualizare_btn.Location = new Point(547, 194);
            actualizare_btn.Name = "actualizare_btn";
            actualizare_btn.Size = new Size(75, 30);
            actualizare_btn.TabIndex = 7;
            actualizare_btn.Text = "Actualizare";
            actualizare_btn.UseVisualStyleBackColor = false;
            actualizare_btn.Click += actualizare_btn_Click;
            // 
            // sterge_btn
            // 
            sterge_btn.BackColor = Color.FromArgb(33, 11, 97);
            sterge_btn.Cursor = Cursors.Hand;
            sterge_btn.FlatAppearance.BorderSize = 0;
            sterge_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            sterge_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            sterge_btn.FlatStyle = FlatStyle.Flat;
            sterge_btn.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sterge_btn.ForeColor = Color.White;
            sterge_btn.Location = new Point(640, 194);
            sterge_btn.Name = "sterge_btn";
            sterge_btn.Size = new Size(75, 30);
            sterge_btn.TabIndex = 6;
            sterge_btn.Text = "Sterge";
            sterge_btn.UseVisualStyleBackColor = false;
            sterge_btn.Click += sterge_btn_Click;
            // 
            // clear_btn
            // 
            clear_btn.BackColor = Color.FromArgb(33, 11, 97);
            clear_btn.Cursor = Cursors.Hand;
            clear_btn.FlatAppearance.BorderSize = 0;
            clear_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            clear_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            clear_btn.FlatStyle = FlatStyle.Flat;
            clear_btn.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clear_btn.ForeColor = Color.White;
            clear_btn.Location = new Point(736, 194);
            clear_btn.Name = "clear_btn";
            clear_btn.Size = new Size(75, 30);
            clear_btn.TabIndex = 5;
            clear_btn.Text = "Clear";
            clear_btn.UseVisualStyleBackColor = false;
            clear_btn.Click += clear_btn_Click;
            // 
            // parametriiProdus_panel
            // 
            parametriiProdus_panel.BackColor = SystemColors.ButtonHighlight;
            parametriiProdus_panel.BorderStyle = BorderStyle.FixedSingle;
            parametriiProdus_panel.Controls.Add(clear_btn);
            parametriiProdus_panel.Controls.Add(sterge_btn);
            parametriiProdus_panel.Controls.Add(actualizare_btn);
            parametriiProdus_panel.Controls.Add(add_btn);
            parametriiProdus_panel.Controls.Add(status_txt);
            parametriiProdus_panel.Controls.Add(label10);
            parametriiProdus_panel.Controls.Add(label3);
            parametriiProdus_panel.Controls.Add(label9);
            parametriiProdus_panel.Controls.Add(label4);
            parametriiProdus_panel.Controls.Add(scz_lbl);
            parametriiProdus_panel.Controls.Add(label2);
            parametriiProdus_panel.Controls.Add(calorii_lbl);
            parametriiProdus_panel.Controls.Add(label1);
            parametriiProdus_panel.Controls.Add(produsId_lbl);
            parametriiProdus_panel.Controls.Add(label8);
            parametriiProdus_panel.Controls.Add(calorii_txt);
            parametriiProdus_panel.Controls.Add(label12);
            parametriiProdus_panel.Controls.Add(glucide_txt);
            parametriiProdus_panel.Controls.Add(label14);
            parametriiProdus_panel.Controls.Add(lipide_txt);
            parametriiProdus_panel.Controls.Add(label13);
            parametriiProdus_panel.Controls.Add(proteine_txt);
            parametriiProdus_panel.Controls.Add(label11);
            parametriiProdus_panel.Controls.Add(scz_txt);
            parametriiProdus_panel.Controls.Add(label6);
            parametriiProdus_panel.Controls.Add(numeProdus_txt);
            parametriiProdus_panel.Controls.Add(label7);
            parametriiProdus_panel.Controls.Add(label5);
            parametriiProdus_panel.Controls.Add(protVeg_txt);
            parametriiProdus_panel.Controls.Add(lipideVeg_txt);
            parametriiProdus_panel.Controls.Add(protAnimal_txt);
            parametriiProdus_panel.Controls.Add(grup1_txt);
            parametriiProdus_panel.Controls.Add(calciu_txt);
            parametriiProdus_panel.Controls.Add(lipideAnimal_txt);
            parametriiProdus_panel.Controls.Add(fier_txt);
            parametriiProdus_panel.Controls.Add(coef1_txt);
            parametriiProdus_panel.Controls.Add(grup2_txt);
            parametriiProdus_panel.Controls.Add(coef2_txt);
            parametriiProdus_panel.Location = new Point(25, 296);
            parametriiProdus_panel.Name = "parametriiProdus_panel";
            parametriiProdus_panel.Size = new Size(824, 239);
            parametriiProdus_panel.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(193, 200);
            label10.Name = "label10";
            label10.Size = new Size(56, 20);
            label10.TabIndex = 3;
            label10.Text = "Calciu:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(193, 158);
            label9.Name = "label9";
            label9.Size = new Size(40, 20);
            label9.TabIndex = 3;
            label9.Text = "Fier:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(373, 109);
            label8.Name = "label8";
            label8.Size = new Size(64, 40);
            label8.TabIndex = 1;
            label8.Text = "Lipide\r\nanimale\r\n";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(550, 74);
            label12.Name = "label12";
            label12.Size = new Size(80, 40);
            label12.TabIndex = 1;
            label12.Text = "  Grup\r\nproduse 2";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(695, 74);
            label14.Name = "label14";
            label14.Size = new Size(58, 40);
            label14.TabIndex = 1;
            label14.Text = "Coef.\r\nechiv.2";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(695, 23);
            label13.Name = "label13";
            label13.Size = new Size(58, 40);
            label13.TabIndex = 1;
            label13.Text = "Coef.\r\nechiv.1\r\n";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(550, 23);
            label11.Name = "label11";
            label11.Size = new Size(80, 40);
            label11.TabIndex = 1;
            label11.Text = "  Grup\r\nproduse 1\r\n";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(373, 65);
            label6.Name = "label6";
            label6.Size = new Size(68, 40);
            label6.TabIndex = 1;
            label6.Text = "Proteine\r\nanimale\r\n";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(193, 109);
            label7.Name = "label7";
            label7.Size = new Size(69, 40);
            label7.TabIndex = 1;
            label7.Text = "Lipide\r\nvegetale";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(193, 65);
            label5.Name = "label5";
            label5.Size = new Size(69, 40);
            label5.TabIndex = 1;
            label5.Text = "Proteine\r\nvegetale";
            // 
            // protVeg_txt
            // 
            protVeg_txt.Location = new Point(282, 74);
            protVeg_txt.Name = "protVeg_txt";
            protVeg_txt.Size = new Size(75, 23);
            protVeg_txt.TabIndex = 2;
            // 
            // lipideVeg_txt
            // 
            lipideVeg_txt.Location = new Point(282, 118);
            lipideVeg_txt.Name = "lipideVeg_txt";
            lipideVeg_txt.Size = new Size(75, 23);
            lipideVeg_txt.TabIndex = 2;
            // 
            // protAnimal_txt
            // 
            protAnimal_txt.Location = new Point(462, 74);
            protAnimal_txt.Name = "protAnimal_txt";
            protAnimal_txt.Size = new Size(75, 23);
            protAnimal_txt.TabIndex = 2;
            // 
            // grup1_txt
            // 
            grup1_txt.Location = new Point(639, 32);
            grup1_txt.Name = "grup1_txt";
            grup1_txt.Size = new Size(50, 23);
            grup1_txt.TabIndex = 2;
            // 
            // calciu_txt
            // 
            calciu_txt.Location = new Point(282, 200);
            calciu_txt.Name = "calciu_txt";
            calciu_txt.Size = new Size(75, 23);
            calciu_txt.TabIndex = 2;
            // 
            // lipideAnimal_txt
            // 
            lipideAnimal_txt.Location = new Point(462, 118);
            lipideAnimal_txt.Name = "lipideAnimal_txt";
            lipideAnimal_txt.Size = new Size(75, 23);
            lipideAnimal_txt.TabIndex = 2;
            // 
            // fier_txt
            // 
            fier_txt.Location = new Point(282, 158);
            fier_txt.Name = "fier_txt";
            fier_txt.Size = new Size(75, 23);
            fier_txt.TabIndex = 2;
            // 
            // coef1_txt
            // 
            coef1_txt.Location = new Point(761, 31);
            coef1_txt.Name = "coef1_txt";
            coef1_txt.Size = new Size(50, 23);
            coef1_txt.TabIndex = 2;
            // 
            // grup2_txt
            // 
            grup2_txt.Location = new Point(639, 83);
            grup2_txt.Name = "grup2_txt";
            grup2_txt.Size = new Size(50, 23);
            grup2_txt.TabIndex = 2;
            // 
            // coef2_txt
            // 
            coef2_txt.Location = new Point(761, 82);
            coef2_txt.Name = "coef2_txt";
            coef2_txt.Size = new Size(50, 23);
            coef2_txt.TabIndex = 2;
            // 
            // Oua
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(parametriiProdus_panel);
            Controls.Add(dateBazaProduseOua_panel);
            Name = "Oua";
            Size = new Size(875, 565);
            dateBazaProduseOua_panel.ResumeLayout(false);
            dateBazaProduseOua_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataOua).EndInit();
            parametriiProdus_panel.ResumeLayout(false);
            parametriiProdus_panel.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel dateBazaProduseOua_panel;
        private System.Windows.Forms.Label BazaDateDerivate_lbl;
        private System.Windows.Forms.Label oua_lbl;
        private System.Windows.Forms.TextBox numeProdus_txt;
        private System.Windows.Forms.TextBox scz_txt;
        private System.Windows.Forms.TextBox proteine_txt;
        private System.Windows.Forms.TextBox lipide_txt;
        private System.Windows.Forms.TextBox glucide_txt;
        private System.Windows.Forms.TextBox calorii_txt;
        private System.Windows.Forms.Label produsId_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label calorii_lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label scz_lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox status_txt;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button actualizare_btn;
        private System.Windows.Forms.Button sterge_btn;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.Panel parametriiProdus_panel;
        public DataGridView dataOua;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label12;
        private Label label14;
        private Label label13;
        private Label label11;
        private Label label6;
        private Label label7;
        private Label label5;
        private TextBox protVeg_txt;
        private TextBox lipideVeg_txt;
        private TextBox protAnimal_txt;
        private TextBox grup1_txt;
        private TextBox calciu_txt;
        private TextBox lipideAnimal_txt;
        private TextBox fier_txt;
        private TextBox coef1_txt;
        private TextBox grup2_txt;
        private TextBox coef2_txt;
    }
}
