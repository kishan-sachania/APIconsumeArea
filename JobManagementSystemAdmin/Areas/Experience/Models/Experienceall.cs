namespace JobManagementSystemAdmin.Areas.Experience.Models
{
    public class Experienceall
    {
        public int experienceID { get; set; }
        public string companyName { get; set; }
        public string position { get; set; }
        public string location { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int userID { get; set; }
    }
}
