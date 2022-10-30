using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendu
{
    internal class TablesMultiplicationsQuiz
    {
        private int _nbPoints;
        private int _tableChoisie;
        private bool _exit = false;
        internal void LancerJeu()
        {
            Init();
            while (!_exit)
            {
                Console.Clear();
                AfficherFilDAriane(1);
                PresenterMenu();
                var rep = Console.ReadLine();
                if (rep.ToUpper().Equals("Q"))
                {
                    _exit = true;
                    break;
                }

                switch (rep.ToUpper())
                {
                    case "2":
                        LancerSerie(2);
                        break;

                    case "3":
                        LancerSerie(3);
                        break;

                    case "4":
                        LancerSerie(4);
                        break;

                    case "5":
                        LancerSerie(5);
                        break;

                    case "6":
                        LancerSerie(6);
                        break;

                    case "7":
                        LancerSerie(7);
                        break;

                    case "8":
                        LancerSerie(8);
                        break;

                    case "9":
                        LancerSerie(9);
                        break;

                    case "A":
                        LancerSerie(null);
                        break;
                }

                Console.WriteLine("Rejouer au quiz sur les tables de multiplications ? o/n");
                var repRejouer = Console.ReadLine();
                if(repRejouer.ToLower().Equals("n"))
                    _exit = true;
            }


        }

        public void PresenterMenu()
        {
            StringBuilder blr = new StringBuilder();
            blr.AppendLine(" [ A ] - Toutes les tables confondues");
            blr.AppendLine(" [ 2 ] - Table de 2");
            blr.AppendLine(" [ 3 ] - Table de 3");
            blr.AppendLine(" [ 4 ] - Table de 4");
            blr.AppendLine(" [ 5 ] - Table de 5");
            blr.AppendLine(" [ 6 ] - Table de 6");
            blr.AppendLine(" [ 7 ] - Table de 7");
            blr.AppendLine(" [ 8 ] - Table de 8");
            blr.AppendLine(" [ 9 ] - Table de 9");
            blr.AppendLine(" [ Q ] - Quitter");
            Console.WriteLine(blr.ToString());
        }

        private void LancerSerie(int? table)
        {
            _nbPoints = 0;
            _tableChoisie = table.HasValue ? table.Value : _tableChoisie = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                AfficherFilDAriane(2);
                PoserQuestion(table);
            }
            Console.WriteLine($"Votre note : {_nbPoints}/10");
        }

        private void PoserQuestion(int? table)
        {
            int A = new Random().Next(1, 10);
            int B = table.HasValue ? table.Value : new Random().Next(1, 10);
            Console.WriteLine($"{A} x {B} = ?");
            string r = Console.ReadLine();
            int reponse = int.Parse(r);
            int resultat = A * B;
            if (resultat.Equals(reponse))
            {
                Console.WriteLine($"Bravo !");
                _nbPoints++;
            }
            else
            {
                Console.WriteLine($"Perdu.");
            }
        }

        private void Init()
        {

        }

        private void PasserLignes(int v)
        {
            GameHelper.PasserLignes(v);
        }

        private void AfficherFilDAriane(int partie)
        {
            if(partie == 1)
            {
                StringBuilder blr = new StringBuilder();
                blr.AppendLine("          /                           /");
                blr.AppendLine("  MENU   /   Quiz multiplications    /");
                blr.AppendLine("________/___________________________/");
                Console.WriteLine(blr.ToString());
            }

            if (partie == 2)
            {
                StringBuilder blr = new StringBuilder();

                if (_tableChoisie != 0)
                {
                    blr.AppendLine("          /                           /                /");
                    blr.AppendLine($"  MENU   /   Quiz multiplications    /   Table de {_tableChoisie}   /");
                    blr.AppendLine("________/___________________________/________________/");
                }
                else
                {
                    blr.AppendLine("          /                           /                       /");
                    blr.AppendLine("  MENU   /   Quiz multiplications    /   Toutes les tables   /");
                    blr.AppendLine("________/___________________________/_______________________/");
                }

                Console.WriteLine(blr.ToString());
            }
        }
    }
}
