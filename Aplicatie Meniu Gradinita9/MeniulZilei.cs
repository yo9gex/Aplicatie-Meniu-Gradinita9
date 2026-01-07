using QuestPDF.Fluent;
using System.Data;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;





namespace Aplicatie_Meniu_Gradinita9
{
    public partial class MeniulZilei : UserControl
    {
        //SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30");
        // SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
        string dbPath;
        string connectionString;
        SqlConnection conn;

        public string Date;
        public string ListaMicDejun { get; private set; }
        public string ListaGustare { get; private set; }
        public string ListaPranzFel1 { get; private set; }
        public string ListaPranzFel2 { get; private set; }

        public string NumeProdusAlergen1 => numeProdusAlergen_txt.Text;
        public string NumeProdusAlergen2 => numeProdusAlergen2_txt.Text;
        public string NumeProdusAlergen3 => numeProdusAlergen3_txt.Text;
        public string NumeProdusAlergen4 => numeProdusAlergen4_txt.Text;

        public string NumeGradinita => gradinita_txt.Text;
        public string OrasGradinita => oras_txt.Text;
        public string JudetGradinita => judet_txt.Text;

        public string MicDejunText { get => micDejun_txt.Text; set => micDejun_txt.Text = value; }
        public string Felul1Text { get => felul1_txt.Text; set => felul1_txt.Text = value; }
        public string Felul2Text { get => felul2_txt.Text; set => felul2_txt.Text = value; }
        public string GustareText { get => gustare_txt.Text; set => gustare_txt.Text = value; }

        public MeniulZilei()
        {
            InitializeComponent();
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(connectionString);
            Date = DateTime.Now.ToString("dd-MM-yyyy");
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;

            }

            CreareMicDejun();
            CrearePranzFelul1();
            CrearePranzFelul2();
            CreareGustare();
            TotalDeclaratieNutritionala();
            DeclaratieNutritionalaMicDejun();
            DeclaratieNutritionalaGustare();
            DeclaratieNutritionalaPranzF1();
            DeclaratieNutritionalaPranzF2();
            NecesarEstimatCopil();
        }
        private void MeniulZilei_Load(object sender, EventArgs e)
        {
            dataToday_lbl.Text = Date;

            CreareMicDejun();
            CrearePranzFelul1();
            CrearePranzFelul2();
            CreareGustare();
            TotalDeclaratieNutritionala();
            DeclaratieNutritionalaMicDejun();
            DeclaratieNutritionalaGustare();
            DeclaratieNutritionalaPranzF1();
            DeclaratieNutritionalaPranzF2();
            NecesarEstimatCopil();
            MeniuDejun();
        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                try
                {
                    conn.Open();
                    string verificaDataProteine = "SELECT COUNT(*) FROM proteine WHERE data_adaugare = @today  ";
                    string verificaDataLipide = "SELECT COUNT(*) FROM lipide WHERE data_adaugare = @today  ";
                    string verificaDataGlucide = "SELECT COUNT(*) FROM glucide WHERE data_adaugare = @today  ";
                    string verificaDataCalorii = "SELECT COUNT(*) FROM calorii WHERE data_adaugare = @today  ";
                    using (SqlCommand cmd = new SqlCommand(verificaDataProteine, conn))
                    using (SqlCommand cmd2 = new SqlCommand(verificaDataLipide, conn))
                    using (SqlCommand cmd3 = new SqlCommand(verificaDataGlucide, conn))
                    using (SqlCommand cmd4 = new SqlCommand(verificaDataCalorii, conn))
                    {
                        DateTime today = DateTime.Today;
                        cmd.Parameters.AddWithValue("@today", today);
                        cmd2.Parameters.AddWithValue("@today", today);
                        cmd3.Parameters.AddWithValue("@today", today);
                        cmd4.Parameters.AddWithValue("@today", today);
                        int count = (int)cmd.ExecuteScalar();
                        int count2 = (int)cmd2.ExecuteScalar();
                        int count3 = (int)cmd3.ExecuteScalar();
                        int count4 = (int)cmd4.ExecuteScalar();
                        if (count > 0 || count2 > 0 || count3 > 0 || count4 > 0 || count > .0)
                        {
                            MessageBox.Show("Parametrii nutritionali pentru ziua de astazi au fost deja adaugati in Ancheta Alimentara si Total Nutrienti!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            ProteineTotale();
            LipideTotale();
            GlucideTotale();
            CaloriiTotale();



            MessageBox.Show("Parametrii nutritionali, ai zilei de astazi, au fost adaugati in Ancheta Alimentara si Total Nutrienti!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CreareMicDejun()
        {
            //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30";
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True";

            string query = "Select nume, TCantitate, TNet FROM totalAlimenteMicDejun ORDER BY nume";


            using (SqlConnection conn = new SqlConnection(connectionString))

            {
                SqlCommand command = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    micDejun_lst.Items.Clear();
                    //micDejun_lst.Items.Add("Produs              Tcantitate            TNet");
                    // micDejun_lst.Items.Add("----------------------------------------------------");

                    while (reader.Read())
                    {
                        string nume = reader["nume"].ToString();
                        string cantitate = reader["Tcantitate"].ToString();
                        string TNet = reader["TNet"].ToString();

                        string lineNume = nume.PadRight(24);
                        string lineTcantitate = cantitate.PadRight(12);
                        string lineTNet = TNet.PadRight(12);
                        string valoareLine = $"{lineNume}{lineTcantitate}{lineTNet}";
                        micDejun_lst.Items.Add(valoareLine);


                        // string itemText = string.Format("{0}\t{1}\t{2}",
                        //reader["nume"].ToString(),
                        //reader["Tcantitate"].ToString(),exempl
                        //reader["TNet"].ToString());
                        // micDejun_lst.Items.Add(itemText);

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
        }

        private void CrearePranzFelul1()
        {
            // string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30";
            // string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True";

            string query = "Select nume, TCantitate, TNet FROM totalAlimentePranz WHERE tip_fel = 'Felul 1' OR tip_fel = 'Ambele' ORDER BY nume";

            using (SqlConnection conn = new SqlConnection(connectionString))

            {
                SqlCommand command = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    felul1Pranz_lst.Items.Clear();

                    while (reader.Read())
                    {
                        string nume = reader["nume"].ToString();
                        string cantitate = reader["Tcantitate"].ToString();
                        string TNet = reader["TNet"].ToString();

                        string lineNume = nume.PadRight(24);
                        string lineTcantitate = cantitate.PadRight(12);
                        string lineTNet = TNet.PadRight(12);
                        string valoareLine = $"{lineNume}{lineTcantitate}{lineTNet}";
                        felul1Pranz_lst.Items.Add(valoareLine);
                        // string itemText = string.Format("{0}\t{1}\t{2}",
                        //reader["nume"].ToString(),
                        //reader["Tcantitate"].ToString(),
                        //reader["TNet"].ToString());
                        // felul1Pranz_lst.Items.Add(itemText);
                    }
                    reader.Close();
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
        }
        private void CrearePranzFelul2()
        {
            // string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30";
            // string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True";

            string query = "Select nume, TCantitate, TNet FROM totalAlimentePranz WHERE tip_fel = 'Felul 2' OR tip_fel = 'Ambele' ORDER BY nume";

            using (SqlConnection conn = new SqlConnection(connectionString))

            {
                SqlCommand command = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    felul2Pranz_lst.Items.Clear();

                    while (reader.Read())
                    {
                        string nume = reader["nume"].ToString();
                        string cantitate = reader["Tcantitate"].ToString();
                        string TNet = reader["TNet"].ToString();

                        string lineNume = nume.PadRight(24);
                        string lineTcantitate = cantitate.PadRight(12);
                        string lineTNet = TNet.PadRight(12);
                        string valoareLine = $"{lineNume}{lineTcantitate}{lineTNet}";
                        felul2Pranz_lst.Items.Add(valoareLine);
                        // string itemText = string.Format("{0}\t{1}\t{2}",
                        //reader["nume"].ToString(),
                        //reader["Tcantitate"].ToString(),
                        //reader["TNet"].ToString());
                        // felul2Pranz_lst.Items.Add(itemText);
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
        }
        private void CreareGustare()
        {
            //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30";
            // string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True";

            string query = "Select nume, TCantitate, TNet FROM totalAlimenteGustare ORDER BY nume";

            using (SqlConnection conn = new SqlConnection(connectionString))

            {
                SqlCommand command = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    gustare_lst.Items.Clear();

                    while (reader.Read())
                    {
                        string nume = reader["nume"].ToString();
                        string cantitate = reader["Tcantitate"].ToString();
                        string TNet = reader["TNet"].ToString();

                        string lineNume = nume.PadRight(24);
                        string lineTcantitate = cantitate.PadRight(12);
                        string lineTNet = TNet.PadRight(12);
                        string valoareLine = $"{lineNume}{lineTcantitate}{lineTNet}";
                        gustare_lst.Items.Add(valoareLine);
                        // string itemText = string.Format("{0}\t\n{1}\t\n{2}",
                        //reader["nume"].ToString(),
                        //reader["Tcantitate"].ToString(),
                        //reader["TNet"].ToString());
                        // gustare_lst.Items.Add(itemText);
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
        }
        private void DeclaratieNutritionalaMicDejun()
        {
            MicDejunAlimente md = new MicDejunAlimente();
            md.CalculeParametriNutrienti(out decimal totalProteine, out decimal totalLipide, out decimal totalGlucide, out decimal totalCalorii);
            declaratieNutrientiMD_lst.Items.Clear();
            declaratieNutrientiMD_lst.Items.Add("");
            declaratieNutrientiMD_lst.Items.Add("");
            declaratieNutrientiMD_lst.Items.Add("");
            declaratieNutrientiMD_lst.Items.Add("");



            declaratieNutrientiMD_lst.Items.Add("Total Proteine: " + totalProteine + " gr.");
            declaratieNutrientiMD_lst.Items.Add("Total Lipide: " + totalLipide + " gr.");
            declaratieNutrientiMD_lst.Items.Add("Total Glucide: " + totalGlucide + " gr.");
            declaratieNutrientiMD_lst.Items.Add("Total Calorii: " + totalCalorii + " kcal/copil");


        }
        private void DeclaratieNutritionalaPranzF1()
        {
            PranzAlimente pa = new PranzAlimente();
            pa.CalculParametriNutrientiFel1(out decimal totalProteine1, out decimal totalLipide1, out decimal totalGlucide1, out decimal totalCalorii1);
            declaratieNutritionalaFel1_lst.Items.Clear();
            declaratieNutritionalaFel1_lst.Items.Add("");
            declaratieNutritionalaFel1_lst.Items.Add("");
            declaratieNutritionalaFel1_lst.Items.Add("");
            declaratieNutritionalaFel1_lst.Items.Add("");

            declaratieNutritionalaFel1_lst.Items.Add("Total Proteine: " + totalProteine1 + " gr.");
            declaratieNutritionalaFel1_lst.Items.Add("Total Lipide: " + totalLipide1 + " gr.");
            declaratieNutritionalaFel1_lst.Items.Add("Total Glucide: " + totalGlucide1 + " gr.");
            declaratieNutritionalaFel1_lst.Items.Add("Total Calorii: " + totalCalorii1 + " kcal/copil");
        }
        private void DeclaratieNutritionalaPranzF2()
        {
            PranzAlimente pa = new PranzAlimente();
            pa.CalculParametriNutrientiFel2(out decimal totalProteine2, out decimal totalLipide2, out decimal totalGlucide2, out decimal totalCalorii2);
            declaratieNutritionalaFel2_lst.Items.Clear();
            declaratieNutritionalaFel2_lst.Items.Add("");
            declaratieNutritionalaFel2_lst.Items.Add("");
            declaratieNutritionalaFel2_lst.Items.Add("");
            declaratieNutritionalaFel2_lst.Items.Add("");

            declaratieNutritionalaFel2_lst.Items.Add("Total Proteine: " + totalProteine2 + " gr.");
            declaratieNutritionalaFel2_lst.Items.Add("Total Lipide: " + totalLipide2 + " gr.");
            declaratieNutritionalaFel2_lst.Items.Add("Total Glucide: " + totalGlucide2 + " gr.");
            declaratieNutritionalaFel2_lst.Items.Add("Total Calorii: " + totalCalorii2 + " kcal/copil");
        }
        private void DeclaratieNutritionalaGustare()
        {
            GustareAlimente ga = new GustareAlimente();
            ga.CalculParametriNutrienti(out decimal totalProteine3, out decimal totalLipide3, out decimal totalGlucide3, out decimal totalCalorii3);
            declaratieNutritionalaG_lst.Items.Clear();
            declaratieNutritionalaG_lst.Items.Add("");
            declaratieNutritionalaG_lst.Items.Add("");
            declaratieNutritionalaG_lst.Items.Add("");
            declaratieNutritionalaG_lst.Items.Add("");

            declaratieNutritionalaG_lst.Items.Add("Total Proteine: " + totalProteine3 + " gr.");
            declaratieNutritionalaG_lst.Items.Add("Total Lipide: " + totalLipide3 + " gr.");
            declaratieNutritionalaG_lst.Items.Add("Total Glucide: " + totalGlucide3 + " gr.");
            declaratieNutritionalaG_lst.Items.Add("Total Calorii: " + totalCalorii3 + " kcal/copil");
        }
        private void TotalDeclaratieNutritionala()
        { 

            NecesarAlimente na = new NecesarAlimente();
            na.CalculeazaParametri(out int NumarCopiiTotal, out string tBrut, out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, out string procentGlucide, out string procentLipide,
                na.GetTotalCantitate_lbl());
          
            totalDeclaratieNutrienti_lst.Items.Clear();
            if(NumarCopiiTotal == 0)
            {
                NumarCopiiTotal = 1; // Previne diviziunea la zero
            }
            totalDeclaratieNutrienti_lst.Items.Add("");
            totalDeclaratieNutrienti_lst.Items.Add("");
            totalDeclaratieNutrienti_lst.Items.Add("");
            totalDeclaratieNutrienti_lst.Items.Add("Total Proteine: " + (decimal.Parse(tP) / NumarCopiiTotal).ToString("F2") + " gr.");
            totalDeclaratieNutrienti_lst.Items.Add("Total Lipide: " + (decimal.Parse(tL) / NumarCopiiTotal).ToString("F2") + " gr.");
            totalDeclaratieNutrienti_lst.Items.Add("Total Glucide: " + (decimal.Parse(tG)/ NumarCopiiTotal).ToString("F2") + " gr.");
            totalDeclaratieNutrienti_lst.Items.Add("Total Calorii: " + (decimal.Parse(tCal) / NumarCopiiTotal).ToString("F2") + " kcal/copil");

        }
        private void NecesarEstimatCopil()
        {
            NecesarAlimente na = new NecesarAlimente();
            na.CalculeazaParametri(out int NumarCopiiTotal, out string tBrut, out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, out string procentGlucide, out string procentLipide,
                na.GetTotalCantitate_lbl());
            necesarEstimativCopil_lst.Items.Clear();
            necesarEstimativCopil_lst.Items.Add("");
            necesarEstimativCopil_lst.Items.Add("");

            necesarEstimativCopil_lst.Items.Add("");
            necesarEstimativCopil_lst.Items.Add("");
            necesarEstimativCopil_lst.Items.Add("");
            necesarEstimativCopil_lst.Items.Add("");
            necesarEstimativCopil_lst.Items.Add("=====================");
            necesarEstimativCopil_lst.Items.Add("");
            necesarEstimativCopil_lst.Items.Add("");
            necesarEstimativCopil_lst.Items.Add("");
            necesarEstimativCopil_lst.Items.Add("");




            necesarEstimativCopil_lst.Items.Add("Proteine: " + decimal.Parse(procentProteine).ToString("#.##") + "%");
            necesarEstimativCopil_lst.Items.Add("Lipide: " + decimal.Parse(procentLipide).ToString("#.##") + "%");
            necesarEstimativCopil_lst.Items.Add("Glucide: " + decimal.Parse(procentGlucide).ToString("#.##") + "%");

        }
        private void ProteineTotale()
        {
            NecesarAlimente na = new NecesarAlimente();
            na.CalculeazaParametri(out int NumarCopiiTotal, out string tBrut, out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, out string procentGlucide, out string procentLipide,
                na.GetTotalCantitate_lbl());

            decimal total_proteine = decimal.Parse(tP);
            // SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30");


            if (conn.State == ConnectionState.Closed)
                try
                {
                    conn.Open();
                    DateTime today = DateTime.Now;
                    string query = "INSERT INTO proteine (data_adaugare, total_proteine) Values (@today, @total_proteine)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@today", today);
                        cmd.Parameters.AddWithValue("@total_proteine", total_proteine);
                        cmd.ExecuteNonQuery();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
        }
        private void LipideTotale()
        {
            NecesarAlimente na = new NecesarAlimente();
            na.CalculeazaParametri(out int NumarCopiiTotal, out string tBrut, out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, out string procentGlucide, out string procentLipide,
                na.GetTotalCantitate_lbl());

            decimal total_lipide = decimal.Parse(tL);
            // SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30");

            if (conn.State == ConnectionState.Closed)
                try
                {
                    conn.Open();
                    DateTime today = DateTime.Now;
                    string query = "INSERT INTO lipide (data_adaugare, total_lipide) Values (@today, @total_lipide)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@today", today);
                        cmd.Parameters.AddWithValue("@total_lipide", total_lipide);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
        }
        private void GlucideTotale()
        {
            NecesarAlimente na = new NecesarAlimente();
            na.CalculeazaParametri(out int NumarCopiiTotal, out string tBrut, out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, out string procentGlucide, out string procentLipide,
                na.GetTotalCantitate_lbl());
            decimal total_glucide = decimal.Parse(tG);
            //SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30");
            if (conn.State == ConnectionState.Closed)
                try
                {
                    conn.Open();
                    DateTime today = DateTime.Now;
                    string query = "INSERT INTO glucide (data_adaugare, total_glucide) Values (@today, @total_glucide)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@today", today);
                        cmd.Parameters.AddWithValue("@total_glucide", total_glucide);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
        }
        public void CaloriiTotale()
        {
            NecesarAlimente na = new NecesarAlimente();
            na.CalculeazaParametri(out int NumarCopiiTotal, out string tBrut, out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, out string procentGlucide, out string procentLipide,
                na.GetTotalCantitate_lbl());
            decimal total_calorii = decimal.Parse(tCal);
            //  SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30");
            if (conn.State == ConnectionState.Closed)
                try
                {
                    conn.Open();
                    DateTime today = DateTime.Now;
                    string query = "INSERT INTO calorii (data_adaugare, total_calorii) Values (@today, @total_calorii)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@today", today);
                        cmd.Parameters.AddWithValue("@total_calorii", total_calorii);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
        }
        public void MeniuDejun()
        {
            MicDejunData lmd = new MicDejunData();
            List<MicDejunData> micDejunData = lmd.ListaMicDejunData();

            ListaMicDejun = string.Join(" gr " + "\n" + "\n", micDejunData.Select(item => item.ToString()));
            Console.WriteLine(ListaMicDejun);

        }
        public void MeniuPranzFel1()
        {
            PranzDataFel1 lpd1 = new PranzDataFel1();
            List<PranzDataFel1> listaPranzFel1 = lpd1.ListaPranzDataFel1();
            ListaPranzFel1 = string.Join(" gr " + "\n" + "\n", listaPranzFel1.Select(item => item.ToString()));
        }
        public void MeniuPranzFel2()
        {
            PranzDataFel2 lpd2 = new PranzDataFel2();
            List<PranzDataFel2> listaPranzFel2 = lpd2.ListaPranzDataFel2();
            ListaPranzFel2 = string.Join(" gr " + "\n" + "\n", listaPranzFel2.Select(item => item.ToString()));
        }
        public void MeniuGustare()
        {
            GustareData lgd = new GustareData();
            List<GustareData> gustareData = lgd.ListaGustareData();
            ListaGustare = string.Join(" gr " + "\n" + "\n", gustareData.Select(item => item.ToString()));
        }

                private void generarePDF_btn_Click(object sender, EventArgs e)

                {

                    if (string.IsNullOrWhiteSpace(gradinita_txt.Text) ||

                        string.IsNullOrWhiteSpace(oras_txt.Text) ||

                        string.IsNullOrWhiteSpace(judet_txt.Text))

                    {

                        MessageBox.Show("Antetul gradinitei nu a fost completat !", "Avertisment", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;

                    }

            

                    MeniuPDF document = new MeniuPDF(this);

                    document.GeneratePdfAndShow();
           // ClearField();
            
        }
        public void ClearField()
        {
            micDejun_txt.Text = "";
            felul1_txt.Text = "";
            felul2_txt.Text = "";
            gustare_txt.Text = "";

        }
        private void genereazaPdfNecesarAlimente_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gradinita_txt.Text) ||
                string.IsNullOrWhiteSpace(oras_txt.Text) ||
                string.IsNullOrWhiteSpace(judet_txt.Text))
            {
                MessageBox.Show("Antetul gradinitei nu a fost completat !", "Avertisment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RaportPDF document = new RaportPDF(this);
            document.GeneratePdfAndShow();
        }
    }
}
