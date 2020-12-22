using XGamer.Domain.Arguments.Plataforma;

namespace XGamer.Domain.Interfaces.Services
{
    public interface IServicePlataforma
    {
        AdiconarPlataformaResponse AdicionarPlataforma(AdicionarPlataformaRequest request);
    }
}
