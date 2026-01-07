using System.Data;
using Microsoft.Data.SqlClient;

namespace Aplicatie_Meniu_Gradinita9
{
    public partial class ListaProduse : UserControl
    {
        //SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30");
        //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
        string dbPath;
        string connectionString;
        SqlConnection connection;
        public ListaProduse()
        {
            InitializeComponent();
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            connection = new SqlConnection(connectionString);
            displayPDC();
            displayUlei();
            displayOUA();
            displayProduseZaharoase();
            displayLegumeConservate();
            dispalyCarneProduseCarne();
            displayLaptePreparateLapte();
            displaySucuriCompoturi();
            displayFructe();
            displayLegumeProaspete();
            displayCereale();
            displayFructeOleaginoase();
        }
        public void displayPDC()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(id) FROM produseDerivateCereale";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            pdc_lbl.Text = count.ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void displayOUA()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(id) FROM oua";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            pOua_lbl.Text = count.ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void displayUlei()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(id) FROM ulei";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            ulei_lbl.Text = count.ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void displayLegumeConservate()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(id) FROM legumeConservate";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            legumeConservate_lbl.Text = count.ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void displayProduseZaharoase()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(id) FROM produseZaharoase";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            zaharoase_lbl.Text = count.ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void dispalyCarneProduseCarne()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(id) FROM carneProduseCarne";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            carnepc_lbl.Text = count.ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void displayLaptePreparateLapte()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(id) FROM laptePreparateLapte";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            laptepl_lbl.Text = count.ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void displaySucuriCompoturi()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(id) FROM sucuriCompoturi";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            sucuri_lbl.Text = count.ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void displayFructe()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(id) FROM fructe";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            fructe_lbl.Text = count.ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void displayLegumeProaspete()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(id) FROM legumeProaspete";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            lp_lbl.Text = count.ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }
        public void displayCereale()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(id) FROM cereale";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            cereale_lbl.Text = count.ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }


        }
        public void displayFructeOleaginoase()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(id) FROM fructeOleaginoase";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            fo_lbl.Text = count.ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            displayPDC();
            displayOUA();
            displayUlei();
            displayProduseZaharoase();
            displayLegumeConservate();
            dispalyCarneProduseCarne();
            displayLaptePreparateLapte();
            displaySucuriCompoturi();
            displayFructe();
            displayLegumeProaspete();
            displayFructeOleaginoase();
            displayCereale();
        }
        private void produseCereale_btn_Click(object sender, EventArgs e)
        {
            //adauga user control-ul in panelul din main form

            if (!MainForm.Instance.PnlContainer.Controls.ContainsKey("ProduseDerivateCereale"))
            {
                ProduseDerivateCereale produseDerivateCereale = new ProduseDerivateCereale();
                produseDerivateCereale.Dock = DockStyle.Fill;
                MainForm.Instance.PnlContainer.Controls.Add(produseDerivateCereale);
            }
            MainForm.Instance.PnlContainer.Controls["ProduseDerivateCereale"].BringToFront();
            MainForm.Instance.BtnListaProduse.Visible = true;
            ProduseDerivateCereale pdcc = MainForm.Instance.PnlContainer.Controls["ProduseDerivateCereale"] as ProduseDerivateCereale;
            if (pdcc != null && pdcc.dataProduseDerivateCereale != null)
            {
                pdcc.RefreshData();
            }
            displayPDC();
        }
        private void zaharoase_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.Instance.PnlContainer.Controls.ContainsKey("ProduseZaharoase"))
            {
                ProduseZaharoase produseZaharoase = new ProduseZaharoase();
                produseZaharoase.Dock = DockStyle.Fill;
                MainForm.Instance.PnlContainer.Controls.Add(produseZaharoase);
            }
            MainForm.Instance.PnlContainer.Controls["ProduseZaharoase"].BringToFront();
            MainForm.Instance.BtnListaProduse.Visible = true;
            ProduseZaharoase pzz = MainForm.Instance.PnlContainer.Controls["ProduseZaharoase"] as ProduseZaharoase;
            if (pzz != null && pzz.dataProduseZaharoase != null)
            {
                pzz.RefreshData();
            }
            displayProduseZaharoase();
        }
        private void carne_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.Instance.PnlContainer.Controls.ContainsKey("CarneProduseCarne"))
            {
                CarneProduseCarne carneProduseCarne = new CarneProduseCarne();
                carneProduseCarne.Dock = DockStyle.Fill;
                MainForm.Instance.PnlContainer.Controls.Add(carneProduseCarne);
            }
            MainForm.Instance.PnlContainer.Controls["CarneProduseCarne"].BringToFront();
            MainForm.Instance.BtnListaProduse.Visible = true;
            CarneProduseCarne cpc = MainForm.Instance.PnlContainer.Controls["CarneProduseCarne"] as CarneProduseCarne;
            if (cpc != null && cpc.dataCarneProduseCarne != null)
            {
                cpc.RefreshData();
            }
            dispalyCarneProduseCarne();
        }
        private void lapte_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.Instance.PnlContainer.Controls.ContainsKey("LaptePreparateLapte"))
            {
                LaptePreparateLapte laptePreparateLapte = new LaptePreparateLapte();
                laptePreparateLapte.Dock = DockStyle.Fill;
                MainForm.Instance.PnlContainer.Controls.Add(laptePreparateLapte);
            }
            MainForm.Instance.PnlContainer.Controls["LaptePreparateLapte"].BringToFront();
            MainForm.Instance.BtnListaProduse.Visible = true;
            LaptePreparateLapte lpl = MainForm.Instance.PnlContainer.Controls["LaptePreparateLapte"] as LaptePreparateLapte;
            if (lpl != null && lpl.dataLapte != null)
            {
                lpl.RefreshData();
            }
            displayLaptePreparateLapte();

        }
        private void sucuri_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.Instance.PnlContainer.Controls.ContainsKey("SucuriCompoturi"))
            {
                SucuriCompoturi sucuriCompoturi = new SucuriCompoturi();
                sucuriCompoturi.Dock = DockStyle.Fill;
                MainForm.Instance.PnlContainer.Controls.Add(sucuriCompoturi);
            }
            MainForm.Instance.PnlContainer.Controls["SucuriCompoturi"].BringToFront();
            MainForm.Instance.BtnListaProduse.Visible = true;
            SucuriCompoturi scc = MainForm.Instance.PnlContainer.Controls["SucuriCompoturi"] as SucuriCompoturi;
            if (scc != null && scc.dataSucuriCompoturi != null)
            {
                scc.RefreshData();
            }
            displaySucuriCompoturi();
        }
        private void fructe_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.Instance.PnlContainer.Controls.ContainsKey("Fructe"))
            {
                Fructe fructe = new Fructe();
                fructe.Dock = DockStyle.Fill;
                MainForm.Instance.PnlContainer.Controls.Add(fructe);
            }
            MainForm.Instance.PnlContainer.Controls["Fructe"].BringToFront();
            MainForm.Instance.BtnListaProduse.Visible = true;
            Fructe fcc = MainForm.Instance.PnlContainer.Controls["Fructe"] as Fructe;
            if (fcc != null && fcc.dataFructe != null)
            {
                fcc.RefreshData();
            }
            displayFructe();
        }
        private void ulei_btn_Click(object sender, EventArgs e)
        {
            //adauga user control-ul in panelul din main form

            if (!MainForm.Instance.PnlContainer.Controls.ContainsKey("Ulei"))
            {
                Ulei ulei = new Ulei();
                ulei.Dock = DockStyle.Fill;
                MainForm.Instance.PnlContainer.Controls.Add(ulei);
            }
            MainForm.Instance.PnlContainer.Controls["Ulei"].BringToFront();
            MainForm.Instance.BtnListaProduse.Visible = true;
            Ulei ulei1 = MainForm.Instance.PnlContainer.Controls["Ulei"] as Ulei;
            if (ulei1 != null && ulei1.dataUlei != null)
            {
                ulei1.RefreshData();
            }
            displayUlei();
        }
        private void legumeConservate_btn_Click(object sender, EventArgs e)
        {
            //adauga user control-ul in panelul din main form
            if (!MainForm.Instance.PnlContainer.Controls.ContainsKey("LegumeConservate"))
            {
                LegumeConservate legumeConservate = new LegumeConservate();
                legumeConservate.Dock = DockStyle.Fill;
                MainForm.Instance.PnlContainer.Controls.Add(legumeConservate);
            }
            MainForm.Instance.PnlContainer.Controls["LegumeConservate"].BringToFront();
            MainForm.Instance.BtnListaProduse.Visible = true;
            LegumeConservate lc = MainForm.Instance.PnlContainer.Controls["LegumeConservate"] as LegumeConservate;
            if (lc != null && lc.dataLegumeConservate != null)
            {
                lc.RefreshData();
            }
            displayLegumeConservate();
        }
        private void legumeProaspete_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.Instance.PnlContainer.Controls.ContainsKey("LegumeProaspete"))
            {
                LegumeProaspete legumeProaspete = new LegumeProaspete();
                legumeProaspete.Dock = DockStyle.Fill;
                MainForm.Instance.PnlContainer.Controls.Add(legumeProaspete);
            }
            MainForm.Instance.PnlContainer.Controls["LegumeProaspete"].BringToFront();
            MainForm.Instance.BtnListaProduse.Visible = true;
            LegumeProaspete lp = MainForm.Instance.PnlContainer.Controls["LegumeProaspete"] as LegumeProaspete;
            if (lp != null && lp.dataLegumeProaspete != null)
            {
                lp.RefreshData();
            }
            displayLegumeProaspete();
        }
        private void oleaginoase_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.Instance.PnlContainer.Controls.ContainsKey("FructeOleaginoase"))
            {
                FructeOleaginoase fructeOleaginoase = new FructeOleaginoase();
                fructeOleaginoase.Dock = DockStyle.Fill;
                MainForm.Instance.PnlContainer.Controls.Add(fructeOleaginoase);
            }
            MainForm.Instance.PnlContainer.Controls["FructeOleaginoase"].BringToFront();
            MainForm.Instance.BtnListaProduse.Visible = true;
            FructeOleaginoase fo = MainForm.Instance.PnlContainer.Controls["FructeOleaginoase"] as FructeOleaginoase;
            if (fo != null && fo.dataFructeOleaginoase != null)
            {
                fo.RefreshData();
            }
            displayFructeOleaginoase();
        }
        private void cereale_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.Instance.PnlContainer.Controls.ContainsKey("Cereale"))
            {
                Cereale cereale = new Cereale();
                cereale.Dock = DockStyle.Fill;
                MainForm.Instance.PnlContainer.Controls.Add(cereale);
            }
            MainForm.Instance.PnlContainer.Controls["Cereale"].BringToFront();
            MainForm.Instance.BtnListaProduse.Visible = true;
            Cereale cc = MainForm.Instance.PnlContainer.Controls["Cereale"] as Cereale;
            if (cc != null && cc.dataCereale != null)
            {
                cc.RefreshData();
            }
            displayCereale();
        }
        private void oua_btn_Click(object sender, EventArgs e)
        {
            //adauga user control-ul in panelul din main form
            if (!MainForm.Instance.PnlContainer.Controls.ContainsKey("Oua"))
            {
                Oua oua = new Oua();
                oua.Dock = DockStyle.Fill;
                MainForm.Instance.PnlContainer.Controls.Add(oua);
            }
            MainForm.Instance.PnlContainer.Controls["Oua"].BringToFront();
            MainForm.Instance.BtnListaProduse.Visible = true;
            Oua oua1 = MainForm.Instance.PnlContainer.Controls["Oua"] as Oua;
            if (oua1 != null && oua1.dataOua != null)
            {
                oua1.RefreshData();
            }
            displayOUA();
        }
    }
}
