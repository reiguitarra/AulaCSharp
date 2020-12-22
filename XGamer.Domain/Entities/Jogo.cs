using System;

namespace XGamer.Domain.Entities
{
    public class Jogo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Produtora { get; set; }
        public string Distribuidora { get; set; }
        public string Genero { get; set; }
        public string Site { get; set; }

        public Jogo()
        {

        }

        public Jogo(Guid id, string nome, string descricao, string produtora, string distribuidora, string genero, string site)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Produtora = produtora;
            Distribuidora = distribuidora;
            Genero = genero;
            Site = site;
        }
    }
}
