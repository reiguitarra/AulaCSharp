using System;

namespace XGamer.Domain.Entities
{
    public class MeuJogo
    {
        public Guid Id { get; set; }
        public JogoPlataforma JogoPlataforma { get; set; }
        public bool Desejo { get; set; }
        public DateTime DtDesejo { get; set; }
        public bool Troca { get; set; }
        public bool Venda { get; set; }

        public MeuJogo()
        {

        }

        public MeuJogo(Guid id, JogoPlataforma jogoPlataforma, bool desejo, DateTime dtDesejo, bool troca, bool venda)
        {
            Id = id;
            JogoPlataforma = jogoPlataforma;
            Desejo = desejo;
            DtDesejo = dtDesejo;
            Troca = troca;
            Venda = venda;
        }
    }
}
