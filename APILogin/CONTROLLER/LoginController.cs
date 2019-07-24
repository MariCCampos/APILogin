using APILogin.DATA;
using APILogin.DATA.VO;
using APILogin.MODEL;
using APILogin.SERVICE.Implementattions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILogin.CONTROLLER
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("v1")]
        public IActionResult Get()
        {
            return new OkObjectResult(_loginService.FindAll());
        }

        [HttpPost("v1/consultalogin")]
        public IActionResult Consult([FromBody]LoginVO login)
        {
            if (login == null) return BadRequest();
            var result = _loginService.Consult(login);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpPost("v1/cadastro")]
        public IActionResult Create([FromBody]LoginVO login)
        {
            if (login.Usuario == null && login.Senha == null) return BadRequest();
            return new ObjectResult(_loginService.Create(login));
        }

        [HttpPut("v1")]
        public IActionResult Put([FromBody] LoginVO login)
        {
            if (login == null) return BadRequest();
            var updatedLogin = _loginService.Update(login);
            if (updatedLogin == null) return BadRequest();
            return new ObjectResult(updatedLogin);
        }

        [HttpDelete("v1/{id}")]
        public IActionResult Delete(int id)
        {
            _loginService.Delete(id);
            return NoContent();
        }
    }
}
