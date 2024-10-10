using Application.Commons.Interfaces;
using AutoMapper;
using Moq;
using System.Reflection;

namespace Application.UnitTest.Commons
{
    public class BaseTest
    {
        protected readonly IMapper _mapper;
        protected readonly IConfigurationProvider _configuration;
        protected Mock<IAppDbContext> _dbContextMock = new();


        public BaseTest()
        {
            _configuration = new MapperConfiguration(config => config.AddMaps(Assembly.GetAssembly(typeof(IAppDbContext))));
            _mapper = _configuration.CreateMapper();
        }

        public bool ValorConverteParaGuid(string valor)
        {
            return Guid.TryParse(valor, out _);
        }
    }
}
