using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WarehouseApp.MVC.Dto;
using WarehouseApp.MVC.Interfaces;
using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper) {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        public IActionResult GetEmployees () {
            var employees = _mapper.Map<List<EmployeeDto>>(_employeeRepository.GetEmployees());

            if (ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(employees);
        }
    }
}
