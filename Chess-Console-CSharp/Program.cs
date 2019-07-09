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
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 1));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 2));
                tab.ColocarPeca(new Rei(tab, Cor.Branca), new Posicao(2, 7));

                Tela.ImprimirTabuleiro(tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}