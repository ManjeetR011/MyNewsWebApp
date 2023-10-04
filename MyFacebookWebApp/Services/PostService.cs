using MyFacebookWebApp.Interfaces;
using MyFacebookWebApp.ViewModels;

namespace MyFacebookWebApp.Services
{
    public class PostService : IPostService
    {
        private IPostRepository postRepo;

        public PostService(IPostRepository _postRepo) {
            postRepo = _postRepo;
        }

        public async Task<List<Post>> GetPosts()
        {
            var posts =  await postRepo.GetPosts();
            return posts;             
        }
        public async Task<List<Post>> Search(string searchString, int pageNum)
        {
            var posts = await postRepo.Search(searchString,pageNum);
            return posts;
        }
    }
}
