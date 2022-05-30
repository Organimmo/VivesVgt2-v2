
using Organimmo.Services.Abstractions;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Organimmo.Services.Model;

namespace Organimmo.Services
{
    public class TranslateService : ITranslateService
    {
        private readonly string _Json;

        public TranslateService()
        {
            //_Json = json;
        }

       

        public async Task<string> TranslateWord(string BaseText, string CurrentText)
        {
            BaseText = CurrentText;
            return BaseText;
        }

       
    }
}
