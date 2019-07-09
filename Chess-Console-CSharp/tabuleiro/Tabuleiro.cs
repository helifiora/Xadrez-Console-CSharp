namespace tabuleiro
{
    public class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca Peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public void ColocarPeca(Peca p, Posicao posicao)
        {
            if (ExistePeca(posicao))
                throw new TabuleiroException("Já existe uma peça nessa posição!");

            pecas[posicao.Linha, posicao.Coluna] = p;
            p.Posicao = posicao;
        }

        public Peca RetirarPeca(Posicao posicao)
        {
            if (Peca(posicao.Linha, posicao.Coluna) == null)
                return null;

            tabuleiro.Peca aux = Peca(posicao.Linha, posicao.Coluna);
            aux.Posicao = null;
            pecas[posicao.Linha, posicao.Coluna] = null;
            return aux;
        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return Peca(posicao.Linha, posicao.Coluna) != null;
        }

        public bool PosicaoValida(Posicao posicao)
        {
            return !(posicao.Linha < 0 || posicao.Linha >= Linhas ||
                     posicao.Coluna < 0 || posicao.Coluna >= Colunas);
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if (!PosicaoValida(posicao))
                throw new TabuleiroException("Posição Inválida!");
        }
    }
}