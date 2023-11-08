namespace cosmic_management_api.Models
{
    public class StageResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public Stage stage{ get; set; }
        public List<Stage> stages { get; set; }
    }
}
