using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organimmo.Services;
using Organimmo.Services.Abstractions;

namespace Organimmo.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslateController : Controller
    {
        private TranslateService _translateService;
        public TranslateController(TranslateService service)
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
