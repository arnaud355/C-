using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaBibliotheque
{
    public class Client
    {
        private string login;
        public string Login
        {
            get { return login; }
        }

        private string motDePasse;
        public string MotDePasse
        {
            get { return motDePasse.Crypte(); }
        }
        public Client()
        {

        }
        public Client(string loginClient, string motDePasseClient)
        {
            login = loginClient;
            motDePasse = motDePasseClient;
        }
    }
}
