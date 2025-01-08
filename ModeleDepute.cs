using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AccesHemiCycle
{
    public class ModeleDepute
    {
        #region Attribut
        private ConnexionBdd conn;
        #endregion

        public bool AccesDepute(string identite, string nom, string prenom, string email) // autre si besoin
        {
            conn = new ConnexionBdd();
            bool test = true;
            string rqtSql = "SELECT id, nom, prenom, mail FROM deputes_active WHERE id = @identite AND nom = @nom AND prenom = @prenom AND mail = @email;";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(rqtSql, conn.Connexion))
                {
                    cmd.Parameters.AddWithValue("@identite", identite);
                    cmd.Parameters.AddWithValue("@prenom", prenom);
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cmd.Parameters.AddWithValue("@email", email);
                    conn.Connexion.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        test = false;
                    }

                    reader.Close();
                    conn.Connexion.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Erreur 3", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true);
                test = false;
            }

            return test;
        }

        public bool EntreeDepute(string identite)
        {
            bool test = true;
            conn = new ConnexionBdd();
            DateTime date = DateTime.Now;
            string rqtSql = "INSERT INTO entree_depute(idDepute, dateEntree) VALUES (@id, @date);";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(rqtSql, conn.Connexion))
                {
                    cmd.Parameters.AddWithValue("@id", identite);
                    cmd.Parameters.AddWithValue("@date", date);
                    conn.Connexion.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    conn.Connexion.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Erreur 3", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true);
                test = false;
            }

            return test;
        }
    }
}
