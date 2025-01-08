using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AccesHemiCycle
{
    public class ModeleDepute
    {
        #region Attribut
        private ConnexionBdd conn;
        #endregion

        /// <summary>
        /// Permet de vérifier si les informations du Qr Code scanné sont bien celles d'un député
        /// </summary>
        /// <param name="identite"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="email"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Permet d'enregistrer l'entrée d'un député correspondant au scan du Qr Code 
        /// </summary>
        /// <param name="identite"></param>
        /// <returns></returns>
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

        public int CountDeputes()
        {
            int value = 0;
            conn = new ConnexionBdd();
            string rqtSql = "SELECT COUNT(id) as nb FROM deputes_active;";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(rqtSql, conn.Connexion))
                {
                    conn.Connexion.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        value = reader.GetInt32("nb");
                    }
                    reader.Close();
                    conn.Connexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return value;
        }

        public DataTable ListDepute(string recherche)
        {
            DataTable dataDeputes = new DataTable();
            conn = new ConnexionBdd();
            string rqtSql = "SELECT id, nom, prenom, mail, villeNaissance, naissance FROM deputes_active WHERE nom LIKE @recherche OR prenom LIKE @recherche;";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(rqtSql, conn.Connexion))
                {
                    cmd.Parameters.AddWithValue("@recherche", "%" + recherche + "%");
                    conn.Connexion.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dataDeputes.Load(reader);
                    reader.Close();
                    conn.Connexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataDeputes;
        }

        public DataTable ListDepute(int pageNumber)
        {
            DataTable dataDeputes = new DataTable();
            conn = new ConnexionBdd();
            int pageSize = 20;
            int nbValue = (pageNumber - 1) * pageSize;
            string rqtSql = "SELECT id, nom, prenom, mail, villeNaissance, naissance FROM deputes_active LIMIT @pageSize OFFSET @nbValue;";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(rqtSql, conn.Connexion))
                {
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);
                    cmd.Parameters.AddWithValue("@nbValue", nbValue);
                    conn.Connexion.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dataDeputes.Load(reader);
                    reader.Close();
                    conn.Connexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataDeputes;
        }

        public DataTable ListDeputePresentAuj()
        {
            DataTable dataDeputes = new DataTable();



            return dataDeputes;
        }
    }
}
