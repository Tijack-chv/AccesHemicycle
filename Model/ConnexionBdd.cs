using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesHemiCycle
{
    public class ConnexionBdd
    {
        #region Attribut
        private MySqlConnection _connection;
        private string _server;
        private string _database;
        private string _uid;
        private string _password;
        #endregion

        /// <summary>
        /// Initialise la connexion à la base de données
        /// </summary>
        #region Initialise
        private void Init()
        {
            _server = "192.168.10.16";
            _database = "chauveau_pierre_HackathonHemicycle";

            _uid = "chauveau_pierre";
            _password = "Nu4RAvbR";
            string connectionString;
            connectionString = "SERVER=" + _server + ";" + "DATABASE=" +
            _database + ";" + "UID=" + _uid + ";" + "PASSWORD=" + _password + ";";

            _connection = new MySqlConnection(connectionString);
        }
        #endregion

        #region GetConnexion
        public MySqlConnection Connexion
        {
            get { return _connection; }
        }
        #endregion

        #region Constructeur
        public ConnexionBdd()
        {
            Init();
        }
        #endregion
    }
}
