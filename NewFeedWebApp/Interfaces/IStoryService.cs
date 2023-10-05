using NewsFeedWebApp.ViewModels;

namespace NewsFeedWebApp.Interfaces
{
    public interface IStoryService
    {
        Task<List<Story>> GetNewStories();

    }
}
