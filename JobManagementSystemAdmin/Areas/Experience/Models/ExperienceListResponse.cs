namespace JobManagementSystemAdmin.Areas.Experience.Models
{
   

    public class ExperienceListResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Experienceall> data { get; set; }
    }
    
}
