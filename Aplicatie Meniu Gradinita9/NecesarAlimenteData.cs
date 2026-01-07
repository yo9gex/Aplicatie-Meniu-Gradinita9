using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicatie_Meniu_Gradinita9
{
    class NecesarAlimenteData
    {

        public string NumeProdus { get; set; }//0
        public decimal Cantitatea { get; set; }//1
        public string TipMeniu { get; set; }//2
        public string TCantitate { get; set; }//3
        public string TNet { get; set; }//4
        public string TProteine { get; set; }//5
        public string TLipide { get; set; }//6
        public string TGlucide { get; set; }//7
        public string TFier { get; set; }
        public string TCalciu { get; set; }      
        public string TCalorii { get; set; }//8
        public string Proteine { get; set; }
        public string Lipide { get; set; }
        public string Glucide { get; set; }
         
        public string Calorii { get; set; }

        string dbPath;
        string connectionString;
        SqlConnection connection;
        // SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");

        public List<NecesarAlimenteData> ListaNecesarAlimenteData()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $" Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            connection = new SqlConnection(connectionString);

            List<NecesarAlimenteData> produseList = new List<NecesarAlimenteData>();

            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM produseDerivateCereale WHERE status = 'Alege'  ";
                    


                    using (SqlCommand cmd = new SqlCommand(query, connection))                     
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            NecesarAlimenteData na = new NecesarAlimenteData();
                            na.NumeProdus = reader["nume"].ToString();
                            na.Cantitatea = (decimal)reader["cantitate"];
                            na.TipMeniu = reader["tip_meniu"].ToString();
                            na.TCantitate = reader["TCantitate"].ToString();
                            na.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            na.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            na.TFier = reader.IsDBNull(reader.GetOrdinal("TFier")) ? "0.00" : reader["TFier"].ToString();
                            na.TCalciu = reader.IsDBNull(reader.GetOrdinal("TCalciu")) ? "0.00" : reader["TCalciu"].ToString();
                            na.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            na.Proteine = reader.IsDBNull(reader.GetOrdinal("proteine")) ? "0.00" : reader["proteine"].ToString();
                            na.Lipide = reader.IsDBNull(reader.GetOrdinal("lipide")) ? "0.00" : reader["lipide"].ToString();
                            na.Glucide = reader.IsDBNull(reader.GetOrdinal("glucide")) ? "0.00" : reader["glucide"].ToString();
                            na.Calorii = reader.IsDBNull(reader.GetOrdinal("calorii")) ? "0.00" : reader["calorii"].ToString();

                            produseList.Add(na);
                        }
                    }
                  
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
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM oua WHERE status = 'Alege' ";


                    using (SqlCommand cmd = new SqlCommand(query, connection))


                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            NecesarAlimenteData na = new NecesarAlimenteData();
                            na.NumeProdus = reader["nume"].ToString();
                            na.Cantitatea = (decimal)reader["cantitate"];
                            na.TipMeniu = reader["tip_meniu"].ToString();
                            na.TCantitate = reader["TCantitate"].ToString();
                            na.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            na.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            na.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            na.Proteine = reader.IsDBNull(reader.GetOrdinal("proteine")) ? "0.00" : reader["proteine"].ToString();
                            na.Lipide = reader.IsDBNull(reader.GetOrdinal("lipide")) ? "0.00" : reader["lipide"].ToString();
                            na.Glucide = reader.IsDBNull(reader.GetOrdinal("glucide")) ? "0.00" : reader["glucide"].ToString();
                            na.Calorii = reader.IsDBNull(reader.GetOrdinal("calorii")) ? "0.00" : reader["calorii"].ToString();

                            produseList.Add(na);
                        }
                    }
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

            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM ulei WHERE status = 'Alege' ";


                    using (SqlCommand cmd = new SqlCommand(query, connection))


                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            NecesarAlimenteData na = new NecesarAlimenteData();
                            na.NumeProdus = reader["nume"].ToString();
                            na.Cantitatea = (decimal)reader["cantitate"];
                            na.TipMeniu = reader["tip_meniu"].ToString();
                            na.TCantitate = reader["TCantitate"].ToString();
                            na.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            na.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            na.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            na.Proteine = reader.IsDBNull(reader.GetOrdinal("proteine")) ? "0.00" : reader["proteine"].ToString();
                            na.Lipide = reader.IsDBNull(reader.GetOrdinal("lipide")) ? "0.00" : reader["lipide"].ToString();
                            na.Glucide = reader.IsDBNull(reader.GetOrdinal("glucide")) ? "0.00" : reader["glucide"].ToString();
                            na.Calorii = reader.IsDBNull(reader.GetOrdinal("calorii")) ? "0.00" : reader["calorii"].ToString();

                            produseList.Add(na);
                        }
                    }
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

            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM legumeConservate WHERE status = 'Alege' ";


                    using (SqlCommand cmd = new SqlCommand(query, connection))


                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            NecesarAlimenteData na = new NecesarAlimenteData();
                            na.NumeProdus = reader["nume"].ToString();
                            na.Cantitatea = (decimal)reader["cantitate"];
                            na.TipMeniu = reader["tip_meniu"].ToString();
                            na.TCantitate = reader["TCantitate"].ToString();
                            na.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            na.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            na.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            na.Proteine = reader.IsDBNull(reader.GetOrdinal("proteine")) ? "0.00" : reader["proteine"].ToString();
                            na.Lipide = reader.IsDBNull(reader.GetOrdinal("lipide")) ? "0.00" : reader["lipide"].ToString();
                            na.Glucide = reader.IsDBNull(reader.GetOrdinal("glucide")) ? "0.00" : reader["glucide"].ToString();
                            na.Calorii = reader.IsDBNull(reader.GetOrdinal("calorii")) ? "0.00" : reader["calorii"].ToString();

                            produseList.Add(na);
                        }
                    }
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

            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM produseZaharoase WHERE status = 'Alege' ";


                    using (SqlCommand cmd = new SqlCommand(query, connection))


                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            NecesarAlimenteData na = new NecesarAlimenteData();
                            na.NumeProdus = reader["nume"].ToString();
                            na.Cantitatea = (decimal)reader["cantitate"];
                            na.TipMeniu = reader["tip_meniu"].ToString();
                            na.TCantitate = reader["TCantitate"].ToString();
                            na.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            na.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            na.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            na.Proteine = reader.IsDBNull(reader.GetOrdinal("proteine")) ? "0.00" : reader["proteine"].ToString();
                            na.Lipide = reader.IsDBNull(reader.GetOrdinal("lipide")) ? "0.00" : reader["lipide"].ToString();
                            na.Glucide = reader.IsDBNull(reader.GetOrdinal("glucide")) ? "0.00" : reader["glucide"].ToString();
                            na.Calorii = reader.IsDBNull(reader.GetOrdinal("calorii")) ? "0.00" : reader["calorii"].ToString();

                            produseList.Add(na);
                        }
                    }
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

            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM carneProduseCarne WHERE status = 'Alege' ";


                    using (SqlCommand cmd = new SqlCommand(query, connection))


                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            NecesarAlimenteData na = new NecesarAlimenteData();
                            na.NumeProdus = reader["nume"].ToString();
                            na.Cantitatea = (decimal)reader["cantitate"];
                            na.TipMeniu = reader["tip_meniu"].ToString();
                            na.TCantitate = reader["TCantitate"].ToString();
                            na.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            na.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            na.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            na.Proteine = reader.IsDBNull(reader.GetOrdinal("proteine")) ? "0.00" : reader["proteine"].ToString();
                            na.Lipide = reader.IsDBNull(reader.GetOrdinal("lipide")) ? "0.00" : reader["lipide"].ToString();
                            na.Glucide = reader.IsDBNull(reader.GetOrdinal("glucide")) ? "0.00" : reader["glucide"].ToString();
                            na.Calorii = reader.IsDBNull(reader.GetOrdinal("calorii")) ? "0.00" : reader["calorii"].ToString();

                            produseList.Add(na);
                        }
                    }
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

            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM laptePreparateLapte WHERE status = 'Alege' ";


                    using (SqlCommand cmd = new SqlCommand(query, connection))


                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            NecesarAlimenteData na = new NecesarAlimenteData();
                            na.NumeProdus = reader["nume"].ToString();
                            na.Cantitatea = (decimal)reader["cantitate"];
                            na.TipMeniu = reader["tip_meniu"].ToString();
                            na.TCantitate = reader["TCantitate"].ToString();
                            na.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            na.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            na.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            na.Proteine = reader.IsDBNull(reader.GetOrdinal("proteine")) ? "0.00" : reader["proteine"].ToString();
                            na.Lipide = reader.IsDBNull(reader.GetOrdinal("lipide")) ? "0.00" : reader["lipide"].ToString();
                            na.Glucide = reader.IsDBNull(reader.GetOrdinal("glucide")) ? "0.00" : reader["glucide"].ToString();
                            na.Calorii = reader.IsDBNull(reader.GetOrdinal("calorii")) ? "0.00" : reader["calorii"].ToString();

                            produseList.Add(na);
                        }
                    }
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

            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM sucuriCompoturi WHERE status = 'Alege' ";


                    using (SqlCommand cmd = new SqlCommand(query, connection))


                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            NecesarAlimenteData na = new NecesarAlimenteData();
                            na.NumeProdus = reader["nume"].ToString();
                            na.Cantitatea = (decimal)reader["cantitate"];
                            na.TipMeniu = reader["tip_meniu"].ToString();
                            na.TCantitate = reader["TCantitate"].ToString();
                            na.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            na.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            na.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            na.Proteine = reader.IsDBNull(reader.GetOrdinal("proteine")) ? "0.00" : reader["proteine"].ToString();
                            na.Lipide = reader.IsDBNull(reader.GetOrdinal("lipide")) ? "0.00" : reader["lipide"].ToString();
                            na.Glucide = reader.IsDBNull(reader.GetOrdinal("glucide")) ? "0.00" : reader["glucide"].ToString();
                            na.Calorii = reader.IsDBNull(reader.GetOrdinal("calorii")) ? "0.00" : reader["calorii"].ToString();

                            produseList.Add(na);
                        }
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
                }
            }
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM fructe WHERE status = 'Alege' ";


                    using (SqlCommand cmd = new SqlCommand(query, connection))


                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            NecesarAlimenteData na = new NecesarAlimenteData();
                            na.NumeProdus = reader["nume"].ToString();
                            na.Cantitatea = (decimal)reader["cantitate"];
                            na.TipMeniu = reader["tip_meniu"].ToString();
                            na.TCantitate = reader["TCantitate"].ToString();
                            na.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            na.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            na.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            na.Proteine = reader.IsDBNull(reader.GetOrdinal("proteine")) ? "0.00" : reader["proteine"].ToString();
                            na.Lipide = reader.IsDBNull(reader.GetOrdinal("lipide")) ? "0.00" : reader["lipide"].ToString();
                            na.Glucide = reader.IsDBNull(reader.GetOrdinal("glucide")) ? "0.00" : reader["glucide"].ToString();
                            na.Calorii = reader.IsDBNull(reader.GetOrdinal("calorii")) ? "0.00" : reader["calorii"].ToString();

                            produseList.Add(na);
                        }
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
                }
            }
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM legumeProaspete WHERE status = 'Alege' ";


                    using (SqlCommand cmd = new SqlCommand(query, connection))


                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            NecesarAlimenteData na = new NecesarAlimenteData();
                            na.NumeProdus = reader["nume"].ToString();
                            na.Cantitatea = (decimal)reader["cantitate"];
                            na.TipMeniu = reader["tip_meniu"].ToString();
                            na.TCantitate = reader["TCantitate"].ToString();
                            na.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            na.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            na.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            na.Proteine = reader.IsDBNull(reader.GetOrdinal("proteine")) ? "0.00" : reader["proteine"].ToString();
                            na.Lipide = reader.IsDBNull(reader.GetOrdinal("lipide")) ? "0.00" : reader["lipide"].ToString();
                            na.Glucide = reader.IsDBNull(reader.GetOrdinal("glucide")) ? "0.00" : reader["glucide"].ToString();
                            na.Calorii = reader.IsDBNull(reader.GetOrdinal("calorii")) ? "0.00" : reader["calorii"].ToString();

                            produseList.Add(na);
                        }
                    }
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
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM fructeOleaginoase WHERE status = 'Alege' ";


                    using (SqlCommand cmd = new SqlCommand(query, connection))


                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            NecesarAlimenteData na = new NecesarAlimenteData();
                            na.NumeProdus = reader["nume"].ToString();
                            na.Cantitatea = (decimal)reader["cantitate"];
                            na.TipMeniu = reader["tip_meniu"].ToString();
                            na.TCantitate = reader["TCantitate"].ToString();
                            na.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            na.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            na.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            na.Proteine = reader.IsDBNull(reader.GetOrdinal("proteine")) ? "0.00" : reader["proteine"].ToString();
                            na.Lipide = reader.IsDBNull(reader.GetOrdinal("lipide")) ? "0.00" : reader["lipide"].ToString();
                            na.Glucide = reader.IsDBNull(reader.GetOrdinal("glucide")) ? "0.00" : reader["glucide"].ToString();
                            na.Calorii = reader.IsDBNull(reader.GetOrdinal("calorii")) ? "0.00" : reader["calorii"].ToString();

                            produseList.Add(na);
                        }
                    }
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
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM cereale WHERE status = 'Alege' ";


                    using (SqlCommand cmd = new SqlCommand(query, connection))


                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            NecesarAlimenteData na = new NecesarAlimenteData();
                            na.NumeProdus = reader["nume"].ToString();
                            na.Cantitatea = (decimal)reader["cantitate"];
                            na.TipMeniu = reader["tip_meniu"].ToString();
                            na.TCantitate = reader["TCantitate"].ToString();
                            na.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            na.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            na.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            na.Proteine = reader.IsDBNull(reader.GetOrdinal("proteine")) ? "0.00" : reader["proteine"].ToString();
                            na.Lipide = reader.IsDBNull(reader.GetOrdinal("lipide")) ? "0.00" : reader["lipide"].ToString();
                            na.Glucide = reader.IsDBNull(reader.GetOrdinal("glucide")) ? "0.00" : reader["glucide"].ToString();
                            na.Calorii = reader.IsDBNull(reader.GetOrdinal("calorii")) ? "0.00" : reader["calorii"].ToString();

                            produseList.Add(na);
                        }
                    }
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
            return produseList;
        }

    }
   
    }
