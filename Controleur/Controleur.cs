using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaTek86.DAL;

namespace MediaTek86.Controleur
    {
    public static class Controleur
        {
        /// <summary>
        /// Vérifie les identifiants d'un utilisateur en appelant `DeveloppeurAccess`
        /// </summary>
        public static bool VerifierAuthentification(string login, string password)
            {
            return DeveloppeurAccess.ControleAuthentification(login, password);
            }
        }
    }