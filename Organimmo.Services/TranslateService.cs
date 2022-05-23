
using Organimmo.DAL;
using Organimmo.Services.Abstractions;
using Organimmo.Services.Model;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Organimmo.Services
{
    public class TranslateService : ITranslateService
    {
        private readonly string _Json;

        public TranslateService(string json)
        {
            _Json = json;
        }

        public async Task<string> TranslateWord(string text, string translation)
        {
            text = Translation;
            return text;
        }

       
    }
}
