using System.Data.SqlClient;

namespace Aplicatie_Meniu_Gradinita9
{
    class GlucideTotaleData
    {
        public string Data { get; set; }
        public string NecesarMinim { get; set; }
        public string NecesarMaxim { get; set; }
        public string TotalGlucide { get; set; }

        //SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30");
        //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
        string dbPath;
        string connectionString;
        SqlConnection connection;
        public GlucideTotaleData()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }
        public List<GlucideTotaleData> ListaData()
        {
           

            List<GlucideTotaleData> dataList = new List<GlucideTotaleData>();
            try
            {
                connection.Open();
                string query = "SELECT data_adaugare, necesar_minim_glucide, necesar_maxim_glucide, total_glucide FROM glucide";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GlucideTotaleData data = new GlucideTotaleData();
                    data.Data = Convert.ToDateTime(reader["data_adaugare"]).ToString("dd/MM/yyyy ");
                    data.NecesarMinim = reader.IsDBNull(reader.GetOrdinal("necesar_minim_glucide")) ? "0.00" : reader["necesar_minim_glucide"].ToString();
                    data.NecesarMaxim = reader.IsDBNull(reader.GetOrdinal("necesar_maxim_glucide")) ? "0.00" : reader["necesar_maxim_glucide"].ToString();
                    data.TotalGlucide = reader.IsDBNull(reader.GetOrdinal("total_glucide")) ? "0.00" : reader["total_glucide"].ToString();
                    dataList.Add(data);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                connection.Close();
            }
            return dataList;
        }
    }
}
