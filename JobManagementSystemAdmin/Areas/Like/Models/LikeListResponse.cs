namespace JobManagementSystemAdmin.Areas.Like.Models
{
   
    public class LikeListResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Likeall> data { get; set; }
    }
    
}
