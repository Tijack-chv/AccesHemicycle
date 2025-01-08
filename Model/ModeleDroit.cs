using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BC = BCrypt.Net.BCrypt;

namespace AccesHemiCycle.Model
{
    public class ModeleDroit
    {
        #region Attribut
        private ConnexionBdd conn;
        #endregion

        /// <summary>
        /// Permet de vérifier si l'utilisateur a les droits d'accès
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        #region AccesDroitDeputes
        public bool AccesDroitDeputes(string mail, string password)
        {
            conn = new ConnexionBdd();
            bool test = true;
            string rqtSql = "SELECT mail, password FROM droit_admin WHERE mail = @mail;";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(rqtSql, conn.Connexion))
                {
                    cmd.Parameters.AddWithValue("@mail", mail);
                    conn.Connexion.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        test = false;
                    }
                    else
                    {
                        string hash = "";
                        while (reader.Read())
                        {
                            hash = reader["password"].ToString();
                        }
                        if (!BC.Verify(password, hash))
                        {
                            test = false;
                        }
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
        #endregion
    }
}
