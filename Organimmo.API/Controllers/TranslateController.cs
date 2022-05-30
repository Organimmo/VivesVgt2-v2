using Microsoft.AspNetCore.Mvc;
using Organimmo.Services.Abstractions;
using Organimmo.Services.Model;

namespace Organimmo.API
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {

        
        private readonly ITranslateService _translateService;

        public TranslateController(ITranslateService service)
        {
            _translateService = service;
        }

        [Route("/TranslateWord")]
        [HttpPost]
        public async Task<IActionResult> TranslateWordAsync(string BaseText, string CurrentText)
        {
            var word = await _translateService.TranslateWord(BaseText, CurrentText);
            return Ok(word);
        }

        [HttpPost("/SerializeRootAsync/")]
        public async Task<IActionResult> SerializeRootAsync(RootDto root)
        {
            var json = await _translateService.SerializeToJsonObject(root);
            return Ok(json);
        }

        [HttpPost("/DerializeRootAsync/")]
        public async Task<IActionResult> DerializeRootAsync(string jsonFile)
        {
            var json = await _translateService.Deserialize(jsonFile);
            return Ok(json);
        }
    }
}
