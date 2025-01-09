using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesHemiCycle.Model
{
    public class ModeleLog
    {
        #region Attribut
        private ConnexionBdd conn;
        #endregion

        public void Log(string message)
        {
            conn = new ConnexionBdd();
            string rqtSql = "INSERT INTO log (description) VALUES (@message);";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(rqtSql, conn.Connexion))
                {
                    cmd.Parameters.AddWithValue("@message", message);
                    conn.Connexion.Open();
                    cmd.ExecuteNonQuery();
                    conn.Connexion.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Erreur 3", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true);
            }
        }
    }
}
