using MediatR;

namespace XpChallenge.Exchange.Application.Queries.ObterExtrato
{
    public class ObterExtratoQuery(Guid idCliente) : IRequest<ObterExtratoQueryResponse>
    {
        public Guid IdCliente { get; set; } = idCliente;
    }
}
