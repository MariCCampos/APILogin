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

        [HttpPost]
        public IActionResult Post([FromBody]Login login)
        {
            if (login == null) return BadRequest();
            _loginService.Find(login);
            return StatusCode(200);
        }
    }
}
