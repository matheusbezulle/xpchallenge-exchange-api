using Mapster;
using XpChallenge.Investimento.Application.DataTransfer;
using XpChallenge.Investimento.Domain.ValueObjects;

namespace XpChallenge.Investimento.Application.Mappings
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
