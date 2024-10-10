using Application.Commons.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Api.IntegrationTest.Commons
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
    {
        private readonly IServiceScope _scope;

        protected readonly ISender Sender;
        protected readonly HttpClient Client;
        protected readonly IAppDbContext DbContext;


        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();
            Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
            Client = factory.CreateClient();
            DbContext = _scope.ServiceProvider.GetRequiredService<IAppDbContext>();
        }
    }
}
