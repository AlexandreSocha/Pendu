using System;
using System.Text;

namespace Pendu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                AfficherFilDAriane();
                Console.WriteLine("Bienvenue, à quoi voulez vous-jouer ? \nTapez la lettre qui correspond à un jeu pour le lancer :)");
                DonnerListeJeux();
                string lettre = Console.ReadLine();

                switch (lettre.ToUpper())
                {
                    case "A":
                        new Pendu().LancerJeu();
                        break;

                    case "B":
                        new TablesMultiplicationsQuiz().LancerJeu();
                        break;

                    case "Q":
                        exit = true;
                        break;
                }

            }

            Adios();
        }

        private static void Adios()
        {
            Console.WriteLine("Merci d'avoir joué, au revoir ;)");
        }

        private static void DonnerListeJeux()
        {
            GameHelper.PasserLignes(2);
            StringBuilder blr = new StringBuilder();
            blr.AppendLine(" [ A ] - Pendu");
            blr.AppendLine(" [ B ] - Quiz sur les tables de multiplications");
            blr.AppendLine(" [ Q ] - Quitter");
            Console.WriteLine(blr.ToString());
        }

        private static void AfficherFilDAriane()
        {
            StringBuilder blr = new StringBuilder();
            blr.AppendLine("          /");
            blr.AppendLine("  MENU   /");
            blr.AppendLine("________/");
            Console.WriteLine(blr.ToString());
        }
    }
}