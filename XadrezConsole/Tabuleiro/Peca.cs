namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int qtdMovimentos { get; set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor) 
        { 
            Posicao = null; 
            Cor = cor;
            Tabuleiro= tabuleiro;
            qtdMovimentos = 0;
        }
        public abstract bool[,] MovimentosPossiveis();
    }
}
