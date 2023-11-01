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
        public IActionResult GetOwners() {
            var employees = _mapper.Map<List<EmployeeDto>>(_employeeRepository.GetEmployees());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(employees);
        }

        [HttpGet("{employeeId}")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]

        public IActionResult GetEmployee(int employeeId) {
            if (!_employeeRepository.EmployeeExists(employeeId))
                return NotFound();

            var employee = _mapper.Map<EmployeeDto>(_employeeRepository.GetEmployee(employeeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(employee);
        }

        [HttpGet("{employeeId}/Requisitions")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        [ProducesResponseType(400)]

        public IActionResult GetRequisitionsByEmployee (int employeeId) {
            if (!_employeeRepository.EmployeeExists(employeeId))
                return NotFound();

            var requisitions = _mapper.Map<List<RequisitionDto>>(_employeeRepository.GetRequisitionsByEmployee(employeeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(requisitions);
        }

        [HttpGet("{employeeId}/Login")]
        [ProducesResponseType(200, Type = typeof(Login))]
        [ProducesResponseType(400)]

        public IActionResult GetLoginByEmployeeId(int employeeId) {
            if (!_employeeRepository.EmployeeExists(employeeId))
                return NotFound();

            var login = _mapper.Map<LoginDto>(_employeeRepository.GetLoginOfAEmployee(employeeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(login);
        }
    }
}
