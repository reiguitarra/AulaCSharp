using System;
using XGamer.Domain.Arguments.Jogador;
using XGamer.Domain.Interfaces.Repositories;
using XGamer.Domain.Interfaces.Services;

namespace XGamer.Domain.Services
{
    class ServiceJogador : IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
           Guid id = _repositoryJogador.AdicionarJogador(request);

            return new AdicionarJogadorResponse() { Id = id, Message = "Operação realizada com Sucesso! " };
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
               throw new Exception("O AutenticarJogadorRequest é obrigatório!");

            }

            if (string.IsNullOrEmpty(request.Email))
            {
                throw new Exception("Informe um E-Mail Válido!!");
            }

            if (string.IsNullOrEmpty(request.Senha))
            {
                throw new Exception("Informe uma Senha");
            }

            if (request.Senha.Length < 6)
            {
                throw new Exception("A senha deve conter no mínimo 6 caracteresS");
            }

            var response = _repositoryJogador.AutenticarJogador(request);
            
            return response;
        }
    }
}
