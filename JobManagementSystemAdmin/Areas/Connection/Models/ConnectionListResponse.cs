namespace JobManagementSystemAdmin.Areas.Connection.Models
{
    

    public class ConnectionListResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Connectionall> data { get; set; }
    }
    
}
