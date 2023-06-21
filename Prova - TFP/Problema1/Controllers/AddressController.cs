using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Problema1.Objects;
using System.Net;
using System.Text.RegularExpressions;

namespace Problema1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private async Task<CepData> GetCepData(string cep)
        {
            cep = Regex.Replace(cep, @"\D", "");

            using (var client = new HttpClient())
            {
                var url = $"https://viacep.com.br/ws/{cep}/json/";

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<CepData>(content);

                    data.Valido = !content.Contains("\"erro\": true");

                    return data;
                }
                else
                {
                    return new CepData { Valido = false };
                }
            }
        }

        /// <summary>
        /// Esse end point recebe uma lista contendo os CEPs | Ex: "12345678".
        /// </summary>
        /// <param name="request">O request.</param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(typeof(ApiResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] List<string> ceps)
        {
            var cepDataList = new List<CepData>();

            foreach (var cep in ceps)
            {
                var data = await GetCepData(cep);

                cepDataList.Add(data);
            }

            var result = new ApiResult { Ceps = cepDataList };

            return Ok(result);
        }
    }
}
