using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WarehouseApp.MVC.Dto;
using WarehouseApp.MVC.Interfaces;
using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;

        public LoginController(ILoginRepository loginRepository, IMapper mapper) {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Login>))]

        public IActionResult GetLogins() {
            var logins = _mapper.Map<List<LoginDto>>(_loginRepository.GetLogins());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(logins);
        }

        [HttpGet("{loginId}")]
        [ProducesResponseType(200, Type = typeof(Login))]
        [ProducesResponseType(400)]

        public IActionResult GetLogin(int loginId) {
            if (!_loginRepository.LoginExists(loginId)) 
                return NotFound();

            var login = _mapper.Map<LoginDto>(_loginRepository.GetLogin(loginId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(login);
        }
    }
}
