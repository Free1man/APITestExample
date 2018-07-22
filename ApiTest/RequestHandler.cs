using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ApiTest
{
    public class RequestHandler
    {
        public async Task<JToken> GetJsonFromUrl(string url)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(url);
                var parsedJson = JToken.Parse(result);
                return parsedJson;
            }
        }
    }
}
