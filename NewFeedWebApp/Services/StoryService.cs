using Microsoft.AspNetCore.Mvc;
using NewsFeedWebApp.Interfaces;
using NewsFeedWebApp.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace NewsFeedWebApp.Services
{
    /// <summary>
    /// Stories service
    /// </summary>
    public class StoryService : IStoryService
    {
        string Baseurl = "https://hacker-news.firebaseio.com/";


        public StoryService() {
        }
        /// <summary>
        /// Get the list of new stories
        /// </summary>
        /// <returns>List of new stories</returns>
        public async Task<List<Story>> GetNewStories()
        {
            var storyIdlist = await GetTopStories();
            var newlist = storyIdlist.Take(200).ToArray();

            var stories =  await GetItems(newlist);
            var filteredStories = stories.Where(x => x.Url != null).ToList();
            return filteredStories;  
            
        }
       
        /// <summary>
        /// Get the Id of top stories
        /// </summary>
        /// <returns>List of  Story Id</returns>
        public async Task<int[]> GetTopStories()
        {

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                int[] array = null;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("v0/newstories.json?print=pretty");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {

                    var ObjResponse = Res.Content.ReadAsStringAsync().Result;
                    array = JsonConvert.DeserializeObject<int[]>(ObjResponse);
                    
                }
                return array;
            }
        }

        /// <summary>
        /// Get the item details
        /// </summary>
        /// <param name="idList"></param>
        /// <returns>List of stories with details</returns>
        public async Task<List<Story>> GetItems(int[] idList)
        {
            List<Story> storyList = new List<Story>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                int[] array = null;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                foreach (int id in idList)
                {
                    //Sending request to find web api REST service resource get Items using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("v0/item/"+id+".json?print=pretty");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {

                        var ObjResponse = Res.Content.ReadAsStringAsync().Result;
                        var story = JsonConvert.DeserializeObject<Story>(ObjResponse);
                        storyList.Add(story);
                    }
                }

               
                return storyList;
                //returning the story list to view  
            }
        }
    }
}
