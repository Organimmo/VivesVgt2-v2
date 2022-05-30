using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organimmo.Services;
using Organimmo.Services.Abstractions;
using Organimmo.Services.Model;

namespace Organimmo.API
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class TranslateController : Controller
    {
        private TranslateService _translateService;
        public TranslateController(TranslateService service)
        {
            _translateService = service;
        }

        [Route("/TranslateWord")]
        [HttpPost]
        public async Task<IActionResult> TranslateWordAsync(string text, string translation)
        {
            var word = await _translateService.TranslateWord(text, translation);
            return Ok(word);
        }

        [HttpPost("/SerializeRootAsync/")]
        public async Task<IActionResult> SerializeRootAsync(RootDto root)
        {
            var json = await _translateService.SerializeToJsonObject(root);
            return Ok(json);
        }
    }
}
