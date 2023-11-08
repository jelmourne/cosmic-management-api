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

        [HttpPost]
        [Route("createUser")]
        public Response createUser(User user) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.createUser(con, user);

            return response;
        }

        
        [HttpGet]
        [Route("getProduction")]
        public Response getProduction() {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.getProduction(con);

            return response;
        }

        [HttpPut]
        [Route("updateProduction")]
        public Response updateProduction(Production prod) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.updateProduction(con, prod);

            return response;
        }

        [HttpPost]
        [Route("insertProduction")]
        public Response insertProduction(Production prod) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.insertProduction(con, prod);

            return response;
        }

        [HttpDelete]
        [Route("deleteProduction")]
        public Response deleteProduction(Production prod)
        {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.deleteProduction(con, prod);

            return response;
        }
    }
}
