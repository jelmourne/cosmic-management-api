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
        public StageResponse AddStage(Stage stage)
        {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            StageResponse response = db.AddStage(con, stage);

            return response;
        }



        [HttpDelete]
        [Route("DeleteStage/{name}")]
        public StageResponse DeleteStage(string name)
        {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            StageResponse response = db.DeleteStage(con, name);

            return response;
        }

        [HttpPut]
        [Route("UpdateStage")]
        public StageResponse UpdateStage(Stage stage)
        {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            StageResponse response = db.UpdateStage(con, stage);

            return response;
        }

        [HttpGet]
        [Route("GetAllStages")]
        public StageResponse GetAllStages()
        {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            StageResponse response = db.GetAllStages(con);

            return response;
        }

        [HttpGet]
        [Route("GetStageByName/{name}")]
        public StageResponse GetStageByName(string name)
        {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            StageResponse response = db.GetStageByName(con, name);

            return response;
        }

        [HttpGet]
        [Route("GetStageReqs/{id}")]
        public Response GetStageReqs(int id)
        {
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DatabaseConnection"));

            Database db = new Database();
            Response response = db.GetStageReqs(con, id);

            return response;
        }

    }
}
