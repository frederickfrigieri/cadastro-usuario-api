using Api.IntegrationTest.Commons;
using Application.Usuarios.Cadastrar;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Api.IntegrationTest.Usuarios
{
    public class CadastrarTest : BaseIntegrationTest
    {
        public CadastrarTest(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async void QuandoDadoValido_DeveCadastrarUsuarioComSucesso()
        {
            //arrange
            var request = new CadastrarRequest
            {
                ConfirmarSenha = "123456",
                Email = "joao@test.com",
                Nome = "Joao",
                Senha = "123456",
                Sobrenome = "Silva"
            };

            var usuario = DbContext.Usuarios.SingleOrDefault(x => x.Email == request.Email);
            if (usuario != null)
            {
                DbContext.Usuarios.Remove(usuario);
                await DbContext.SaveChangesAsync(new CancellationToken());
            }

            var requestJson = JsonSerializer.Serialize(request);
            var statusEsperado = HttpStatusCode.OK;

            //act
            var response = await Client.PostAsync("/usuarios", new StringContent(requestJson, Encoding.Unicode, "application/json-patch+json"));

            //assert
            Assert.Equal(statusEsperado, response.StatusCode);

            //TODO
            //testar o objeto retornado
        }

        [Fact]
        public async void QuandoCadastrandoComDadoInvalido_DeveRetornarErro()
        {
            //arrange
            var emailDuplicado = "joao@test.com";

            var usuarioDto = FakeData.Usuarios.ObterUsuarioDtoA();
            usuarioDto.Email = emailDuplicado;
            
            var usuario = FakeData.Usuarios.ObterUsuario(usuarioDto);
            
            DbContext.Usuarios.Add(usuario);
            await DbContext.SaveChangesAsync(new CancellationToken());

            var request = new CadastrarRequest
            {
                ConfirmarSenha = "123456",
                Email = emailDuplicado,
                Nome = "Joao",
                Senha = "123456",
                Sobrenome = "Silva"
            };

            var requestJson = JsonSerializer.Serialize(request);
            var statusEsperado = HttpStatusCode.InternalServerError;

            //act
            var response = await Client.PostAsync("/usuarios", new StringContent(requestJson, Encoding.Unicode, "application/json-patch+json"));

            //assert
            Assert.Equal(statusEsperado, response.StatusCode);

            //TODO
            //testar a mensagem do erro
        }
    }
}
