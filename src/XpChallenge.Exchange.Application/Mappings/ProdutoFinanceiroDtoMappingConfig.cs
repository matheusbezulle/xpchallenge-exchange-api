using Mapster;
using XpChallenge.Exchange.Application.DataTransfer;
using XpChallenge.Exchange.Domain.ValueObjects;

namespace XpChallenge.Exchange.Application.Mappings
{
    public class ProdutoFinanceiroDtoMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProdutoFinanceiro, ProdutoFinanceiroDto>()
                .Map(dest => dest.ValorTotal, src => src.ValorMedia * src.Quantidade);
        }
    }
}
