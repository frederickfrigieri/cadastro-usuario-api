using Application.Commons.Repositories;
using Application.UnitTest.Commons;
using Application.Usuarios.Cadastrar;
using Domain.Commons.Exceptions;
using Domain.Dtos;
using Domain.entities;
using Moq;

namespace Application.UnitTest.Usuarios
{

    public class CadastrarTest : BaseTest
    {
        private Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private CancellationToken _cancellation;
        private CadastrarCommand _command;

        public CadastrarTest()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            _cancellation = new CancellationToken();
            _command = new CadastrarCommand
            {
                Nome = "Zé",
                Sobrenome = "Roberto",
                Email = "zeroberto@test.com",
                Senha = "123456",
                ConfirmarSenha = "123456"
            };
        }

        [Fact]
        public async void QuandoDadosValido_RetornaDadosDoUsuarioCadastrado()
        {
            //arrange
            var commandHandler = new CadastrarCommandHandler(_usuarioRepositoryMock.Object, _mapper);

            var nomeEsperado = "Zé";
            var sobrenomeEsperado = "Roberto";
            var emailEsperado = "zeroberto@test.com";

            //act
            var response = await commandHandler.Handle(_command, _cancellation);

            //verify
            _usuarioRepositoryMock.Verify(x => x.CadastrarAsync(It.IsAny<Usuario>(), _cancellation), Times.Once());

            //assert
            Assert.NotNull(response);
            Assert.Equal(response.Nome, nomeEsperado);
            Assert.Equal(response.Sobrenome, sobrenomeEsperado);
            Assert.Equal(response.Email, emailEsperado);
            Assert.True(ValorConverteParaGuid(response.Id));
        }

        [Fact]
        public async void QuandoEmailInformadoJaExiste_DeveReceberDomainException()
        {
            //arrange
            var usuarioDto = new UsuarioDto
            {
                Email = _command.Email,
                Nome = _command.Nome,
                Sobrenome = _command.Sobrenome,
                Senha = _command.Senha
            };
            var usuario = Usuario.Criar(usuarioDto);
            _usuarioRepositoryMock.Setup(x => x.ProcurarPorEmailAsync(It.IsAny<string>(), _cancellation)).ReturnsAsync(usuario);

            var mensagemErroEsperado = "Email já está sendo utilizado";
            var tipoErroEsperado = typeof(DomainException).Name;
            var mensagemDeErroRecebida = string.Empty;
            var tipoErroRecebido = string.Empty;

            var commandHandler = new CadastrarCommandHandler(_usuarioRepositoryMock.Object, _mapper);
            //act
            try
            {
                var response = await commandHandler.Handle(_command, _cancellation);
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
    }
}
