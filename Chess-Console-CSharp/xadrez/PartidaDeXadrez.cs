using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using tabuleiro;

namespace xadrez
{
    public class PartidaDeXadrez
    {
        public bool Xeque { get; set; }
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; set; }
        public bool Terminado { get; private set; }

        public HashSet<Peca> Pecas { get; set; }

        public HashSet<Peca> Capturadas { get; set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminado = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementaQtdeMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
            if (pecaCapturada != null)
                Capturadas.Add(pecaCapturada);
            
            return pecaCapturada;
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca peca = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, peca);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if (EstaEmXeque(Adversaria(JogadorAtual)))
                Xeque = true;
            else
                Xeque = false;
            
            Turno++;
            MudaJogador();
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tabuleiro.RetirarPeca(destino);
            p.DecrementaQtdeMovimento();
            if (pecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            
            Tabuleiro.ColocarPeca(p, origem);
        }
        
        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca xCapturada in Capturadas)
            {
                if (xCapturada.Cor == cor)
                    aux.Add(xCapturada);
            }

            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca xCapturada in Pecas)
            {
                if (xCapturada.Cor == cor)
                    aux.Add(xCapturada);
            }

            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
                return Cor.Preta;
            else
                return Cor.Branca;
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if (x is Rei)
                    return x;
            }

            return null;
        }
        
        private void MudaJogador()
        {
            JogadorAtual = JogadorAtual == Cor.Branca ? Cor.Preta : Cor.Branca;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca r = Rei(cor);
            if(r == null)
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            
            foreach (Peca peca in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = peca.MovimentosPossiveis();
                if (mat[r.Posicao.Linha, r.Posicao.Coluna])
                    return true;
            }

            return false;
        }
        
        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (Tabuleiro.Peca(pos) == null)
                throw new TabuleiroException("Não Existe Peça na Posição de Origem Escolhida!");
            if (JogadorAtual != Tabuleiro.Peca(pos).Cor)
                throw new TabuleiroException("A Peça de Origem Escolhida Não é Sua!");
            if (!Tabuleiro.Peca(pos).ExisteMovimentosPossiveis())
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.Peca(origem).PodeMoverPara(destino))
                throw new TabuleiroException("Posição de Destino Inválida!");
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrex(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tabuleiro, Cor.Branca));
            
            ColocarNovaPeca('c', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('c', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tabuleiro, Cor.Preta));
        }
    }
}