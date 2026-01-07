using System.Data;
using System.Data.SqlClient;

namespace Aplicatie_Meniu_Gradinita9
{
    class GustareAlimenteData
    {
        public string NumeProdus { get; set; }//0
        public decimal Cantitatea { get; set; }//1
        public string TCantitatea { get; set; }//3
        public string TNet { get; set; }//3
        public string TProteine { get; set; }//4
        public string TLipide { get; set; }//5
        public string TGlucide { get; set; }//6
        public string TCalorii { get; set; }//7
        public string TipMeniu { get; set; }//8
        public string Status { get; set; }//9


        // SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30");

        // SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
        string dbPath;
        string connectionString;
        SqlConnection connection;
        public GustareAlimenteData()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        public List<GustareAlimenteData> ListaGustareAlimenteData()
        {
          

            List<GustareAlimenteData> produseList = new List<GustareAlimenteData>();
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM produseDerivateCereale WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'P+G' OR tip_meniu = 'MD+G') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            GustareAlimenteData gad = new GustareAlimenteData();
                            gad.NumeProdus = reader["nume"].ToString();
                            gad.TCantitatea = reader["TCantitate"].ToString();
                            gad.Cantitatea = (decimal)reader["cantitate"];
                            gad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            gad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            gad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            gad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            gad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            gad.TipMeniu = reader["tip_meniu"].ToString();
                            gad.Status = reader["status"].ToString();
                            produseList.Add(gad);

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
                    string query = "SELECT * FROM laptePreparateLapte WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'P+G' OR tip_meniu = 'MD+G') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            GustareAlimenteData gad = new GustareAlimenteData();
                            gad.NumeProdus = reader["nume"].ToString();
                            gad.TCantitatea = reader["TCantitate"].ToString();
                            gad.Cantitatea = (decimal)reader["cantitate"];
                            gad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            gad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            gad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            gad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            gad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            gad.TipMeniu = reader["tip_meniu"].ToString();
                            gad.Status = reader["status"].ToString();
                            produseList.Add(gad);

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
                    string query = "SELECT * FROM carneProduseCarne WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'P+G' OR tip_meniu = 'MD+G') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            GustareAlimenteData gad = new GustareAlimenteData();
                            gad.NumeProdus = reader["nume"].ToString();
                            gad.TCantitatea = reader["TCantitate"].ToString();
                            gad.Cantitatea = (decimal)reader["cantitate"];
                            gad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            gad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            gad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            gad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            gad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            gad.TipMeniu = reader["tip_meniu"].ToString();
                            gad.Status = reader["status"].ToString();
                            produseList.Add(gad);

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
                    string query = "SELECT * FROM cereale WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'P+G' OR tip_meniu = 'MD+G') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            GustareAlimenteData gad = new GustareAlimenteData();
                            gad.NumeProdus = reader["nume"].ToString();
                            gad.TCantitatea = reader["TCantitate"].ToString();
                            gad.Cantitatea = (decimal)reader["cantitate"];
                            gad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            gad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            gad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            gad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            gad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            gad.TipMeniu = reader["tip_meniu"].ToString();
                            gad.Status = reader["status"].ToString();
                            produseList.Add(gad);

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
            } // cereale
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM fructe WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'P+G' OR tip_meniu = 'MD+G') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            GustareAlimenteData gad = new GustareAlimenteData();
                            gad.NumeProdus = reader["nume"].ToString();
                            gad.TCantitatea = reader["TCantitate"].ToString();
                            gad.Cantitatea = (decimal)reader["cantitate"];
                            gad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            gad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            gad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            gad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            gad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            gad.TipMeniu = reader["tip_meniu"].ToString();
                            gad.Status = reader["status"].ToString();
                            produseList.Add(gad);

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
                    string query = "SELECT * FROM fructeOleaginoase WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'P+G' OR tip_meniu = 'MD+G') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            GustareAlimenteData gad = new GustareAlimenteData();
                            gad.NumeProdus = reader["nume"].ToString();
                            gad.TCantitatea = reader["TCantitate"].ToString();
                            gad.Cantitatea = (decimal)reader["cantitate"];
                            gad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            gad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            gad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            gad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            gad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            gad.TipMeniu = reader["tip_meniu"].ToString();
                            gad.Status = reader["status"].ToString();
                            produseList.Add(gad);

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
                    string query = "SELECT * FROM legumeConservate WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'P+G' OR tip_meniu = 'MD+G') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            GustareAlimenteData gad = new GustareAlimenteData();
                            gad.NumeProdus = reader["nume"].ToString();
                            gad.TCantitatea = reader["TCantitate"].ToString();
                            gad.Cantitatea = (decimal)reader["cantitate"];
                            gad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            gad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            gad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            gad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            gad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            gad.TipMeniu = reader["tip_meniu"].ToString();
                            gad.Status = reader["status"].ToString();
                            produseList.Add(gad);

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
                    string query = "SELECT * FROM legumeProaspete WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'P+G' OR tip_meniu = 'MD+G') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            GustareAlimenteData gad = new GustareAlimenteData();
                            gad.NumeProdus = reader["nume"].ToString();
                            gad.TCantitatea = reader["TCantitate"].ToString();
                            gad.Cantitatea = (decimal)reader["cantitate"];
                            gad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            gad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            gad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            gad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            gad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            gad.TipMeniu = reader["tip_meniu"].ToString();
                            gad.Status = reader["status"].ToString();
                            produseList.Add(gad);

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
            } // legumeProaspete
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM oua WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'P+G' OR tip_meniu = 'MD+G') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            GustareAlimenteData gad = new GustareAlimenteData();
                            gad.NumeProdus = reader["nume"].ToString();
                            gad.TCantitatea = reader["TCantitate"].ToString();
                            gad.Cantitatea = (decimal)reader["cantitate"];
                            gad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            gad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            gad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            gad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            gad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            gad.TipMeniu = reader["tip_meniu"].ToString();
                            gad.Status = reader["status"].ToString();
                            produseList.Add(gad);

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
                    string query = "SELECT * FROM produseZaharoase WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'P+G' OR tip_meniu = 'MD+G') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            GustareAlimenteData gad = new GustareAlimenteData();
                            gad.NumeProdus = reader["nume"].ToString();
                            gad.TCantitatea = reader["TCantitate"].ToString();
                            gad.Cantitatea = (decimal)reader["cantitate"];
                            gad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            gad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            gad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            gad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            gad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            gad.TipMeniu = reader["tip_meniu"].ToString();
                            gad.Status = reader["status"].ToString();
                            produseList.Add(gad);

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
                    string query = "SELECT * FROM sucuriCompoturi WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'P+G' OR tip_meniu = 'MD+G') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            GustareAlimenteData gad = new GustareAlimenteData();
                            gad.NumeProdus = reader["nume"].ToString();
                            gad.TCantitatea = reader["TCantitate"].ToString();
                            gad.Cantitatea = (decimal)reader["cantitate"];
                            gad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            gad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            gad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            gad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            gad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            gad.TipMeniu = reader["tip_meniu"].ToString();
                            gad.Status = reader["status"].ToString();
                            produseList.Add(gad);

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
                    string query = "SELECT * FROM ulei WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'P+G' OR tip_meniu = 'MD+G') ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            GustareAlimenteData gad = new GustareAlimenteData();
                            gad.NumeProdus = reader["nume"].ToString();
                            gad.TCantitatea = reader["TCantitate"].ToString();
                            gad.Cantitatea = (decimal)reader["cantitate"];
                            gad.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            gad.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            gad.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            gad.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            gad.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            gad.TipMeniu = reader["tip_meniu"].ToString();
                            gad.Status = reader["status"].ToString();
                            produseList.Add(gad);

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
