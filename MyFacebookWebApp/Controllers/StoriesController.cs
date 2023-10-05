using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NewsFeedWebApp.Interfaces;
using NewsFeedWebApp.ViewModels;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsFeedWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        // GET: api/<StoriyController>
        private readonly string GetPostsCacheKey = "GetPosts";
        private readonly IStoryService storyService;
        private readonly IMemoryCache memoryCache;
        private ILogger<StoriesController> logger;
        private MemoryCacheEntryOptions cacheOptions;
        public StoriesController(IStoryService _storyService, IMemoryCache _memoryCache, ILogger<StoriesController> _logger)
        {
            memoryCache = _memoryCache;
            storyService = _storyService;
            logger = _logger;
            cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(50))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3000))
                    .SetPriority(CacheItemPriority.Normal)
                    .SetSize(1024);

        }

        [HttpGet]
        public async Task<ActionResult<List<Story>>> Get()
        {
            try
            {
                if (memoryCache.TryGetValue(GetPostsCacheKey, out List<Story> posts))
                {
                    logger.Log(LogLevel.Information, "returned cached value");
                }
                else
                {
                    logger.Log(LogLevel.Information, "caching GetStories value");
                    posts = await storyService.GetNewStories();
                    
                    memoryCache.Set(GetPostsCacheKey, posts, cacheOptions);
                }
                return Ok(posts);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            
        }


    }
}
