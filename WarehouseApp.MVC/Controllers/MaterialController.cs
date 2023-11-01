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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public MaterialController (IMaterialRepository materialRepository, ICategoryRepository categoryRepository, IMapper mapper) {
            _materialRepository = materialRepository;
            _categoryRepository = categoryRepository;
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateMaterial([FromQuery]int categoryId,  [FromBody]Material materialCreate) {
            if (!_categoryRepository.CategoryExists(categoryId)) {
                ModelState.AddModelError("", "Category Not Found");
                return StatusCode(404, ModelState);
            }

            if (materialCreate == null)
                return BadRequest(ModelState);

            var materials = _materialRepository.GetMaterials()
                .Where(m => m.Name.Trim().ToUpper() == materialCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (materials != null) {
                ModelState.AddModelError("", "Material already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var materialMap = _mapper.Map<Material>(materialCreate);

            if (!_materialRepository.CreateMaterial(categoryId, materialMap)) {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
