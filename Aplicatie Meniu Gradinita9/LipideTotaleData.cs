using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;


namespace Aplicatie_Meniu_Gradinita9
{
     class LipideTotaleData
    {
        public string Data { get; set; }
        public string LipideVegetale { get; set; }
        public string LipideAnimale { get; set; }
        public string NecesarMinim { get; set; }
        public string NecesarMaxim { get; set; }
        public string TotalLipide { get; set; }

        string dbPath;
        string connectionString;
        SqlConnection connection;
        public LipideTotaleData()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }
        public List<LipideTotaleData> ListaData()
        {
            List<LipideTotaleData> dataList = new List<LipideTotaleData>();
            try
            {
                connection.Open();
                string query = "SELECT data_adaugare, lipide_vegetale, lipide_animale, necesar_minim_lipide, necesar_maxim_lipide, total_lipide FROM lipide";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    LipideTotaleData data = new LipideTotaleData();
                    data.Data = Convert.ToDateTime(reader["data_adaugare"]).ToString("dd/MM/yyyy");
                    data.LipideVegetale = reader.IsDBNull(reader.GetOrdinal("lipide_vegetale")) ? "0.00" : reader["lipide_vegetale"].ToString();
                    data.LipideAnimale = reader.IsDBNull(reader.GetOrdinal("lipide_animale")) ? "0.00" : reader["lipide_animale"].ToString();
                    data.NecesarMinim = reader.IsDBNull(reader.GetOrdinal("necesar_minim_lipide")) ? "0.00" : reader["necesar_minim_lipide"].ToString();
                    data.NecesarMaxim = reader.IsDBNull(reader.GetOrdinal("necesar_maxim_lipide")) ? "0.00" : reader["necesar_maxim_lipide"].ToString();
                    data.TotalLipide = reader.IsDBNull(reader.GetOrdinal("total_lipide")) ? "0.00" : reader["total_lipide"].ToString();
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
