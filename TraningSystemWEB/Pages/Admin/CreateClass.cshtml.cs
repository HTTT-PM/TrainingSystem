using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XTLAB;
using Newtonsoft.Json;

namespace TraningSystemWEB.Pages
{
    public class CreateClassModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public List<Course> CourseItems;
        public void OnGet()
        {
            ViewData["active"] = "active";

            var url = "https://localhost:44321/api/course";

            var responseTask = client.GetAsync(url);
            responseTask.Wait();

            HttpResponseMessage result = responseTask.Result;

            if(result.IsSuccessStatusCode)
            {
                var messageTask = result.Content.ReadAsStringAsync();
                messageTask.Wait();

                CourseItems = JsonConvert.DeserializeObject <List<Course>>(messageTask.Result);
            }

        }
    }
}
