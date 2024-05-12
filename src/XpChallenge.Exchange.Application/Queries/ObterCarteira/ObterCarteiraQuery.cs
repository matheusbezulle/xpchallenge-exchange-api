using MediatR;

namespace XpChallenge.Exchange.Application.Queries.ObterCarteira
{
    public class ObterCarteiraQuery(Guid idCliente) : IRequest<ObterCarteiraQueryResponse>
    {
        public Guid IdCliente { get; set; } = idCliente;
    }
}
