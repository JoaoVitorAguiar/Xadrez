using System;
using tabuleiro;
using xadrez;

namespace XadrezConsole
{
    internal class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    Peca peca = tabuleiro.GetPeca(i, j);
                    ImprimirPeca(peca);

                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] possicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (possicoesPossiveis[i, j]) Console.BackgroundColor = fundoAlterado;
                    else Console.BackgroundColor = fundoOriginal;
                    Peca peca = tabuleiro.GetPeca(i, j);
                    ImprimirPeca(peca);
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
  
        }
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string input = Console.ReadLine();
            char coluna = input[0];
            int linha = int.Parse(input[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
        private static void ImprimirPeca(Peca peca)
        {
            if (peca == null) Console.Write("- ");
            else
            {
                if (peca.Cor == Cor.Branca) Console.Write($"{peca} ");
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{peca} ");
                    Console.ForegroundColor = aux;
                }
            }

        }
    }
}
