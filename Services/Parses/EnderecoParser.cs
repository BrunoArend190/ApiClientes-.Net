using ApiClientes.Database.Models;
using ApiClientes.Services.DTOs;

namespace ApiClientes.Service.Parses
{
    public class EnderecoParser
    {
        public static TbEndereco ToTbEndereco(CriarEnderecoDTO dto)
        {
            return new TbEndereco
            {
                Cep = dto.Cep,
                Logradouro = dto.Logradouro,
                Numero = dto.Numero,
                Complemento = dto.Complemento,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                Uf = dto.Uf,
                Clienteid = dto.Clienteid,
                Status = dto.Status
            };
        }

        public static EnderecoDTO ToEnderecoDTO(TbEndereco entity)
        {
            return new EnderecoDTO
            {
                Id = entity.Id,
                Cep = entity.Cep,
                Logradouro = entity.Logradouro,
                Numero = entity.Numero,
                Complemento = entity.Complemento,
                Bairro = entity.Bairro,
                Cidade = entity.Cidade,
                Uf = entity.Uf,
                Clienteid = entity.Clienteid,
                Status = entity.Status
            };
        }
    }
}
