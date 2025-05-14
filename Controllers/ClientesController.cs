using ApiClientes.Database.Models;
using ApiClientes.Service;
using ApiClientes.Services.DTOs;
using ApiClientes.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _service;

        public ClientesController(ClientesService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<TbCliente> Adicionar([FromBody] CriarClienteDTO body)
        {
            try
            {
                var response = _service.Criar(body);
                return Ok(response);
            }
            catch (BadRequestExeception b)
            {
                return BadRequest(b.Message);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<ClienteDTO>> BuscarTodos()
        {
            try
            {
                var response = _service.BuscarTodos();
                return Ok(response);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteDTO> BuscarPorId(int id)
        {
            try
            {
                var response = _service.BuscarPorId(id);
                if (response == null)
                    return NotFound("Cliente não encontrado");

                return Ok(response);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ClienteDTO> Atualizar(int id, [FromBody] CriarClienteDTO dto)
        {
            try
            {
                var response = _service.Atualizar(id, dto);
                return Ok(response);
            }
            catch (BadRequestExeception b)
            {
                return BadRequest(b.Message);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Cliente não encontrado");
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _service.Deletar(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Cliente não encontrado");
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
