using Microsoft.AspNetCore.Mvc;
using Organimmo.Services.Abstractions;

namespace Organimmo.API.Controllers
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


        //[Route("/TranslateWordAsync/")]
        [HttpPost("/TranslateWordAsync/")]
        public async Task<IActionResult> TranslateWordAsync(string BaseText, string CurrentText)
        {
            var word = await _translateService.TranslateWord(BaseText, CurrentText);
            return Ok(word);
        }
    }
}
