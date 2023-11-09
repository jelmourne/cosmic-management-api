using Microsoft.OpenApi.Any;

namespace cosmic_management_api.Models {
    public class Response<T> {
        public int status { get; set; }
        public string message { get; set; }
        public T body { get; set; }
        public List<T> data { get; set; }
    }
}
