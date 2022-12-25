using tabuleiro.exception;
namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;
        public Tabuleiro(int linha, int colunas)
        {
            Linhas = linha; Colunas = colunas;
            Pecas = new Peca[linha, colunas];
        }

        public Peca GetPeca(int linha, int coluna)
        {
            return Pecas[linha, coluna];

        }
        public Peca GetPeca(Posicao posicao)
        {
            return Pecas[posicao.Linha, posicao.Coluna];
        }
        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return GetPeca(posicao) != null;
        }
        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if (ExistePeca(posicao)) throw new TabuleiroException("Já existe uma peça nessa posição!");
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }
        public bool PosicaoValida(Posicao posicao)
        {
            if (posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas ) return false;
            return true;
        }
        public void ValidarPosicao(Posicao posicao)
        {
            if (!PosicaoValida(posicao)) throw new TabuleiroException("Posição Inválida!");
        }
    }
}
