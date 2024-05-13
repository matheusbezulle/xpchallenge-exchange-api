using MediatR;

namespace XpChallenge.Investimento.Application.Queries.ObterExtrato
{
    public class ObterExtratoQuery(Guid idCliente) : IRequest<ObterExtratoQueryResponse>
    {
        public Guid IdCliente { get; set; } = idCliente;
    }
}
