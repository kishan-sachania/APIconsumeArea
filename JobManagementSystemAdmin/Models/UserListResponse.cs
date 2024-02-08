namespace JobManagementSystemAdmin.Models
{
    public class UserListResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<User> data { get; set; }
    }
}
