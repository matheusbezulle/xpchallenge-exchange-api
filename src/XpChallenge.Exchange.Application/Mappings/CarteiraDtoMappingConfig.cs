using Mapster;
using XpChallenge.Exchange.Application.DataTransfer;
using XpChallenge.Exchange.Domain.AggregateRoots;

namespace XpChallenge.Exchange.Application.Mappings
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
