using System.Data;
using Microsoft.Data.SqlClient;


namespace Aplicatie_Meniu_Gradinita9
{
    public partial class GustareAlimente : UserControl
    {
        public string Date;
        // SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30");
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
        string dbPath;
        string connectionString;
        SqlConnection connection;
        public MeniulZilei MeniulZileiInstance { get; set; }

        public GustareAlimente()
        {
            InitializeComponent();
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
            connection = new SqlConnection(connectionString);
            // DisplayGustareAlimente();
            Date = DateTime.Now.ToString("dd-MM-yyyy");
            DisableFields();
        }
        private void DisableFields()
        {
            numeProdus_lbl.Enabled = false;
            numeProdus_txt.Enabled = false;
            numeGustare_txt.Enabled = false;
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;

            }
            CalculParametriNutrienti(out decimal totalProteine, out decimal totalLipide, out decimal totalGlucide, out decimal totalCalorii);
            DisplayGustareAlimenteActualizate();
           


        }
        public void DisplayGustareAlimente()
        {
            GustareAlimenteData gad = new GustareAlimenteData();
            List<GustareAlimenteData> gaList = gad.ListaGustareAlimenteData();
            dataGustareAlimente.DataSource = gaList;
        }
        public void DisplayGustareAlimenteActualizate()
        {
            GustareAlimenteDataActualizate gada = new GustareAlimenteDataActualizate();
            List<GustareAlimenteDataActualizate> gadaList = gada.ListaGustareAlimeteDataActualizate();
            dataGustareAlimente.DataSource = gadaList;
            Refresh();
        }
        private void GustareAlimente_Load(object sender, EventArgs e)
        {
            TabelaGustare();
            dataToday_lbl.Text = Date;
            DisplayGustareAlimenteActualizate();

            meniuGustare_comboBox.DataSource = ListaMeniuri.Gustare;
            meniuGustare_comboBox.SelectedIndexChanged += meniuGustare_comboBox_SelectedIndexChanged;
        }

        private void meniuGustare_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (meniuGustare_comboBox.SelectedItem != null)
            {
                numeGustare_txt.Text = meniuGustare_comboBox.SelectedItem.ToString();
                if (MeniulZileiInstance != null)
                {
                    MeniulZileiInstance.GustareText = meniuGustare_comboBox.SelectedItem.ToString();
                }
            }
        }

        private void cantitate_actualizare_Btn_Click(object sender, EventArgs e)
        {
            ActualizareCantitate();
            CalculParametriNutrienti(out decimal totalProteine, out decimal totalLipide, out decimal totalGlucide, out decimal totalCalorii);

        }
        private void cantitate_clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            numeProdus_txt.Text = "";
            cantitate_txt.Text = "";

        }

        private void dataGustareAlimente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = this.dataGustareAlimente.Rows[e.RowIndex];
                numeProdus_txt.Text = row.Cells[0].Value.ToString();
                cantitate_txt.Text = row.Cells[1].Value.ToString();

            }
        }

        //private void necesarAlimente_btn_Click(object sender, EventArgs e)
        //{
        //    MainForm.Instance.PnlContainer.Controls["NecesarAlimente"].BringToFront();
        //    MainForm.Instance.BtnListaProduse.Visible = true;
        //    MainForm.Instance.BtnNecesarAlimente.Visible = true;

        //}
        public void TabelaGustare()
        {
            // RefreshData();

            //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30";
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True";
          

            string queryy = @"INSERT INTO totalAlimenteGustare  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status 
                              FROM produseDerivateCereale p WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+G')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimenteGustare t WHERE t.nume = p.nume);
                              ";
            string queryy2 = @"INSERT INTO totalAlimenteGustare  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status 
                              FROM laptePreparateLapte p WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+G')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimenteGustare t WHERE t.nume = p.nume);
                              ";
            string queryy3 = @"INSERT INTO totalAlimenteGustare  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status 
                              FROM carneProduseCarne p WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+G')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimenteGustare t WHERE t.nume = p.nume);
                              ";
            string queryy4 = @"INSERT INTO totalAlimenteGustare  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status 
                              FROM cereale p WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+G')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimenteGustare t WHERE t.nume = p.nume);
                              ";
            string queryy5 = @"INSERT INTO totalAlimenteGustare  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status 
                              FROM fructe p WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+G')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimenteGustare t WHERE t.nume = p.nume);
                              ";
            string queryy6 = @"INSERT INTO totalAlimenteGustare  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status 
                              FROM fructeOleaginoase p WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+G')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimenteGustare t WHERE t.nume = p.nume);
                              ";
            string queryy7 = @"INSERT INTO totalAlimenteGustare  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status 
                              FROM legumeConservate p WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+G')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimenteGustare t WHERE t.nume = p.nume);
                              ";
            string queryy8 = @"INSERT INTO totalAlimenteGustare  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status 
                              FROM legumeProaspete p WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+G')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimenteGustare t WHERE t.nume = p.nume);
                              ";
            string queryy9 = @"INSERT INTO totalAlimenteGustare  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status 
                              FROM oua p WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+G')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimenteGustare t WHERE t.nume = p.nume);
                              ";
            string queryy10 = @"INSERT INTO totalAlimenteGustare  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status 
                              FROM produseZaharoase p WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+G')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimenteGustare t WHERE t.nume = p.nume);
                              ";
            string queryy11 = @"INSERT INTO totalAlimenteGustare  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status 
                              FROM sucuriCompoturi p WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+G')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimenteGustare t WHERE t.nume = p.nume);
                              ";
            string queryy12 = @"INSERT INTO totalAlimenteGustare  (nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status)
                              SELECT nume, proteine, lipide, glucide, calorii, scazamant, cantitate, TProteine, TLipide, TGlucide, TCalorii, TCantitate, TNet, tip_meniu, status 
                              FROM ulei p WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+G')
                             AND NOT EXISTS ( SELECT 1 FROM totalAlimenteGustare t WHERE t.nume = p.nume);
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
        public void StergeProdusGustare()
        {
            //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30";
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True";
            
            string coloanaNume = "tip_meniu";
            string coloanaNume2 = "status";

            string query = $@"DELETE m1
                            FROM totalAlimenteGustare m1
                            JOIN produseDerivateCereale m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query2 = $@"DELETE m1
                            FROM totalAlimenteGustare m1
                            JOIN laptePreparateLapte m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query3 = $@"DELETE m1
                            FROM totalAlimenteGustare m1
                            JOIN carneProduseCarne m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query4 = $@"DELETE m1
                            FROM totalAlimenteGustare m1
                            JOIN cereale m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query5 = $@"DELETE m1
                            FROM totalAlimenteGustare m1
                            JOIN fructe m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query6 = $@"DELETE m1
                            FROM totalAlimenteGustare m1
                            JOIN fructeOleaginoase m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query7 = $@"DELETE m1
                            FROM totalAlimenteGustare m1
                            JOIN legumeConservate m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query8 = $@"DELETE m1
                            FROM totalAlimenteGustare m1
                            JOIN legumeProaspete m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query9 = $@"DELETE m1
                            FROM totalAlimenteGustare m1
                            JOIN oua m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query10 = $@"DELETE m1
                            FROM totalAlimenteGustare m1
                            JOIN produseZaharoase m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query11 = $@"DELETE m1
                            FROM totalAlimenteGustare m1
                            JOIN sucuriCompoturi m ON m.nume = m1.nume
                            WHERE m1.{coloanaNume} <> m.{coloanaNume} OR m1.{coloanaNume2} <> m.{coloanaNume2}";
            string query12 = $@"DELETE m1
                            FROM totalAlimenteGustare m1
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
            || cantitate_txt.Text == "")
           // || dataGustareAlimente.DataSource == null)
            {
                MessageBox.Show("Selecteaza un produs din lista pentru a actualiza cantitatea!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Esti sigur ca vrei sa actualizezi cantitatea?", "Actualizare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        try
                        {
                            connection.Open();
                            string updateData = "UPDATE totalAlimenteGustare SET cantitate=@cantitate WHERE nume = @nume ";

                            using (SqlCommand cmd = new SqlCommand(updateData, connection))
                            {
                                cmd.Parameters.AddWithValue("@nume", numeProdus_txt.Text.Trim());
                                cmd.Parameters.AddWithValue("@cantitate", decimal.Parse(cantitate_txt.Text.Trim()));
                                cmd.ExecuteNonQuery();
                                DisplayGustareAlimenteActualizate();
                            }
                            MessageBox.Show("Cantitatea a fost actualizata cu succes!", "Actualizare reusita", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void CalculParametriNutrienti(out decimal totalProteine, out decimal totalLipide, out decimal totalGlucide, out decimal totalCalorii)
        {
            totalProteine = 0;
            totalLipide = 0;
            totalGlucide = 0;
            totalCalorii = 0;

           // string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30";
           // string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True";
          

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "Select * FROM totalAlimenteGustare WHERE status = 'Alege' ";
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

                            string updateQuery = "UPDATE totalAlimenteGustare SET TCantitate = @cantitateTotala, TNet = @totalNet, TProteine = @proteineTotale, TLipide = @lipideTotale, TGlucide = @glucideTotale, TCalorii = @caloriiTotale WHERE status = 'Alege'  AND nume = @nume";
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
                                DisplayGustareAlimente();
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
            DisplayGustareAlimenteActualizate();
            for (int i = 0; i < dataGustareAlimente.Rows.Count; i++)
            {
                if (dataGustareAlimente.Rows[i].Cells["TProteine"].Value != DBNull.Value &&
                    dataGustareAlimente.Rows[i].Cells["TLipide"].Value != DBNull.Value &&
                    dataGustareAlimente.Rows[i].Cells["TGlucide"].Value != DBNull.Value &&
                    dataGustareAlimente.Rows[i].Cells["TCalorii"].Value != DBNull.Value)
                {
                    totalProteine += Convert.ToDecimal(dataGustareAlimente.Rows[i].Cells["TProteine"].Value);
                    totalLipide += Convert.ToDecimal(dataGustareAlimente.Rows[i].Cells["TLipide"].Value);
                    totalGlucide += Convert.ToDecimal(dataGustareAlimente.Rows[i].Cells["TGlucide"].Value);
                    totalCalorii += Convert.ToDecimal(dataGustareAlimente.Rows[i].Cells["TCalorii"].Value);

                }
            }
        }
    }
}
