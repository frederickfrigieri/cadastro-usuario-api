using Application.Commons.Repositories;
using Application.UnitTest.Commons;
using Application.Usuarios.Atualizar;
using Application.Usuarios.Cadastrar;
using Domain.Commons.Exceptions;
using Domain.entities;
using Moq;

namespace Application.UnitTest.Usuarios
{
    public class AtualizarTest : BaseTest
    {
        private Guid _usuarioId;
        private Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private CancellationToken _cancellation;
        private AtualizarCommand _command;
        private CadastrarCommandHandler _commandHandler;

        public AtualizarTest()
        {
            _usuarioId = Guid.NewGuid();
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            _cancellation = new CancellationToken();
            _command = new AtualizarCommand
            {
                Nome = "José",
                Sobrenome = "Roberto",
                Email = "zeroberto@test.com",
                Id = _usuarioId
            };
        }

        [Fact]
        public async Task QuandoEmailAtualizandoJaExisteParaOutroUsuario_DeveRetornarDomainException()
        {
            //arrange
            var usuarioQualquer = FakeData.Usuarios.ObterUsuario(FakeData.Usuarios.ObterUsuarioB());
            var meuUsuarioAtual = FakeData.Usuarios.ObterUsuario(FakeData.Usuarios.ObterUsuarioDtoA());

            meuUsuarioAtual.GetType().GetProperty("Id")!.SetValue(meuUsuarioAtual, _command.Id, null);

            _usuarioRepositoryMock.Setup(x => x.ProcurarPorEmailAsync(It.IsAny<string>(), _cancellation)).ReturnsAsync(usuarioQualquer);
            _usuarioRepositoryMock.Setup(x => x.ObterPorIdAsync(_command.Id, _cancellation)).ReturnsAsync(meuUsuarioAtual);

            var commandHandler = new AtualizarCommandHandler(_dbContextMock.Object, _usuarioRepositoryMock.Object, _mapper);

            var mensagemErroEsperado = "E-mail já cadastrado";
            var tipoErroEsperado = typeof(DomainException).Name;
            var mensagemDeErroRecebida = string.Empty;
            var tipoErroRecebido = string.Empty;

            _command.Email = "renato@test.com";

            try
            {
                //act
                await commandHandler.Handle(_command, _cancellation);
            }
            catch (Exception e)
            {
                mensagemDeErroRecebida = e.Message;
                tipoErroRecebido = e.GetType().Name;
            }

            //verify
            _usuarioRepositoryMock.Verify(x => x.CadastrarAsync(It.IsAny<Usuario>(), _cancellation), Times.Never);

            //assert
            Assert.Equal(mensagemErroEsperado, mensagemDeErroRecebida);
            Assert.Equal(tipoErroEsperado, tipoErroRecebido);
        }

        [Fact]
        public async Task QuandoAtualizandoComDadoValido_DeveRetornarObjetoComDadosDoUsuarioAtualizado()
        {
            //arrange
            var meuUsuarioAtual = FakeData.Usuarios.ObterUsuario(FakeData.Usuarios.ObterUsuarioDtoA());
            meuUsuarioAtual.GetType().GetProperty("Id")!.SetValue(meuUsuarioAtual, _command.Id, null);

            _usuarioRepositoryMock.Setup(x => x.ProcurarPorEmailAsync(It.IsAny<string>(), _cancellation)).Returns(Task.FromResult<Usuario?>(null));
            _usuarioRepositoryMock.Setup(x => x.ObterPorIdAsync(_command.Id, _cancellation)).ReturnsAsync(meuUsuarioAtual);

            var commandHandler = new AtualizarCommandHandler(_dbContextMock.Object, _usuarioRepositoryMock.Object, _mapper);

            _command.Email = "zeroberto3@test.com";

            //act
            var response = await commandHandler.Handle(_command, _cancellation);

            //verify
            _dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

            //assert
            Assert.Equal(response.Email, _command.Email);
            Assert.Equal(response.Nome, _command.Nome);
            Assert.Equal(response.Sobrenome, _command.Sobrenome);
        }
    }
}
