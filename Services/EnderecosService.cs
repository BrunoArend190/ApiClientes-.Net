using ApiClientes.Database.Models;
using ApiClientes.Service.Parses;
using ApiClientes.Services.DTOs;
using ApiClientes.Services.Validations;
using System.Collections.Generic;
using System.Linq;

namespace ApiClientes.Service
{
    public class EnderecosService
    {
        private readonly ClientesContext _context;

        public EnderecosService(ClientesContext context)
        {
            _context = context;
        }

        public EnderecoDTO Criar(CriarEnderecoDTO dto)
        {
            EnderecoValidation.ValidarCriarEndereco(dto);

            var endereco = EnderecoParser.ToTbEndereco(dto);
            _context.TbEnderecos.Add(endereco);
            _context.SaveChanges();

            return EnderecoParser.ToEnderecoDTO(endereco);
        }

        public List<EnderecoDTO> BuscarTodos()
        {
            return _context.TbEnderecos
                .Select(e => EnderecoParser.ToEnderecoDTO(e))
                .ToList();
        }

        public EnderecoDTO BuscarPorId(int id)
        {
            var endereco = _context.TbEnderecos.FirstOrDefault(e => e.Id == id);
            return endereco == null ? null : EnderecoParser.ToEnderecoDTO(endereco);
        }

        public EnderecoDTO Atualizar(int id, CriarEnderecoDTO dto)
        {
            EnderecoValidation.ValidarCriarEndereco(dto);

            var endereco = _context.TbEnderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null) throw new KeyNotFoundException();

            endereco.Cep = dto.Cep;
            endereco.Logradouro = dto.Logradouro;
            endereco.Numero = dto.Numero;
            endereco.Complemento = dto.Complemento;
            endereco.Bairro = dto.Bairro;
            endereco.Cidade = dto.Cidade;
            endereco.Uf = dto.Uf;
            endereco.Clienteid = dto.Clienteid;
            endereco.Status = dto.Status;

            _context.SaveChanges();

            return EnderecoParser.ToEnderecoDTO(endereco);
        }

        public void Deletar(int id)
        {
            var endereco = _context.TbEnderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null) throw new KeyNotFoundException();

            _context.TbEnderecos.Remove(endereco);
            _context.SaveChanges();
        }
    }
}
