using Newtonsoft.Json;

namespace Application.Utilities
{
    public class AppDomainResult
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
