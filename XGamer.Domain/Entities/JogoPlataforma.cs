using System;

namespace XGamer.Domain.Entities
{
    public class JogoPlataforma
    {
        public Guid Id { get; set; }
        public Jogo Jogo { get; set; }
        public Plataforma Plataforma { get; set; }
        public DateTime DtLancamento { get; set; }

        public JogoPlataforma()
        {

        }
        public JogoPlataforma(Guid id, Jogo jogo, Plataforma plataforma, DateTime dtLancamento)
        {
            Id = id;
            Jogo = jogo;
            Plataforma = plataforma;
            DtLancamento = dtLancamento;
        }
    }
}
