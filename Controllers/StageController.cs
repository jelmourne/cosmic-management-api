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
    }
}
