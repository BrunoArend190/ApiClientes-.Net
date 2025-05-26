using ApiClientes.Service;
using ApiClientes.Services.DTOs;
using ApiClientes.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly EnderecosService _service;

        public EnderecosController(EnderecosService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<EnderecoDTO> Criar([FromBody] CriarEnderecoDTO dto)
        {
            try
            {
                var response = _service.Criar(dto);
                return Ok(response);
            }
            catch (BadRequestExeception e)
            {
                return BadRequest(e.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<EnderecoDTO>> BuscarTodos()
        {
            try
            {
                return Ok(_service.BuscarTodos());
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<EnderecoDTO> BuscarPorId(int id)
        {
            try
            {
                var response = _service.BuscarPorId(id);
                if (response == null) return NotFound("Endereço não encontrado");
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<EnderecoDTO> Atualizar(int id, [FromBody] CriarEnderecoDTO dto)
        {
            try
            {
                return Ok(_service.Atualizar(id, dto));
            }
            catch (BadRequestExeception e)
            {
                return BadRequest(e.Message);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Endereço não encontrado");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
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
                return NotFound("Endereço não encontrado");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
