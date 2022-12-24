namespace XadrezConsole.tabuleiro
{
    internal class Tabuleiro
    {
        public int Linha { get; set; }
        public int Colunas { get; set; }
        public Peca[,] Pecas; 
        public Tabuleiro (int linha, int colunas)
        {
            Linha = linha; Colunas = colunas;
            Pecas = new Peca[linha, colunas];
        }
    }
}
