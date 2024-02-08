namespace JobManagementSystemAdmin.Areas.Post.Models
{
   
    public class PostListResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Postall> data { get; set; }
    }
   
}
