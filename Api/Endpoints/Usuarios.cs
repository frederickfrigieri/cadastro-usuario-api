using Application.Usuarios.Cadastrar;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints
{
    public static class EndpointsMap
    {
        public static WebApplication EndpointUsuario(this WebApplication app)
        {
            string endpoint = "/usuarios";

            app.MapGet("/usuarios", async (ISender sender, IMapper mapper, [FromBody] CadastrarRequest request) =>
            {
                var command = mapper.Map<CadastrarCommand>(request);
                await sender.Send(command);
            });

            app.MapPost(endpoint, async (ISender sender, IMapper mapper, [FromBody] CadastrarRequest request) =>
            {
                var command = mapper.Map<CadastrarCommand>(request);
                await sender.Send(command);
            });

            app.MapPut("/usuarios", async (ISender sender, IMapper mapper, [FromBody] CadastrarRequest request) =>
            {
                var command = mapper.Map<CadastrarCommand>(request);
                await sender.Send(command);
            });

            return app;
        }
    }
}