using MyFacebookWebApp.ViewModels;

namespace MyFacebookWebApp.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetPosts();

        Task<List<Post>> Search(string searchString, int pageNum);
    }
}
