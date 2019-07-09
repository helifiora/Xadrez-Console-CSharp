using System;
using tabuleiro;

namespace Chess_Console_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);
            Tela.ImprimirTabuleiro(tab);
        }
    }
}