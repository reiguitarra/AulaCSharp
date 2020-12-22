using XGamer.Domain.Arguments.Jogador;

namespace XGamer.Domain.Interfaces.Services
{
    public interface IServiceJogador
    {
       AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);

       AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request);
    }
}
