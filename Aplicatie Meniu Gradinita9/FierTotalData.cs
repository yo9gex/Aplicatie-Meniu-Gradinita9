using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Aplicatie_Meniu_Gradinita9
{
    internal class FierTotalData
    {
        public string Data { get; set; }
        public string NecesarMediu { get; set; }
        public string TotalFier { get; set; }

        string dbPath;
        string connectionString;
        SqlConnection connect;

        public List<FierTotalData> ListaData()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
            connect = new SqlConnection(connectionString);
            List<FierTotalData> dataList = new List<FierTotalData>();
            try
            {
                connect.Open();
                string query = "SELECT data_adaugare, necesar_mediu_fier, total_fier FROM fier";
                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    FierTotalData data = new FierTotalData();
                    data.Data = Convert.ToDateTime(reader["data_adaugare"]).ToString("dd/MM/yyyy ");
                    data.NecesarMediu = reader.IsDBNull(reader.GetOrdinal("necesar_mediu_fier")) ? "0.00" : reader["necesar_mediu_fier"].ToString();
                    data.TotalFier = reader.IsDBNull(reader.GetOrdinal("total_fier")) ? "0.00" : reader["total_fier"].ToString();
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
