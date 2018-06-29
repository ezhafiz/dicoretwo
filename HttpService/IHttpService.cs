using System.Threading.Tasks;

namespace HttpService
{
    using Models;
    using Newtonsoft.Json.Linq;

    public interface IHttpService
    {
        T GetAllBeers<T>(string page, string pageSize);
    }
}
