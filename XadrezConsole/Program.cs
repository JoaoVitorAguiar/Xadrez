using System;
using tabuleiro;
using xadrez;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0,0));
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1,4));
            tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(4,5));

            Tela.ImprimirTabuleiro(tab);
            Console.ReadLine();
        }
    }
}