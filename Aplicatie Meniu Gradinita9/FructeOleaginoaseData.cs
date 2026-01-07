using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicatie_Meniu_Gradinita9
{
     class FructeOleaginoaseData
    {
        public string NumeProdus { set; get; } //0
        public decimal Proteine { set; get; } //1
        public decimal ProteineVegetale { set; get; } //2
        public decimal ProteineAnimale { set; get; } //3
        public decimal Lipide { set; get; }  //4
        public decimal LipideVegetale { set; get; }  //5
        public decimal LipideAnimale { set; get; }  //6
        public decimal Glucide { set; get; } //7
        public decimal Fier { set; get; } //8
        public decimal Calciu { set; get; } //9
        public decimal Calorii { set; get; }  //10
        public decimal Scazamant { set; get; }  //11
        public decimal Cantitate { set; get; }  //12
        public int GrupProduse1 { set; get; }  //13
        public decimal CoeficientEchiv1 { set; get; }  //14
        public int GrupProduse2 { set; get; }  //15
        public decimal CoeficientEchiv2 { set; get; }  //16
        public string Status { set; get; }  //17

        //SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30");
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
        string dbPath;
        string connectionString;
        SqlConnection conn;
        public FructeOleaginoaseData()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            conn = new SqlConnection(connectionString);
        }
        public List<FructeOleaginoaseData> produseOleaginoaseListData()
        {
           
            List<FructeOleaginoaseData> produseList = new List<FructeOleaginoaseData>();
            if (conn.State == ConnectionState.Closed)
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM fructeOleaginoase";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FructeOleaginoaseData fod = new FructeOleaginoaseData();
                        // pd.Id = (int)reader["id"];
                        fod.NumeProdus = reader["nume"].ToString();                        
                        fod.Proteine = Convert.ToDecimal(reader["proteine"] == DBNull.Value ? 0 : reader["proteine"]);
                        fod.ProteineVegetale = Convert.ToDecimal(reader["proteine_vegetale"] == DBNull.Value ? 0 : reader["proteine_vegetale"]);
                        fod.ProteineAnimale = Convert.ToDecimal(reader["proteine_animale"] == DBNull.Value ? 0 : reader["proteine_animale"]);
                        fod.Lipide = Convert.ToDecimal(reader["lipide"] == DBNull.Value ? 0 : reader["lipide"]);
                        fod.LipideVegetale = Convert.ToDecimal(reader["lipide_vegetale"] == DBNull.Value ? 0 : reader["lipide_vegetale"]);
                        fod.LipideAnimale = Convert.ToDecimal(reader["lipide_animale"] == DBNull.Value ? 0 : reader["lipide_animale"]);
                        fod.Glucide = Convert.ToDecimal(reader["glucide"] == DBNull.Value ? 0 : reader["glucide"]);
                        fod.Fier = Convert.ToDecimal(reader["fier"] == DBNull.Value ? 0 : reader["fier"]);
                        fod.Calciu = Convert.ToDecimal(reader["calciu"] == DBNull.Value ? 0 : reader["calciu"]);
                        fod.Calorii = Convert.ToDecimal(reader["calorii"] == DBNull.Value ? 0 : reader["calorii"]);
                        fod.Scazamant = Convert.ToDecimal(reader["scazamant"] == DBNull.Value ? 0 : reader["scazamant"]);
                        fod.Cantitate = Convert.ToDecimal(reader["cantitate"] == DBNull.Value ? 0 : reader["cantitate"]);
                        fod.GrupProduse1 = Convert.ToInt32(reader["grupa_produse1"] == DBNull.Value ? 0 : reader["grupa_produse1"]);
                        fod.CoeficientEchiv1 = Convert.ToDecimal(reader["coeficient_echivalent1"] == DBNull.Value ? 0 : reader["coeficient_echivalent1"]);
                        fod.GrupProduse2 = Convert.ToInt32(reader["grupa_produse2"] == DBNull.Value ? 0 : reader["grupa_produse2"]);
                        fod.CoeficientEchiv2 = Convert.ToDecimal(reader["coeficient_echivalent2"] == DBNull.Value ? 0 : reader["coeficient_echivalent2"]);
                        fod.Status = reader["status"].ToString();

                        produseList.Add(fod);
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log it)
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            return produseList;
        }

        public List<FructeOleaginoaseData> listaNecesarAlimenteData()
        {

            List<FructeOleaginoaseData> produseList = new List<FructeOleaginoaseData>();
           
            if (conn.State == ConnectionState.Closed)
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM fructeOleaginoase WHERE status = 'Alege' ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FructeOleaginoaseData fod = new FructeOleaginoaseData();
                        // pd.Id = (int)reader["id"];
                        fod.NumeProdus = reader["nume"].ToString();
                        fod.Proteine = Convert.ToDecimal(reader["proteine"] == DBNull.Value ? 0 : reader["proteine"]);
                        fod.ProteineVegetale = Convert.ToDecimal(reader["proteine_vegetale"] == DBNull.Value ? 0 : reader["proteine_vegetale"]);
                        fod.ProteineAnimale = Convert.ToDecimal(reader["proteine_animale"] == DBNull.Value ? 0 : reader["proteine_animale"]);
                        fod.Lipide = Convert.ToDecimal(reader["lipide"] == DBNull.Value ? 0 : reader["lipide"]);
                        fod.LipideVegetale = Convert.ToDecimal(reader["lipide_vegetale"] == DBNull.Value ? 0 : reader["lipide_vegetale"]);
                        fod.LipideAnimale = Convert.ToDecimal(reader["lipide_animale"] == DBNull.Value ? 0 : reader["lipide_animale"]);
                        fod.Glucide = Convert.ToDecimal(reader["glucide"] == DBNull.Value ? 0 : reader["glucide"]);
                        fod.Fier = Convert.ToDecimal(reader["fier"] == DBNull.Value ? 0 : reader["fier"]);
                        fod.Calciu = Convert.ToDecimal(reader["calciu"] == DBNull.Value ? 0 : reader["calciu"]);
                        fod.Calorii = Convert.ToDecimal(reader["calorii"] == DBNull.Value ? 0 : reader["calorii"]);
                        fod.Scazamant = Convert.ToDecimal(reader["scazamant"] == DBNull.Value ? 0 : reader["scazamant"]);
                        fod.Cantitate = Convert.ToDecimal(reader["cantitate"] == DBNull.Value ? 0 : reader["cantitate"]);
                        fod.GrupProduse1 = Convert.ToInt32(reader["grupa_produse1"] == DBNull.Value ? 0 : reader["grupa_produse1"]);
                        fod.CoeficientEchiv1 = Convert.ToDecimal(reader["coeficient_echivalent1"] == DBNull.Value ? 0 : reader["coeficient_echivalent1"]);
                        fod.GrupProduse2 = Convert.ToInt32(reader["grupa_produse2"] == DBNull.Value ? 0 : reader["grupa_produse2"]);
                        fod.CoeficientEchiv2 = Convert.ToDecimal(reader["coeficient_echivalent2"] == DBNull.Value ? 0 : reader["coeficient_echivalent2"]);
                        fod.Status = reader["status"].ToString();

                        produseList.Add(fod);
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log it)
                    MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            return produseList;
        }
    }
}
