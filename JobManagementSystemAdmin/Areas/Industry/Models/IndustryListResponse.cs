namespace JobManagementSystemAdmin.Areas.Industry.Models
{
    
    public class IndustryListResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Industryall> data { get; set; }
    }
    
}
