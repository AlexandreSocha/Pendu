using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendu
{
    internal class GameHelper
    {
        public static void PasserLignes(int nbLignes)
        {
            for (int i = 0; i < nbLignes; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
