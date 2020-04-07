using tabuleiro;
using System.Collections.Generic;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool Xeque { get; private set; }


        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }


        //public PartidaDeXadrez(Tabuleiro tab, int turno, Cor jogadorAtual)
        //{
        //    this.Tab = tab;
        //    this.turno = turno;
        //    this.jogadorAtual = jogadorAtual;
        //}

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.incrementaQtdeMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);

            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }

            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tab.RetirarPeca(destino);
            p.decrementaQteMovimentos();
            if (pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);

        }


        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Voce não pode se colocar em Xeque!");

            }

            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            turno++;
            mudaJogador();

        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (Tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não Existe peça na posição de origem!");
            }

            if (jogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça na posição escolhida não é sua!");
            }
            if (!Tab.Peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existe movimentos possíveis para a peça de origem escolhida! ");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida! ");
            }
        }
        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Preta;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }


        private Peca rei(Cor cor)
        {
            foreach (Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }

            return null;
        }

        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);

            if (R == null)
            {
                throw new TabuleiroException("Não tem Rei da cor " + cor + " no tabuleiro.");
            }

            foreach (Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();

                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }

            return false;
        }


        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }



        private void colocarPecas()
        {
            //Brancas

            colocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(Tab, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(Tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));

            //Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            //Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            //Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            //Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            //Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            //Tab.ColocarPeca(new Rei(Tab, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());
            //Pretas

            colocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Torre(Tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(Tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(Tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));

            

        }
    }
}
