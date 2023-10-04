using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MyFacebookWebApp.Interfaces;
using MyFacebookWebApp.ViewModels;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFacebookWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        // GET: api/<StoriyController>
        private readonly string GetPostsCacheKey = "GetPosts";
        private readonly IPostService postService;
        private readonly IMemoryCache memoryCache;
        private ILogger<StoriesController> logger;
        private MemoryCacheEntryOptions cacheOptions;
        public StoriesController(IPostService _postService, IMemoryCache _memoryCache, ILogger<StoriesController> _logger)
        {
            memoryCache = _memoryCache;
            postService = _postService;
            logger = _logger;
            cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(50))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3000))
                    .SetPriority(CacheItemPriority.Normal)
                    .SetSize(1024);

        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> Get()
        {
            try
            {
                if (memoryCache.TryGetValue(GetPostsCacheKey, out List<Post> posts))
                {
                    logger.Log(LogLevel.Information, "returned cached value");
                }
                else
                {
                    logger.Log(LogLevel.Information, "caching getPosts value");
                    posts = await postService.GetPosts();
                    
                    memoryCache.Set(GetPostsCacheKey, posts, cacheOptions);
                }
                return Ok(posts);

            }
            catch (Exception ex)
            {
                return NoContent();
            }
            
        }

        [HttpGet("Search")]
        public async Task<ActionResult<List<Post>>> Search(string searchString, int pageNum)
        {
            try
            {
                if(memoryCache.TryGetValue(searchString, out List<Post> result))
                {
                    logger.Log(LogLevel.Information, "Gettig stored searchresult");
                }
                else
                {
                    logger.Log(LogLevel.Information, "Fetching  searched result");

                    result = await postService.Search(searchString, pageNum);
                    memoryCache.Set(searchString, result, cacheOptions);
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return new BadRequestResult();
            }
        }
    }
}
