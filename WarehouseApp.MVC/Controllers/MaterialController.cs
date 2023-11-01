using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WarehouseApp.MVC.Dto;
using WarehouseApp.MVC.Interfaces;
using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : Controller {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialController (IMaterialRepository materialRepository, IMapper mapper) {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Material>))]
        public IActionResult GetMaterials() {
            var materials = _mapper.Map<List<MaterialDto>>(_materialRepository.GetMaterials());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(materials);
        }

        [HttpGet("{materialId}")]
        [ProducesResponseType(200, Type = typeof(Material))]
        [ProducesResponseType(400)]
        public IActionResult GetMaterial(int materialId) {
            if (!_materialRepository.MaterialExists(materialId))
                return NotFound();

            var material = _mapper.Map<MaterialDto>(_materialRepository.GetMaterial(materialId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(material);
        }
    }
}
