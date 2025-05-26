using ApiClientes.Services.DTOs;
using ApiClientes.Services.Exceptions;

namespace ApiClientes.Services.Validations
{
    public class EnderecoValidation
    {
        public static void ValidarCriarEndereco(CriarEnderecoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Logradouro))
                throw new BadRequestExeception("Logradouro é obrigatório");
            if (string.IsNullOrEmpty(dto.Numero))
                throw new BadRequestExeception("Número é obrigatório");
            if (string.IsNullOrEmpty(dto.Bairro))
                throw new BadRequestExeception("Bairro é obrigatório");
            if (string.IsNullOrEmpty(dto.Cidade))
                throw new BadRequestExeception("Cidade é obrigatória");
            if (string.IsNullOrEmpty(dto.Uf) || dto.Uf.Length != 2)
                throw new BadRequestExeception("UF inválido");
            if (dto.Clienteid <= 0)
                throw new BadRequestExeception("Cliente ID inválido");
        }
    }
}
