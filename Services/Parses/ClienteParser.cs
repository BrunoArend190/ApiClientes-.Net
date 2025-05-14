using ApiClientes.Database.Models;

using ApiClientes.Services.DTOs;
using System;

namespace ApiClientes.Service.Parses
{
    public class ClienteParser
    {
        public static TbCliente ToTbCliente(CriarClienteDTO dto)
        {
            TbCliente novoCliente = new();
            novoCliente.Nome = dto.Nome;
            novoCliente.Nascimento = dto.Nascimento;
            novoCliente.Telefone = dto.Telefone;
            novoCliente.Documento = dto.Documento;
            novoCliente.Tipodoc = dto.Tipodoc;
            novoCliente.Criadoem = DateTime.Now.ToUniversalTime();
            novoCliente.Alteradoem = novoCliente.Criadoem;

            return novoCliente;
        }
        public static ClienteDTO ToClienteDTO(TbCliente cliente)
        {
            ClienteDTO Response = new();
            Response.Id = cliente.Id;
            Response.Nome = cliente.Nome;
            Response.Nascimento = cliente.Nascimento;
            Response.Telefone = cliente.Telefone;
            Response.Documento = cliente.Documento;
            Response.Tipodoc = cliente.Tipodoc;
            Response.Criadoem = cliente.Criadoem;
            Response.Alteradoem = cliente.Alteradoem;
            return Response;
        }
    }
}