using Application.Usuarios.Apagar;
using Application.Usuarios.Atualizar;
using Application.Usuarios.Cadastrar;
using Application.Usuarios.Listar;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints
{
    public static class UsuarioEndpoint
    {
        public static WebApplication RegisterUsuarioEndpoint(this WebApplication app)
        {
            string endpoint = "/usuarios";

            app.MapGet(endpoint, Listar);
            app.MapPost(endpoint, CadastrarUsuario);
            app.MapPut("/usuarios/{usuarioId}", Atualizar);
            app.MapDelete("/usuarios/{usuarioId}", Apagar);

            return app;
        }

        private static async Task<ListarResponse[]> Listar(ISender sender)
        {
            var query = new ListarQuery();
            return await sender.Send(query);
        }

        private static async Task<CadastrarResponse> CadastrarUsuario(ISender sender, IMapper mapper, [FromBody] CadastrarRequest request)
        {
            var command = mapper.Map<CadastrarCommand>(request);
            return await sender.Send(command);
        }

        private static async Task<AtualizarResponse> Atualizar(ISender sender, IMapper mapper, [FromRoute] Guid usuarioId, [FromBody] AtualizarRequest request)
        {
            var command = mapper.Map<AtualizarCommand>(request);
            command.Id = usuarioId;
            return await sender.Send(command);
        }

        private static async Task<ApagarResponse> Apagar(ISender sender, [FromRoute] Guid usuarioId)
        {
            var command = new ApagarCommand { UsuarioId = usuarioId };
            return await sender.Send(command);
        }
    }
}