using System.Data;
using System.Data.SqlClient;

namespace Aplicatie_Meniu_Gradinita9
{
    class MicDejunAlimenteDataActualizate
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

        // SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30");
        // SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
        string dbPath;
        string connectionString;
        SqlConnection connection;

        public List<MicDejunAlimenteDataActualizate> ListaMicDejunAlimeteDataActualizate()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
            connection = new SqlConnection(connectionString);

            List<MicDejunAlimenteDataActualizate> produseList = new List<MicDejunAlimenteDataActualizate>();
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM totalAlimenteMicDejun WHERE status = 'Alege' AND (tip_meniu = 'MD' OR tip_meniu = 'MD+P' OR tip_meniu = 'MD+G') ";


                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            MicDejunAlimenteDataActualizate mda = new MicDejunAlimenteDataActualizate();
                            mda.NumeProdus = reader["nume"].ToString();
                            mda.Cantitatea = (decimal)reader["cantitate"];
                            mda.TCantitatea = reader["TCantitate"].ToString();
                            mda.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            mda.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                            mda.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                            mda.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                            mda.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                            mda.TipMeniu = reader["tip_meniu"].ToString();
                            mda.Status = reader["status"].ToString();
                            produseList.Add(mda);
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
