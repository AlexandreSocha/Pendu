using System;

namespace Pendu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool rejouer = true;

            while (rejouer)
            {
                new Pendu().LancerJeu();
                Console.WriteLine("Try again ? o/n");
                string rep = Console.ReadLine().ToLower();
                if (rep == "n")
                    rejouer = false;
            }

            Adios();
        }

        private static void Adios()
        {
            Console.WriteLine("Merci d'avoir joué, au revoir ;)");
        }
    }
}