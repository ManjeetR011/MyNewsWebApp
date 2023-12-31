
using Moq;
using NewsFeedWebApp.Interfaces;
using NewsFeedWebApp.Services;
using NewsFeedWebApp.ViewModels;
using NUnit.Framework.Internal;

namespace TestNewsFeedApp
{
    public class Tests
    {
        /// <summary>
        /// Define the Mock members
        /// </summary>
        private StoryService storyService;
        private List<Story> stories;

        /// <summary>
        /// SEtup up method to define the value of mock member
        /// </summary>
        [SetUp]
        public void SetUp()
            {
            stories = new List<Story>()
            {
              new Story() {
                   Id = 1,
                   By = "justin",
                   Title = "justin.tv is looking for a lead flash engineer!",
                  Descendents = 16,
                   Text = "justin.tv is the biggest live video site online. we serve hundreds of thousands of video streams a day, and have supported up to 50k live concurrent viewers. our site is growing every week, and we just added a 10 gbps line to our colo. our unique visitors are up 900% since january.<p>there are a lot of pieces that fit together to make justin.tv work: our video cluster, irc server, our web app, and our monitoring and search services, to name a few. a lot of our website is dependent on flash, and we're looking for talented flash engineers who know as2 and as3 very well who want to be leaders in the development of our flash.<p>responsibilities<p><pre><code>    * contribute to product design and implementation discussions\n    * implement projects from the idea phase to production\n    * test and iterate code before and after production release \n</code></pre>\nqualifications<p><pre><code>    * you should know as2, as3, and maybe a little be of flex.\n    * experience building web applications.\n    * a strong desire to work on website with passionate users and ideas for how to improve it.\n    * experience hacking video streams, python, twisted or rails all a plus.\n</code></pre>\nwhile we're growing rapidly, justin.tv is still a small, technology focused company, built by hackers for hackers. seven of our ten person team are engineers or designers. we believe in rapid development, and push out new code releases every week. we're based in a beautiful office in the soma district of sf, one block from the caltrain station. if you want a fun job hacking on code that will touch a lot of people, jtv is for you.<p>note: you must be physically present in sf to work for jtv. completing the technical problem at <a href=\"http://www.justin.tv/problems/bml\" rel=\"nofollow\">http://www.justin.tv/problems/bml</a> will go a long way with us. cheers!",
                   Type = "story",
               }
            };
            storyService = new StoryService();

        }

        /// <summary>
        /// Test method for Story Service Get New Stories method
        /// </summary>
        [Test]
        public async Task TestGetStories()
        {
           //Assert
            var result =  await storyService.GetNewStories();
            Assert.NotZero(result.Count);
        }

       

    }
}