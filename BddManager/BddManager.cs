using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

namespace MediaTek86.bddmanager
    {
    /// Singleton : connexion à la base de données et exécution des requêtes
    /// </summary>
    public class BddManager
        {
        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static BddManager instance = null;
        /// <summary>
        /// objet de connexion à la BDD à partir d'une chaîne de connexion
        /// </summary>
        private readonly MySqlConnection connection;

        /// <summary>
        /// Constructeur pour créer la connexion à la BDD et l'ouvrir
        /// </summary>
        /// <param name="stringConnect">chaine de connexion</param>
        private BddManager(string stringConnect)
            {
            connection = new MySqlConnection(stringConnect);
            connection.Open();
            }

        /// <summary>
        /// Création d'une seule instance de la classe
        /// </summary>
        /// <param name="stringConnect">chaine de connexion</param>
        /// <returns>instance unique de la classe</returns>
        public static BddManager GetInstance(string stringConnect)
            {
            if (instance == null)
                {
                instance = new BddManager(stringConnect);
                }
            return instance;
            }


        /// <summary>
        /// Exécution d'une requête de type LCT (begin transaction, commit, rollback)
        /// </summary>
        /// <param name="stringQuery">requête</param>
        public void ReqControle(string stringQuery)
            {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);
            command.ExecuteNonQuery();
            }

        /// <summary>
        /// Exécution d'une requête de type LMD (insert, update, delete)
        /// </summary>
        /// <param name="stringQuery">requête autre que select</param>
        /// <param name="parameters">dictionnire contenant les parametres</param>
        public void ReqUpdate(string stringQuery, Dictionary<string, object> parameters = null)
            {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);

            if (parameters != null && parameters.Count > 0)
                {
                foreach (KeyValuePair<string, object> parameter in parameters)
                    {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                    }
                }
            else
                {
                Console.WriteLine(" Aucun paramètre détecté !");
                return; // Si aucun paramètre, on ne fait pas la mise à jour
                }

            command.Prepare();

            int rowsAffected = command.ExecuteNonQuery(); // Exécute la requête et récupère le nombre de lignes affectées
            Console.WriteLine($" Mise à jour effectuée : {rowsAffected} lignes modifiées.");
            }


        /// <summary>
        /// Execution d'une requête de type LIT (select)
        /// </summary>
        /// <param name="stringQuery">requête select</param>
        /// <param name="parameters">dictoinnaire contenant les parametres</param>

        public List<Object[]> ReqSelect(string stringQuery, Dictionary<string, object> parameters = null)
            {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);
            if (!(parameters is null))
                {
                foreach (KeyValuePair<string, object> parameter in parameters)
                    {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                    }
                }
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();
            int nbCols = reader.FieldCount;
            List<Object[]> records = new List<object[]>();
            while (reader.Read())
                {
                Object[] attributs = new Object[nbCols];
                reader.GetValues(attributs);
                records.Add(attributs);
                }
            reader.Close();
            return records;
            }
        public DataTable ReqSelectDataTable(string stringQuery, Dictionary<string, object> parameters = null)
            {
            DataTable dataTable = new DataTable();
            using (MySqlCommand command = new MySqlCommand(stringQuery, connection))
                {
                Console.WriteLine($" Requête SQL exécutée : {stringQuery}");
                if (parameters != null && parameters.Count > 0)
                    {
                    foreach (var param in parameters)
                        {
                        Console.WriteLine($" Paramètre {param.Key} = {param.Value}");
                        }
                    }
                else
                    {
                    Console.WriteLine(" Aucun paramètre détecté !");
                    }





                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                    adapter.Fill(dataTable);
                    }
                }
            return dataTable;
            }

        }
    }