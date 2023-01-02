using System;
using System.Collections.Generic;
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
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine($"\nTurno: {partida.Turno}");
            Console.WriteLine($"Aguardgando jogada: {partida.JogadorAtual}");
            if (partida.Xeque) Console.WriteLine("Você está em Xeque!");
        }

        private static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        private static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            string output = "[ ";
            foreach (Peca p in conjunto)
                output += $"{p} ";
            output += "]" ;
            Console.WriteLine(output);
        }
    }
}
