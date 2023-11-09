namespace cosmic_management_api.Models {
    public class Location {
        public int id {  get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string postal { get;set; }
        public int cityId { get; set; }
        public string phone { get; set; }
    }
}
