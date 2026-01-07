using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Aplicatie_Meniu_Gradinita9
{
     class ProteineTotaleData
    {
        public string Data { get; set; }
       public string NecesarMinim { get; set; }
        public string NecesarMaxim { get; set; }
        public string TotalProteine { get; set; }

        // SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
        string dbPath;
        string connectionString;
        SqlConnection connection;
        public ProteineTotaleData()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }
        public List<ProteineTotaleData> ListaData()
        {
            List<ProteineTotaleData> dataList = new List<ProteineTotaleData>();
            try
            {
                connection.Open();
                string query = "SELECT data_adaugare, necesar_minim_proteine, necesar_maxim_proteine, total_proteine FROM proteine";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ProteineTotaleData data = new ProteineTotaleData();
                      data.Data = Convert.ToDateTime(reader["data_adaugare"]).ToString("dd/MM/yyyy ");
                      data.NecesarMinim = reader.IsDBNull(reader.GetOrdinal("necesar_minim_proteine")) ? "0.00" :reader["necesar_minim_proteine"].ToString();
                      data.NecesarMaxim = reader.IsDBNull(reader.GetOrdinal("necesar_maxim_proteine")) ? "0.00" : reader["necesar_maxim_proteine"].ToString();
                      data.TotalProteine = reader.IsDBNull(reader.GetOrdinal("total_proteine")) ? "0.00" : reader["total_proteine"].ToString();

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
