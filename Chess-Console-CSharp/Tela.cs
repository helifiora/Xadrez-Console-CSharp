using System;
using tabuleiro;
using xadrez;

namespace Chess_Console_CSharp
{
    public class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    ImprimePeca(tabuleiro.Peca(i, j));
                    Console.Write(" ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                        Console.BackgroundColor = fundoAlterado;
                    else
                        Console.BackgroundColor = fundoOriginal;
                        
                    ImprimePeca(tabuleiro.Peca(i, j));
                    Console.Write(" ");
                    Console.BackgroundColor = fundoOriginal;
                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }
        
        public static void ImprimePeca(Peca peca)
        {
            if (peca == null)
                Console.Write("-");
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                
                if (peca.Cor == Cor.Branca)
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                else
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.Write(peca);

                Console.ForegroundColor = aux;
            }
        }
        
        

        public static PosicaoXadrex LerPosicaoXadrex()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrex(coluna, linha);
        }
    }
}