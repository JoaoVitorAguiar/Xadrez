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
                PosicaoXadrez pos = new PosicaoXadrez('a', 1);
                Console.WriteLine(pos);
                Console.WriteLine(pos.ToPosicao());
                
            } catch( TabuleiroException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}