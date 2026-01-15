using System.Data;
using Microsoft.Data.SqlClient;

namespace Aplicatie_Meniu_Gradinita9
{
    public partial class PranzAlimente : UserControl
    {
        public string Date;
        string dbPath;
        string connectionString;
        SqlConnection connection;

        public MeniulZilei MeniulZileiInstance { get; set; }

        public PranzAlimente()
        {
            InitializeComponent();
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
            connection = new SqlConnection(connectionString);
            Date = DateTime.Now.ToString("dd-MM-yyyy");
            DisableFields();
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;

            }

            DisplayPranzDataActualizate();
            CalculParametriNutrientiFel1(out decimal totalProteine, out decimal totalLipide, out decimal totalGlucide, out decimal totalCalorii);
            CalculParametriNutrientiFel2(out decimal totalProteine2, out decimal totalLipide2, out decimal totalGlucide2, out decimal totalCalorii2);
        }

        private void DisableFields()
        {
            numeProdus_lbl.Enabled = false;
            numeProdus_txt.Enabled = false;
            numePranzFel1_txt.Enabled = false;
            numePranzFel2_txt.Enabled = false;
        }

        public void DisplayPranzData()
        {
            PranzAlimenteData pad = new PranzAlimenteData();
            List<PranzAlimenteData> padList = pad.ListaPranzAlimenteData();
            dataPranzAlimente.DataSource = padList;

        }
        public void DisplayPranzDataActualizate()
        {
            PranzAlimenteDataActualizate pada = new PranzAlimenteDataActualizate();
            List<PranzAlimenteDataActualizate> padaList = pada.ListaPranzAlimenteDataActualizate();
            dataPranzAlimente.DataSource = padaList;

        }
        private void PranzAlimente_Load(object sender, EventArgs e)
        {
            TabelaPranz();
            dataToday_lbl.Text = Date;
            DisplayPranzDataActualizate();

            meniuPranzFel1_comboBox.DataSource = ListaMeniuri.PranzFelul1;
            meniuPranzFel1_comboBox.SelectedIndexChanged += meniuPranzFel1_comboBox_SelectedIndexChanged;

            meniuPranzFel2_comboBox.DataSource = ListaMeniuri.PranzFelul2;
            meniuPranzFel2_comboBox.SelectedIndexChanged += meniuPranzFel2_comboBox_SelectedIndexChanged;
        }

        private void meniuPranzFel1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (meniuPranzFel1_comboBox.SelectedItem != null)
            {
                numePranzFel1_txt.Text = meniuPranzFel1_comboBox.SelectedItem.ToString();
                if (MeniulZileiInstance != null)
                {
                    MeniulZileiInstance.Felul1Text = meniuPranzFel1_comboBox.SelectedItem.ToString();
                }
            }
        }

        private void meniuPranzFel2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (meniuPranzFel2_comboBox.SelectedItem != null)
            {
                numePranzFel2_txt.Text = meniuPranzFel2_comboBox.SelectedItem.ToString();
                if (MeniulZileiInstance != null)
                {
                    MeniulZileiInstance.Felul2Text = meniuPranzFel2_comboBox.SelectedItem.ToString();
                }
            }
        }

        private void dataPranzAlimente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = this.dataPranzAlimente.Rows[e.RowIndex];
                numeProdus_txt.Text = row.Cells[0].Value.ToString();
                cantitate_txt.Text = row.Cells[1].Value.ToString();
                tipFel_txt.Text = row.Cells[8].Value.ToString();
            }
        }
        private void cantitate_actualizareBtn_Click(object sender, EventArgs e)
        {
            ActualizareCantitate();
            CalculParametriNutrientiFel1(out decimal totalProteine, out decimal totalLipide, out decimal totalGlucide, out decimal totalCalorii);
            CalculParametriNutrientiFel2(out decimal totalProteine2, out decimal totalLipide2, out decimal totalGlucide2, out decimal totalCalorii2);

        }
        private void cantitate_clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            numeProdus_txt.Text = "";
            cantitate_txt.Text = "";
            tipFel_txt.Text = "";

        }

        public void TabelaPranz()
        {


            string queryy = @"INSERT INTO totalAlimentePranz  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel
                              FROM produseDerivateCereale p WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+P')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimentePranz t WHERE t.nume = p.nume);
                              ";
            string queryy2 = @"INSERT INTO totalAlimentePranz  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel
                              FROM laptePreparateLapte p WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+P')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimentePranz t WHERE t.nume = p.nume);
                              ";
            string queryy3 = @"INSERT INTO totalAlimentePranz  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel
                              FROM carneProduseCarne p WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+P')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimentePranz t WHERE t.nume = p.nume);
                              ";
            string queryy4 = @"INSERT INTO totalAlimentePranz  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel
                              FROM peste p WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+P')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimentePranz t WHERE t.nume = p.nume);
                              ";
            string queryy5 = @"INSERT INTO totalAlimentePranz  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel
                              FROM fructe p WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+P')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimentePranz t WHERE t.nume = p.nume);
                              ";
            string queryy6 = @"INSERT INTO totalAlimentePranz  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel
                              FROM fructeOleaginoase p WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+P')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimentePranz t WHERE t.nume = p.nume);
                              ";
            string queryy7 = @"INSERT INTO totalAlimentePranz  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel
                              FROM legumeConservate p WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+P')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimentePranz t WHERE t.nume = p.nume);
                              ";
            string queryy8 = @"INSERT INTO totalAlimentePranz  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel
                              FROM legumeProaspete p WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+P')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimentePranz t WHERE t.nume = p.nume);
                              ";
            string queryy9 = @"INSERT INTO totalAlimentePranz  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel
                              FROM oua p WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+P')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimentePranz t WHERE t.nume = p.nume);
                              ";
            string queryy10 = @"INSERT INTO totalAlimentePranz  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel
                              FROM produseZaharoase p WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+P')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimentePranz t WHERE t.nume = p.nume);
                              ";
            string queryy11 = @"INSERT INTO totalAlimentePranz  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel
                              FROM sucuriCompoturi p WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+P')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimentePranz t WHERE t.nume = p.nume);
                              ";
            string queryy12 = @"INSERT INTO totalAlimentePranz  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status, tip_fel
                              FROM ulei p WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+P')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimentePranz t WHERE t.nume = p.nume);
                              ";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryy, con);
                con.Open();
                int rowsModif = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsModif} rânduri introduse în tabelul meniu.");

            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryy2, con);
                con.Open();
                int rowsModif = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsModif} rânduri introduse în tabelul meniu.");

            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryy3, con);
                con.Open();
                int rowsModif = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsModif} rânduri introduse în tabelul meniu.");

            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryy4, con);
                con.Open();
                int rowsModif = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsModif} rânduri introduse în tabelul meniu.");

            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryy5, con);
                con.Open();
                int rowsModif = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsModif} rânduri introduse în tabelul meniu.");

            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryy6, con);
                con.Open();
                int rowsModif = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsModif} rânduri introduse în tabelul meniu.");

            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryy7, con);
                con.Open();
                int rowsModif = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsModif} rânduri introduse în tabelul meniu.");

            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryy8, con);
                con.Open();
                int rowsModif = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsModif} rânduri introduse în tabelul meniu.");

            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryy9, con);
                con.Open();
                int rowsModif = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsModif} rânduri introduse în tabelul meniu.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryy10, con);
                con.Open();
                int rowsModif = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsModif} rânduri introduse în tabelul meniu.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryy11, con);
                con.Open();
                int rowsModif = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsModif} rânduri introduse în tabelul meniu.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryy12, con);
                con.Open();
                int rowsModif = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsModif} rânduri introduse în tabelul meniu.");
            }

        }
        public void StergePranz()
        {
           // string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True";
            string coloanaNume = "tip_meniu";
            string coloanaNume2 = "status";

            string query = $@"DELETE m1
                            FROM totalAlimentePranz m1
                            JOIN produseDerivateCereale m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query2 = $@"DELETE m1
                            FROM totalAlimentePranz m1
                            JOIN laptePreparateLapte m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query3 = $@"DELETE m1
                            FROM totalAlimentePranz m1
                            JOIN carneProduseCarne m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query4 = $@"DELETE m1
                            FROM totalAlimentePranz m1
                            JOIN peste m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query5 = $@"DELETE m1
                            FROM totalAlimentePranz m1
                            JOIN fructe m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query6 = $@"DELETE m1
                            FROM totalAlimentePranz m1
                            JOIN fructeOleaginoase m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query7 = $@"DELETE m1
                            FROM totalAlimentePranz m1
                            JOIN legumeConservate m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query8 = $@"DELETE m1
                            FROM totalAlimentePranz m1
                            JOIN legumeProaspete m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query9 = $@"DELETE m1
                            FROM totalAlimentePranz m1
                            JOIN oua m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query10 = $@"DELETE m1
                            FROM totalAlimentePranz m1
                            JOIN produseZaharoase m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query11 = $@"DELETE m1
                            FROM totalAlimentePranz m1
                            JOIN sucuriCompoturi m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query12 = $@"DELETE m1
                            FROM totalAlimentePranz m1
                            JOIN ulei m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} randuri sterse.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query2, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} randuri sterse.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query3, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} randuri sterse.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query4, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} randuri sterse.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query5, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} randuri sterse.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query6, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} randuri sterse.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query7, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} randuri sterse.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query8, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} randuri sterse.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query9, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} randuri sterse.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query10, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} randuri sterse.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query11, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} randuri sterse.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query12, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} randuri sterse.");
            }

        }
        public void ActualizareCantitate()
        {
            if (numeProdus_txt.Text == ""
                || cantitate_txt.Text == ""
                || tipFel_txt.Text == ""
                || dataPranzAlimente.DataSource == null)
            {
                MessageBox.Show("Selecteaza un produs din lista pentru a actualiza cantitatea!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Esti sigur ca vrei sa actualizezi cantitatea?", "Actualizare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    //Actualizare cantitate
                    if (connection.State == ConnectionState.Closed)
                    {
                        try
                        {
                            connection.Open();
                            string query = "UPDATE totalAlimentePranz SET cantitate = @cantitate, tip_fel = @tip_fel WHERE nume = @nume ";
                            SqlCommand cmd = new SqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@nume", numeProdus_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@cantitate", decimal.Parse(cantitate_txt.Text.Trim()));
                            cmd.Parameters.AddWithValue("@tip_fel", tipFel_txt.Text.Trim());
                            cmd.ExecuteNonQuery();
                            DisplayPranzDataActualizate();
                            MessageBox.Show("Cantitatea a fost actualizata cu succes!", "Actualizare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                    ClearFields();
                }
            }
        }
        public void CalculParametriNutrientiFel1(out decimal totalProteine, out decimal totalLipide, out decimal totalGlucide, out decimal totalCalorii)
        {
            totalProteine = 0;
            totalLipide = 0;
            totalGlucide = 0;
            totalCalorii = 0;
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "Select * FROM totalAlimentePranz WHERE status = 'Alege' ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var produse = new List<(string Nume, decimal Cantitate, decimal TotalNet, decimal TotalProteine, decimal TotalLipide, decimal TotalGlucide, decimal TotalCalorii)>();
                        while (reader.Read())
                        {
                            string nume = reader["nume"].ToString();

                            decimal cantitateaDinTabela = reader.GetDecimal(reader.GetOrdinal("cantitate"));
                            decimal scazamantTabela = reader.GetDecimal(reader.GetOrdinal("scazamant"));
                            decimal proteineTabela = reader.GetDecimal(reader.GetOrdinal("proteine"));
                            decimal lipideTabela = reader.GetDecimal(reader.GetOrdinal("lipide"));
                            decimal glucideTabela = reader.GetDecimal(reader.GetOrdinal("glucide"));
                            decimal caloriiTabela = reader.GetDecimal(reader.GetOrdinal("calorii"));
                            produse.Add((nume, cantitateaDinTabela, scazamantTabela, proteineTabela, lipideTabela, glucideTabela, caloriiTabela));
                        }

                        reader.Close();

                        foreach (var produs in produse)
                        {
                            decimal cantitateTotala = produs.Cantitate * 1;
                            decimal scazamantTotal = cantitateTotala - (cantitateTotala * (produs.TotalNet));
                            decimal totalNet = scazamantTotal;
                            decimal proteineTotale = totalNet * produs.TotalProteine / 100;
                            decimal lipideTotale = totalNet * produs.TotalLipide / 100;
                            decimal glucideTotale = totalNet * produs.TotalGlucide / 100;
                            decimal caloriiTotale = totalNet * produs.TotalCalorii / 100;

                            string updateQuery = "UPDATE totalAlimentePranz SET TCantitate = @cantitateTotala, TNet = @totalNet, TProteine = @proteineTotale, TLipide = @lipideTotale, TGlucide = @glucideTotale, TCalorii = @caloriiTotale WHERE status = 'Alege'  AND nume = @nume";
                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@cantitateTotala", cantitateTotala);
                                updateCommand.Parameters.AddWithValue("@nume", produs.Nume);
                                updateCommand.Parameters.AddWithValue("@totalNet", totalNet);
                                updateCommand.Parameters.AddWithValue("@proteineTotale", proteineTotale);
                                updateCommand.Parameters.AddWithValue("@lipideTotale", lipideTotale);
                                updateCommand.Parameters.AddWithValue("@glucideTotale", glucideTotale);
                                updateCommand.Parameters.AddWithValue("@caloriiTotale", caloriiTotale);
                                updateCommand.ExecuteNonQuery();
                                DisplayPranzData();
                            }
                        }
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            DisplayPranzDataActualizate();
            for (int i = 0; i < dataPranzAlimente.Rows.Count; i++)
            {
                if (dataPranzAlimente.Rows[i].Cells["TProteine"].Value != DBNull.Value &&
                    dataPranzAlimente.Rows[i].Cells["TLipide"].Value != DBNull.Value &&
                    dataPranzAlimente.Rows[i].Cells["TGlucide"].Value != DBNull.Value &&
                    dataPranzAlimente.Rows[i].Cells["TCalorii"].Value != DBNull.Value)
                {


                    if (dataPranzAlimente.Columns.Contains("TipFel"))
                    {
                        var val = dataPranzAlimente.Rows[i].Cells["TipFel"].Value;
                        var status = val?.ToString();
                        if (status == "Ambele" || status == "Felul 1")
                        {

                            totalProteine += Convert.ToDecimal(dataPranzAlimente.Rows[i].Cells["TProteine"].Value);
                            totalLipide += Convert.ToDecimal(dataPranzAlimente.Rows[i].Cells["TLipide"].Value);
                            totalGlucide += Convert.ToDecimal(dataPranzAlimente.Rows[i].Cells["TGlucide"].Value);
                            totalCalorii += Convert.ToDecimal(dataPranzAlimente.Rows[i].Cells["TCalorii"].Value);
                        }
                    }
                }
            }



        }
        public void CalculParametriNutrientiFel2(out decimal totalProteine2, out decimal totalLipide2, out decimal totalGlucide2, out decimal totalCalorii2)
        {
            totalProteine2 = 0;
            totalLipide2 = 0;
            totalGlucide2 = 0;
            totalCalorii2 = 0;
           // string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "Select * FROM totalAlimentePranz WHERE status = 'Alege' ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var produse = new List<(string Nume, decimal Cantitate, decimal TotalNet, decimal TotalProteine, decimal TotalLipide, decimal TotalGlucide, decimal TotalCalorii)>();
                        while (reader.Read())
                        {
                            string nume = reader["nume"].ToString();

                            decimal cantitateaDinTabela = reader.GetDecimal(reader.GetOrdinal("cantitate"));
                            decimal scazamantTabela = reader.GetDecimal(reader.GetOrdinal("scazamant"));
                            decimal proteineTabela = reader.GetDecimal(reader.GetOrdinal("proteine"));
                            decimal lipideTabela = reader.GetDecimal(reader.GetOrdinal("lipide"));
                            decimal glucideTabela = reader.GetDecimal(reader.GetOrdinal("glucide"));
                            decimal caloriiTabela = reader.GetDecimal(reader.GetOrdinal("calorii"));
                            produse.Add((nume, cantitateaDinTabela, scazamantTabela, proteineTabela, lipideTabela, glucideTabela, caloriiTabela));
                        }

                        reader.Close();

                        foreach (var produs in produse)
                        {
                            decimal cantitateTotala = produs.Cantitate * 1;
                            decimal scazamantTotal = cantitateTotala - (cantitateTotala * (produs.TotalNet));
                            decimal totalNet = scazamantTotal;
                            decimal proteineTotale = totalNet * produs.TotalProteine / 100;
                            decimal lipideTotale = totalNet * produs.TotalLipide / 100;
                            decimal glucideTotale = totalNet * produs.TotalGlucide / 100;
                            decimal caloriiTotale = totalNet * produs.TotalCalorii / 100;

                            string updateQuery = "UPDATE totalAlimentePranz SET TCantitate = @cantitateTotala, TNet = @totalNet, TProteine = @proteineTotale, TLipide = @lipideTotale, TGlucide = @glucideTotale, TCalorii = @caloriiTotale WHERE status = 'Alege'  AND nume = @nume";
                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@cantitateTotala", cantitateTotala);
                                updateCommand.Parameters.AddWithValue("@nume", produs.Nume);
                                updateCommand.Parameters.AddWithValue("@totalNet", totalNet);
                                updateCommand.Parameters.AddWithValue("@proteineTotale", proteineTotale);
                                updateCommand.Parameters.AddWithValue("@lipideTotale", lipideTotale);
                                updateCommand.Parameters.AddWithValue("@glucideTotale", glucideTotale);
                                updateCommand.Parameters.AddWithValue("@caloriiTotale", caloriiTotale);
                                updateCommand.ExecuteNonQuery();
                                DisplayPranzData();
                            }
                        }
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            DisplayPranzDataActualizate();
            for (int i = 0; i < dataPranzAlimente.Rows.Count; i++)
            {

                if (dataPranzAlimente.Rows[i].Cells["TProteine"].Value != DBNull.Value &&
                    dataPranzAlimente.Rows[i].Cells["TLipide"].Value != DBNull.Value &&
                    dataPranzAlimente.Rows[i].Cells["TGlucide"].Value != DBNull.Value &&
                    dataPranzAlimente.Rows[i].Cells["TCalorii"].Value != DBNull.Value)
                {

                    if (dataPranzAlimente.Columns.Contains("TipFel"))
                    {
                        var val = dataPranzAlimente.Rows[i].Cells["TipFel"].Value;
                        var status = val?.ToString();
                        if (status == "Ambele" || status == "Felul 2")
                        {

                            totalProteine2 += Convert.ToDecimal(dataPranzAlimente.Rows[i].Cells["TProteine"].Value);
                            totalLipide2 += Convert.ToDecimal(dataPranzAlimente.Rows[i].Cells["TLipide"].Value);
                            totalGlucide2 += Convert.ToDecimal(dataPranzAlimente.Rows[i].Cells["TGlucide"].Value);
                            totalCalorii2 += Convert.ToDecimal(dataPranzAlimente.Rows[i].Cells["TCalorii"].Value);
                        }
                    }
                }
            }
        }
    }
}
