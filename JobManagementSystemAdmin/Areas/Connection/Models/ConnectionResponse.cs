namespace JobManagementSystemAdmin.Areas.Connection.Models
{
    public class ConnectionResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Connectionall data { get; set; }
    }
}
