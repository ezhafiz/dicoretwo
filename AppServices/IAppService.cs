namespace AppServices
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    
    public interface IAppService
    {
        string GetAllBeersFromService();

        string GetDebugFromHttp();
    }
}
