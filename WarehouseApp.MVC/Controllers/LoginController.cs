﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WarehouseApp.MVC.Dto;
using WarehouseApp.MVC.Interfaces;
using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller {
        private readonly ILoginRepository _loginRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public LoginController(ILoginRepository loginRepository, IEmployeeRepository employeeRepository, IMapper mapper) {
            _loginRepository = loginRepository;
            _employeeRepository = employeeRepository;
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

        [HttpPut("{loginId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateLogin([FromBody]LoginDto loginToUpdate) {
            if (loginToUpdate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var loginMap = _mapper.Map<Login>(loginToUpdate);

            if (!_loginRepository.UpdateLogin(loginMap)) {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
