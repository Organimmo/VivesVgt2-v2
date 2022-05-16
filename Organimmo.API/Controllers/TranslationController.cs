using Microsoft.AspNetCore.Mvc;
using Organimmo.Services;

namespace Organimmo.API.Controllers
{
    public class TranslationController : Controller
    {

        private TranslateService _translateService;
        public TranslationController(TranslateService service)
        {
            _translateService = service;
        }

        [HttpPost] 
        public async Task<IActionResult> TranslateWordAsync(string text, string translation)
        {
            var word = await _translateService.TranslateWord(text, translation);
            return Ok(word);
        }
    }
}
