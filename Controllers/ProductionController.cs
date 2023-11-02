using cosmic_management_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace cosmic_management_api.Controllers {

    [Route("[controller]")]
    [ApiController]
    public class ProductionController : ControllerBase {
        private readonly IConfiguration _configuration;

        public ProductionController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("loginUser")] 
        public Response loginUser(User user) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.loginUser(con, user);

            return response;
        }

    }
}
