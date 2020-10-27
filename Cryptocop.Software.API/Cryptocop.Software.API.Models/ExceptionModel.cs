using Newtonsoft.Json;

namespace Cryptocop.Software.API.Models
{
    public class ExceptionModel
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}