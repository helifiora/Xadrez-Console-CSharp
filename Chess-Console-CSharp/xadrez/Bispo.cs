using System.Runtime.InteropServices.WindowsRuntime;
using tabuleiro;

namespace xadrez
{
    public class Bispo : Peca
    {
        public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca p = Tabuleiro.Peca(posicao);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao p = new Posicao(0, 0);

            p.Define(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tabuleiro.Peca(p) != null && Tabuleiro.Peca(p).Cor != Cor)
                    break;

                p.Define(p.Linha - 1, p.Coluna - 1);
            }

            p.Define(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tabuleiro.Peca(p) != null && Tabuleiro.Peca(p).Cor != Cor)
                    break;

                p.Define(p.Linha - 1, p.Coluna + 1);
            }


            p.Define(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tabuleiro.Peca(p) != null && Tabuleiro.Peca(p).Cor != Cor)
                    break;

                p.Define(p.Linha + 1, p.Coluna + 1);
            }


            p.Define(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tabuleiro.Peca(p) != null && Tabuleiro.Peca(p).Cor != Cor)
                    break;

                p.Define(p.Linha + 1, p.Coluna + 1);
            }

            return mat;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}