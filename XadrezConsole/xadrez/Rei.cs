using tabuleiro;

namespace xadrez
{
    internal class Rei : Peca
    {
        private PartidaDeXadrez Partida;
        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor) 
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool TesteTorreRoque(Posicao pos)
        {
            Peca p = Tabuleiro.GetPeca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.qtdMovimentos == 0;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);

            // Norte
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            // Nordeste
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            // Leste
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            // Suldeste
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            // Sul
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            // Suldoeste
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            // Oeste
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            // Noroeste
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            // # Jogada Especial - roque
            if (qtdMovimentos == 0 && !Partida.Xeque)
            {
                // Roque pequeno
                Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreRoque(posT1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tabuleiro.GetPeca(p1) == null && Tabuleiro.GetPeca(p2) == null)
                        matriz[Posicao.Linha, Posicao.Coluna + 2] = true;
                }
                // Roque pequeno
                Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteTorreRoque(posT2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tabuleiro.GetPeca(p1) == null && Tabuleiro.GetPeca(p2) == null && Tabuleiro.GetPeca(p3) == null)
                        matriz[Posicao.Linha, Posicao.Coluna - 2] = true;
                }
            }



            return matriz;
        }
    }
}
