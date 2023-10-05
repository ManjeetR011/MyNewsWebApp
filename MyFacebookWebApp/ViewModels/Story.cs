namespace NewsFeedWebApp.ViewModels
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string By { get; set; }
        public int[] Parts { get; set; }
        public Uri Url { get; set; }
        public bool Deleted { get; set; }
        public string Time { get; set; }
        public bool Dead { get; set; }
        public int Parent { get; set; }
        public int Poll { get; set; }
        public int[] Kids { get; set; }
        public int Score { get; set; }
        public int Descendents { get; set; }

    }
}
