using Microsoft.OpenApi.Any;

namespace cosmic_management_api.Models {
    public class Response {
        public int status { get; set; }
        public string message { get; set; }
        public object body { get; set; }
        public List<object> data { get; set; }
    }
}
