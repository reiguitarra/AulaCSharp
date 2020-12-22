using System;
using XGamer.Domain.Enums;
using XGamer.Domain.ValueObjects;

namespace XGamer.Domain.Entities
{
    class Jogador
    {
        
        public Guid Id { get; set; }
        public Nome Nome { get; set; }
        public Email Email { get; set; }
        public string Senha { get; set; }
        public EnumSituacaoJogador Status { get; set; }

        public Jogador()
        {

        }

        public Jogador(Guid id, Nome nome, Email email, string senha, EnumSituacaoJogador status)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Status = status;
        }
    }
}
