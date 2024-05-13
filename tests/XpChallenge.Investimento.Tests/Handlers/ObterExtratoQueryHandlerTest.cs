using MapsterMapper;
using Moq;
using XpChallenge.Investimento.Application.DataTransfer;
using XpChallenge.Investimento.Application.Queries.ObterExtrato;
using XpChallenge.Investimento.Application.Services.Interfaces;
using XpChallenge.Investimento.Domain.AggregateRoots;
using XpChallenge.Investimento.Domain.ValueObjects;

namespace XpChallenge.Investimento.Tests.Handlers
{
    public class ObterExtratoQueryHandlerTest
    {
        private readonly Mock<IOperacaoService> _operacaoServiceMock;
        private readonly Mock<IMapper> _mapperMock;

        private readonly ObterExtratoQueryHandler _handler;

        public ObterExtratoQueryHandlerTest()
        {
            _operacaoServiceMock = new Mock<IOperacaoService>();
            _mapperMock = new Mock<IMapper>();

            _handler = new(_operacaoServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task ObterExtrato_Sucesso()
        {
            var query = new ObterExtratoQuery(Guid.NewGuid());

            _operacaoServiceMock.Setup(x => x.ObterPorIdClienteAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync([
                    new(Guid.NewGuid(),
                        TipoOperacao.Compra,
                        "PETR4",
                        41.37M,
                        10)
                ]);

            _mapperMock.Setup(x => x.Map<List<RegistroOperacaoDto>>(It.IsAny<List<Operacao>>()))
                .Returns([
                    new()
                ]);

            var result = await _handler.Handle(query, new CancellationToken());

            Assert.NotEmpty(result.Registros);
        }

        [Fact]
        public async Task ObterExtrato_ExtratoVazio_Sucesso()
        {
            var query = new ObterExtratoQuery(Guid.NewGuid());

            _operacaoServiceMock.Setup(x => x.ObterPorIdClienteAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync([]);

            var result = await _handler.Handle(query, new CancellationToken());

            Assert.Empty(result.Registros);
        }
    }
}
