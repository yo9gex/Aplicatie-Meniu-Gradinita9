using System.Data.SqlClient;


namespace Aplicatie_Meniu_Gradinita9
{
    class CaloriiTotaleData
    {
        public string Data { get; set; }
        public string NecesarMinim { get; set; }
        public string NecesarMaxim { get; set; }
        public string TotalCalorii { get; set; }

        
        string dbPath;
        string connectionString;
        SqlConnection connect;
     

        public List<CaloriiTotaleData> ListaData()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
            connect = new SqlConnection(connectionString);

            List<CaloriiTotaleData> dataList = new List<CaloriiTotaleData>();
            try
            {
                connect.Open();
                string query = "SELECT data_adaugare, necesar_minim_calorii, necesar_maxim_calorii, total_calorii FROM calorii";
                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CaloriiTotaleData data = new CaloriiTotaleData();
                    data.Data = Convert.ToDateTime(reader["data_adaugare"]).ToString("dd/MM/yyyy ");
                    data.NecesarMinim = reader.IsDBNull(reader.GetOrdinal("necesar_minim_calorii")) ? "0.00" : reader["necesar_minim_calorii"].ToString();
                    data.NecesarMaxim = reader.IsDBNull(reader.GetOrdinal("necesar_maxim_calorii")) ? "0.00" : reader["necesar_maxim_calorii"].ToString();
                    data.TotalCalorii = reader.IsDBNull(reader.GetOrdinal("total_calorii")) ? "0.00" : reader["total_calorii"].ToString();
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
                connect.Close();
            }
            return dataList;
        }
    }
}
