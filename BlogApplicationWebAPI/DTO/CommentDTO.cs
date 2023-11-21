namespace BlogApplicationWebAPI.DTO
{
    public class CommentDTO
    {
        
        public string ? Text { get; set; }
        public string ? UserName { get; set; }
        public string ? PostTitle { get; set; }
        public string? CommentStatus { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }


    }
}
