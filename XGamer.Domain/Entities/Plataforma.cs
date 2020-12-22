using System;

namespace XGamer.Domain.Entities
{
    public class Plataforma
    {
        public Guid Id { get; set; }
        public string NomePlataforma { get; set; }



        public Plataforma()
        {

        }

        public Plataforma(Guid id, string nomePlataforma)
        {
            Id = id;
            NomePlataforma = nomePlataforma;
        }
    }

   

}
