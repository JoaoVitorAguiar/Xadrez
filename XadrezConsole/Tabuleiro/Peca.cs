﻿namespace tabuleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor) 
        { 
            Posicao = null; 
            Cor = cor;
            Tabuleiro= tabuleiro;
            qtdMovimentos = 0;
        }
    }
}