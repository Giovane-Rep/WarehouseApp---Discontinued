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
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, ILoginRepository loginRepository, IMapper mapper) {
            _employeeRepository = employeeRepository;
            _loginRepository = loginRepository;
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

        public IActionResult GetRequisitionsByEmployee(int employeeId) {
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEmployee([FromBody] EmployeeDto employeeCreate) {
            if (employeeCreate == null)
                return BadRequest(ModelState);

            var employees = _employeeRepository.GetEmployees()
                .Where(e => e.Name.Trim().ToUpper() == employeeCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (employees != null) {
                ModelState.AddModelError("", "Employee already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeMap = _mapper.Map<Employee>(employeeCreate);

            if (!_employeeRepository.CreateEmployee(employeeMap)) {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{employeeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEmployee(int employeeId, [FromBody] EmployeeDto employeeToUpdate) {
            if (employeeToUpdate == null)
                return BadRequest(ModelState);

            if (employeeId != employeeToUpdate.Id)
                return BadRequest(ModelState);

            if (!_employeeRepository.EmployeeExists(employeeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeMap = _mapper.Map<Employee>(employeeToUpdate);

            //Fazer tratamento para que o LoginId inserido seja o mesmo do banco de dados
            //Também é necessário que ao criar o Employee, garantir que o LoginId da tabela Employees seja o mesmo que o Id da tabela Logins
            //Uma maneira de fazer isso é atribuir ao LoginId o Id do Employee, assim garantindo que não haverá nenhum LoginId se repetindo no banco

            if (!_employeeRepository.UpdateEmployee(employeeMap)) {
                ModelState.AddModelError("", "Something went wrong updating Employee");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{employeeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEmployee(int employeeId) {
            if (!_employeeRepository.EmployeeExists(employeeId))
                return BadRequest(ModelState);

            var employeeToDelete = _employeeRepository.GetEmployee(employeeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_employeeRepository.DeleteEmployee(employeeToDelete)) {
                ModelState.AddModelError("", "Something went wrong deleting Employee");
                return StatusCode(500, ModelState);
            }
            
            return NoContent();
        }
    }
}
