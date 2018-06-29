using System;

namespace HttpService.Cofigs
{
    using System.Net.Http.Headers;

    public class Configuration
    {
        public static readonly Uri EndpointBaseAddress = new Uri("https://api.punkapi.com/v2/beers");
        public static readonly MediaTypeWithQualityHeaderValue RequestHeaderType =new MediaTypeWithQualityHeaderValue("application/json");
    }
}
