using System.ComponentModel.DataAnnotations;

namespace JobManagementSystemAdmin.Models
{
    public class User
    {
        
        public int userId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string location { get; set; }
    }
}
