﻿namespace Domain.Dtos
{
    public class UsuarioDto
    {
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}
