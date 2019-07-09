using System;
using tabuleiro;
using xadrez;

namespace Chess_Console_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partidaDeXadrez = new PartidaDeXadrez();
                while (!partidaDeXadrez.Terminado)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro);
                    Console.WriteLine();
                    Console.WriteLine("Turno: " + partidaDeXadrez.Turno);
                    Console.WriteLine("Aguardando Jogada: " + partidaDeXadrez.JogadorAtual);
                    
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrex().ToPosicao();
                    partidaDeXadrez.ValidarPosicaoOrigem(origem);

                    bool[,] posicoesPossiveis = partidaDeXadrez.Tabuleiro.Peca(origem).MovimentosPossiveis();
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro, posicoesPossiveis);
                    
                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrex().ToPosicao();
                    partidaDeXadrez.ValidarPosicaoDestino(origem, destino);
                    
                    partidaDeXadrez.RealizaJogada(origem, destino);
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}