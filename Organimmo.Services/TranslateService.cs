
using Organimmo.Services.Abstractions;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Organimmo.Services
{
    public class TranslateService : ITranslateService
    {
        private readonly string json;

        public TranslateService(string json)
        {
                
        }

        public string TranslateWord(string text, string Translation)
        {
            text = Translation;
            return text;
        }

       
    }
}
