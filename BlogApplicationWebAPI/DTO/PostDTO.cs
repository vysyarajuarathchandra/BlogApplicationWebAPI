namespace BlogApplicationWebAPI.DTO
{
    public class PostDTO
    {
       
        public string ? PostTitle { get; set; }
        public string? Content { get; set; }      
        public string ? UrlHandle { get; set; }

        public string ? PostsStatus { get;set; }    
        public string ? AuthorName { get; set; }
        public string ? CategoryName { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; } 
    }
}
