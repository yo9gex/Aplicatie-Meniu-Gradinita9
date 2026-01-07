using System.Data;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;


namespace Aplicatie_Meniu_Gradinita9
{
    public partial class TotalNutrienti : UserControl
    {
        public string Date;
        public string TotalProteine;
        public string TotalLipide;
        public string TotalGlucide;
        public string TotalCalorii;
        public string ProcentProteine;
        public string ProcentLipide;
        public string ProcentGlucide;
        string dbPath;
        string connectionString;
        SqlConnection conn;
        public TotalNutrienti()
        {
            InitializeComponent();
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            conn = new SqlConnection(connectionString);
            Date = DateTime.Now.ToString("dd-MM-yyyy");
            CalculParametriNutrienti();
            DisplayProteine();
            DisplayLipide();
            DisplayGlucide();
            DisplayCalorii();
            DisplayCalciu();
            DisplayFier();
            // Adăugați handler-ul de eveniment
            this.proteineData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.proteineData_RowPostPaint);
            this.lipideData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.proteineData_RowPostPaint);
            this.glucideData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.proteineData_RowPostPaint);
            this.caloriiData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.proteineData_RowPostPaint);
            this.calciuData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.proteineData_RowPostPaint);
            this.fierData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.proteineData_RowPostPaint);

        }
        private void proteineData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Această metodă desenează numărul rândului în antetul rândului

            // Formatați textul (numărul rândului)
            var rowNumber = (e.RowIndex + 1).ToString();
            var size = e.Graphics.MeasureString(rowNumber, this.Font);

            // Calculați poziția pentru a centra textul
            if (proteineData.RowHeadersWidth < size.Width + 20)
            {
                proteineData.RowHeadersWidth = (int)(size.Width + 20);
            }

            var boundingRect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, proteineData.RowHeadersWidth, e.RowBounds.Height);

            // Desenați șirul în antetul rândului
            TextRenderer.DrawText(e.Graphics, rowNumber,
                                  this.Font,
                                  boundingRect,
                                  this.proteineData.RowHeadersDefaultCellStyle.ForeColor,
                                  TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }


        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;

            }
            DisplayProteine();
            DisplayLipide();
            DisplayGlucide();
            DisplayCalorii();
            DisplayCalciu();
            DisplayFier();
            CalculParametriNutrienti();
        }
        private void DisplayProteine()
        {
            ProteineTotaleData aad = new ProteineTotaleData();
            List<ProteineTotaleData> dataList = aad.ListaData();
            proteineData.DataSource = dataList;

        }
        private void DisplayLipide()
        {
            LipideTotaleData pld = new LipideTotaleData();
            List<LipideTotaleData> dataList = pld.ListaData();
            lipideData.DataSource = dataList;
        }
        private void DisplayGlucide()
        {
            GlucideTotaleData gtd = new GlucideTotaleData();
            List<GlucideTotaleData> dataList = gtd.ListaData();
            glucideData.DataSource = dataList;
        }
        private void DisplayCalorii()
        {
            CaloriiTotaleData ctd = new CaloriiTotaleData();
            List<CaloriiTotaleData> dataList = ctd.ListaData();
            caloriiData.DataSource = dataList;
        }
        private void DisplayCalciu()
        {
            CalciuTotalData ctd = new CalciuTotalData();
            List<CalciuTotalData> dataList = ctd.ListaData();
            calciuData.DataSource = dataList;
        }
        private void DisplayFier()
        {
            FierTotalData ftd = new FierTotalData();
            List<FierTotalData> dataList = ftd.ListaData();
            fierData.DataSource = dataList;
        }

        private void TotalNutrienti_Load(object sender, EventArgs e)
        {
            dataToday_lbl.Text = Date;

        }
        public void CalculParametriNutrienti()
        {            
            decimal totalProteine = 0;
            decimal totalLipide = 0;
            decimal totalGlucide = 0;
            decimal totalCalorii = 0;
            decimal procentProteine;
            decimal procentLipide;
            decimal procentGlucide;

            if (conn.State == ConnectionState.Closed)
                try
                {
                    conn.Open();
                    string query = "SELECT total_calorii FROM calorii WHERE data_adaugare is NOT NULL";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (!reader.IsDBNull(0))
                                {
                                    totalCalorii += Convert.ToDecimal(reader["total_calorii"]) / 10;
                                }
                            }
                        }
                    }
                    TotalCalorii = totalCalorii.ToString();
                    totalCalorii_lbl.Text = totalCalorii.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            try
            {
                conn.Open();
                string query = "SELECT total_proteine FROM proteine WHERE data_adaugare is NOT NULL";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                totalProteine += Convert.ToDecimal(reader["total_proteine"]) / 10;

                            }
                        }
                    }
                }
                TotalProteine = totalProteine.ToString();
                totalProteine_lbl.Text = totalProteine.ToString();
                if (totalCalorii != 0)
                {
                    procentProteine = totalProteine * 4.10m / totalCalorii;
                    ProcentProteine = procentProteine.ToString("#.##  %");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();

            }
            try
            {
                conn.Open();

                string query = "SELECT total_lipide FROM lipide WHERE data_adaugare is NOT NULL";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                totalLipide += Convert.ToDecimal(reader["total_lipide"]) / 10;

                            }
                        }
                    }
                }

                TotalLipide = totalLipide.ToString();
                totalLipide_lbl.Text = totalLipide.ToString();
                if (totalCalorii != 0)
                {
                    procentLipide = totalLipide * 9.10m / totalCalorii;
                    ProcentLipide = procentLipide.ToString("#.## %");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();

            }
            try
            {
                conn.Open();

                string query = "SELECT total_glucide FROM glucide WHERE data_adaugare is NOT NULL";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                totalGlucide += Convert.ToDecimal(reader["total_glucide"]) / 10;

                            }
                        }
                    }
                }

                TotalGlucide = totalGlucide.ToString();
                totalGlucide_lbl.Text = totalGlucide.ToString();
                if (totalCalorii != 0)
                {
                    procentGlucide = totalGlucide * 4.10m / totalCalorii;
                    ProcentGlucide = procentGlucide.ToString("#.## %");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();

            }

        }
        private void reset_btn_Click(object sender, EventArgs e)
        {
            ResetNutrienti();


        }
        public void ResetNutrienti()
        {
            if (MessageBox.Show("Sigur doriti sa resetati totalurile de nutrienti?", "Confirmare Resetare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                // SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
                try
                {
                    conn.Open();
                    string deleteProteineQuery = "DELETE FROM proteine";
                    string deleteLipideQuery = "DELETE FROM lipide";
                    string deleteGlucideQuery = "DELETE FROM glucide";
                    string deleteCaloriiQuery = "DELETE FROM calorii";
                    using (SqlCommand cmd = new SqlCommand(deleteProteineQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(deleteLipideQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(deleteGlucideQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(deleteCaloriiQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Totalurile de nutrienti au fost resetate cu succes.", "Resetare Reusita", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
                RefreshData();
            }
        }

        private void sterge_btn_Click(object sender, EventArgs e)
        {
            if (data_txt.Text == "")
            {
                MessageBox.Show("Te rog selecteaza o data pentru stergere", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Sunteți sigur că doriți să ștergeți datele?", "Avertizare Ștergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (conn.State == ConnectionState.Closed)
                        try
                        {
                            conn.Open();
                            string deleteQueryProteine = "DELETE FROM proteine WHERE data_adaugare = @dataAdaugare";
                            string deleteQueryLipide = "DELETE FROM lipide WHERE data_adaugare = @dataAdaugare";
                            string deleteQueryGlucide = "DELETE FROM glucide WHERE data_adaugare = @dataAdaugare";
                            string deleteQueryCalorii = "DELETE FROM calorii WHERE data_adaugare = @dataAdaugare";

                            SqlCommand cmd = new SqlCommand(deleteQueryProteine, conn);
                            SqlCommand cmdLipide = new SqlCommand(deleteQueryLipide, conn);
                            SqlCommand cmdGlucide = new SqlCommand(deleteQueryGlucide, conn);
                            SqlCommand cmdCalorii = new SqlCommand(deleteQueryCalorii, conn);

                            cmd.Parameters.AddWithValue("@dataAdaugare", Convert.ToDateTime(data_txt.Text.Trim(), new CultureInfo("ro-RO")));
                            cmdLipide.Parameters.AddWithValue("@dataAdaugare", Convert.ToDateTime(data_txt.Text.Trim(), new CultureInfo("ro-RO")));
                            cmdGlucide.Parameters.AddWithValue("@dataAdaugare", Convert.ToDateTime(data_txt.Text.Trim(), new CultureInfo("ro-RO")));
                            cmdCalorii.Parameters.AddWithValue("@dataAdaugare", Convert.ToDateTime(data_txt.Text.Trim(), new CultureInfo("ro-RO")));


                            int rowsAffected = cmd.ExecuteNonQuery();
                            rowsAffected = cmdLipide.ExecuteNonQuery();
                            rowsAffected = cmdGlucide.ExecuteNonQuery();
                            rowsAffected = cmdCalorii.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Inregistrarea din Proteine, Lipide, Glucide si Calorii din data de " + data_txt.Text + "a fost stearsa cu succes.", "Stergere Reusita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Nu s-a gasit nicio inregistrare pentru data specificata in Proteine.", "Stergere Esuata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            ClearFields();

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                            RefreshData();
                        }
                }
                else
                {
                    // User clicked No, do nothing
                    MessageBox.Show("Stergerea a fost anulata.", "Anulare Stergere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearFields();
            }
        }
        private void ClearFields()
        {
            //produsId_txt.Text = "";
            data_txt.Text = "";

        }

        private void proteineData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = proteineData.Rows[e.RowIndex];
                data_txt.Text = row.Cells[0].Value.ToString();
            }

        }
        private void lipideData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = lipideData.Rows[e.RowIndex];

                data_txt.Text = row.Cells[0].Value.ToString();

            }
        }
        private void glucideData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = glucideData.Rows[e.RowIndex];

                data_txt.Text = row.Cells[0].Value.ToString();

            }
        }

        private void caloriiData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = caloriiData.Rows[e.RowIndex];

                data_txt.Text = row.Cells[0].Value.ToString();

            }
        }

        private void calciuData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = calciuData.Rows[e.RowIndex];

                data_txt.Text = row.Cells[0].Value.ToString();

            }
        }

        private void fierData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = fierData.Rows[e.RowIndex];

                data_txt.Text = row.Cells[0].Value.ToString();

            }
        }
    }
}
