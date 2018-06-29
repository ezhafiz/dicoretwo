namespace AppServices
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HttpService;

    public class AppService : IAppService
    {
        private readonly IHttpService _httpService;

        public AppService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public string GetAllBeersFromService()
        {
           
        }

        public string GetDebugFromHttp()
        {
            return _httpService.DebugService();
        }
    }
}
