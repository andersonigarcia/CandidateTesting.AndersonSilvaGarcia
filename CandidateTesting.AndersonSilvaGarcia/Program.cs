﻿using System;

namespace CandidateTesting.AndersonSilvaGarcia
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matriz;
            Adjacent adjacent;

            Console.Title = Constant.DescriptionTitle;
            Console.WriteLine(Constant.SubTitle);
            Console.WriteLine(Constant.Options);
            Console.Write(Constant.InformOption);

            switch (Console.ReadLine())
            {
                case "1":
                    matriz = Helper.ReadMatriz(Constant.MatrizInform);
                    int indiceA = Helper.ReadValue(string.Format(Constant.DefaultInputIndice, "(P)"), matriz.Length);
                    int indiceB = Helper.ReadValue(string.Format(Constant.DefaultInputIndice, "(Q)"), matriz.Length);
                    adjacent = new Adjacent(matriz, indiceA, indiceB);
                    Console.WriteLine(adjacent.MaxAdjacentDistance());
                    break;

                case "2":
                    matriz = Helper.ReadMatriz(Constant.MatrizInform);
                    adjacent = new Adjacent(matriz);
                    Console.WriteLine(adjacent.MaxDistanceAllValues());
                    break;

                case "3":
                    Console.Write(Constant.DescriptionUri);
                    Uri uri = new Uri(Console.ReadLine());

                    Console.Write(Constant.DescriptionPathTarget);
                    var log = new Log(uri, Console.ReadLine());

                    if (!log.CreateAgoraArchive())
                        Console.WriteLine(log.TargetPath);
                    break;

                default:
                    break;
            }

            Console.WriteLine(Constant.AbortMessage);
            Console.ReadKey();
        }
    }
}

