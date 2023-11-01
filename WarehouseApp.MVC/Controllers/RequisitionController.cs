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

            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(requisitions);
        }

        [HttpGet("{requisitionId}")]
        [ProducesResponseType(200, Type =typeof(Requisition))]
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
        public IActionResult GetMaterialsByRequisition (int requisitionId) {
            if (!_requisitionRepository.RequisitionExists(requisitionId))
                return NotFound();

            var materials = _mapper.Map<List<MaterialDto>>(_requisitionRepository.GetMaterialsByRequisition(requisitionId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(materials);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRequisition([FromQuery]int employeeId, [FromQuery]int material, [FromBody]RequisitionDto requisitionCreate) {
            if (material == null)
                return BadRequest(ModelState);

            if (requisitionCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var requisitionMap = _mapper.Map<Requisition>(requisitionCreate);

            if (!_requisitionRepository.CreateRequisition(employeeId, material, requisitionMap)) {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Seccessfully created");
        }
    }
}
