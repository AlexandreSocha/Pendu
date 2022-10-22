using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendu
{
    internal class Pendu
    {
        private string _motATrouver;
        private string _motAtrouverCache;
        private List<string> _lettresATrouver;
        private List<string> _lettresTrouvees;
        private List<string> _lettresProposees;
        private string[] _motDisonibles = new string[] { "banane", "pelle", "tractopelle" };
        private int _nbErreurs;

        private void Init()
        {

        }

        private void MasquerMot()
        {

        }

        internal void LancerJeu()
        {

        }

        private void Feliciter()
        {
            Console.WriteLine("Félicitations, vous avez gagné !");
        }

        private void Adios()
        {
            Console.WriteLine("Merci d'avoir joué, au revoir ;)");
        }
    }
}
