using System.Data;
using Microsoft.Data.SqlClient;

namespace Aplicatie_Meniu_Gradinita9
{
    class PranzAlimenteData
    {
        public string NumeProdus { get; set; }//0
        public string TCantitatea { get; set; }//1
        public string TNet { get; set; }//2
        public string TProteine { get; set; }//3
        public string TLipide { get; set; }//4
        public string TGlucide { get; set; }//5
        public string TCalorii { get; set; }//6
        public string TipMeniu { get; set; }//7
        public string TipFel { get; set; }//8


        string dbPath;
        string connectionString;
        SqlConnection connection;
        public PranzAlimenteData()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
            connection = new SqlConnection(connectionString);
        }
        public List<PranzAlimenteData> ListaPranzAlimenteData()
        {
            List<PranzAlimenteData> produseList = new List<PranzAlimenteData>();
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM produseDerivateCereale WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'MD+P' OR tip_meniu = 'G+P') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            PranzAlimenteData pad = new PranzAlimenteData();
                            pad.NumeProdus = reader["nume"].ToString();
                            pad.TCantitatea = reader["TCantitate"].ToString();
                            pad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            pad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            pad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            pad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            pad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            pad.TipMeniu = reader["tip_meniu"].ToString();
                            pad.TipFel = reader["tip_fel"].ToString();
                            produseList.Add(pad);
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
            } // produseDerivateCereale
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM laptePreparateLapte WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'MD+P' OR tip_meniu = 'G+P') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            PranzAlimenteData pad = new PranzAlimenteData();
                            pad.NumeProdus = reader["nume"].ToString();
                            pad.TCantitatea = reader["TCantitate"].ToString();
                            pad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            pad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            pad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            pad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            pad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            pad.TipMeniu = reader["tip_meniu"].ToString();
                            pad.TipFel = reader["tip_fel"].ToString();
                            produseList.Add(pad);
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
            } // laptePreparateLapte
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM carneProduseCarne WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'MD+P' OR tip_meniu = 'G+P') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            PranzAlimenteData pad = new PranzAlimenteData();
                            pad.NumeProdus = reader["nume"].ToString();
                            pad.TCantitatea = reader["TCantitate"].ToString();
                            pad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            pad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            pad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            pad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            pad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            pad.TipMeniu = reader["tip_meniu"].ToString();
                            pad.TipFel = reader["tip_fel"].ToString();
                            produseList.Add(pad);
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
            } // carneProduseCarne
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM peste WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'MD+P' OR tip_meniu = 'G+P') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            PranzAlimenteData pad = new PranzAlimenteData();
                            pad.NumeProdus = reader["nume"].ToString();
                            pad.TCantitatea = reader["TCantitate"].ToString();
                            pad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            pad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            pad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            pad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            pad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            pad.TipMeniu = reader["tip_meniu"].ToString();
                            pad.TipFel = reader["tip_fel"].ToString();
                            produseList.Add(pad);
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
            } // peste
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM fructe WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'MD+P' OR tip_meniu = 'G+P') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            PranzAlimenteData pad = new PranzAlimenteData();
                            pad.NumeProdus = reader["nume"].ToString();
                            pad.TCantitatea = reader["TCantitate"].ToString();
                            pad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            pad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            pad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            pad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            pad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            pad.TipMeniu = reader["tip_meniu"].ToString();
                            pad.TipFel = reader["tip_fel"].ToString();
                            produseList.Add(pad);
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
            } // fructe
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM fructeOleaginoase WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'MD+P' OR tip_meniu = 'G+P') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            PranzAlimenteData pad = new PranzAlimenteData();
                            pad.NumeProdus = reader["nume"].ToString();
                            pad.TCantitatea = reader["TCantitate"].ToString();
                            pad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            pad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            pad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            pad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            pad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            pad.TipMeniu = reader["tip_meniu"].ToString();
                            pad.TipFel = reader["tip_fel"].ToString();
                            produseList.Add(pad);
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
            } // fructeOleaginoase
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM legumeConservate WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'MD+P' OR tip_meniu = 'G+P') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            PranzAlimenteData pad = new PranzAlimenteData();
                            pad.NumeProdus = reader["nume"].ToString();
                            pad.TCantitatea = reader["TCantitate"].ToString();
                            pad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            pad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            pad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            pad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            pad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            pad.TipMeniu = reader["tip_meniu"].ToString();
                            pad.TipFel = reader["tip_fel"].ToString();
                            produseList.Add(pad);
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
            } // legumeConservate
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM legumeProaspete WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'MD+P' OR tip_meniu = 'G+P') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            PranzAlimenteData pad = new PranzAlimenteData();
                            pad.NumeProdus = reader["nume"].ToString();
                            pad.TCantitatea = reader["TCantitate"].ToString();
                            pad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            pad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            pad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            pad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            pad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            pad.TipMeniu = reader["tip_meniu"].ToString();
                            pad.TipFel = reader["tip_fel"].ToString();
                            produseList.Add(pad);
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
            } // legumeproaspete
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM oua WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'MD+P' OR tip_meniu = 'G+P') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            PranzAlimenteData pad = new PranzAlimenteData();
                            pad.NumeProdus = reader["nume"].ToString();
                            pad.TCantitatea = reader["TCantitate"].ToString();
                            pad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            pad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            pad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            pad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            pad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            pad.TipMeniu = reader["tip_meniu"].ToString();
                            pad.TipFel = reader["tip_fel"].ToString();
                            produseList.Add(pad);
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
            } // oua
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM produseZaharoase WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'MD+P' OR tip_meniu = 'G+P') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            PranzAlimenteData pad = new PranzAlimenteData();
                            pad.NumeProdus = reader["nume"].ToString();
                            pad.TCantitatea = reader["TCantitate"].ToString();
                            pad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            pad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            pad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            pad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            pad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            pad.TipMeniu = reader["tip_meniu"].ToString();
                            pad.TipFel = reader["tip_fel"].ToString();
                            produseList.Add(pad);
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
            } // produseZaharoase
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM sucuriCompoturi WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'MD+P' OR tip_meniu = 'G+P') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            PranzAlimenteData pad = new PranzAlimenteData();
                            pad.NumeProdus = reader["nume"].ToString();
                            pad.TCantitatea = reader["TCantitate"].ToString();
                            pad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            pad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            pad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            pad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            pad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            pad.TipMeniu = reader["tip_meniu"].ToString();
                            pad.TipFel = reader["tip_fel"].ToString();
                            produseList.Add(pad);
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
            } // sucuriCompoturi
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM ulei WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'MD+P' OR tip_meniu = 'G+P') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            PranzAlimenteData pad = new PranzAlimenteData();
                            pad.NumeProdus = reader["nume"].ToString();
                            pad.TCantitatea = reader["TCantitate"].ToString();
                            pad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            pad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            pad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            pad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            pad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            pad.TipMeniu = reader["tip_meniu"].ToString();
                            pad.TipFel = reader["tip_fel"].ToString();
                            produseList.Add(pad);
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
            } // ulei
            return produseList;
        }
    }
}
