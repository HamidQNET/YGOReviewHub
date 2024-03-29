﻿using AutoMapper;
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
        public IActionResult GetDeck(int deckId)
        {
            if (!_deckRepository.DeckExists(deckId))
                return NotFound();

            var deck = _mapper.Map<DeckDto>(
                _deckRepository.GetDeck(deckId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(deck);
        }

        [HttpGet("/ownersdeck/{ownerId}")]
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDeck([FromBody] DeckDto deckCreate)
        {
            if (deckCreate == null)
                return BadRequest(ModelState);
            var deck = _deckRepository.GetDecks()
                .Where(d => d.Name.Trim().ToUpper() == deckCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (deck != null)
            {
                ModelState.AddModelError("", "Model already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var deckMap = _mapper.Map<Deck>(deckCreate);

            if (!_deckRepository.CreateDeck(deckMap))
            {
                ModelState.AddModelError("", "Something went wrong wile saving.. :(");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully Created! :D");
        }

        [HttpPut("{deckId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDeck(int deckId, [FromBody] DeckDto updatedDeck)
        {
            if (updatedDeck == null)
                return BadRequest(ModelState);

            if (deckId != updatedDeck.Id)
                return BadRequest(ModelState);

            if (!_deckRepository.DeckExists(deckId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var deckMap = _mapper.Map<Deck>(updatedDeck);

            if (!_deckRepository.UpdateDeck(deckMap))
            {
                ModelState.AddModelError("", "Something went wrong updating deck...");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{deckId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDeck(int deckId)
        {
            if (!_deckRepository.DeckExists(deckId))
            {
                return NotFound();
            }

            var deckToDelete = _deckRepository.GetDeck(deckId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_deckRepository.DeleteDeck(deckToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting a deck...");
            }

            return NoContent();
        }

    }
}
