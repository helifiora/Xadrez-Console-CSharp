using tabuleiro;

namespace xadrez
{
    public class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }
        private bool PodeMover(Posicao posicao)
        {
            Peca p = Tabuleiro.Peca(posicao.Linha, posicao.Coluna);
            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao p = new Posicao(0, 0);
            
            // acima
            p.Define(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tabuleiro.Peca(p.Linha, p.Coluna) != null && Tabuleiro.Peca(p.Linha, p.Coluna).Cor != Cor)
                    break;

                p.Linha -= 1;
            }
            
            // abaixo
            p.Define(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tabuleiro.Peca(p.Linha, p.Coluna) != null && Tabuleiro.Peca(p.Linha, p.Coluna).Cor != Cor)
                    break;

                p.Linha += 1;
            }

            // esquerda
            p.Define(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tabuleiro.Peca(p.Linha, p.Coluna) != null && Tabuleiro.Peca(p.Linha, p.Coluna).Cor != Cor)
                    break;

                p.Coluna -= 1;
            }
            
            // direita
            p.Define(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tabuleiro.Peca(p.Linha, p.Coluna) != null && Tabuleiro.Peca(p.Linha, p.Coluna).Cor != Cor)
                    break;

                p.Coluna += 1;
            }

            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}