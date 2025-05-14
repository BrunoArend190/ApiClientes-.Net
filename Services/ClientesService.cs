using ApiClientes.Database.Models;
using ApiClientes.Service.Parses;
using ApiClientes.Services.DTOs;
using ApiClientes.Services.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiClientes.Service
{
    public class ClientesService
    {
        private readonly ClientesContext _dbcontext;

        public ClientesService(ClientesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public ClienteDTO Criar(CriarClienteDTO dto)
        {
            ClienteValidation.ValidarCriarCliente(dto);

            TbCliente novoCliente = ClienteParser.ToTbCliente(dto);

            _dbcontext.TbClientes.Add(novoCliente);
            _dbcontext.SaveChanges();

            return ClienteParser.ToClienteDTO(novoCliente);
        }

        public List<ClienteDTO> BuscarTodos()
        {
            return _dbcontext.TbClientes
                .Select(c => ClienteParser.ToClienteDTO(c))
                .ToList();
        }

        public ClienteDTO BuscarPorId(int id)
        {
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                return null;

            return ClienteParser.ToClienteDTO(cliente);
        }

        public ClienteDTO Atualizar(int id, CriarClienteDTO dto)
        {
            ClienteValidation.ValidarCriarCliente(dto);

            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                throw new KeyNotFoundException();

            cliente.Nome = dto.Nome;
            cliente.Nascimento = dto.Nascimento;
            cliente.Telefone = dto.Telefone;
            cliente.Documento = dto.Documento;
            cliente.Tipodoc = dto.Tipodoc;
            cliente.Alteradoem = DateTime.UtcNow;

            _dbcontext.SaveChanges();

            return ClienteParser.ToClienteDTO(cliente);
        }

        public void Deletar(int id)
        {
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                throw new KeyNotFoundException();

            _dbcontext.TbClientes.Remove(cliente);
            _dbcontext.SaveChanges();
        }
    }
}
