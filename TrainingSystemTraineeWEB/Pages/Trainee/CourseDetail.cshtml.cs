using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TraniningSystemAPI.Entity;

namespace TrainingSystemTraineeWEB.Pages.Trainee
{
    public class CourseDetailModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int CourseID { get; set; }
        public Course course { get; set; } 
        public void OnGet()
        {
            CourseID = Int32.Parse((string)RouteData.Values["CourseID"]);
            var url = "https://localhost:44321/api/course";
            var responseTask = client.GetAsync(url + "/" + CourseID);
            responseTask.Wait();
            HttpResponseMessage resultl = responseTask.Result;
            if (resultl.IsSuccessStatusCode)
            {
                var messageTask = resultl.Content.ReadAsStringAsync();
                messageTask.Wait();
                course = JsonConvert.DeserializeObject<Course>(messageTask.Result);
            }
        }
    }
}
