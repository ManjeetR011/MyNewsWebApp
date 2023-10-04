using MyFacebookWebApp.Interfaces;
using MyFacebookWebApp.ViewModels;

namespace MyFacebookWebApp.Repository
{
    public class PostRepository: IPostRepository
    {
        public PostRepository() { }

        public readonly List<Post> data = new List<Post>()
        {
               new Post() {
                   Id = 1,
                   Author = "dhouston",
                   Descendents = 11,
                   Kids = new int[] {2},
                   PollCount = 111,
                   CreatedAt = new DateTime(2007,04,05,12,46,40),
                   Title = "My YC app: Dropbox - Throw away your USB drive",
                   Type = "story",
               },
               new Post() {
                   Id = 2,
                   Author = "ragul",
                   Descendents = 1,
                   Kids = new int[] {2},
                   PollCount = 11,
                   CreatedAt = new DateTime(2010,05,09,02,26,42),
                   Title = "Cool to see ice of jar with margertia",
                   Type = "story",
               },
               new Post() {
                   Id = 3,
                   Author = "tel",
                   Title = "Ask HN: The Arc Effect",
                   Descendents = 16,
                   PollCount = 25,
                   Description = "HN: the Next Iteration. I get the impression that with Arc being released a lot of people who never had time for HN before are suddenly dropping in more often. (PG: what are the numbers on this? I'm envisioning a spike.Not to say that isn't great, but I'm wary of Diggification. Between links comparing programming to sex and a flurry of gratuitous, ostentatious  adjectives in the headlines it's a bit concerning. 80% of the stuff that makes the front page is still pretty awesome, but what's in place to keep the signal/noise ratio high? Does the HN model still work as the community scales? What's in store for (++ HN)?",
                   Kids = new int[] {},
                   CreatedAt = new DateTime(2008,02,22,08,03,40),
                   Type = "story",
               },
               new Post() {
                   Id = 5,
                   Author = "pg",
                   Descendents = 54,
                   Description= "",
                   Kids = new int[] {},
                   PollCount = 46,
                   CreatedAt = new DateTime(2008,03,02,02,04,12),
                   Title = "Poll: What would happen if News.YC had explicit support for polls?",
                   Type = "poll",
               },
               new Post() {
                   Id = 6,
                   Author = "dhouston",
                   Descendents = 71,
                   Kids = new int[] {2},
                   PollCount = 111,
                   CreatedAt = new DateTime(2009,05,05,12,46,40),
                   Title = "My YC app: Dropbox - Throw away your USB drive",
                   Type = "story",
               },
            };
        
        public async Task<List<Post>> GetPosts()
        {
            var posts =  Task.FromResult(data.Where(x => x.Title != String.Empty).OrderByDescending(x => x.CreatedAt).ToList());
            return await posts;
        }
        public async Task<List<Post>> Search(string searchString, int pageNumber)
        {
            searchString = searchString ?? "";
            pageNumber = Math.Max(1, pageNumber);
            int limit = 10;
            int offset = (pageNumber - 1) * limit;
            var posts = await Task.FromResult(data.Skip(offset).Take(limit).Where(x => x.Type != "comment" && x.Title.Contains(searchString)));
            return posts.ToList();
            
           
        }
    }
}
