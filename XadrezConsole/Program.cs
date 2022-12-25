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
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(-2, 5));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(4, 5));

                Tela.ImprimirTabuleiro(tab);
                Console.ReadLine();
            } catch( TabuleiroException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}