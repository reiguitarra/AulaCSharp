﻿using System;
using tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        private bool podeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor;
        }


        public override bool[,] movimentosPossiveis()
        {

            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);


            //acima
            pos.definirValores(Posicao.Linha - 1 , Posicao.Coluna);

            while (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {

                    break;
                }

                pos.Linha -= 1;
            }

            //abaixo

            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);

            while (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {

                    break;
                }

                pos.Linha += 1;
            }

            //direita

            
            pos.definirValores(Posicao.Linha, Posicao.Coluna + 1);

            while (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {

                    break;
                }

                pos.Coluna += 1;
            }

            //esquerda


            pos.definirValores(Posicao.Linha, Posicao.Coluna - 1);

            while (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {

                    break;
                }

                pos.Coluna -= 1;
            }


            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
