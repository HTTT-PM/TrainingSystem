using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TraniningSystemAPI.Entity;

namespace TrainingSystemTrainerWEB.Pages.Trainer
{
    public class ManageDocumentModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public List<Course> ListCourse { get; set; }
        public void OnGet()
        {
            var url = "https://localhost:44321/api/course";
            var response = client.GetAsync(url);
            response.Wait();
            HttpResponseMessage result = response.Result;
            var messageTask = result.Content.ReadAsStringAsync();
            messageTask.Wait();
            ListCourse = JsonConvert.DeserializeObject<List<Course>>(messageTask.Result);
        }
    }
}
