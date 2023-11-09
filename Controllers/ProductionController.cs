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
        public Response<User> loginUser(User user) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<User> response = db.loginUser(con, user);

            return response;
        }

        [HttpPost]
        [Route("createUser")]
        public Response<User> createUser(User user) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<User> response = db.createUser(con, user);

            return response;
        }

        
        [HttpGet]
        [Route("getPoduction")]
        public Response<Production> getProduction() {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<Production> response = db.getProduction(con);

            return response;
        }

        [HttpPut]
        [Route("updateProduction")]
        public Response<Production> updateProduction(Production prod) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<Production> response = db.updateProduction(con, prod);

            return response;
        }

        [HttpPost]
        [Route("insertProduction")]
        public Response<Production> insertProduction(Production prod) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<Production> response = db.insertProduction(con, prod);

            return response;
        }

        [HttpDelete]
        [Route("deleteProduction")]
        public Response<Production> deleteProduction(Production prod) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<Production> response = db.deleteProduction(con, prod);

            return response;
        }

        [HttpGet]
        [Route("getVendor")]
        public Response<Vendor> getVendor() {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<Vendor> response = db.getVendor(con);

            return response;
        }

        [HttpPut]
        [Route("updateVendor")]
        public Response<Vendor> updateVendor(Vendor vendor) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<Vendor> response = db.updateVendor(con, vendor);

            return response;
        }

        [HttpPost]
        [Route("insertVendor")]
        public Response<Vendor> insertVendor(Vendor vendor) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<Vendor> response = db.insertVendor(con, vendor);

            return response;
        }

        [HttpDelete]
        [Route("deleteVendor")]
        public Response<Vendor> deleteVendor(Vendor vendor) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<Vendor> response = db.deleteVendor(con, vendor);

            return response;
        }

        [HttpPost]
        [Route("AddStage")]
        public Response<Stage> AddStage(Stage stage) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<Stage> response = db.AddStage(con, stage);

            return response;
        }

        [HttpPut]
        [Route("UpdateStage")]
        public Response<Stage> UpdateStage(Stage stage) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<Stage> response = db.UpdateStage(con, stage);

            return response;
        }

        [HttpGet]
        [Route("GetAllStages")]
        public Response<Stage> llStages() {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<Stage> response = db.GetAllStages(con);

            return response;
        }

        [HttpGet]
        [Route("GetStageByName/{name}")]
        public Response<Stage> GetStageByName(string name) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<Stage> response = db.GetStageByName(con, name);

            return response;
        }

        [HttpDelete]
        [Route("DeleteStage/{name}")]
        public Response<Stage> DeleteStage(string name) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<Stage> response = db.DeleteStage(con, name);

            return response;
        }

        

        [HttpGet]
        [Route("GetStageReqs/{id}")]
        public Response<Production> GetStageReqs(int id) {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response<Production> response = db.GetStageReqs(con, id);

            return response;
        }
    }
}
