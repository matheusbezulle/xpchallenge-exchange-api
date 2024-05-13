using Mapster;
using XpChallenge.Investimento.Application.DataTransfer;
using XpChallenge.Investimento.Domain.AggregateRoots;

namespace XpChallenge.Investimento.Application.Mappings
{
    public class RegistroOperacaoDtoMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Operacao, RegistroOperacaoDto>()
                .Map(dest => dest.TipoOperacao, src => src.Tipo.ToString())
                .Map(dest => dest.Valor, src => src.ValorTotal)
                .Map(dest => dest.Descricao, src => $"{src.Quantidade}x {src.NomeProdutoFinanceiro}");
        }
    }
}
