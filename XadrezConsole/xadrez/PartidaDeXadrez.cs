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
        public bool Xeque { get; private set; }

        public PartidaDeXadrez ()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 0;
            JogadorAtual = Cor.Branca;
            Xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
        }
        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.RetiraPeca(origem);
            p.qtdMovimentos++;
            Peca pecaCaputurada = Tabuleiro.RetiraPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
            if (pecaCaputurada != null) 
                capturadas.Add(pecaCaputurada);
            return pecaCaputurada;
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
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual)) 
            {
                DezfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }
            Xeque = EstaEmXeque(Adversaio(JogadorAtual)) ? true : false;
            Turno++;
            MudaJogador();
        }

        private void DezfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tabuleiro.RetiraPeca(destino);
            p.qtdMovimentos--;
            if (pecaCapturada != null) {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
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

        private Cor Adversaio(Cor cor)
        {
            return cor == Cor.Branca ? Cor.Preta : Cor.Branca;
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if (x is Rei) return x;
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca r = Rei(cor);
            if (r == null) throw new TabuleiroException($"Não tem rei da cor {cor} no tabuleiro.");
            foreach (Peca x in PecasEmJogo(Adversaio(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[r.Posicao.Linha, r.Posicao.Coluna]) return true;
            }
            return false;
        }

        public void ValidarPosicaoOrigem(Posicao posicao)
        {
            if (Tabuleiro.GetPeca(posicao) == null)
                throw new TabuleiroException("Não existe peça na posição de origem escolhida.");
            if (JogadorAtual != Tabuleiro.GetPeca(posicao).Cor)
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            if (!Tabuleiro.GetPeca(posicao).ExisteMovimentosPossiveis())
                throw new TabuleiroException("Não há movimento possiveis para a peça de origem escolhida.");
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.GetPeca(origem).PodeMoverPara(destino))
                throw new TabuleiroException("Posiçao de destino inválida");
        }
    }
}
