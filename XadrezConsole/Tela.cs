using System;
using tabuleiro;
namespace XadrezConsole
{
    internal class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (tabuleiro.getPeca(i, j) == null)
                    {
                        Console.Write("- ");
                    }else
                    {
                        Console.Write($"{tabuleiro.getPeca(i, j)} ");
                    }

                }
                Console.WriteLine("");
            }
        }
    }
}
