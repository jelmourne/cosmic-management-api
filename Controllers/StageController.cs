using cosmic_management_api.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace cosmic_management_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StageController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public StageController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddStage")]
        public Response AddStage(Stage stage)
        {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.AddStage(con, stage);

            return response;
        }

        [HttpDelete]
        [Route("DeleteStage/{name}")]
        public Response DeleteStage(string name)
        {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.DeleteStage(con, name);

            return response;
        }

        [HttpPut]
        [Route("UpdateStage")]
        public Response UpdateStage(Stage stage)
        {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.UpdateStage(con, stage);

            return response;
        }

        [HttpGet]
        [Route("GetAllStages")]
        public Response GetAllStages()
        {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.GetAllStages(con);

            return response;
        }

        [HttpGet]
        [Route("GetStageByName/{name}")]
        public Response GetStageByName(string name)
        {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.GetStageByName(con, name);

            return response;
        }
    }
}
