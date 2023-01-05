using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TraniningSystemAPI.Entity;

namespace TrainingSystemTrainerWEB.Pages
{
    public class NotifyModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public List<Notify> ListCourse { get; set; }
        public void OnGet()
        {
            var url = "https://localhost:44321/api/notify?status=true";
            var response = client.GetAsync(url);
            response.Wait();
            HttpResponseMessage result = response.Result;
            var messageTask = result.Content.ReadAsStringAsync();
            messageTask.Wait();
            ListCourse = JsonConvert.DeserializeObject<List<Notify>>(messageTask.Result);
        }
    }

}
