namespace JobManagementSystemAdmin.Areas.Education.Models
{
    public class Educationall

    {
        public int educationID { get; set; }
        public string schoolName { get; set; }
        public string degree { get; set; }
        public string studyField { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int userID { get; set; }
    }
}
