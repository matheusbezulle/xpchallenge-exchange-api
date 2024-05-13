using Moq;
using XpChallenge.Investimento.Application.Commands.ComprarProdutoFinanceiro;
using XpChallenge.Investimento.Application.Notifications;
using XpChallenge.Investimento.Application.Services.Interfaces;
using XpChallenge.Investimento.Domain.AggregateRoots;

namespace XpChallenge.Investimento.Tests.Handlers
{
    public class ComprarProdutoFinanceiroCommandHandlerTest
    {
        private readonly Mock<IProdutoFinanceiroService> _produtoFinanceiroServiceMock;
        private readonly Mock<ICarteiraService> _carteiraServiceMock;
        private readonly Mock<IOperacaoService> _operacaoServiceMock;
        private readonly Mock<INotificator> _notificatorMock;

        private readonly ComprarProdutoFinanceiroCommandHandler _handler;

        public ComprarProdutoFinanceiroCommandHandlerTest()
        {
            _produtoFinanceiroServiceMock = new Mock<IProdutoFinanceiroService>();
            _carteiraServiceMock = new Mock<ICarteiraService>();
            _operacaoServiceMock = new Mock<IOperacaoService>();
            _notificatorMock = new Mock<INotificator>();

            _handler = new(_produtoFinanceiroServiceMock.Object, _carteiraServiceMock.Object, _operacaoServiceMock.Object, _notificatorMock.Object);
        }

        [Fact]
        public async Task ComprarProdutoFinanceiro_Sucesso()
        {
            var command = new ComprarProdutoFinanceiroCommand(Guid.NewGuid(), "PETR4", 10);

            _produtoFinanceiroServiceMock.Setup(x => x.ObterCotacaoAtualAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(5.69M);

            _notificatorMock.Setup(x => x.AdicionarErroNegocio(It.IsAny<string>()))
                .Verifiable();

            _operacaoServiceMock.Setup(x => x.RegistrarOperacaoAsync(It.IsAny<Carteira>(), It.IsAny<Operacao>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            await _handler.Handle(command, new CancellationToken());

            _notificatorMock.Verify(x => x.AdicionarErroNegocio(It.IsAny<string>()), Times.Never);
            _operacaoServiceMock.Verify(x => x.RegistrarOperacaoAsync(It.IsAny<Carteira>(), It.IsAny<Operacao>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ComprarProdutoFinanceiro_CotacaoIndisponivel_Falha()
        {
            var command = new ComprarProdutoFinanceiroCommand(Guid.NewGuid(), "PETR4", 10);

            _produtoFinanceiroServiceMock.Setup(x => x.ObterCotacaoAtualAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(0M);

            _notificatorMock.Setup(x => x.AdicionarErroNegocio(It.IsAny<string>()))
                .Verifiable();

            _operacaoServiceMock.Setup(x => x.RegistrarOperacaoAsync(It.IsAny<Carteira>(), It.IsAny<Operacao>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            await _handler.Handle(command, new CancellationToken());

            _notificatorMock.Verify(x => x.AdicionarErroNegocio(It.IsAny<string>()), Times.Once);
            _operacaoServiceMock.Verify(x => x.RegistrarOperacaoAsync(It.IsAny<Carteira>(), It.IsAny<Operacao>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
