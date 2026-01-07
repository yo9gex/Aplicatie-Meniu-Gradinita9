using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicatie_Meniu_Gradinita9
{
    public partial class LegumeProaspete : UserControl
    {
        //SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30");
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
        string dbPath;
        string connectionString;
        SqlConnection conn;
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;

            }
            DisplayLegumeProaspete();
        }
        public LegumeProaspete()
        {
            InitializeComponent();
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            conn = new SqlConnection(connectionString);
            DisplayLegumeProaspete();
        }
        public void DisplayLegumeProaspete()
        {
            LegumeProaspeteData lpd = new LegumeProaspeteData();
            List<LegumeProaspeteData> produseList = lpd.produseLegumeProaspeteListData();
            dataLegumeProaspete.DataSource = produseList;
        }
        private void ClearFields()
        {
            //produsId_txt.Text = "";
            numeProdus_txt.Text = "";
            proteine_txt.Text = "";
            lipide_txt.Text = "";
            glucide_txt.Text = "";
            calorii_txt.Text = "";
            scz_txt.Text = "";
            status_txt.Text = "";
            protVeg_txt.Text = "";
            protAnimal_txt.Text = "";
            lipideVeg_txt.Text = "";
            lipideAnimal_txt.Text = "";
            fier_txt.Text = "";
            calciu_txt.Text = "";
            grup1_txt.Text = "";
            grup2_txt.Text = "";
            coef1_txt.Text = "";
            coef2_txt.Text = "";
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void sterge_btn_Click(object sender, EventArgs e)
        {
            if (numeProdus_txt.Text == ""
               || proteine_txt.Text == ""
               || lipide_txt.Text == ""
               || glucide_txt.Text == ""
               || calorii_txt.Text == ""
               || scz_txt.Text == "")
            {
                MessageBox.Show("Te rog sa completezi toate campurile", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (conn.State == ConnectionState.Closed)
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM legumeProaspete WHERE nume=@NumeProdus";
                        string query1 = "DELETE FROM totalAlimenteGustare WHERE nume=@NumeProdus";
                        string query2 = "DELETE FROM totalAlimenteMicDejun WHERE nume=@NumeProdus";
                        string query3 = "DELETE FROM totalAlimentePranz WHERE nume=@NumeProdus";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        SqlCommand cmd1 = new SqlCommand(query1, conn);
                        SqlCommand cmd2 = new SqlCommand(query2, conn);
                        SqlCommand cmd3 = new SqlCommand(query3, conn);
                        cmd.Parameters.AddWithValue("@NumeProdus", numeProdus_txt.Text.Trim());
                        cmd1.Parameters.AddWithValue("@NumeProdus", numeProdus_txt.Text.Trim());
                        cmd2.Parameters.AddWithValue("@NumeProdus", numeProdus_txt.Text.Trim());
                        cmd3.Parameters.AddWithValue("@NumeProdus", numeProdus_txt.Text.Trim());
                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        cmd3.ExecuteNonQuery();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Produs sters cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Produsul nu a fost gasit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                        RefreshData();
                    }
            }
        }

        private void actualizare_btn_Click(object sender, EventArgs e)
        {
            if (numeProdus_txt.Text == ""
              || proteine_txt.Text == ""
              || lipide_txt.Text == ""
              || glucide_txt.Text == ""
              || calorii_txt.Text == ""
              || scz_txt.Text == ""
              || status_txt.Text == ""
              || protVeg_txt.Text == ""
              || protAnimal_txt.Text == ""
              || lipideVeg_txt.Text == ""
              || lipideAnimal_txt.Text == ""
              || fier_txt.Text == ""
              || calciu_txt.Text == ""
              || grup1_txt.Text == ""
              || grup2_txt.Text == ""
              || coef1_txt.Text == ""
              || coef2_txt.Text == "")
            {
                MessageBox.Show("Te rog sa completezi toate campurile", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Esti sigur ca vrei sa actualizezi produsul " + numeProdus_txt.Text.Trim() + "?", "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        conn.Open();
                        DateTime today = DateTime.Today;

                        string query = "UPDATE legumeProaspete SET proteine=@Proteine, lipide=@Lipide, glucide=@Glucide, calorii=@Calorii, scazamant=@Scazamant, status=@Status, " +
                            "proteine_vegetale=@Proteine_vegetale, proteine_animale=@Proteine_animale, lipide_vegetale=@Lipide_vegetale, lipide_animale=@Lipide_animale, fier=@Fier, calciu=@Calciu, grupa_produse1=@Grupa_produse1, " +
                            "grupa_produse2=@Grupa_produse2, coeficient_echivalent1=@Coeficient_echivalent1, coeficient_echivalent2=@Coeficient_echivalent2 WHERE nume=@NumeProdus";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@NumeProdus", numeProdus_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Proteine", proteine_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Lipide", lipide_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Glucide", glucide_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Calorii", calorii_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Scazamant", scz_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Status", status_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Proteine_vegetale", protVeg_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Proteine_animale", protAnimal_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Lipide_vegetale", lipideVeg_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Lipide_animale", lipideAnimal_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Fier", fier_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Calciu", calciu_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Grupa_produse1", grup1_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Grupa_produse2", grup2_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Coeficient_echivalent1", coef1_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@Coeficient_echivalent2", coef2_txt.Text.Trim());
                            cmd.ExecuteNonQuery();
                            DisplayLegumeProaspete();

                            MessageBox.Show("Produs actualizat cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            ClearFields();
                            // Actualizeaza tabelele din celelalte formulare

                            MicDejunAlimente mda = new MicDejunAlimente();
                            PranzAlimente pa = new PranzAlimente();
                            GustareAlimente ga = new GustareAlimente();
                            mda.TabelaMicDejun();
                            mda.StergeProdusDinMicDejun();
                            mda.RefreshData();
                            pa.TabelaPranz();
                            pa.RefreshData();
                            pa.StergePranz();
                            ga.TabelaGustare();
                            ga.StergeProdusGustare();
                            ga.RefreshData();

                        }

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                        RefreshData();
                    }

                }
                else
                {

                    MessageBox.Show("Produsul nu a fost gasit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (//produsId_txt.Text == ""
                numeProdus_txt.Text == ""
               || proteine_txt.Text == ""
               || protVeg_txt.Text == ""
               || protAnimal_txt.Text == ""
               || lipide_txt.Text == ""
               || lipideVeg_txt.Text == ""
               || lipideAnimal_txt.Text == ""
               || glucide_txt.Text == ""
               || fier_txt.Text == ""
               || calciu_txt.Text == ""
               || calorii_txt.Text == ""
               || grup1_txt.Text == ""
               || grup2_txt.Text == ""
               || coef1_txt.Text == ""
               || coef2_txt.Text == ""
               || scz_txt.Text == "")

            {
                MessageBox.Show("Te rog sa completezi toate campurile", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (conn.State == ConnectionState.Closed)
                    try
                    {
                        conn.Open();
                        // Check if the nume already exists
                        string checkNume = "SELECT COUNT(*) FROM legumeProaspete WHERE nume = @nume";
                        using (SqlCommand checkCmd = new SqlCommand(checkNume, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@nume", numeProdus_txt.Text.Trim());
                            int count = (int)checkCmd.ExecuteScalar();
                            if (count >= 1)
                            {
                                MessageBox.Show(numeProdus_txt.Text.Trim() + " Produsul deja exista. Te rog sa alegi un alt produs.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ClearFields();
                                return; // Exit the method if the name already exists
                            }
                        }

                        string query = "INSERT INTO legumeProaspete (nume, proteine, proteine_vegetale, proteine_animale, lipide, lipide_vegetale, lipide_animale, glucide, fier, calciu, calorii, grupa_produse1, grupa_produse2, coeficient_echivalent1, coeficient_echivalent2, scazamant, cantitate, status) " +
                            " VALUES ( @NumeProdus, @Proteine, @Proteine_vegetale, @Proteine_animale, @Lipide, @Lipide_vegetale, @Lipide_animale, @Glucide, @Fier, @Calciu, @Calorii, @Grupa_produse1, @Grupa_produse2, @Coeficient_echivalent1, @Coeficient_echivalent2, @Scazamant, @Cantitate, @Status)";
                        SqlCommand cmd = new SqlCommand(query, conn);

                        cmd.Parameters.AddWithValue("@NumeProdus", numeProdus_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Proteine", proteine_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Proteine_vegetale", protVeg_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Proteine_animale", protAnimal_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Lipide", lipide_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Lipide_vegetale", lipideVeg_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Lipide_animale", lipideAnimal_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Glucide", glucide_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Fier", fier_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Calciu", calciu_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Calorii", calorii_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Grupa_produse1", grup1_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Grupa_produse2", grup2_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Coeficient_echivalent1", coef1_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Coeficient_echivalent2", coef2_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Scazamant", scz_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@Cantitate", 0); // Initial cantitate set to 0
                        cmd.Parameters.AddWithValue("@Status", status_txt.Text.Trim());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Produs adaugat cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                        RefreshData();
                    }
            }

        }

        private void dataLegumeProaspete_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataLegumeProaspete.Rows[e.RowIndex];

                numeProdus_txt.Text = row.Cells[0].Value.ToString();
                proteine_txt.Text = row.Cells[1].Value.ToString();
                protVeg_txt.Text = row.Cells[2].Value.ToString();
                protAnimal_txt.Text = row.Cells[3].Value.ToString();
                lipide_txt.Text = row.Cells[4].Value.ToString();
                lipideVeg_txt.Text = row.Cells[5].Value.ToString();
                lipideAnimal_txt.Text = row.Cells[6].Value.ToString();
                glucide_txt.Text = row.Cells[7].Value.ToString();
                fier_txt.Text = row.Cells[8].Value.ToString();
                calciu_txt.Text = row.Cells[9].Value.ToString();
                calorii_txt.Text = row.Cells[10].Value.ToString();
                scz_txt.Text = row.Cells[11].Value.ToString();
                grup1_txt.Text = row.Cells[13].Value.ToString();
                coef1_txt.Text = row.Cells[14].Value.ToString();
                grup2_txt.Text = row.Cells[15].Value.ToString();
                coef2_txt.Text = row.Cells[16].Value.ToString();
                status_txt.Text = row.Cells[17].Value.ToString();
            }
        }
    }
}
