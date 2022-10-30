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
        private string _motAtrouverMasque;
        private List<string> _lettresATrouver = new List<string>();
        private List<string> _lettresTrouvees = new List<string>();
        private List<string> _lettresProposees = new List<string>();
        private string[] _motDisonibles = new string[] { "banane", "pelle", "tractopelle","perceuse", "brouette", "livre", "anticonstitutionnellement", "guitare", "batterie", "pentatonique", "voiture", "politique", "tessiture", "acronyme", "chantier", "misogyne", "pelleteuse", "androcéphale", "arachibutyrophobie", "agoraphobie" };
        private int _nbErreurs;
        private bool _gagne = false;
        private bool _perdu = false;
        private bool _exit = false;

        private void Init()
        {
            GetMotRandom();
            string premiereLettre = _motATrouver.Substring(0, 1);
            for (int i = 1; i < _motATrouver.Length; i++)
            {
                string l = _motATrouver.Substring(i, 1);

                if (l.Equals(premiereLettre))
                    continue;

                if(!_lettresATrouver.Contains(l))
                    _lettresATrouver.Add(l);
            }

        }

        private void GetMotRandom()
        {
            Random aleatoire = new Random();
            int index = aleatoire.Next(0, _motDisonibles.Length); 
            _motATrouver = _motDisonibles[index];
        }

        private void MasquerMot()
        {
            StringBuilder blr = new StringBuilder();
            string premiereLettre = _motATrouver.Substring(0, 1);
            for (int i = 0; i < _motATrouver.Length; i++)
            {
                string l = _motATrouver.Substring(i, 1);

                if (l.Equals(premiereLettre))
                {
                    blr.Append(l.ToUpper() + " ");
                    continue;
                }
                if (_lettresTrouvees.Contains(l))
                {
                    blr.Append(l.ToUpper() + " ");
                }
                else
                {
                    if(_perdu)
                        blr.Append(l.ToUpper() + " ");
                    else
                        blr.Append("_ ");
                }

            }

            _motAtrouverMasque = blr.ToString();
        }

        internal void LancerJeu()
        {
            Init();

            while (!_exit)
            {
                AfficherInfos();
                var lettre = Console.ReadLine();
                lettre = lettre.ToLower();

                if(lettre == "stop")
                {
                    _exit = true;
                    continue;
                }

                if (_lettresATrouver.Contains(lettre))
                {
                    _lettresATrouver.Remove(lettre);
                    _lettresTrouvees.Add(lettre);
                }
                else
                {
                    if(!_lettresProposees.Contains(lettre))
                        _nbErreurs++;
                }

                if(_nbErreurs == 11)
                {
                    _exit = true;
                    _perdu = true;
                    continue;
                }

                if (!_lettresProposees.Contains(lettre))
                    _lettresProposees.Add(lettre);

                if (_lettresATrouver.Count == 0)
                {
                    _gagne = true;
                    _exit = true;
                }
            }

            if (_gagne)
            {
                AfficherInfos();
                PasserLignes(1);
                Feliciter();
            }
            else if (_perdu)
            {
                AfficherInfos();
                PasserLignes(1);
                Console.WriteLine("Bah bravo ! Vous avez tué le pendu !");
            }

        }

        private void Feliciter()
        {
            Console.WriteLine("Félicitations, vous avez gagné !");
        }

        private void AfficherInfos()
        {
            Console.Clear();
            PasserLignes(4);
            AfficherPendu();
            PasserLignes(1);
            AfficherMessage();
            PasserLignes(3);
            MasquerMot();
            Console.WriteLine("    " + _motAtrouverMasque);
            PasserLignes(4);
            Console.WriteLine("Erreurs : " + _nbErreurs);
            Console.Write("Lettres déjà proposées: ");
            for(int i = 0; i < _lettresProposees.Count; i++)
            {
                if (i != 0)
                    Console.Write(", ");

                Console.Write(_lettresProposees[i].ToUpper());
            }
            if(_lettresProposees.Count > 0)
                Console.Write(".");

            PasserLignes(2);
        }

        private void PasserLignes(int nbLignes)
        {
            for(int i = 0; i < nbLignes; i++)
            {
                Console.WriteLine();
            }
        }
        private void AfficherMessage()
        {
            string message = "";

            if (_nbErreurs == 0)
                message = "";

            if (_nbErreurs == 1)
                message = "";

            if (_nbErreurs == 2)
                message = "";

            if (_nbErreurs == 3)
                message = "";

            if (_nbErreurs == 4)
                message = "";

            if (_nbErreurs == 5)
                message = "";

            if (_nbErreurs == 6)
                message = "  \"Aidez-moi je vais mourir !\"";

            if (_nbErreurs == 7)
                message = "  \"Pitiez, faites quelque chose...\"";

            if (_nbErreurs == 8)
                message = "  \"Vous n'allez pas me laisser comme ça ?!\"";

            if (_nbErreurs == 9)
                message = "  \"Dépêchez-vous, je ne sais plus respirer, vite !!!\"";

            if (_nbErreurs == 10)
                message = "  \"J'ai une femme et des enfants.....\"";

            if (_nbErreurs == 11)
                message = "  \"Argh... x.x\"";

            Console.WriteLine(message);
        }

        private void AfficherPendu()
        {
            StringBuilder blr = new StringBuilder();

            if(_nbErreurs == 0)
            {
                blr.AppendLine("                           ");
                blr.AppendLine("                           ");
                blr.AppendLine("                           ");
                blr.AppendLine("                           ");
                blr.AppendLine("                           ");
                blr.AppendLine("                           ");
            }

            if (_nbErreurs == 1)
            {
                blr.AppendLine("                           ");
                blr.AppendLine("                           ");
                blr.AppendLine("                           ");
                blr.AppendLine("                           ");
                blr.AppendLine("                           ");
                blr.AppendLine("___________________________");
            }

            if (_nbErreurs == 2)
            {
                blr.AppendLine("                           ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("_________|_________________");
            }

            if (_nbErreurs == 3)
            {
                blr.AppendLine("         __________        ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("_________|_________________");
            }

            if (_nbErreurs == 4)
            {
                blr.AppendLine("         __________        ");
                blr.AppendLine("         | /               ");
                blr.AppendLine("         |/                ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("_________|_________________");
            }

            if (_nbErreurs == 5)
            {
                blr.AppendLine("         __________        ");
                blr.AppendLine("         | /      |        ");
                blr.AppendLine("         |/                ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("_________|_________________");
            }

            if (_nbErreurs == 6)
            {
                blr.AppendLine("         __________        ");
                blr.AppendLine("         | /      |        ");
                blr.AppendLine("         |/       O        ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("_________|_________________");
            }

            if (_nbErreurs == 7)
            {
                blr.AppendLine("         __________        ");
                blr.AppendLine("         | /      |        ");
                blr.AppendLine("         |/       O        ");
                blr.AppendLine("         |        |");
                blr.AppendLine("         |                 ");
                blr.AppendLine("_________|_________________");
            }

            if (_nbErreurs == 8)
            {
                blr.AppendLine("         __________        ");
                blr.AppendLine("         | /      |        ");
                blr.AppendLine("         |/       O        ");
                blr.AppendLine("         |       -|        ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("_________|_________________");
            }

            if (_nbErreurs == 9)
            {
                blr.AppendLine("         __________        ");
                blr.AppendLine("         | /      |        ");
                blr.AppendLine("         |/       O        ");
                blr.AppendLine("         |       -|-       ");
                blr.AppendLine("         |                 ");
                blr.AppendLine("_________|_________________");
            }

            if (_nbErreurs == 10)
            {
                blr.AppendLine("         __________        ");
                blr.AppendLine("         | /      |        ");
                blr.AppendLine("         |/       O        ");
                blr.AppendLine("         |       -|-       ");
                blr.AppendLine("         |       /         ");
                blr.AppendLine("_________|_________________");
            }

            if (_nbErreurs == 11)
            {
                blr.AppendLine("         __________        ");
                blr.AppendLine("         | /      |        ");
                blr.AppendLine("         |/       O        ");
                blr.AppendLine("         |       -|-       ");
                blr.AppendLine("         |       / \\       ");
                blr.AppendLine("_________|_________________");
            }

            Console.WriteLine(blr.ToString());
        }

    }
}
