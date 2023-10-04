using MyFacebookWebApp.ViewModels;

namespace MyFacebookWebApp.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> GetPosts();

        Task<List<Post>> Search(string searchString, int pageNum);

    }
}
