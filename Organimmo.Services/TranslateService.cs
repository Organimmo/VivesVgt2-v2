
using Organimmo.Services.Abstractions;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Organimmo.Services
{
    public class TranslateService : ITranslateService
    {
        private readonly string Json;

        public TranslateService()
        {
                
        }

        public string TranslateWord(string Json)
        {
            throw new NotImplementedException();
        }
    }
}
