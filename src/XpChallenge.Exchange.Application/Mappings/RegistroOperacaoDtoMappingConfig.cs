using Mapster;
using XpChallenge.Exchange.Application.DataTransfer;
using XpChallenge.Exchange.Domain.AggregateRoots;

namespace XpChallenge.Exchange.Application.Mappings
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
