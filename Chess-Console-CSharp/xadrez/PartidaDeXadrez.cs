using tabuleiro;

namespace xadrez
{
    public class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; set; }
        public bool Terminado { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminado = false;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementaQtdeMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        private void MudaJogador()
        {
            JogadorAtual = JogadorAtual == Cor.Branca ? Cor.Preta : Cor.Branca;
        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if(Tabuleiro.Peca(pos) == null)
                throw new TabuleiroException("Não Existe Peça na Posição de Origem Escolhida!");
            if (JogadorAtual != Tabuleiro.Peca(pos).Cor)
                throw new TabuleiroException("A Peça de Origem Escolhida Não é Sua!");
            if(!Tabuleiro.Peca(pos).ExisteMovimentosPossiveis())
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if(!Tabuleiro.Peca(origem).PodeMoverPara(destino))
                throw new TabuleiroException("Posição de Destino Inválida!");
        }
        
        private void ColocarPecas()
        {
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrex('c', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrex('c', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrex('d', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrex('e', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrex('e', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Branca), new PosicaoXadrex('d', 1).ToPosicao());
            
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrex('c', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrex('c', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrex('d', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrex('e', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrex('e', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Preta), new PosicaoXadrex('d', 8).ToPosicao());

        }
    }
}