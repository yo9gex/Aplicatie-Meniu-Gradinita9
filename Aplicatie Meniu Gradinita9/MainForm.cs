using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Aplicatie_Meniu_Gradinita9
{

    public partial class MainForm : Form
    {
     

        public string Date;
        static MainForm _obj;
        public static MainForm Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new MainForm();
                }
                return _obj;
            }
        }
        public Panel PnlContainer
        {
            get { return panelContainer; }
            set { panelContainer = value; }
        }
        public Button BtnListaProduse
        {
            get { return listaproduse_btn; }
            set { listaproduse_btn = value; }
        }
        public Button BtnNecesarAlimente
        {
            get { return necesaralimente_btn; }
            set { necesaralimente_btn = value; }
        }
        public Button BtnMicDejunAlimente
        {
            get { return micDejun_btn; }
            set { micDejun_btn = value; }
        }
        public Button BtnPranzAlimente
        {
            get { return pranz_btn; }
            set { pranz_btn = value; }
        }
        public Button BtnGustareAlimente
        {
            get { return gustare_btn; }
            set { gustare_btn = value; }
        }
        public Button BtnMeniulZilei
        {
            get { return meniulZilei_btn; }
            set { meniulZilei_btn = value; }
        }
        public Button BtnAnchetaAlimentara
        {
            get { return anchetaAlimentara_btn; }
            set { anchetaAlimentara_btn = value; }
        }
        public Button BtnTotalNutrienti
        {
            get { return totalNutrienti_btn; }
            set { totalNutrienti_btn = value; }
        }
        public Button BtnGraficeNutrienti
        {
            get { return graficeNutrienti_btn; }
            set { graficeNutrienti_btn = value; }
        }

        public Button BtnEchivalente
        {
            get { return echivalente_btn; }
            set { echivalente_btn = value; }
        }

        public MainForm()
        {
            InitializeComponent();
            RefreshData();
            Date = DateTime.Now.ToString("dd-MM-yyyy");
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;

            }
        }
        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esti sigur ca vrei sa te deloghezi?", "Delogare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide();
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            dataToday_lbl.Text = Date;
            listaproduse_btn.Visible = true;
            _obj = this;

            ListaProduse lp = new ListaProduse();
            lp.RefreshData();
            lp.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(lp);

            NecesarAlimente na = new NecesarAlimente();
            na.RefreshData();
            na.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(na);

            MicDejunAlimente mda = new MicDejunAlimente();
            mda.RefreshData();
            mda.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(mda);


            PranzAlimente pa = new PranzAlimente();
            pa.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(pa);

            GustareAlimente ga = new GustareAlimente();
            ga.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ga);


            MeniulZilei mz = new MeniulZilei();
            mz.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(mz);

            mda.MeniulZileiInstance = mz;
            pa.MeniulZileiInstance = mz;
            ga.MeniulZileiInstance = mz;

            TotalNutrienti tn = new TotalNutrienti();
            tn.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(tn);

            AnchetaAlimentara aa = new AnchetaAlimentara();
            aa.Dock = DockStyle.Fill;
            aa.MeniulZileiInstance = mz;
            panelContainer.Controls.Add(aa);

            GraficeNutrienti gn = new GraficeNutrienti();
            gn.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(gn);

            Echivalente ec = new Echivalente();
            ec.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ec);

            RefreshData();
        }
        private void listaproduse_btn_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["ListaProduse"].BringToFront();
            BtnListaProduse.Visible = true;
            BtnAnchetaAlimentara.Visible = true;

            ListaProduse lp = panelContainer.Controls["ListaProduse"] as ListaProduse;
            if (lp != null)
            {
                lp.RefreshData();
            }

        }
        private void necesaralimente_btn_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["NecesarAlimente"].BringToFront();
            BtnNecesarAlimente.Visible = true;
            BtnListaProduse.Visible = true;
            BtnAnchetaAlimentara.Visible = true;

            NecesarAlimente na = panelContainer.Controls["NecesarAlimente"] as NecesarAlimente;
            if (na != null)
            {
                na.RefreshData();
            }
        }
        private void meniulZilei_btn_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["MeniulZilei"].BringToFront();
            BtnMeniulZilei.Visible = true;
            BtnAnchetaAlimentara.Visible = true;

            MeniulZilei mz = panelContainer.Controls["MeniulZilei"] as MeniulZilei;
            if (mz != null)
            {
                mz.RefreshData();
            }
        }
        private void micDejun_btn_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["MicDejunAlimente"].BringToFront();
            BtnMicDejunAlimente.Visible = true;
            BtnAnchetaAlimentara.Visible = true;

            MicDejunAlimente mda = panelContainer.Controls["MicDejunAlimente"] as MicDejunAlimente;
            if (mda != null && mda.dataMicDejunAlimente != null)
            {
                mda.RefreshData();
            }
        }
        private void pranz_btn_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["PranzAlimente"].BringToFront();
            BtnPranzAlimente.Visible = true;
            BtnAnchetaAlimentara.Visible = true;

            PranzAlimente pa = panelContainer.Controls["PranzAlimente"] as PranzAlimente;
            if (pa != null && pa.dataPranzAlimente != null)
            {
                pa.RefreshData();
            }
        }
        private void gustare_btn_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["GustareAlimente"].BringToFront();
            BtnGustareAlimente.Visible = true;
            BtnAnchetaAlimentara.Visible = true;

            GustareAlimente ga = panelContainer.Controls["GustareAlimente"] as GustareAlimente;
            if (ga != null && ga.dataGustareAlimente != null)
            {
                ga.RefreshData();
            }
        }

        private void anchetaAlimentara_btn_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["AnchetaAlimentara"].BringToFront();
            BtnAnchetaAlimentara.Visible = true;

            AnchetaAlimentara aa = panelContainer.Controls["AnchetaAlimentara"] as AnchetaAlimentara;
            if (aa != null)
            {
                aa.RefreshData();
            }
        }

        private void totalNutrienti_btn_Click(object sender, EventArgs e)

        {
            panelContainer.Controls["TotalNutrienti"].BringToFront();

            TotalNutrienti tn = panelContainer.Controls["TotalNutrienti"] as TotalNutrienti;
            if (tn != null)
            {
                tn.RefreshData();
            }
        }

        private void graficeNutrienti_btn_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["GraficeNutrienti"].BringToFront();
            BtnGraficeNutrienti.Visible = true;

            GraficeNutrienti gn = panelContainer.Controls["GraficeNutrienti"] as GraficeNutrienti;
            if (gn != null)
            {
                gn.RefreshData();
            }
        }

        private void licenta_btn_Click(object sender, EventArgs e)
        {

        }

        private void echivalente_btn_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["Echivalente"].BringToFront();
            BtnEchivalente.Visible = true;

            Echivalente ec = panelContainer.Controls["Echivalente"] as Echivalente;
            if (ec != null)
            {
                ec.RefreshData();
            }
        }

       
    }
}
