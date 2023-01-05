using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TraniningSystemAPI.Entity;

namespace TrainingSystemManagerWEB.Pages
{
    public class ClassRoom : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public List<Classroom> ListCourse { get; set; }
        public void OnGet()
        {
            var url = "https://localhost:44321/api/classroom";
            var response = client.GetAsync(url);
            response.Wait();
            HttpResponseMessage result = response.Result;
            var messageTask = result.Content.ReadAsStringAsync();
            messageTask.Wait();
            ListCourse = JsonConvert.DeserializeObject<List<Classroom>>(messageTask.Result);
        }
    }

}
