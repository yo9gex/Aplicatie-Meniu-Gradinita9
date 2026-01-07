using Microsoft.Data.SqlClient;


namespace Aplicatie_Meniu_Gradinita9
{

    class PranzDataFel1
    {
        public string NumeProdus { get; set; }//0        
        public string TCantitatea { get; set; }//1
        public string TNet { get; set; }//2
        public override string ToString()
        {
            return $"{NumeProdus} - {TCantitatea} - {TNet}";
        }
        // SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
        string dbPath;
        string connectionString;
        SqlConnection connection;
        public PranzDataFel1()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }
        public List<PranzDataFel1> ListaPranzDataFel1()
        {
            List<PranzDataFel1> listaPranzFel1 = new List<PranzDataFel1>();

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT nume, TCantitate, TNet FROM totalAlimentePranz WHERE tip_fel = 'Felul 1' OR tip_fel ='Ambele' ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            PranzDataFel1 lista = new PranzDataFel1();
                            lista.NumeProdus = reader["nume"].ToString();
                            lista.TCantitatea = reader["TCantitate"].ToString();
                            lista.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            listaPranzFel1.Add(lista);
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
            return listaPranzFel1;
        }

    }


}
