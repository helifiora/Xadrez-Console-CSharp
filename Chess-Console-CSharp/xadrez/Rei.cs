using tabuleiro;

namespace xadrez
{
    public class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca p = Tabuleiro.Peca(posicao);
            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matrix = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao p = new Posicao(Posicao.Linha, Posicao.Coluna);
            
            p.Define(Posicao.Linha - 1, Posicao.Coluna);
            if (PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;

            p.Define(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;
            
            p.Define(Posicao.Linha, Posicao.Coluna + 1);
            if (PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;

            p.Define(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;
            
            p.Define(Posicao.Linha + 1, Posicao.Coluna);
            if (PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;
            
            p.Define(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;
            
            p.Define(Posicao.Linha, Posicao.Coluna - 1);
            if (PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;

            p.Define(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;

            return matrix;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}