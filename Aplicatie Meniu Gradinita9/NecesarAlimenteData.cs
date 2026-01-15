using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
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
        public string TProteine_veg { get; set; }//6
        public string TProteine_anim { get; set; }//7
        public string TLipide { get; set; }//8 6
        public string TLipide_veg { get; set; }//9
        public string TLipide_anim { get; set; }//10
        public string TGlucide { get; set; }//11 7
        public string TFier { get; set; }//12 8
        public string TCalciu { get; set; }  //13 9    
        public string TCalorii { get; set; } //14 10
        public string Proteine { get; set; }
        public string Lipide { get; set; }
        public string Glucide { get; set; }
         
        public string Calorii { get; set; }
        public string TCoeficient1 { get; set; }
        public string TCoeficient2 { get; set; }

        string dbPath;
        string connectionString;
        SqlConnection connection;
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
                            na.TProteine_veg = reader.IsDBNull(reader.GetOrdinal("TProteineVegetale")) ? "0.00" : reader["TProteineVegetale"].ToString();
                            na.TProteine_anim = reader.IsDBNull(reader.GetOrdinal("TProteineAnimale")) ? "0.00" : reader["TProteineAnimale"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TLipide_veg = reader.IsDBNull(reader.GetOrdinal("TLipideVegetale")) ? "0.00" : reader["TLipideVegetale"].ToString();
                            na.TLipide_anim = reader.IsDBNull(reader.GetOrdinal("TLipideAnimale")) ? "0.00" : reader["TLipideAnimale"].ToString();
                            na.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            na.TFier = reader.IsDBNull(reader.GetOrdinal("TFier")) ? "0.00" : reader["TFier"].ToString();
                            na.TCalciu = reader.IsDBNull(reader.GetOrdinal("TCalciu")) ? "0.00" : reader["TCalciu"].ToString();
                            na.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            na.Proteine = reader.IsDBNull(reader.GetOrdinal("proteine")) ? "0.00" : reader["proteine"].ToString();
                            na.Lipide = reader.IsDBNull(reader.GetOrdinal("lipide")) ? "0.00" : reader["lipide"].ToString();
                            na.Glucide = reader.IsDBNull(reader.GetOrdinal("glucide")) ? "0.00" : reader["glucide"].ToString();
                            na.Calorii = reader.IsDBNull(reader.GetOrdinal("calorii")) ? "0.00" : reader["calorii"].ToString();
                            na.TCoeficient1 = reader.IsDBNull(reader.GetOrdinal("TCoeficient1")) ? "0.00" : reader["TCoeficient1"].ToString();
                            na.TCoeficient2 = reader.IsDBNull(reader.GetOrdinal("TCoeficient2")) ? "0.00" : reader["TCoeficient2"].ToString();


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
                            na.TProteine_veg = reader.IsDBNull(reader.GetOrdinal("TProteineVegetale")) ? "0.00" : reader["TProteineVegetale"].ToString();
                            na.TProteine_anim = reader.IsDBNull(reader.GetOrdinal("TProteineAnimale")) ? "0.00" : reader["TProteineAnimale"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TLipide_veg = reader.IsDBNull(reader.GetOrdinal("TLipideVegetale")) ? "0.00" : reader["TLipideVegetale"].ToString();
                            na.TLipide_anim = reader.IsDBNull(reader.GetOrdinal("TLipideAnimale")) ? "0.00" : reader["TLipideAnimale"].ToString();
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
                            na.TProteine_veg = reader.IsDBNull(reader.GetOrdinal("TProteineVegetale")) ? "0.00" : reader["TProteineVegetale"].ToString();
                            na.TProteine_anim = reader.IsDBNull(reader.GetOrdinal("TProteineAnimale")) ? "0.00" : reader["TProteineAnimale"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TLipide_veg = reader.IsDBNull(reader.GetOrdinal("TLipideVegetale")) ? "0.00" : reader["TLipideVegetale"].ToString();
                            na.TLipide_anim = reader.IsDBNull(reader.GetOrdinal("TLipideAnimale")) ? "0.00" : reader["TLipideAnimale"].ToString();
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
                            na.TProteine_veg = reader.IsDBNull(reader.GetOrdinal("TProteineVegetale")) ? "0.00" : reader["TProteineVegetale"].ToString();
                            na.TProteine_anim = reader.IsDBNull(reader.GetOrdinal("TProteineAnimale")) ? "0.00" : reader["TProteineAnimale"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TLipide_veg = reader.IsDBNull(reader.GetOrdinal("TLipideVegetale")) ? "0.00" : reader["TLipideVegetale"].ToString();
                            na.TLipide_anim = reader.IsDBNull(reader.GetOrdinal("TLipideAnimale")) ? "0.00" : reader["TLipideAnimale"].ToString();
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
                            na.TProteine_veg = reader.IsDBNull(reader.GetOrdinal("TProteineVegetale")) ? "0.00" : reader["TProteineVegetale"].ToString();
                            na.TProteine_anim = reader.IsDBNull(reader.GetOrdinal("TProteineAnimale")) ? "0.00" : reader["TProteineAnimale"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TLipide_veg = reader.IsDBNull(reader.GetOrdinal("TLipideVegetale")) ? "0.00" : reader["TLipideVegetale"].ToString();
                            na.TLipide_anim = reader.IsDBNull(reader.GetOrdinal("TLipideAnimale")) ? "0.00" : reader["TLipideAnimale"].ToString();
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
                            na.TProteine_veg = reader.IsDBNull(reader.GetOrdinal("TProteineVegetale")) ? "0.00" : reader["TProteineVegetale"].ToString();
                            na.TProteine_anim = reader.IsDBNull(reader.GetOrdinal("TProteineAnimale")) ? "0.00" : reader["TProteineAnimale"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TLipide_veg = reader.IsDBNull(reader.GetOrdinal("TLipideVegetale")) ? "0.00" : reader["TLipideVegetale"].ToString();
                            na.TLipide_anim = reader.IsDBNull(reader.GetOrdinal("TLipideAnimale")) ? "0.00" : reader["TLipideAnimale"].ToString();
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
                            na.TProteine_veg = reader.IsDBNull(reader.GetOrdinal("TProteineVegetale")) ? "0.00" : reader["TProteineVegetale"].ToString();
                            na.TProteine_anim = reader.IsDBNull(reader.GetOrdinal("TProteineAnimale")) ? "0.00" : reader["TProteineAnimale"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TLipide_veg = reader.IsDBNull(reader.GetOrdinal("TLipideVegetale")) ? "0.00" : reader["TLipideVegetale"].ToString();
                            na.TLipide_anim = reader.IsDBNull(reader.GetOrdinal("TLipideAnimale")) ? "0.00" : reader["TLipideAnimale"].ToString();
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
                            na.TProteine_veg = reader.IsDBNull(reader.GetOrdinal("TProteineVegetale")) ? "0.00" : reader["TProteineVegetale"].ToString();
                            na.TProteine_anim = reader.IsDBNull(reader.GetOrdinal("TProteineAnimale")) ? "0.00" : reader["TProteineAnimale"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TLipide_veg = reader.IsDBNull(reader.GetOrdinal("TLipideVegetale")) ? "0.00" : reader["TLipideVegetale"].ToString();
                            na.TLipide_anim = reader.IsDBNull(reader.GetOrdinal("TLipideAnimale")) ? "0.00" : reader["TLipideAnimale"].ToString();
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
                            na.TProteine_veg = reader.IsDBNull(reader.GetOrdinal("TProteineVegetale")) ? "0.00" : reader["TProteineVegetale"].ToString();
                            na.TProteine_anim = reader.IsDBNull(reader.GetOrdinal("TProteineAnimale")) ? "0.00" : reader["TProteineAnimale"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TLipide_veg = reader.IsDBNull(reader.GetOrdinal("TLipideVegetale")) ? "0.00" : reader["TLipideVegetale"].ToString();
                            na.TLipide_anim = reader.IsDBNull(reader.GetOrdinal("TLipideAnimale")) ? "0.00" : reader["TLipideAnimale"].ToString();
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
                            na.TProteine_veg = reader.IsDBNull(reader.GetOrdinal("TProteineVegetale")) ? "0.00" : reader["TProteineVegetale"].ToString();
                            na.TProteine_anim = reader.IsDBNull(reader.GetOrdinal("TProteineAnimale")) ? "0.00" : reader["TProteineAnimale"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TLipide_veg = reader.IsDBNull(reader.GetOrdinal("TLipideVegetale")) ? "0.00" : reader["TLipideVegetale"].ToString();
                            na.TLipide_anim = reader.IsDBNull(reader.GetOrdinal("TLipideAnimale")) ? "0.00" : reader["TLipideAnimale"].ToString();
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
                            na.TProteine_veg = reader.IsDBNull(reader.GetOrdinal("TProteineVegetale")) ? "0.00" : reader["TProteineVegetale"].ToString();
                            na.TProteine_anim = reader.IsDBNull(reader.GetOrdinal("TProteineAnimale")) ? "0.00" : reader["TProteineAnimale"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TLipide_veg = reader.IsDBNull(reader.GetOrdinal("TLipideVegetale")) ? "0.00" : reader["TLipideVegetale"].ToString();
                            na.TLipide_anim = reader.IsDBNull(reader.GetOrdinal("TLipideAnimale")) ? "0.00" : reader["TLipideAnimale"].ToString();
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

                    string query = "SELECT * FROM peste WHERE status = 'Alege' ";


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
                            na.TProteine_veg = reader.IsDBNull(reader.GetOrdinal("TProteineVegetale")) ? "0.00" : reader["TProteineVegetale"].ToString();
                            na.TProteine_anim = reader.IsDBNull(reader.GetOrdinal("TProteineAnimale")) ? "0.00" : reader["TProteineAnimale"].ToString();
                            na.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            na.TLipide_veg = reader.IsDBNull(reader.GetOrdinal("TLipideVegetale")) ? "0.00" : reader["TLipideVegetale"].ToString();
                            na.TLipide_anim = reader.IsDBNull(reader.GetOrdinal("TLipideAnimale")) ? "0.00" : reader["TLipideAnimale"].ToString();
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
            return produseList;
        }

    }
   
    }
