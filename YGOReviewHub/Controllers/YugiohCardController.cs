using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
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

        public YugiohCardController(IYugiohCardRepository yugiohCardRepository)
        {
            _yugiohcardRepository = yugiohCardRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<YugiohCard>))]
        public IActionResult GetYugiohCards()
        {
            var yugiohcards = _yugiohcardRepository.GetYugiohCards();
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(yugiohcards);
        }
    }
}
