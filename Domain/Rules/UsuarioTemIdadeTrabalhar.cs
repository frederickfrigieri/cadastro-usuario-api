using Domain.Commons;

namespace Domain.Rules
{
    public class UsuarioTemIdadeTrabalhar : IBusinessRule
    {
        public string Message => "O usuário não tem idade para trabalhar";

        public bool IsBroken()
        {
            throw new NotImplementedException();
        }
    }
}
