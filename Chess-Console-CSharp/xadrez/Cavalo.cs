using tabuleiro;

namespace xadrez
{
    public class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public bool PodeMover(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao p = new Posicao(0, 0);
            
            p.Define(Posicao.Linha - 1, Posicao.Coluna -2);
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                mat[p.Linha, p.Coluna] = true;
            
            p.Define(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                mat[p.Linha, p.Coluna] = true;
            
            p.Define(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                mat[p.Linha, p.Coluna] = true;

            p.Define(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                mat[p.Linha, p.Coluna] = true;
            
            p.Define(Posicao.Linha + 1, Posicao.Coluna -2);
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                mat[p.Linha, p.Coluna] = true;
            
            p.Define(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                mat[p.Linha, p.Coluna] = true;
            
            p.Define(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                mat[p.Linha, p.Coluna] = true;

            p.Define(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                mat[p.Linha, p.Coluna] = true;

            return mat;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}