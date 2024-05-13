using MapsterMapper;
using MediatR;
using XpChallenge.Investimento.Application.DataTransfer;
using XpChallenge.Investimento.Application.Services.Interfaces;

namespace XpChallenge.Investimento.Application.Queries.ObterExtrato
{
    public class ObterExtratoQueryHandler(IOperacaoService operacaoService,
        IMapper mapper) : IRequestHandler<ObterExtratoQuery, ObterExtratoQueryResponse>
    {
        private readonly IOperacaoService _operacaoService = operacaoService;
        private readonly IMapper _mapper = mapper;

        public async Task<ObterExtratoQueryResponse> Handle(ObterExtratoQuery request, CancellationToken cancellationToken)
        {
            var response = new ObterExtratoQueryResponse();

            var operacoes = await _operacaoService.ObterPorIdClienteAsync(request.IdCliente, cancellationToken);

            if (operacoes.Count == 0)
                return response;

            response.Registros = _mapper.Map<List<RegistroOperacaoDto>>(operacoes);

            return response;
        }
    }
}
