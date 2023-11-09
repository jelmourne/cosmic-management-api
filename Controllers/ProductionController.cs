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

        [HttpGet]
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
        [Route("getPoduction")]
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
        public Response deleteProduction(Production prod) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.deleteProduction(con, prod);

            return response;
        }

        [HttpGet]
        [Route("getVendor")]
        public Response getVendor() {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.getVendor(con);

            return response;
        }

        [HttpPut]
        [Route("updateVendor")]
        public Response updateVendor(Vendor vendor) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.updateVendor(con, vendor);

            return response;
        }

        [HttpPost]
        [Route("insertVendor")]
        public Response insertVendor(Vendor vendor) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.insertVendor(con, vendor);

            return response;
        }

        [HttpDelete]
        [Route("deleteVendor")]
        public Response deleteVendor(Vendor vendor) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.deleteVendor(con, vendor);

            return response;
        }
    }
}
