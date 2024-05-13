using MediatR;

namespace XpChallenge.Investimento.Application.Queries.ObterCarteira
{
    public class ObterCarteiraQuery(Guid idCliente) : IRequest<ObterCarteiraQueryResponse>
    {
        public Guid IdCliente { get; set; } = idCliente;
    }
}
