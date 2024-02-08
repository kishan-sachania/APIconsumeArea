namespace JobManagementSystemAdmin.Models
{

    public class UserResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public User data { get; set; }
    }

}
