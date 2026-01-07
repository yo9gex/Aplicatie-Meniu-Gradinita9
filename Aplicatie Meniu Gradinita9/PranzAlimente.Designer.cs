namespace Aplicatie_Meniu_Gradinita9
{
    partial class PranzAlimente
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
            panel1 = new Panel();
            dataToday_lbl = new Label();
            label1 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            dataPranzAlimente = new DataGridView();
            panel3 = new Panel();
            cantitate_clearBtn = new Button();
            cantitate_actualizareBtn = new Button();
            label7 = new Label();
            label2 = new Label();
            tCantitate_lbl = new Label();
            cantitate_txt = new TextBox();
            numeProdus_lbl = new Label();
            numePranzFel2_txt = new TextBox();
            numePranzFel1_txt = new TextBox();
            numeProdus_txt = new TextBox();
            tipFel_lbl = new Label();
            tipFel_txt = new ComboBox();
            meniuPranzFel1_comboBox = new ComboBox();
            meniuPranzFel2_comboBox = new ComboBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataPranzAlimente).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dataToday_lbl);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(19, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(843, 72);
            panel1.TabIndex = 0;
            // 
            // dataToday_lbl
            // 
            dataToday_lbl.AutoSize = true;
            dataToday_lbl.BackColor = Color.White;
            dataToday_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataToday_lbl.ForeColor = Color.Black;
            dataToday_lbl.Location = new Point(452, 24);
            dataToday_lbl.Name = "dataToday_lbl";
            dataToday_lbl.Size = new Size(19, 20);
            dataToday_lbl.TabIndex = 4;
            dataToday_lbl.Text = "?";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(264, 36);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(149, 19);
            label1.TabIndex = 5;
            label1.Text = "PRÂNZ ora 12:00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(247, 10);
            label3.Name = "label3";
            label3.Size = new Size(176, 19);
            label3.TabIndex = 5;
            label3.Text = "NECESAR ALIMENTE";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dataPranzAlimente);
            panel2.Location = new Point(19, 79);
            panel2.Name = "panel2";
            panel2.Size = new Size(843, 197);
            panel2.TabIndex = 0;
            // 
            // dataPranzAlimente
            // 
            dataPranzAlimente.AllowUserToAddRows = false;
            dataPranzAlimente.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataPranzAlimente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataPranzAlimente.BackgroundColor = Color.FromArgb(184, 163, 232);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(33, 11, 97);
            dataGridViewCellStyle2.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataPranzAlimente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataPranzAlimente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Yellow;
            dataGridViewCellStyle3.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataPranzAlimente.DefaultCellStyle = dataGridViewCellStyle3;
            dataPranzAlimente.EnableHeadersVisualStyles = false;
            dataPranzAlimente.Location = new Point(32, 10);
            dataPranzAlimente.Name = "dataPranzAlimente";
            dataPranzAlimente.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = Color.Yellow;
            dataGridViewCellStyle4.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataPranzAlimente.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataPranzAlimente.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.Blue;
            dataGridViewCellStyle5.SelectionForeColor = Color.LightGray;
            dataPranzAlimente.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataPranzAlimente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataPranzAlimente.Size = new Size(778, 177);
            dataPranzAlimente.TabIndex = 2;
            dataPranzAlimente.CellClick += dataPranzAlimente_CellClick;
            dataPranzAlimente.CellEnter += dataPranzAlimente_CellClick;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(cantitate_clearBtn);
            panel3.Controls.Add(cantitate_actualizareBtn);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(tCantitate_lbl);
            panel3.Controls.Add(cantitate_txt);
            panel3.Controls.Add(numeProdus_lbl);
            panel3.Controls.Add(numePranzFel2_txt);
            panel3.Controls.Add(numePranzFel1_txt);
            panel3.Controls.Add(numeProdus_txt);
            panel3.Controls.Add(tipFel_lbl);
            panel3.Controls.Add(tipFel_txt);
            panel3.Controls.Add(meniuPranzFel1_comboBox);
            panel3.Controls.Add(meniuPranzFel2_comboBox);
            panel3.Location = new Point(19, 280);
            panel3.Name = "panel3";
            panel3.Size = new Size(843, 300);
            panel3.TabIndex = 0;
            // 
            // cantitate_clearBtn
            // 
            cantitate_clearBtn.BackColor = Color.FromArgb(33, 11, 97);
            cantitate_clearBtn.Cursor = Cursors.Hand;
            cantitate_clearBtn.FlatAppearance.BorderSize = 0;
            cantitate_clearBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            cantitate_clearBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            cantitate_clearBtn.FlatStyle = FlatStyle.Flat;
            cantitate_clearBtn.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cantitate_clearBtn.ForeColor = Color.White;
            cantitate_clearBtn.Location = new Point(142, 112);
            cantitate_clearBtn.Name = "cantitate_clearBtn";
            cantitate_clearBtn.Size = new Size(75, 30);
            cantitate_clearBtn.TabIndex = 7;
            cantitate_clearBtn.Text = "Clear";
            cantitate_clearBtn.UseVisualStyleBackColor = false;
            cantitate_clearBtn.Click += cantitate_clearBtn_Click;
            // 
            // cantitate_actualizareBtn
            // 
            cantitate_actualizareBtn.BackColor = Color.FromArgb(33, 11, 97);
            cantitate_actualizareBtn.Cursor = Cursors.Hand;
            cantitate_actualizareBtn.FlatAppearance.BorderSize = 0;
            cantitate_actualizareBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            cantitate_actualizareBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            cantitate_actualizareBtn.FlatStyle = FlatStyle.Flat;
            cantitate_actualizareBtn.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cantitate_actualizareBtn.ForeColor = Color.White;
            cantitate_actualizareBtn.Location = new Point(40, 112);
            cantitate_actualizareBtn.Name = "cantitate_actualizareBtn";
            cantitate_actualizareBtn.Size = new Size(75, 30);
            cantitate_actualizareBtn.TabIndex = 9;
            cantitate_actualizareBtn.Text = "Actualizare";
            cantitate_actualizareBtn.UseVisualStyleBackColor = false;
            cantitate_actualizareBtn.Click += cantitate_actualizareBtn_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(237, 65);
            label7.Name = "label7";
            label7.Size = new Size(54, 20);
            label7.TabIndex = 5;
            label7.Text = "grame";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(44, 203);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 5;
            label2.Text = "Alege meniu";
            // 
            // tCantitate_lbl
            // 
            tCantitate_lbl.AutoSize = true;
            tCantitate_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tCantitate_lbl.ForeColor = Color.Black;
            tCantitate_lbl.Location = new Point(28, 63);
            tCantitate_lbl.Name = "tCantitate_lbl";
            tCantitate_lbl.Size = new Size(87, 20);
            tCantitate_lbl.TabIndex = 5;
            tCantitate_lbl.Text = "Cantitatea:";
            // 
            // cantitate_txt
            // 
            cantitate_txt.ForeColor = Color.Black;
            cantitate_txt.ImeMode = ImeMode.NoControl;
            cantitate_txt.Location = new Point(142, 65);
            cantitate_txt.Name = "cantitate_txt";
            cantitate_txt.RightToLeft = RightToLeft.No;
            cantitate_txt.Size = new Size(78, 23);
            cantitate_txt.TabIndex = 6;
            // 
            // numeProdus_lbl
            // 
            numeProdus_lbl.AutoSize = true;
            numeProdus_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numeProdus_lbl.ForeColor = Color.Black;
            numeProdus_lbl.Location = new Point(28, 29);
            numeProdus_lbl.Name = "numeProdus_lbl";
            numeProdus_lbl.Size = new Size(108, 20);
            numeProdus_lbl.TabIndex = 5;
            numeProdus_lbl.Text = "Nume produs:";
            // 
            // numePranzFel2_txt
            // 
            numePranzFel2_txt.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numePranzFel2_txt.ForeColor = Color.Black;
            numePranzFel2_txt.ImeMode = ImeMode.NoControl;
            numePranzFel2_txt.Location = new Point(468, 232);
            numePranzFel2_txt.Name = "numePranzFel2_txt";
            numePranzFel2_txt.RightToLeft = RightToLeft.No;
            numePranzFel2_txt.Size = new Size(365, 22);
            numePranzFel2_txt.TabIndex = 6;
            // 
            // numePranzFel1_txt
            // 
            numePranzFel1_txt.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numePranzFel1_txt.ForeColor = Color.Black;
            numePranzFel1_txt.ImeMode = ImeMode.NoControl;
            numePranzFel1_txt.Location = new Point(144, 232);
            numePranzFel1_txt.Name = "numePranzFel1_txt";
            numePranzFel1_txt.RightToLeft = RightToLeft.No;
            numePranzFel1_txt.Size = new Size(304, 22);
            numePranzFel1_txt.TabIndex = 6;
            // 
            // numeProdus_txt
            // 
            numeProdus_txt.ForeColor = Color.Black;
            numeProdus_txt.ImeMode = ImeMode.NoControl;
            numeProdus_txt.Location = new Point(142, 31);
            numeProdus_txt.Name = "numeProdus_txt";
            numeProdus_txt.RightToLeft = RightToLeft.No;
            numeProdus_txt.Size = new Size(195, 23);
            numeProdus_txt.TabIndex = 6;
            // 
            // tipFel_lbl
            // 
            tipFel_lbl.AutoSize = true;
            tipFel_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tipFel_lbl.ForeColor = Color.Black;
            tipFel_lbl.Location = new Point(352, 34);
            tipFel_lbl.Name = "tipFel_lbl";
            tipFel_lbl.Size = new Size(110, 20);
            tipFel_lbl.TabIndex = 5;
            tipFel_lbl.Text = "Felul mâncării:";
            // 
            // tipFel_txt
            // 
            tipFel_txt.FormattingEnabled = true;
            tipFel_txt.Items.AddRange(new object[] { "Felul 1", "Felul 2", "Ambele" });
            tipFel_txt.Location = new Point(468, 34);
            tipFel_txt.Name = "tipFel_txt";
            tipFel_txt.Size = new Size(121, 23);
            tipFel_txt.TabIndex = 11;
            // 
            // meniuPranzFel1_comboBox
            // 
            meniuPranzFel1_comboBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            meniuPranzFel1_comboBox.FormattingEnabled = true;
            meniuPranzFel1_comboBox.Location = new Point(144, 203);
            meniuPranzFel1_comboBox.Name = "meniuPranzFel1_comboBox";
            meniuPranzFel1_comboBox.Size = new Size(304, 21);
            meniuPranzFel1_comboBox.TabIndex = 12;
            // 
            // meniuPranzFel2_comboBox
            // 
            meniuPranzFel2_comboBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            meniuPranzFel2_comboBox.FormattingEnabled = true;
            meniuPranzFel2_comboBox.Location = new Point(468, 203);
            meniuPranzFel2_comboBox.Name = "meniuPranzFel2_comboBox";
            meniuPranzFel2_comboBox.Size = new Size(365, 21);
            meniuPranzFel2_comboBox.TabIndex = 13;
            // 
            // PranzAlimente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Name = "PranzAlimente";
            Size = new Size(875, 583);
            Load += PranzAlimente_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataPranzAlimente).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label dataToday_lbl;
        private Label label1;
        private Label label3;
        private Panel panel2;
        private Panel panel3;
        private Button cantitate_clearBtn;
        private Button cantitate_actualizareBtn;
        private Label label7;
        private Label tCantitate_lbl;
        private TextBox cantitate_txt;
        private Label numeProdus_lbl;
        private TextBox numeProdus_txt;
        private Label tipFel_lbl;
        private ComboBox tipFel_txt;
        public DataGridView dataPranzAlimente;
        private ComboBox meniuPranzFel1_comboBox;
        private ComboBox meniuPranzFel2_comboBox;
        private Label label2;
        private TextBox numePranzFel2_txt;
        private TextBox numePranzFel1_txt;
    }
}
