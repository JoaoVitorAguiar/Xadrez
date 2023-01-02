using System.Collections.Generic;
using tabuleiro;
using tabuleiro.exception;
using XadrezConsole;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; } 
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez ()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 0;
            JogadorAtual = Cor.Branca;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
        }
        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.RetiraPeca(origem);
            p.qtdMovimentos++;
            Peca pecaCaputurada = Tabuleiro.RetiraPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
            if (pecaCaputurada != null) 
                capturadas.Add(pecaCaputurada);
        }
        private void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
             pecas.Add(peca);
        }
        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 3, new Rei(Tabuleiro, Cor.Preta));
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }
        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca) JogadorAtual = Cor.Preta;
            else JogadorAtual = Cor.Branca;
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> pecas = new HashSet<Peca>();
            foreach (Peca p in capturadas)
                if (p.Cor == cor)
                    pecas.Add(p);
            return pecas;
        }
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> pecas = new HashSet<Peca>();
            foreach (Peca p in pecas)
                if (p.Cor == cor)
                    pecas.Add(p);
            pecas.ExceptWith(PecasCapturadas(cor));
            return pecas;
        }

        public void ValidarPosicaoOrigem(Posicao posicao)
        {
            if (Tabuleiro.GetPeca(posicao) == null)
                throw new TabuleiroException("Não existe peça na posição de origem escolhida.");
            if (JogadorAtual != Tabuleiro.GetPeca(posicao).Cor)
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            if (!Tabuleiro.GetPeca(posicao).ExisteMovimentosPossiveis())
                throw new TabuleiroException("Não há movimento possiveis para a peça de origem escolhida");
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.GetPeca(origem).PodeMoverPara(destino))
                throw new TabuleiroException("Posiçao de destino inválida");
        }
    }
}
