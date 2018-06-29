namespace BrewdogApi
{
    using System;
    using HttpService;
    using Newtonsoft.Json.Linq;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using HttpService.Cofigs;
    using Newtonsoft.Json;

    public class BrewdogApi
    {
        private readonly IHttpService _brewdogApiService;
        
        public BrewdogApi(IHttpService brewdogApiService)
        {
            _brewdogApiService = brewdogApiService;
        }

        public JToken GetBeers(string page, string pageSize)
        {
            return _brewdogApiService.GetAllBeers<JToken>(page, pageSize);
        }
    }
}
