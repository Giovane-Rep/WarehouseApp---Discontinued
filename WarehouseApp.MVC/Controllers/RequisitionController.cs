using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WarehouseApp.MVC.Dto;
using WarehouseApp.MVC.Interfaces;
using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitionController : Controller {
        private readonly IRequisitionRepository _requisitionRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public RequisitionController(IRequisitionRepository requisitionRepository, IMaterialRepository materialRepository, IMapper mapper) {
            _requisitionRepository = requisitionRepository;
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Requisition>))]
        public IActionResult GetRequisitions() {
            var requisitions = _mapper.Map<List<RequisitionDto>>(_requisitionRepository.GetRequisitions());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(requisitions);
        }

        [HttpGet("{requisitionId}")]
        [ProducesResponseType(200, Type = typeof(Requisition))]
        [ProducesResponseType(400)]
        public IActionResult GetRequisition(int requisitionId) {
            if (!_requisitionRepository.RequisitionExists(requisitionId))
                return NotFound();

            var requisition = _mapper.Map<RequisitionDto>(_requisitionRepository.GetRequisition(requisitionId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(requisition);
        }

        [HttpGet("{requisitionId}/Materials")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Requisition>))]
        [ProducesResponseType(400)]
        public IActionResult GetMaterialsByRequisition(int requisitionId) {
            if (!_requisitionRepository.RequisitionExists(requisitionId))
                return NotFound();

            var materials = _mapper.Map<List<MaterialDto>>(_requisitionRepository.GetMaterialsByRequisition(requisitionId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(materials);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRequisition([FromQuery] int employeeId, [FromBody] RequisitionDto requisitionCreate) {
            if (requisitionCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var requisitionMap = _mapper.Map<Requisition>(requisitionCreate);

            if (!_requisitionRepository.CreateRequisition(employeeId, requisitionMap)) {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Seccessfully created");
        }

        [HttpPut("{requisitionId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRequisition([FromBody] RequisitionDto requisitionToUpdate) {
            if (requisitionToUpdate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var requisitionMap = _mapper.Map<Requisition>(requisitionToUpdate);

            //Fazer tratamento para que o EmployeeId inserido seja o mesmo do banco de dados
            //Também é necessário que ao criar a Requisition, garantir que o EmployeeId da tabela Requisitions seja o mesmo que o Id da tabela Employees
            //Uma maneira de fazer isso é atribuir ao EmployeeId(Requisitions) o Id do Employee(Employees) no momento da criação da Requisition,
            //assim garantindo que não haverá nenhum LoginId se repetindo no banco

            if (!_requisitionRepository.UpdateRequisition(requisitionMap)) {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{requisitionId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRequisition(int requisitionId) {
            if (!_requisitionRepository.RequisitionExists(requisitionId))
                return NotFound();

            var requisitionToDelete = _requisitionRepository.GetRequisition(requisitionId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_requisitionRepository.DeleteRequisition(requisitionToDelete)) {
                ModelState.AddModelError("", "Something went wrong deleting Requisition");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
