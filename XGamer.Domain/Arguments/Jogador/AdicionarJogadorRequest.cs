using XGamer.Domain.Interfaces.Arguments;
using XGamer.Domain.ValueObjects;

namespace XGamer.Domain.Arguments.Jogador
{
    public class AdicionarJogadorRequest : IRequest
    {
        public Nome Nome { get; set; }
        public Email Email { get; set; }
        public string Senha { get; set; }
    }
}
