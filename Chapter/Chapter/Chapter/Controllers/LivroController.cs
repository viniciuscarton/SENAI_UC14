using Chapter.Models;
using Chapter.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Chapter.Controllers

{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    //[Authorize]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());
            }
            catch (Exception e)

            {
                throw new Exception(e.Message);
            }
        }
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult BuscarId(int id)
        {
            try
            {
                Livro livro = _livroRepository.BuscarId(id);

                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro);
            }

            catch (Exception)
            {
                throw;
            }


        }

        [HttpPost]

        public IActionResult Cadastrar(Livro livro)

        {

            try
            {
                _livroRepository.Cadastrar(livro);
                return Ok(livro);
            }

            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Livro livro)
        {
            try
            {
                _livroRepository.Atualizar(id, livro);
                return StatusCode(204);
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);
                return StatusCode(204);

            }
            catch (Exception)
            {
                throw;
            }
        }


    }


}
