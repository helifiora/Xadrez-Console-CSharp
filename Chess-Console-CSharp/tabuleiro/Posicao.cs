namespace tabuleiro
{
    public class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public void Define(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
        
        public override string ToString()
        {
            return $"Posicao[Linha: {Linha:00}, Coluna: {Coluna:00}]";
        }
    }
}