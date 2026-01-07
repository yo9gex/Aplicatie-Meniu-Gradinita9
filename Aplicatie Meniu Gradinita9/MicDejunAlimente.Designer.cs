namespace Aplicatie_Meniu_Gradinita9
{
    partial class MicDejunAlimente
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
            panel2 = new Panel();
            dataMicDejunAlimente = new DataGridView();
            panel3 = new Panel();
            cantitate_clearBtn = new Button();
            cantitate_actualizare_Btn = new Button();
            label7 = new Label();
            tCantitate_lbl = new Label();
            cantitate_txt = new TextBox();
            label2 = new Label();
            numeProdus_lbl = new Label();
            numeMeniu_txt = new TextBox();
            numeProdus_txt = new TextBox();
            meniuMicDejun_comboBox = new ComboBox();
            label3 = new Label();
            label1 = new Label();
            dataToday_lbl = new Label();
            panel1 = new Panel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataMicDejunAlimente).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dataMicDejunAlimente);
            panel2.Location = new Point(19, 79);
            panel2.Name = "panel2";
            panel2.Size = new Size(843, 237);
            panel2.TabIndex = 0;
            // 
            // dataMicDejunAlimente
            // 
            dataMicDejunAlimente.AllowUserToAddRows = false;
            dataMicDejunAlimente.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataMicDejunAlimente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataMicDejunAlimente.BackgroundColor = Color.FromArgb(184, 163, 232);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(33, 11, 97);
            dataGridViewCellStyle2.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataMicDejunAlimente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataMicDejunAlimente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Yellow;
            dataGridViewCellStyle3.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataMicDejunAlimente.DefaultCellStyle = dataGridViewCellStyle3;
            dataMicDejunAlimente.EnableHeadersVisualStyles = false;
            dataMicDejunAlimente.Location = new Point(32, 14);
            dataMicDejunAlimente.Name = "dataMicDejunAlimente";
            dataMicDejunAlimente.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = Color.Yellow;
            dataGridViewCellStyle4.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataMicDejunAlimente.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataMicDejunAlimente.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.Blue;
            dataGridViewCellStyle5.SelectionForeColor = Color.LightGray;
            dataMicDejunAlimente.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataMicDejunAlimente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataMicDejunAlimente.Size = new Size(778, 209);
            dataMicDejunAlimente.TabIndex = 2;
            dataMicDejunAlimente.CellClick += dataMicDejunAlimente_CellClick;
            dataMicDejunAlimente.CellEnter += dataMicDejunAlimente_CellClick;
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
            panel3.Controls.Add(numeMeniu_txt);
            panel3.Controls.Add(numeProdus_txt);
            panel3.Controls.Add(meniuMicDejun_comboBox);
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
            label2.Location = new Point(410, 26);
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
            // numeMeniu_txt
            // 
            numeMeniu_txt.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numeMeniu_txt.ForeColor = Color.Black;
            numeMeniu_txt.ImeMode = ImeMode.NoControl;
            numeMeniu_txt.Location = new Point(513, 66);
            numeMeniu_txt.Name = "numeMeniu_txt";
            numeMeniu_txt.RightToLeft = RightToLeft.No;
            numeMeniu_txt.Size = new Size(327, 22);
            numeMeniu_txt.TabIndex = 6;
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
            // meniuMicDejun_comboBox
            // 
            meniuMicDejun_comboBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            meniuMicDejun_comboBox.FormattingEnabled = true;
            meniuMicDejun_comboBox.Location = new Point(513, 26);
            meniuMicDejun_comboBox.Name = "meniuMicDejun_comboBox";
            meniuMicDejun_comboBox.Size = new Size(327, 21);
            meniuMicDejun_comboBox.TabIndex = 10;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(247, 35);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(173, 19);
            label1.TabIndex = 5;
            label1.Text = "MIC DEJUN ora 8:30";
            // 
            // dataToday_lbl
            // 
            dataToday_lbl.AutoSize = true;
            dataToday_lbl.BackColor = Color.White;
            dataToday_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataToday_lbl.ForeColor = Color.Black;
            dataToday_lbl.Location = new Point(488, 24);
            dataToday_lbl.Name = "dataToday_lbl";
            dataToday_lbl.Size = new Size(19, 20);
            dataToday_lbl.TabIndex = 4;
            dataToday_lbl.Text = "?";
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
            // MicDejunAlimente
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Name = "MicDejunAlimente";
            Size = new Size(875, 583);
            Load += MicDejunAlimente_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataMicDejunAlimente).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Panel panel3;
        private Button cantitate_clearBtn;
        private Button cantitate_actualizare_Btn;
        private Label label7;
        private Label tCantitate_lbl;
        private TextBox cantitate_txt;
        private Label numeProdus_lbl;
        private TextBox numeProdus_txt;
        private Label label3;
        private Label label1;
        private Label dataToday_lbl;
        private Panel panel1;
        public DataGridView dataMicDejunAlimente;
        private ComboBox meniuMicDejun_comboBox;
        private Label label2;
        private TextBox numeMeniu_txt;
    }
}
