namespace Aplicatie_Meniu_Gradinita9
{
    partial class GustareAlimente
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
            dataGustareAlimente = new DataGridView();
            panel3 = new Panel();
            cantitate_clearBtn = new Button();
            cantitate_actualizare_Btn = new Button();
            label7 = new Label();
            tCantitate_lbl = new Label();
            cantitate_txt = new TextBox();
            label2 = new Label();
            numeProdus_lbl = new Label();
            numeGustare_txt = new TextBox();
            numeProdus_txt = new TextBox();
            meniuGustare_comboBox = new ComboBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGustareAlimente).BeginInit();
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
            dataToday_lbl.Location = new Point(451, 21);
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
            label1.Location = new Point(252, 36);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(171, 19);
            label1.TabIndex = 5;
            label1.Text = "GUSTARE ora 15:00";
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
            panel2.Controls.Add(dataGustareAlimente);
            panel2.Location = new Point(19, 79);
            panel2.Name = "panel2";
            panel2.Size = new Size(843, 237);
            panel2.TabIndex = 0;
            // 
            // dataGustareAlimente
            // 
            dataGustareAlimente.AllowUserToAddRows = false;
            dataGustareAlimente.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGustareAlimente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGustareAlimente.BackgroundColor = Color.FromArgb(184, 163, 232);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(33, 11, 97);
            dataGridViewCellStyle2.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGustareAlimente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGustareAlimente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Yellow;
            dataGridViewCellStyle3.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGustareAlimente.DefaultCellStyle = dataGridViewCellStyle3;
            dataGustareAlimente.EnableHeadersVisualStyles = false;
            dataGustareAlimente.Location = new Point(32, 14);
            dataGustareAlimente.Name = "dataGustareAlimente";
            dataGustareAlimente.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = Color.Yellow;
            dataGridViewCellStyle4.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGustareAlimente.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGustareAlimente.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.Blue;
            dataGridViewCellStyle5.SelectionForeColor = Color.LightGray;
            dataGustareAlimente.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGustareAlimente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGustareAlimente.Size = new Size(778, 209);
            dataGustareAlimente.TabIndex = 2;
            dataGustareAlimente.CellClick += dataGustareAlimente_CellClick;
            dataGustareAlimente.CellEnter += dataGustareAlimente_CellClick;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(cantitate_clearBtn);
            panel3.Controls.Add(cantitate_actualizare_Btn);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(tCantitate_lbl);
            panel3.Controls.Add(cantitate_txt);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(numeProdus_lbl);
            panel3.Controls.Add(numeGustare_txt);
            panel3.Controls.Add(numeProdus_txt);
            panel3.Controls.Add(meniuGustare_comboBox);
            panel3.Location = new Point(19, 320);
            panel3.Name = "panel3";
            panel3.Size = new Size(843, 260);
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
            // cantitate_actualizare_Btn
            // 
            cantitate_actualizare_Btn.BackColor = Color.FromArgb(33, 11, 97);
            cantitate_actualizare_Btn.Cursor = Cursors.Hand;
            cantitate_actualizare_Btn.FlatAppearance.BorderSize = 0;
            cantitate_actualizare_Btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            cantitate_actualizare_Btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            cantitate_actualizare_Btn.FlatStyle = FlatStyle.Flat;
            cantitate_actualizare_Btn.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cantitate_actualizare_Btn.ForeColor = Color.White;
            cantitate_actualizare_Btn.Location = new Point(40, 112);
            cantitate_actualizare_Btn.Name = "cantitate_actualizare_Btn";
            cantitate_actualizare_Btn.Size = new Size(75, 30);
            cantitate_actualizare_Btn.TabIndex = 9;
            cantitate_actualizare_Btn.Text = "Actualizare";
            cantitate_actualizare_Btn.UseVisualStyleBackColor = false;
            cantitate_actualizare_Btn.Click += cantitate_actualizare_Btn_Click;
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
            cantitate_txt.AcceptsReturn = true;
            cantitate_txt.ForeColor = Color.Black;
            cantitate_txt.ImeMode = ImeMode.NoControl;
            cantitate_txt.Location = new Point(142, 65);
            cantitate_txt.Name = "cantitate_txt";
            cantitate_txt.RightToLeft = RightToLeft.No;
            cantitate_txt.Size = new Size(78, 23);
            cantitate_txt.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(402, 34);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 5;
            label2.Text = "Alege meniu";
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
            // numeGustare_txt
            // 
            numeGustare_txt.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numeGustare_txt.ForeColor = Color.Black;
            numeGustare_txt.ImeMode = ImeMode.NoControl;
            numeGustare_txt.Location = new Point(505, 77);
            numeGustare_txt.Name = "numeGustare_txt";
            numeGustare_txt.RightToLeft = RightToLeft.No;
            numeGustare_txt.Size = new Size(294, 22);
            numeGustare_txt.TabIndex = 6;
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
            // meniuGustare_comboBox
            // 
            meniuGustare_comboBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            meniuGustare_comboBox.FormattingEnabled = true;
            meniuGustare_comboBox.Location = new Point(505, 31);
            meniuGustare_comboBox.Name = "meniuGustare_comboBox";
            meniuGustare_comboBox.Size = new Size(294, 21);
            meniuGustare_comboBox.TabIndex = 10;
            // 
            // GustareAlimente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Name = "GustareAlimente";
            Size = new Size(875, 583);
            Load += GustareAlimente_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGustareAlimente).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label dataToday_lbl;
        private Label label1;
        private Label label3;
       // private Button savePdf_btn;
        private Panel panel2;
        private Panel panel3;
        private Button cantitate_clearBtn;
        private Button cantitate_actualizare_Btn;
        private Label label7;
        private Label tCantitate_lbl;
        private TextBox cantitate_txt;
        private Label numeProdus_lbl;
        private TextBox numeProdus_txt;
        public DataGridView dataGustareAlimente;
        private ComboBox meniuGustare_comboBox;
        private Label label2;
        private TextBox numeGustare_txt;
    }
}
