using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaTek86.bddmanager;
using MediaTek86.dal;

namespace MediaTek86.DAL
    {
    public static class DeveloppeurAccess
        {
        /// <summary>
        /// Vérifie si l'utilisateur existe dans la base de données.
        /// </summary>
        /// <param name="login">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <returns>True si l'utilisateur est authentifié, False sinon</returns>
        public static bool ControleAuthentification(string login, string password)
            {
            string req = "SELECT * FROM responsable WHERE login = @login AND pwd = @password;";


            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@login", login },
                { "@password", password }
            };

            List<object[]> records = Access.GetInstance().Manager.ReqSelect(req, parameters);
            return records != null && records.Count > 0;
            }
        }
    }

