using XGamer.Domain.Arguments.Jogador;
using System;

namespace XGamer.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);

       Guid AdicionarJogador(AdicionarJogadorRequest request);
    }
}
    