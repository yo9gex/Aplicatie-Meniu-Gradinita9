using System.Data;
using System.Data.SqlClient;

namespace Aplicatie_Meniu_Gradinita9
{
    class GustareAlimenteDataActualizate
    {

        public string NumeProdus { get; set; }//0
        public decimal Cantitatea { get; set; }//1
        public string TCantitatea { get; set; }//2
        public string TNet { get; set; }//3
        public string TProteine { get; set; }//4
        public string TLipide { get; set; }//5
        public string TGlucide { get; set; }//6
        public string TCalorii { get; set; }//7
        public string TipMeniu { get; set; }//8
        public string Status { get; set; }//9

        string dbPath;
        string connectionString;
        SqlConnection connection;
        public GustareAlimenteDataActualizate()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }
        public List<GustareAlimenteDataActualizate> ListaGustareAlimeteDataActualizate()
        {        
            List<GustareAlimenteDataActualizate> produseList = new List<GustareAlimenteDataActualizate>();
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM totalAlimenteGustare WHERE status = 'Alege' AND (tip_meniu = 'G' OR tip_meniu = 'G+P' OR tip_meniu = 'MD+G') ";


                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            GustareAlimenteDataActualizate gada = new GustareAlimenteDataActualizate();
                            gada.NumeProdus = reader["nume"].ToString();
                            gada.Cantitatea = (decimal)reader["cantitate"];
                            gada.TCantitatea = reader["TCantitate"].ToString();
                            gada.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            gada.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            gada.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            gada.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            gada.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            gada.TipMeniu = reader["tip_meniu"].ToString();
                            gada.Status = reader["status"].ToString();
                            produseList.Add(gada);
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
