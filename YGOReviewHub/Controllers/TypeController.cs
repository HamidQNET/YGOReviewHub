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

            if(!ModelState.IsValid)
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
    }
}
