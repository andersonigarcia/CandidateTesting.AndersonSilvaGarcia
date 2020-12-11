using System;

namespace CandidateTesting.AndersonSilvaGarcia
{
    public static class Helper
    {
        public static int ReadValue(string description, int matrizLength, string erroMessage = Constant.DefaultErrorValue)
        {
            int input = int.MinValue;
            bool repete = true;

            Console.Write(description);
            while (repete)
            {
                repete = !int.TryParse(Console.ReadLine(), out input) || input > matrizLength;
                if (repete) Console.WriteLine(erroMessage);
            }

            return input;
        }
        public static int[] ReadMatriz(string description, string erroMessage = Constant.DefaultErrorMatriz)
        {
            bool repete = true;
            string[] matriz = new string[] { };

            Console.Write(description);
            while (repete)
            {
                matriz = Console.ReadLine().Split(Constant.MatrixItemsSeparation);
                repete = !Array.TrueForAll(matriz, s => int.TryParse(s, out int result));
                if (repete) Console.WriteLine(erroMessage);
            }

            return Array.ConvertAll(matriz, s => int.Parse(s));
        }
    }
}
