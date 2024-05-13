using Mapster;
using XpChallenge.Investimento.Application.DataTransfer;
using XpChallenge.Investimento.Domain.AggregateRoots;

namespace XpChallenge.Investimento.Application.Mappings
{
    public class CarteiraDtoMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Carteira, CarteiraDto>()
                .Map(dest => dest.ValorTotal, src => src.ProdutosFinanceiros.Sum(p => p.ValorMedia * p.Quantidade));
        }
    }
}
