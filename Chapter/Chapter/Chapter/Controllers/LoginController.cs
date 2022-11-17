using Chapter.Interfaces;
using Chapter.Models;
using Chapter.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Chapter.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;

        public LoginController(IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }


        [HttpPost]

        public IActionResult Login(LoginViewModels login)
        {
            Usuario usuarioEncontrado = _iUsuarioRepository.Login(login.Email, login.Senha);
            if (usuarioEncontrado == null)
            {
                return Unauthorized(new { msg = "E-mail ou Senha inválidos" });
            }

            var minhasClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioEncontrado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioEncontrado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioEncontrado.Tipo)
            };

            var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapter-chave-autenticacao"));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var meuToken = new JwtSecurityToken(
                issuer: "chapter.webapi",
                audience: "chapter.webapi",
                claims: minhasClaims,
                expires: DateTime.Now.AddMinutes(500),
                signingCredentials: credenciais
            );

            return Ok(
                new { token = new JwtSecurityTokenHandler().WriteToken(meuToken) }
            );
        }

    }
}