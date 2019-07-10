using tabuleiro;

namespace xadrez
{
    public class Rei : Peca
    {
        private PartidaDeXadrez _partidaDeXadrez;

        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partidaDeXadrez) : base(tabuleiro, cor)
        {
            _partidaDeXadrez = partidaDeXadrez;
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
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;

            p.Define(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;

            p.Define(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;

            p.Define(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;

            p.Define(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;

            p.Define(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;

            p.Define(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;

            p.Define(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
                matrix[p.Linha, p.Coluna] = true;

            // Jogada Especial
            if (QtdMovimentos == 0 && !_partidaDeXadrez.Xeque)
            {
                tabuleiro.Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreParaRoque(posT1))
                {
                    tabuleiro.Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    tabuleiro.Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null)
                        matrix[Posicao.Linha, Posicao.Coluna + 2] = true;
                }

                tabuleiro.Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteTorreParaRoque(posT2))
                {
                    tabuleiro.Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    tabuleiro.Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    tabuleiro.Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null && Tabuleiro.Peca(p3) == null)
                        matrix[Posicao.Linha, Posicao.Coluna - 2] = true;
                }
            }

            return matrix;
        }

        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p != null && p is Torre && p.Cor == Cor && QtdMovimentos == 0;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}