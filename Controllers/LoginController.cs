using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_devagram.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp_devagram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController: ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        
        public LoginController(ILogger<LoginController> logger) 
        {
        _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult EfetuarLogin([FromBody] LoginRequisicaoDto loginrequisicao)
        {
            try 
            {
                return StatusCode(StatusCodes.Status200OK, new ErrorRespostaDto() 
                {
                    Descricao = "Login Realizado com sucesso.",
                    Status = StatusCodes.Status200OK
                });
            }
            catch (Exception e) 
            {
                _logger.LogError($"Ocorreu um erro no login: {e.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto() 
                {
                    Descricao = "Ocorreu um erro ao fazer login.",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}