using System;
using tabuleiro;
using Xadrez;

namespace JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);

                    Console.WriteLine();
                    Console.Write("Origem : ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    bool[,] posicoesPossiveis = partida.Tab.Peca(origem).movimentosPossiveis();
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                    Console.Write("Destino : ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.executaMovimento(origem, destino);
                }

                
            }
            catch (TabuleiroException e)
            {

                Console.WriteLine(e.Message);
            }
            

            Console.ReadKey();
        }
    }
}
