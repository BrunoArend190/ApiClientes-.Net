using ApiClientes.Service;
using ApiClientes.Services.DTOs;
using ApiClientes.Services.Exceptions;
using System;
using System.Linq;

namespace ApiClientes.Services.Validations
{
    public class ClienteValidation
    {
        public static void ValidarCriarCliente(
            CriarClienteDTO criarClienteDTO)
        {
            if (string.IsNullOrEmpty(criarClienteDTO.Nome))
            {
                throw new BadRequestExeception("Nome é obrigatorio");
            }
            if (string.IsNullOrEmpty(criarClienteDTO.Documento))
            {
                throw new BadRequestExeception("Documento é obrigatorio");
            }
            if (!new[] { 0, 1, 2, 3, 99 }.Contains(criarClienteDTO.Tipodoc))
            {
                throw new BadRequestExeception("Tipo de Documento não suportado");
            }            
            //return true;
        }
    }
}
