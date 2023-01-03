using System;
using tabuleiro;
using xadrez;
using tabuleiro.exception;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PartidaDeXadrez partida = new PartidaDeXadrez();
            while (!partida.Terminada)
            {
                try
                {
                    Console.Clear();
                    Tela.ImprimirPartida(partida);
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarPosicaoOrigem(origem);

                    bool[,] posicoesPossiveis = partida.Tabuleiro.GetPeca(origem).MovimentosPossiveis();
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarPosicaoDestino(origem, destino);

                    partida.RealizaJogada(origem, destino);
      
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Tela.ImprimirPartida(partida);
        }
    }
}