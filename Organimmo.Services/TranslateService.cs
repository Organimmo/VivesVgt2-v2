
using Organimmo.DAL;
using Organimmo.Services.Abstractions;
using Organimmo.Services.Model;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;
using Organimmo.Services.Model;

namespace Organimmo.Services
{
    public class TranslateService : ITranslateService
    {

        public TranslateService()
        {
            // empty constructor
        }

        public async Task<string> TranslateWord(string BaseText, string CurrentText)
        {
            BaseText = CurrentText;
            return BaseText;
        }

        public async Task<string> SerializeToJsonObject(RootDto root)
        {
            string jsonString = JsonSerializer.Serialize(root);
            return jsonString;
        }

        public async Task<RootDto> Deserialize(string jsonFile)
        {
            var root = JsonSerializer.Deserialize<RootDto>(jsonFile);
            return root;
        }


    }
}
