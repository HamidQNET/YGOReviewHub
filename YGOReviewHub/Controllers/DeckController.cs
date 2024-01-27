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
    public class DeckController : Controller
    {
        private readonly IDeckRepository _deckRepository;
        private readonly IMapper _mapper;

        public DeckController(IDeckRepository deckRepository, IMapper mapper)
        {
            _deckRepository = deckRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Deck>))]
        public IActionResult GetDecks()
        {
            var decks = _mapper.Map<List<DeckDto>>(_deckRepository.GetDecks());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(decks);
        }

        [HttpGet("{deckId}")]
        [ProducesResponseType(200, Type = typeof(Deck))]
        [ProducesResponseType(400)]
        public IActionResult GetDeck(int id)
        {
            if (!_deckRepository.DeckExists(id))
                return NotFound();

            var deck = _mapper.Map<DeckDto>(
                _deckRepository.GetDeck(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(deck);
        }

        [HttpGet("/owners/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Deck))]
        public IActionResult GetDeckOfAOwner(int ownerId)
        {
            var deck = _mapper.Map<DeckDto>(
                _deckRepository.GetDeckByOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(deck);
        }

    }
}
