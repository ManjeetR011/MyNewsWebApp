namespace MyFacebookWebApp.ViewModels
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string ContentUrl { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDead { get; set; }
        public int Parent { get; set; }
        public string Poll { get; set; }
        public int[] Kids { get; set; }
        public int PollCount { get; set; }
        public int Descendents { get; set; }

    }
}
