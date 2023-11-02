using Microsoft.AspNetCore.Mvc;

namespace cosmic_management_api.Controllers {

    [Route("[cosmic]")]
    [ApiController]
    public class ProductionController : ControllerBase {
        public readonly IConfiguration _configuration;

        ProductionController(IConfiguration configuration) {
            _configuration = configuration;
        }
    }
}
