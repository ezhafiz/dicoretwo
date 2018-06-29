namespace HttpService.Models
{
    using System.Net;

    public class HttpResponse<T>
    {
        public HttpStatusCode ResponseCode { get; set; }

        public T ResponsePayload { get; set; }
    }
}
