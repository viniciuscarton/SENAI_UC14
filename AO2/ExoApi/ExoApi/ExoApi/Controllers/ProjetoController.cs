using ExoApi.Models;
using ExoApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]


    public class ProjetoController : ControllerBase
    {
        private readonly ProjetoRepository _projetoRepository;
        public ProjetoController(ProjetoRepository projetoRepository)
        {
            _projetoRepository= projetoRepository;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_projetoRepository.Listar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [Authorize]
        [HttpGet ("{id}")]
        public IActionResult BuscarId (int id)
        {
            try
            {
                Projeto projeto = _projetoRepository.BuscarId(id);
                if (projeto == null)
                {
                    return NotFound();
                }
                return Ok(projeto);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        [HttpPost]
        public IActionResult Cadastrar (Projeto projeto)
        {
            try
            {
                _projetoRepository.Cadastrar(projeto);
                return StatusCode(201);

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Projeto projeto)
        {
            try
            {
                _projetoRepository.Atualizar(id, projeto);
                return StatusCode(204);

            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize (Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _projetoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
