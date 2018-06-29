namespace HttpService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using Models;
    using Cofigs;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class HttpService : IHttpService
    {
        private HttpClient _client = new HttpClient();

        public T GetAllBeers<T>(string page, string pageSize)
        {
            this._client.BaseAddress = Configuration.EndpointBaseAddress;

            this._client.DefaultRequestHeaders.Accept.Add(Configuration.RequestHeaderType);

            var response = _client.GetAsync($"?page={page}&per_page={pageSize}").Result;

            var stream = response.Content.ReadAsStreamAsync();

            var allBeersResponse = TryConvertResponse<T>(stream.Result);
            
            return allBeersResponse;
        }


        #region Response manipulation
        private T TryConvertResponse<T>(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                using (var jr = new JsonTextReader(reader))
                {
                    var js = new JsonSerializer();
                    return js.Deserialize<T>(jr);
                }
            }
        }
        #endregion
    }

}
