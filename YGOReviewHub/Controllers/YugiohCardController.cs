using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using YGOReviewHub.Dto;
using YGOReviewHub.Interfaces;
using YGOReviewHub.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace YGOReviewHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YugiohCardController : Controller
    {
        private readonly IYugiohCardRepository _yugiohcardRepository;
        private readonly IMapper _mapper;

        public YugiohCardController(IYugiohCardRepository yugiohCardRepository, IMapper mapper)
        {
            _yugiohcardRepository = yugiohCardRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<YugiohCard>))]
        public IActionResult GetYugiohCards()
        {
            var yugiohcards = _mapper.Map<List<YugiohCardDto>>(_yugiohcardRepository.GetYugiohCards());
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(yugiohcards);
        }

        [HttpGet("{yugiId}")]
        [ProducesResponseType(200, Type = typeof(YugiohCard))]
        [ProducesResponseType(400)]
        public IActionResult GetYugiohCard(int yugiId)
        {
            if (!_yugiohcardRepository.YugiohCardExists(yugiId))
                return NotFound();

            var yugiohcard = _mapper.Map<YugiohCardDto>(_yugiohcardRepository.GetYugiohCard(yugiId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(yugiohcard);
        }

        [HttpGet("{yugiId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetYugiohCardRating(int yugiId)
        {
            if(!_yugiohcardRepository.YugiohCardExists(yugiId))
                return NotFound();

            var rating = _yugiohcardRepository.GetYugiohCardRating(yugiId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(rating);
        }
    }
}
