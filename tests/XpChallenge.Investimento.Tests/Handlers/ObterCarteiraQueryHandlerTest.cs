using MapsterMapper;
using Moq;
using XpChallenge.Investimento.Application.DataTransfer;
using XpChallenge.Investimento.Application.Notifications;
using XpChallenge.Investimento.Application.Queries.ObterCarteira;
using XpChallenge.Investimento.Application.Services.Interfaces;
using XpChallenge.Investimento.Domain.AggregateRoots;

namespace XpChallenge.Investimento.Tests.Handlers
{
    public class ObterCarteiraQueryHandlerTest
    {
        private readonly Mock<ICarteiraService> _carteiraServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<INotificator> _notificatorMock;

        private readonly ObterCarteiraQueryHandler _handler;

        public ObterCarteiraQueryHandlerTest()
        {
            _carteiraServiceMock = new Mock<ICarteiraService>();
            _mapperMock = new Mock<IMapper>();
            _notificatorMock = new Mock<INotificator>();

            _handler = new(_carteiraServiceMock.Object, _mapperMock.Object, _notificatorMock.Object);
        }

        [Fact]
        public async Task ObterCarteira_Sucesso()
        {
            var query = new ObterCarteiraQuery(Guid.NewGuid());

            _carteiraServiceMock.Setup(x => x.ObterPorIdClienteAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Carteira(Guid.NewGuid()));

            _mapperMock.Setup(x => x.Map<CarteiraDto>(It.IsAny<Carteira>()))
                .Returns(new CarteiraDto());

            _notificatorMock.Setup(x => x.AdicionarErroNegocio(It.IsAny<string>()))
                .Verifiable();

            var result = await _handler.Handle(query, new CancellationToken());

            Assert.NotNull(result);
            Assert.NotNull(result.Carteira);
            _notificatorMock.Verify(x => x.AdicionarErroNegocio(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task ObterCarteira_CarteiraInexistente_Falha()
        {
            var query = new ObterCarteiraQuery(Guid.NewGuid());

            _carteiraServiceMock.Setup(x => x.ObterPorIdClienteAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Carteira)null!);

            _notificatorMock.Setup(x => x.AdicionarErroNegocio(It.IsAny<string>()))
                .Verifiable();

            var result = await _handler.Handle(query, new CancellationToken());

            Assert.NotNull(result);
            Assert.Null(result.Carteira);
            _notificatorMock.Verify(x => x.AdicionarErroNegocio(It.IsAny<string>()), Times.Once);
        }
    }
}
