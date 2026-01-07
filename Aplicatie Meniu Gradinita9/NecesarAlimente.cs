using DevExpress.Data.Svg;
using MigraDoc.DocumentObjectModel;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuestPDF.Helpers.Colors;


namespace Aplicatie_Meniu_Gradinita9
{
    public partial class NecesarAlimente : UserControl
    {
        // Variable to store the current date and number childrens
        public string Date;
        public static int numarCopii;
        string dbPath;
        string connectionString;     
        SqlConnection connection;

        public NecesarAlimente()
        {
            InitializeComponent();
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            connection = new SqlConnection(connectionString);
            Date = DateTime.Now.ToString("dd-MM-yyyy");
            numarCopii = 1;
            DisplayNecesarAlimente();
            DisableFields();                  
        }

        // Method to refresh data in the DataGridView
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;

            }
            DisplayNecesarAlimente();
            DisableFields();

        }

        // Disable text fields to prevent user input
        private void DisableFields()
        {
            numeProdus_lbl.Enabled = false;
            numeProdus_txt.Enabled = false;

        }
        // Display necessary food items in the DataGridView
        private void DisplayNecesarAlimente()
        {
            NecesarAlimenteData na = new NecesarAlimenteData();
            List<NecesarAlimenteData> pdList = na.ListaNecesarAlimenteData();
            dataNecesarAlimente.DataSource = pdList;
        }

        // Load event for the UserControl
        private void NecesarAlimente_Load(object sender, EventArgs e)
        {
            dataToday_lbl.Text = Date;
        }

        // Populate text fields when a cell in the DataGridView is clicked
        private void dataNecesarAlimente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = this.dataNecesarAlimente.Rows[e.RowIndex];
                numeProdus_txt.Text = row.Cells[0].Value.ToString();
                cantitate_txt.Text = row.Cells[1].Value.ToString();
                tipMeniu_txt.Text = row.Cells[2].Value.ToString();


            }
        }
        // Clear text fields
        private void clearFields()
        {
            numeProdus_txt.Text = "";
            cantitate_txt.Text = "";
            tipMeniu_txt.Text = "";
        }
        // Update the quantity of a selected product
        private void cantitate_actualizareBtn_Click(object sender, EventArgs e)
        {
            ActualizareCantitate();
            CantitatePDC();
            CantitateOua();
            CantitateUlei();
            CantitateLegumeConservate();
            CantitateProduseZaharoase();
            CantitateCarneProduseCarne();
            CantitateLaptePreparateLapte();
            CantitateSucuriCompoturi();
            CantitateFructe();
            CantitateLegumeProaspete();
            CantitateOleaginoase();
            CantitateCereale();

        }
        // Clear button click event to clear text fields
        private void cantitate_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        // OK button click event to process the number of children and update quantities accordingly
        private void  oK_btn_Click(object sender, EventArgs e)
        {
            if (nrCopii_txt.Text == "")
            {
                MessageBox.Show("Te rog, completeaza numarul de copii.", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (int.TryParse(nrCopii_txt.Text, out int nrCopii) == false || nrCopii_txt.Text == "0")
                {
                    MessageBox.Show("Te rog sa introduci un numar valid pentru numarul de copii.", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                  
                }
                if (nrCopii > 500)
                {
                    MessageBox.Show("Numarul de copii nu poate fi mai mare de 500.", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }    
                if (nrCopii < 0)
                {
                    MessageBox.Show("Numarul de copii nu poate fi negativ.", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (nrCopii_txt.Text.StartsWith("0"))
                {
                    MessageBox.Show("Numarul de copii nu poate incepe cu 0.", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (nrCopii > 1)
                {
                    MessageBox.Show("Ai introdus " + nrCopii + " copii.", "Informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (nrCopii == 1)
                {
                    MessageBox.Show("Ai introdus " + nrCopii + " copil.", "Informare", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                numarCopii = int.Parse(nrCopii_txt.Text.Trim());                                                                                    
            }

            CantitatePDC();
            CantitateOua();
            CantitateUlei();
            CantitateLegumeConservate();
            CantitateProduseZaharoase();
            CantitateCarneProduseCarne();
            CantitateLaptePreparateLapte();
            CantitateSucuriCompoturi();
            CantitateFructe();
            CantitateLegumeProaspete();
            CantitateOleaginoase();
            CantitateCereale();
            RefreshData();
            
        }

        public void ActualizareCantitate()
        {
            if (numeProdus_txt.Text == ""
                || cantitate_txt.Text == ""
                || tipMeniu_txt.Text == "")
            {
                MessageBox.Show("Selecteaza un produs, introdu cantitatea si tipul de meniu  pentru a actualizare!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            string updateData = "UPDATE produseDerivateCereale SET cantitate=@cantitate, tip_meniu = @tip_meniu WHERE nume = @nume ";
                            string updateData2 = "UPDATE oua SET cantitate=@cantitate, tip_meniu = @tip_meniu WHERE nume = @nume ";
                            string updateData3 = "UPDATE ulei SET cantitate=@cantitate, tip_meniu = @tip_meniu WHERE nume = @nume ";
                            string updateData4 = "UPDATE legumeConservate SET cantitate=@cantitate, tip_meniu = @tip_meniu WHERE nume = @nume ";
                            string updateData5 = "UPDATE produseZaharoase SET cantitate=@cantitate, tip_meniu = @tip_meniu WHERE nume = @nume ";
                            string updateData6 = "UPDATE carneProduseCarne SET cantitate=@cantitate, tip_meniu = @tip_meniu WHERE nume = @nume ";
                            string updateData7 = "UPDATE laptePreparateLapte SET cantitate=@cantitate, tip_meniu = @tip_meniu WHERE nume = @nume ";
                            string updateData8 = "UPDATE sucuriCompoturi SET cantitate=@cantitate, tip_meniu = @tip_meniu WHERE nume = @nume ";
                            string updateData9 = "UPDATE fructe SET cantitate=@cantitate, tip_meniu = @tip_meniu WHERE nume = @nume ";
                            string updateData10 = "UPDATE legumeProaspete SET cantitate=@cantitate, tip_meniu = @tip_meniu WHERE nume = @nume ";
                            string updateData11 = "UPDATE fructeOleaginoase SET cantitate=@cantitate, tip_meniu = @tip_meniu WHERE nume = @nume ";
                            string updateData12 = "UPDATE cereale SET cantitate=@cantitate, tip_meniu = @tip_meniu WHERE nume = @nume ";

                            using (SqlCommand cmd = new SqlCommand(updateData, connection))
                            {
                                cmd.Parameters.AddWithValue("@nume", numeProdus_txt.Text.Trim());
                                cmd.Parameters.AddWithValue("@cantitate", decimal.Parse(cantitate_txt.Text.Trim()));
                                cmd.Parameters.AddWithValue("@tip_meniu", tipMeniu_txt.Text.Trim());



                                var updateCommands = new List<SqlCommand>
                                {
                                    new SqlCommand(updateData, connection),
                                    new SqlCommand(updateData2, connection),
                                    new SqlCommand(updateData3, connection),
                                    new SqlCommand(updateData4, connection),
                                    new SqlCommand(updateData5, connection),
                                    new SqlCommand(updateData6, connection),
                                    new SqlCommand(updateData7, connection),
                                    new SqlCommand(updateData8, connection),
                                    new SqlCommand(updateData9, connection),
                                    new SqlCommand(updateData10, connection),
                                    new SqlCommand(updateData11, connection),
                                    new SqlCommand(updateData12, connection)
                                };

                                foreach (var updateCmd in updateCommands)
                                {
                                    updateCmd.Parameters.AddWithValue("@nume", numeProdus_txt.Text.Trim());
                                    updateCmd.Parameters.AddWithValue("@cantitate", decimal.Parse(cantitate_txt.Text.Trim()));
                                    updateCmd.Parameters.AddWithValue("@tip_meniu", tipMeniu_txt.Text.Trim());
                                    updateCmd.ExecuteNonQuery();
                                }
                                DisplayNecesarAlimente();
                                MessageBox.Show("Cantitatea a fost actualizata cu succes!", "Actualizare reusita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
                                MicDejunAlimente mda = new MicDejunAlimente();
                                PranzAlimente pa = new PranzAlimente();
                                GustareAlimente ga = new GustareAlimente();
                                mda.TabelaMicDejun();
                                mda.StergeProdusDinMicDejun();
                                pa.TabelaPranz();
                                pa.StergePranz();
                                ga.TabelaGustare();
                                ga.StergeProdusGustare();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            connection.Close();

                        } // end try catch

                    }
                }
            }
        }

        // Method to process and update quantities based on the number of children from produseDerivateCereale table
        public void CantitatePDC()
        {
            int nrTotalCopii = numarCopii;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "Select * FROM produseDerivateCereale WHERE status = 'Alege' ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var produse = new List<(string Nume, decimal Cantitate, decimal TotalNet, decimal TotalProteine, decimal TotalLipide, decimal TotalGlucide, decimal TotalFier, decimal TotalCalciu, decimal TotalCalorii)>();
                        while (reader.Read())
                        {
                            string nume = reader["nume"].ToString();

                            decimal cantitateaDinTabela = reader.GetDecimal(reader.GetOrdinal("cantitate"));
                            decimal scazamantTabela = reader.GetDecimal(reader.GetOrdinal("scazamant"));
                            decimal proteineTabela = reader.GetDecimal(reader.GetOrdinal("proteine"));
                            decimal lipideTabela = reader.GetDecimal(reader.GetOrdinal("lipide"));
                            decimal glucideTabela = reader.GetDecimal(reader.GetOrdinal("glucide"));
                            decimal fierTabela = reader.GetDecimal(reader.GetOrdinal("fier"));
                            decimal calciuTabela = reader.GetDecimal(reader.GetOrdinal("calciu"));
                            decimal caloriiTabela = reader.GetDecimal(reader.GetOrdinal("calorii"));
                            produse.Add((nume, cantitateaDinTabela, scazamantTabela, proteineTabela, lipideTabela, glucideTabela, fierTabela, calciuTabela, caloriiTabela));
                        }

                        reader.Close();

                        foreach (var produs in produse)
                        {
                            decimal cantitateTotala = produs.Cantitate * nrTotalCopii;
                            decimal scazamantTotal = cantitateTotala - (cantitateTotala * (produs.TotalNet));
                            decimal totalNet = scazamantTotal;
                            decimal proteineTotale = totalNet * produs.TotalProteine / 100;
                            decimal lipideTotale = totalNet * produs.TotalLipide / 100;
                            decimal glucideTotale = totalNet * produs.TotalGlucide / 100;
                            decimal fierTotal = totalNet * produs.TotalFier / 100;
                            decimal calciuTotal = totalNet * produs.TotalCalciu / 100;
                            decimal caloriiTotale = totalNet * produs.TotalCalorii / 100;



                            string updateQuery = "UPDATE produseDerivateCereale SET TCantitate = @cantitateTotala, TNet = @totalNet, TProteine = @proteineTotale, TLipide = @lipideTotale, TGlucide = @glucideTotale, TFier = @fierTotal, TCalciu = @calciuTotal, TCalorii = @caloriiTotale WHERE status = 'Alege'  AND nume = @nume";
                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@cantitateTotala", cantitateTotala);
                                updateCommand.Parameters.AddWithValue("@nume", produs.Nume);
                                updateCommand.Parameters.AddWithValue("@totalNet", totalNet);
                                updateCommand.Parameters.AddWithValue("@proteineTotale", proteineTotale);
                                updateCommand.Parameters.AddWithValue("@lipideTotale", lipideTotale);
                                updateCommand.Parameters.AddWithValue("@glucideTotale", glucideTotale);
                                updateCommand.Parameters.AddWithValue("@fierTotal", fierTotal);
                                updateCommand.Parameters.AddWithValue("@calciuTotal", calciuTotal);
                                updateCommand.Parameters.AddWithValue("@caloriiTotale", caloriiTotale);
                                updateCommand.ExecuteNonQuery();
                                DisplayNecesarAlimente();
                            }
                        }
                        clearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Clear the number of children text box after processing
        }

       

        // Method to process and update quantities based on the number of children from oua table
        public void CantitateOua()
        {
            int nrTotalCopii = numarCopii;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "Select * FROM oua WHERE status = 'Alege' ";
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
                            decimal cantitateTotala = produs.Cantitate * nrTotalCopii;
                            decimal scazamantTotal = cantitateTotala - (cantitateTotala * (produs.TotalNet));
                            decimal totalNet = scazamantTotal;
                            decimal proteineTotale = totalNet * produs.TotalProteine / 100;
                            decimal lipideTotale = totalNet * produs.TotalLipide / 100;
                            decimal glucideTotale = totalNet * produs.TotalGlucide / 100;
                            decimal caloriiTotale = totalNet * produs.TotalCalorii / 100;


                            string updateQuery = "UPDATE oua SET TCantitate = @cantitateTotala, TNet = @totalNet, TProteine = @proteineTotale, TLipide = @lipideTotale, TGlucide = @glucideTotale, TCalorii = @caloriiTotale WHERE status = 'Alege' AND nume = @nume";
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
                                DisplayNecesarAlimente();
                            }
                        }
                        clearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
       
        }
        public void CantitateUlei()
        {
            int nrTotalCopii = numarCopii;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "Select * FROM ulei WHERE status = 'Alege' ";
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
                            decimal cantitateTotala = produs.Cantitate * nrTotalCopii;
                            decimal scazamantTotal = cantitateTotala - (cantitateTotala * (produs.TotalNet));
                            decimal totalNet = scazamantTotal;
                            decimal proteineTotale = totalNet * produs.TotalProteine / 100;
                            decimal lipideTotale = totalNet * produs.TotalLipide / 100;
                            decimal glucideTotale = totalNet * produs.TotalGlucide / 100;
                            decimal caloriiTotale = totalNet * produs.TotalCalorii / 100;
                            string updateQuery = "UPDATE ulei SET TCantitate = @cantitateTotala, TNet = @totalNet, TProteine = @proteineTotale, TLipide = @lipideTotale, TGlucide = @glucideTotale, TCalorii = @caloriiTotale WHERE status = 'Alege' AND nume = @nume";
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
                                DisplayNecesarAlimente();
                            }
                        }
                        clearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
   


        }
        public void CantitateLegumeConservate()
        {
            int nrTotalCopii = numarCopii;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "Select * FROM legumeConservate WHERE status = 'Alege' ";
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
                            decimal cantitateTotala = produs.Cantitate * nrTotalCopii;
                            decimal scazamantTotal = cantitateTotala - (cantitateTotala * (produs.TotalNet));
                            decimal totalNet = scazamantTotal;
                            decimal proteineTotale = totalNet * produs.TotalProteine / 100;
                            decimal lipideTotale = totalNet * produs.TotalLipide / 100;
                            decimal glucideTotale = totalNet * produs.TotalGlucide / 100;
                            decimal caloriiTotale = totalNet * produs.TotalCalorii / 100;

                            string updateQuery = "UPDATE legumeConservate SET TCantitate = @cantitateTotala, TNet = @totalNet, TProteine = @proteineTotale, TLipide = @lipideTotale, TGlucide = @glucideTotale, TCalorii = @caloriiTotale WHERE status = 'Alege' AND nume = @nume";
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
                                DisplayNecesarAlimente();
                            }
                        }
                        clearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Clear the number of children text box after processing
            // CalculeazaParametri(out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, GetTotalCantitate_lbl());
        }
        public void CantitateProduseZaharoase()
        {int nrTotalCopii = numarCopii;

            // Open a connection to the database produseZaharoase
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "Select * FROM produseZaharoase WHERE status = 'Alege' ";
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
                            decimal cantitateTotala = produs.Cantitate * nrTotalCopii;
                            decimal scazamantTotal = cantitateTotala - (cantitateTotala * (produs.TotalNet));
                            decimal totalNet = scazamantTotal;
                            decimal proteineTotale = totalNet * produs.TotalProteine / 100;
                            decimal lipideTotale = totalNet * produs.TotalLipide / 100;
                            decimal glucideTotale = totalNet * produs.TotalGlucide / 100;
                            decimal caloriiTotale = totalNet * produs.TotalCalorii / 100;
                            string updateQuery = "UPDATE produseZaharoase SET TCantitate = @cantitateTotala, TNet = @totalNet, TProteine = @proteineTotale, TLipide = @lipideTotale, TGlucide = @glucideTotale, TCalorii = @caloriiTotale WHERE status = 'Alege' AND nume = @nume";
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
                                DisplayNecesarAlimente();
                            }
                        }
                        clearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Clear the number of children text box after processing


            //CalculeazaParametri(out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, GetTotalCantitate_lbl());
        }
        public void CantitateCarneProduseCarne()
        {
            int nrTotalCopii = numarCopii;

            // Open a connection to the database carneProduseCarne
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "Select * FROM carneProduseCarne WHERE status = 'Alege' ";
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
                            decimal cantitateTotala = produs.Cantitate * nrTotalCopii;
                            decimal scazamantTotal = cantitateTotala - (cantitateTotala * (produs.TotalNet));
                            decimal totalNet = scazamantTotal;
                            decimal proteineTotale = totalNet * produs.TotalProteine / 100;
                            decimal lipideTotale = totalNet * produs.TotalLipide / 100;
                            decimal glucideTotale = totalNet * produs.TotalGlucide / 100;
                            decimal caloriiTotale = totalNet * produs.TotalCalorii / 100;




                            string updateQuery = "UPDATE carneProduseCarne SET TCantitate = @cantitateTotala, TNet = @totalNet, TProteine = @proteineTotale, TLipide = @lipideTotale, TGlucide = @glucideTotale, TCalorii = @caloriiTotale WHERE status = 'Alege' AND nume = @nume";
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
                                DisplayNecesarAlimente();
                            }
                        }
                        clearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Clear the number of children text box after processing


            // CalculeazaParametri(out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, GetTotalCantitate_lbl());

        }
        public void CantitateLaptePreparateLapte()
        {
            int nrTotalCopii = numarCopii;

            // Open a connection to the database laptePreparateLapte
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "Select * FROM laptePreparateLapte WHERE status = 'Alege' ";
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
                            decimal cantitateTotala = produs.Cantitate * nrTotalCopii;
                            decimal scazamantTotal = cantitateTotala - (cantitateTotala * (produs.TotalNet));
                            decimal totalNet = scazamantTotal;
                            decimal proteineTotale = totalNet * produs.TotalProteine / 100;
                            decimal lipideTotale = totalNet * produs.TotalLipide / 100;
                            decimal glucideTotale = totalNet * produs.TotalGlucide / 100;
                            decimal caloriiTotale = totalNet * produs.TotalCalorii / 100;

                            string updateQuery = "UPDATE laptePreparateLapte SET TCantitate = @cantitateTotala, TNet = @totalNet, TProteine = @proteineTotale, TLipide = @lipideTotale, TGlucide = @glucideTotale, TCalorii = @caloriiTotale WHERE status = 'Alege' AND nume = @nume";
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
                                DisplayNecesarAlimente();
                            }
                        }
                        clearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Clear the number of children text box after processing


            // CalculeazaParametri(out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, GetTotalCantitate_lbl());
        }
        public void CantitateSucuriCompoturi()
        {
            int nrTotalCopii = numarCopii;

            // Open a connection to the database sucuriCompoturi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "Select * FROM sucuriCompoturi WHERE status = 'Alege' ";
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
                            decimal cantitateTotala = produs.Cantitate * nrTotalCopii;
                            decimal scazamantTotal = cantitateTotala - (cantitateTotala * (produs.TotalNet));
                            decimal totalNet = scazamantTotal;
                            decimal proteineTotale = totalNet * produs.TotalProteine / 100;
                            decimal lipideTotale = totalNet * produs.TotalLipide / 100;
                            decimal glucideTotale = totalNet * produs.TotalGlucide / 100;
                            decimal caloriiTotale = totalNet * produs.TotalCalorii / 100;

                            string updateQuery = "UPDATE sucuriCompoturi SET TCantitate = @cantitateTotala, TNet=@totalNet, TProteine = @proteineTotale, TLipide = @lipideTotale, TGlucide = @glucideTotale, TCalorii = @caloriiTotale WHERE status = 'Alege' AND nume = @nume";
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
                                DisplayNecesarAlimente();
                            }
                        }
                        clearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Clear the number of children text box after processing


            // CalculeazaParametri(out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, GetTotalCantitate_lbl());
        }
        public void CantitateFructe()
        {
            int nrTotalCopii = numarCopii;

            // Open a connection to the database fructe
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "Select * FROM fructe WHERE status = 'Alege' ";
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
                            decimal cantitateTotala = produs.Cantitate * nrTotalCopii;
                            decimal scazamantTotal = cantitateTotala - (cantitateTotala * (produs.TotalNet));
                            decimal totalNet = scazamantTotal;
                            decimal proteineTotale = totalNet * produs.TotalProteine / 100;
                            decimal lipideTotale = totalNet * produs.TotalLipide / 100;
                            decimal glucideTotale = totalNet * produs.TotalGlucide / 100;
                            decimal caloriiTotale = totalNet * produs.TotalCalorii / 100;

                            string updateQuery = "UPDATE fructe SET TCantitate = @cantitateTotala, TNet = @totalNet, TProteine = @proteineTotale, TLipide = @lipideTotale, TGlucide = @glucideTotale, TCalorii = @caloriiTotale WHERE status = 'Alege' AND nume = @nume";
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
                                DisplayNecesarAlimente();
                            }
                        }
                        clearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Clear the number of children text box after processing


            // CalculeazaParametri(out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, GetTotalCantitate_lbl());
        }
        public void CantitateLegumeProaspete()
        {
            int nrTotalCopii = numarCopii;

            // Open a connection to the database legumeProaspete
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "Select * FROM legumeProaspete WHERE status = 'Alege' ";
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
                            decimal cantitateTotala = produs.Cantitate * nrTotalCopii;
                            decimal scazamantTotal = cantitateTotala - (cantitateTotala * (produs.TotalNet));
                            decimal totalNet = scazamantTotal;
                            decimal proteineTotale = totalNet * produs.TotalProteine / 100;
                            decimal lipideTotale = totalNet * produs.TotalLipide / 100;
                            decimal glucideTotale = totalNet * produs.TotalGlucide / 100;
                            decimal caloriiTotale = totalNet * produs.TotalCalorii / 100;

                            string updateQuery = "UPDATE legumeProaspete SET TCantitate = @cantitateTotala, TNet = @totalNet, TProteine = @proteineTotale, TLipide = @lipideTotale, TGlucide = @glucideTotale, TCalorii = @caloriiTotale WHERE status = 'Alege' AND nume = @nume";
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
                                DisplayNecesarAlimente();
                            }
                        }
                        clearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Clear the number of children text box after processing


            //CalculeazaParametri(out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, GetTotalCantitate_lbl());
        }
        public void CantitateOleaginoase()
        {
            int nrTotalCopii = numarCopii;

            // Open a connection to the database oleaginoase

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "Select * FROM fructeOleaginoase WHERE status = 'Alege' ";
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
                            decimal cantitateTotala = produs.Cantitate * nrTotalCopii;
                            decimal scazamantTotal = cantitateTotala - (cantitateTotala * (produs.TotalNet));
                            decimal totalNet = scazamantTotal;
                            decimal proteineTotale = totalNet * produs.TotalProteine / 100;
                            decimal lipideTotale = totalNet * produs.TotalLipide / 100;
                            decimal glucideTotale = totalNet * produs.TotalGlucide / 100;
                            decimal caloriiTotale = totalNet * produs.TotalCalorii / 100;

                            string updateQuery = "UPDATE fructeOleaginoase SET TCantitate = @cantitateTotala, TNet = @totalNet, TProteine = @proteineTotale, TLipide = @lipideTotale, TGlucide = @glucideTotale, TCalorii = @caloriiTotale WHERE status = 'Alege' AND nume = @nume";
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
                                DisplayNecesarAlimente();
                            }
                        }
                        clearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Clear the number of children text box after processing


            // CalculeazaParametri(out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, GetTotalCantitate_lbl());
        }
        public void CantitateCereale()
        {
            int nrTotalCopii = numarCopii;
            // Open a connection to the database cereale

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "Select * FROM cereale WHERE status = 'Alege' ";
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
                            decimal cantitateTotala = produs.Cantitate * nrTotalCopii;
                            decimal scazamantTotal = cantitateTotala - (cantitateTotala * (produs.TotalNet));
                            decimal totalNet = scazamantTotal;
                            decimal proteineTotale = totalNet * produs.TotalProteine / 100;
                            decimal lipideTotale = totalNet * produs.TotalLipide / 100;
                            decimal glucideTotale = totalNet * produs.TotalGlucide / 100;
                            decimal caloriiTotale = totalNet * produs.TotalCalorii / 100;

                            string updateQuery = "UPDATE cereale SET TCantitate = @cantitateTotala, TNet = @TotalNet, TProteine = @proteineTotale, TLipide = @lipideTotale, TGlucide = @glucideTotale, TCalorii = @caloriiTotale WHERE status = 'Alege' AND nume = @nume";
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
                                DisplayNecesarAlimente();
                            }
                        }
                        clearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Clear the number of children text box after processing

            CalculeazaParametri(out int NumarCopiiTotal, out string tBrut, out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, out string procentGlucide, out string procentLipide, GetTotalCantitate_lbl());
            
        }
       
        public Label GetTotalCantitate_lbl()
        {
            return totalCantitate_lbl;
        }
        // Method to calculate and display total parameters in the labels
        public void CalculeazaParametri(out int numarCopiiTotal, out string tBrut, out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, out string procentGlucide, out string procentLipide, Label totalCantitate_lbl)
        {
            numarCopiiTotal = numarCopii;
            tBrut = "0.00";
            tC = "0.00";
            tP = "0.00";
            tL = "0.00";
            tG = "0.00";
            tCal = "0.00";
            procentProteine = "0.00";
            procentLipide = "0.00";
            procentGlucide = "0.00";

            totalCantitateB_lbl.Text = "0.00";
            totalCantitate_lbl.Text = "0.00";
            tProteine_lbl.Text = "0.00";
            tLipide_lbl.Text = "0.00";
            tGlucide_lbl.Text = "0.00";
            tCalorii_lbl.Text = "0.00";

            procentProteine_lbl.Text = "0.00";
            procentLipide_lbl.Text = "0.00";
            procentGlucide_lbl.Text = "0.00";
         
                for (int i = 0; i < dataNecesarAlimente.Rows.Count; i++)
                {
                // C#
                
                    object cell3 = dataNecesarAlimente.Rows[i].Cells[3].Value;
                    object cell4 = dataNecesarAlimente.Rows[i].Cells[4].Value;
                    object cell5 = dataNecesarAlimente.Rows[i].Cells[5].Value;
                    object cell6 = dataNecesarAlimente.Rows[i].Cells[6].Value;
                    object cell7 = dataNecesarAlimente.Rows[i].Cells[7].Value;
                    object cell8 = dataNecesarAlimente.Rows[i].Cells[8].Value;

                    decimal val3 = 0m, val4 = 0m, val5 = 0m, val6 = 0m, val7 = 0m, val8 = 0m;

                    decimal.TryParse(totalCantitateB_lbl.Text, out decimal totalCantB) ;
                    decimal.TryParse(Convert.ToString(cell3 ?? "0"),out val3);
                    decimal.TryParse(totalCantitate_lbl.Text, out decimal totalCant);
                    decimal.TryParse(Convert.ToString(cell4 ?? "0"), out val4);
                    decimal.TryParse(tProteine_lbl.Text, out decimal totalProt);
                    decimal.TryParse(Convert.ToString(cell5 ?? "0"), out val5);
                    decimal.TryParse(tLipide_lbl.Text, out decimal totalLip);
                    decimal.TryParse(Convert.ToString(cell6 ?? "0"), out val6);
                    decimal.TryParse(tGlucide_lbl.Text, out decimal totalGluc);
                    decimal.TryParse(Convert.ToString(cell7 ?? "0"), out val7);
                    decimal.TryParse(tCalorii_lbl.Text, out decimal totalCalVal);
                    decimal.TryParse(Convert.ToString(cell8 ?? "0"), out val8);

                    totalCantB += val3;
                    totalCant += val4;
                    totalProt += val5;
                    totalLip += val6;
                    totalGluc += val7;
                    totalCalVal += val8;

                    totalCantitateB_lbl.Text = totalCantB.ToString("0.00");
                    totalCantitate_lbl.Text = totalCant.ToString("0.00");
                    tProteine_lbl.Text = totalProt.ToString("0.00");
                    tLipide_lbl.Text = totalLip.ToString("0.00");
                    tGlucide_lbl.Text = totalGluc.ToString("0.00");
                    tCalorii_lbl.Text = totalCalVal.ToString("0.00");

                    tBrut = totalCantitateB_lbl.Text;
                    tC = totalCantitate_lbl.Text;
                    tP = tProteine_lbl.Text;
                    tL = tLipide_lbl.Text;
                    tG = tGlucide_lbl.Text;
                    tCal = tCalorii_lbl.Text;
                          
                // compute percentages safely (check totalCalVal > 0) ...
            
                if (
                   totalCalVal != 0)

                {
                    procentProteine = Convert.ToString(((totalProt * (decimal)4.1) / (totalCalVal)) * 100);
                    procentLipide = Convert.ToString(((totalLip * (decimal)9.1) / (totalCalVal)) * 100);
                    procentGlucide = Convert.ToString(((totalGluc * (decimal)4.1) / (totalCalVal)) * 100);

                    procentProteine_lbl.Text = decimal.Parse(procentProteine).ToString("#.##");
                    procentLipide_lbl.Text = decimal.Parse(procentLipide).ToString("#.##");
                    procentGlucide_lbl.Text = decimal.Parse(procentGlucide).ToString("#.##");


                }
                else
                {
                    MessageBox.Show("Oops, a apărut o eroare!! Te rog să introduci în Necesar Alimente, cantitatea produs, numărul de copii și tipul de meniu, nu pot împărți la zero și nu pot calcula valorile nutrienților ! ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
                }          
        }
     
        public void ReseteazaParametri()
        {
            if (connection.State == ConnectionState.Closed)
                try
                {
                    connection.Open();
                    string resetData = "UPDATE produseDerivateCereale SET status=@nume, tip_meniu=@tip_meniu, cantitate=@cantitate, TCantitate=@TCantitate, TNet=@TNet, TProteine=@TProteine, TLipide=@TLipide, TGlucide=@TGlucide, TCalorii=@TCalorii WHERE status = 'Alege' ";
                    string resetData2 = "UPDATE produseZaharoase SET status=@nume, tip_meniu=@tip_meniu, cantitate=@cantitate, TCantitate=@TCantitate, TNet=@TNet, TProteine=@TProteine, TLipide=@TLipide, TGlucide=@TGlucide, TCalorii=@TCalorii WHERE status = 'Alege' ";
                    string resetData3 = "UPDATE carneProduseCarne SET status=@nume, tip_meniu=@tip_meniu, cantitate=@cantitate, TCantitate=@TCantitate, TNet=@TNet, TProteine=@TProteine, TLipide=@TLipide, TGlucide=@TGlucide, TCalorii=@TCalorii WHERE status = 'Alege' ";
                    string resetData4 = "UPDATE laptePreparateLapte SET status=@nume, tip_meniu=@tip_meniu, cantitate=@cantitate, TCantitate=@TCantitate, TNet=@TNet, TProteine=@TProteine, TLipide=@TLipide, TGlucide=@TGlucide, TCalorii=@TCalorii WHERE status = 'Alege' ";
                    string resetData5 = "UPDATE sucuriCompoturi SET status=@nume, tip_meniu=@tip_meniu, cantitate=@cantitate, TCantitate=@TCantitate, TNet=@TNet, TProteine=@TProteine, TLipide=@TLipide, TGlucide=@TGlucide, TCalorii=@TCalorii WHERE status = 'Alege' ";
                    string resetData6 = "UPDATE fructe SET status=@nume, tip_meniu=@tip_meniu, cantitate=@cantitate, TCantitate=@TCantitate, TNet=@TNet, TProteine=@TProteine, TLipide=@TLipide, TGlucide=@TGlucide, TCalorii=@TCalorii WHERE status = 'Alege' ";
                    string resetData7 = "UPDATE ulei SET status=@nume, tip_meniu=@tip_meniu, cantitate=@cantitate, TCantitate=@TCantitate, TNet=@TNet, TProteine=@TProteine, TLipide=@TLipide, TGlucide=@TGlucide, TCalorii=@TCalorii WHERE status = 'Alege' ";
                    string resetData8 = "UPDATE legumeConservate SET status=@nume, tip_meniu=@tip_meniu, cantitate=@cantitate, TCantitate=@TCantitate, TNet=@TNet, TProteine=@TProteine, TLipide=@TLipide, TGlucide=@TGlucide, TCalorii=@TCalorii WHERE status = 'Alege' ";
                    string resetData9 = "UPDATE legumeProaspete SET status=@nume, tip_meniu=@tip_meniu, cantitate=@cantitate, TCantitate=@TCantitate, TNet=@TNet, TProteine=@TProteine, TLipide=@TLipide, TGlucide=@TGlucide, TCalorii=@TCalorii WHERE status = 'Alege' ";
                    string resetData10 = "UPDATE fructeOleaginoase SET status=@nume, tip_meniu=@tip_meniu, cantitate=@cantitate, TCantitate=@TCantitate, TNet=@TNet, TProteine=@TProteine, TLipide=@TLipide, TGlucide=@TGlucide, TCalorii=@TCalorii WHERE status = 'Alege' ";
                    string resetData11 = "UPDATE cereale SET status=@nume, tip_meniu=@tip_meniu, cantitate=@cantitate, TCantitate=@TCantitate, TNet=@TNet, TProteine=@TProteine, TLipide=@TLipide, TGlucide=@TGlucide, TCalorii=@TCalorii WHERE status = 'Alege' ";
                    string resetData12 = "UPDATE oua SET status=@nume, tip_meniu=@tip_meniu, cantitate=@cantitate, TCantitate=@TCantitate, TNet=@TNet, TProteine=@TProteine, TLipide=@TLipide, TGlucide=@TGlucide, TCalorii=@TCalorii WHERE status = 'Alege' ";

                    using (SqlCommand cmd = new SqlCommand(resetData, connection))
                    {
                        cmd.Parameters.AddWithValue("@nume", "Nu aleg");
                        cmd.Parameters.AddWithValue("@tip_meniu", "");
                        cmd.Parameters.AddWithValue("@cantitate", 0.00);
                        cmd.Parameters.AddWithValue("@TCantitate", 0.00);
                        cmd.Parameters.AddWithValue("@TNet", 0.00);
                        cmd.Parameters.AddWithValue("@TProteine", 0.00);
                        cmd.Parameters.AddWithValue("@TLipide", 0.00);
                        cmd.Parameters.AddWithValue("@TGlucide", 0.00);
                        cmd.Parameters.AddWithValue("@TCalorii", 0.00);


                        var resetCommands = new List<SqlCommand>
                        {
                            new SqlCommand(resetData, connection),
                            new SqlCommand(resetData2, connection),
                            new SqlCommand(resetData3, connection),
                            new SqlCommand(resetData4, connection),
                            new SqlCommand(resetData5, connection),
                            new SqlCommand(resetData6, connection),
                            new SqlCommand(resetData7, connection),
                            new SqlCommand(resetData8, connection),
                            new SqlCommand(resetData9, connection),
                            new SqlCommand(resetData10, connection),
                            new SqlCommand(resetData11, connection),
                            new SqlCommand(resetData12, connection)
                        };
                        foreach (var command in resetCommands)
                        {
                            command.Parameters.AddWithValue("@nume", "Nu aleg");
                            command.Parameters.AddWithValue("@tip_meniu", "");
                            command.Parameters.AddWithValue("@cantitate", 0.00);
                            command.Parameters.AddWithValue("@TCantitate", 0.00);
                            command.Parameters.AddWithValue("@TNet", 0.00);
                            command.Parameters.AddWithValue("@TProteine", 0.00);
                            command.Parameters.AddWithValue("@TLipide", 0.00);
                            command.Parameters.AddWithValue("@TGlucide", 0.00);
                            command.Parameters.AddWithValue("@TCalorii", 0.00);
                            command.ExecuteNonQuery();
                        }

                        DisplayNecesarAlimente();


                        MessageBox.Show("Tabelul a fost resetat cu succes!", "Actualizare reusita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();

                        ProduseDerivateCereale pdc = new ProduseDerivateCereale();
                        pdc.dataProduseDerivateCereale.Refresh();
                        MicDejunAlimente mda = new MicDejunAlimente();
                        PranzAlimente pa = new PranzAlimente();
                        GustareAlimente ga = new GustareAlimente();
                        mda.TabelaMicDejun();
                        mda.StergeProdusDinMicDejun();
                        pa.TabelaPranz();
                        pa.StergePranz();
                        ga.TabelaGustare();
                        ga.StergeProdusGustare();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log it)
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                    RefreshData();
                }
        }
      
        private void reset_btn_Click(object sender, EventArgs e)
        {
            ReseteazaParametri();
        }       
    }
}
