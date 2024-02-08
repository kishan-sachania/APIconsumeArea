namespace JobManagementSystemAdmin.Areas.Education.Models
{
   
    public class EducationListResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Educationall> data { get; set; }
    }
    
}
