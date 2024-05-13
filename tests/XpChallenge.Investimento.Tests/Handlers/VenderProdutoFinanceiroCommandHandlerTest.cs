using Moq;
using XpChallenge.Investimento.Application.Commands.VenderProdutoFinanceiro;
using XpChallenge.Investimento.Application.Notifications;
using XpChallenge.Investimento.Application.Services.Interfaces;
using XpChallenge.Investimento.Domain.AggregateRoots;
using XpChallenge.Investimento.Domain.ValueObjects;

namespace XpChallenge.Investimento.Tests.Handlers
{
    public class VenderProdutoFinanceiroCommandHandlerTest
    {
        private readonly Mock<IProdutoFinanceiroService> _produtoFinanceiroServiceMock;
        private readonly Mock<ICarteiraService> _carteiraServiceMock;
        private readonly Mock<IOperacaoService> _operacaoServiceMock;
        private readonly Mock<INotificator> _notificatorMock;

        private readonly VenderProdutoFinanceiroCommandHandler _handler;

        public VenderProdutoFinanceiroCommandHandlerTest()
        {
            _produtoFinanceiroServiceMock = new Mock<IProdutoFinanceiroService>();
            _carteiraServiceMock = new Mock<ICarteiraService>();
            _operacaoServiceMock = new Mock<IOperacaoService>();
            _notificatorMock = new Mock<INotificator>();

            _handler = new(_produtoFinanceiroServiceMock.Object, _carteiraServiceMock.Object, _operacaoServiceMock.Object, _notificatorMock.Object);
        }

        [Fact]
        public async Task VenderProdutoFinanceiro_Sucesso()
        {
            var command = new VenderProdutoFinanceiroCommand(Guid.NewGuid(), "PETR4", 4);

            _carteiraServiceMock.Setup(x => x.ObterPorIdClienteAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GerarCarteira());

            _produtoFinanceiroServiceMock.Setup(x => x.ObterCotacaoAtualAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(41.94M);

            _notificatorMock.Setup(x => x.AdicionarErroNegocio(It.IsAny<string>()))
                .Verifiable();

            await _handler.Handle(command, new CancellationToken());

            _notificatorMock.Verify(x => x.AdicionarErroNegocio(It.IsAny<string>()), Times.Never);
            _operacaoServiceMock.Verify(x => x.RegistrarOperacaoAsync(It.IsAny<Carteira>(), It.IsAny<Operacao>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task VenderProdutoFinanceiro_QuantidadeIgualADisponivel_Sucesso()
        {
            var command = new VenderProdutoFinanceiroCommand(Guid.NewGuid(), "PETR4", 5);

            _carteiraServiceMock.Setup(x => x.ObterPorIdClienteAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GerarCarteira());

            _produtoFinanceiroServiceMock.Setup(x => x.ObterCotacaoAtualAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(41.94M);

            _notificatorMock.Setup(x => x.AdicionarErroNegocio(It.IsAny<string>()))
                .Verifiable();

            await _handler.Handle(command, new CancellationToken());

            _notificatorMock.Verify(x => x.AdicionarErroNegocio(It.IsAny<string>()), Times.Never);
            _operacaoServiceMock.Verify(x => x.RegistrarOperacaoAsync(It.IsAny<Carteira>(), It.IsAny<Operacao>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task VenderProdutoFinanceiro_CarteiraVazia_Falha()
        {
            var command = new VenderProdutoFinanceiroCommand(Guid.NewGuid(), "PETR4", 10);

            _carteiraServiceMock.Setup(x => x.ObterPorIdClienteAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Carteira)null!);

            _notificatorMock.Setup(x => x.AdicionarErroNegocio(It.IsAny<string>()))
                .Verifiable();

            await _handler.Handle(command, new CancellationToken());

            _notificatorMock.Verify(x => x.AdicionarErroNegocio(It.IsAny<string>()), Times.Once);
            _operacaoServiceMock.Verify(x => x.RegistrarOperacaoAsync(It.IsAny<Carteira>(), It.IsAny<Operacao>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task VenderProdutoFinanceiro_QuantidadeInsuficiente_Falha()
        {
            var command = new VenderProdutoFinanceiroCommand(Guid.NewGuid(), "PETR4", 10);

            _carteiraServiceMock.Setup(x => x.ObterPorIdClienteAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GerarCarteira());

            _notificatorMock.Setup(x => x.AdicionarErroNegocio(It.IsAny<string>()))
                .Verifiable();

            await _handler.Handle(command, new CancellationToken());

            _notificatorMock.Verify(x => x.AdicionarErroNegocio(It.IsAny<string>()), Times.Once);
            _operacaoServiceMock.Verify(x => x.RegistrarOperacaoAsync(It.IsAny<Carteira>(), It.IsAny<Operacao>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task VenderProdutoFinanceiro_CotacaoIndisponivel_Falha()
        {
            var command = new VenderProdutoFinanceiroCommand(Guid.NewGuid(), "PETR4", 4);

            _carteiraServiceMock.Setup(x => x.ObterPorIdClienteAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GerarCarteira());

            _produtoFinanceiroServiceMock.Setup(x => x.ObterCotacaoAtualAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(0M);

            _notificatorMock.Setup(x => x.AdicionarErroNegocio(It.IsAny<string>()))
                .Verifiable();

            await _handler.Handle(command, new CancellationToken());

            _notificatorMock.Verify(x => x.AdicionarErroNegocio(It.IsAny<string>()), Times.Once);
            _operacaoServiceMock.Verify(x => x.RegistrarOperacaoAsync(It.IsAny<Carteira>(), It.IsAny<Operacao>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        private static Carteira GerarCarteira(bool incluirItens = true)
        {
            var carteira = new Carteira(Guid.NewGuid());

            if (incluirItens)
            {
                carteira.AdicionarProdutoFinanceiro("PETR4", 5, 41.24M);
            }

            return carteira;
        }
    }
}
