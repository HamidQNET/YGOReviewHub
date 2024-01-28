using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using YGOReviewHub.Dto;
using YGOReviewHub.Interfaces;
using YGOReviewHub.Models;
using YGOReviewHub.Repository;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace YGOReviewHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : Controller
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public TypeController(ITypeRepository typeRepository, IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Models.Type>))]
        public IActionResult GetTypes()
        {
            var types = _mapper.Map<List<TypeDto>>(_typeRepository.GetTypes());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(types);
        }

        [HttpGet("{typeId}")]
        [ProducesResponseType(200, Type = typeof(Models.Type))]
        [ProducesResponseType(400)]
        public IActionResult GetType(int typeId)
        {
            if (!_typeRepository.TypeExists(typeId))
                return NotFound();

            var type = _mapper.Map<TypeDto>(_typeRepository.GetType(typeId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(type);
        }

        [HttpGet("yugiohcard/{typeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<YugiohCard>))]
        [ProducesResponseType(400)]
        public IActionResult GetYugiohCardByTypeId(int typeId)
        {
            var yugiohcards = _mapper.Map<List<YugiohCardDto>>(
                _typeRepository.GetYugiohCardByType(typeId));

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(yugiohcards);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateType([FromBody] TypeDto typeCreate)
        {
            if (typeCreate == null)
                return BadRequest(ModelState);

            var type = _typeRepository.GetTypes()
                .Where(t => t.Name.Trim().ToUpper() == typeCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (type == null)
            {
                ModelState.AddModelError("", "Type already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var typeMap = _mapper.Map<Models.Type>(typeCreate);

            if (!_typeRepository.CreateType(typeMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.. :(");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfully Created!");
        }

        [HttpPut("{typeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateType(int typeId, [FromBody] TypeDto updatedType)
        {
            if (updatedType == null)
                return BadRequest(ModelState);

            if (typeId != updatedType.Id)
                return BadRequest(ModelState);

            if (!_typeRepository.TypeExists(typeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var typeMap = _mapper.Map<Models.Type>(updatedType);

            if (!_typeRepository.UpdateType(typeMap))
            {
                ModelState.AddModelError("", "Something went wrong updating type...");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{typeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteType(int typeId)
        {
            if (!_typeRepository.TypeExists(typeId))
            {
                return NotFound();
            }

            var typeToDelete = _typeRepository.GetType(typeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_typeRepository.DeleteType(typeToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting type...");
            }

            return NoContent();
        }
    }
}
