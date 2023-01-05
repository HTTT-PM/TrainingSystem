using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TraniningSystemAPI.Entity;
using System;

namespace TrainingSystemManagerWEB.Pages
{
    public class CourseModel : PageModel
    {

        static readonly HttpClient client = new HttpClient();
        public List<CourseViewModel> ListCourse { get; set; }
        public int ClassId { get; set; }
        public Course Course { get; set; } 

        public void CallAPIGetCourse()
        {
            var url = "https://localhost:44321/api/course";
            var responseTask = client.GetAsync(url + "?classId=" + ClassId);
            responseTask.Wait();
            HttpResponseMessage resultl = responseTask.Result;
            var messageTask = resultl.Content.ReadAsStringAsync();
            messageTask.Wait();
            ListCourse = JsonConvert.DeserializeObject<List<CourseViewModel>>(messageTask.Result);
        }

        public void OnGet()
        {
            ClassId = Int32.Parse((string)RouteData.Values["ClassId"]);
            this.CallAPIGetCourse();
            // var url = "https://localhost:44321/api/course";
            // var response = client.GetAsync(url);
            // response.Wait();
            // HttpResponseMessage result = response.Result;
            // var messageTask = result.Content.ReadAsStringAsync();
            // messageTask.Wait();
            // ListCourse = JsonConvert.DeserializeObject<List<CourseViewModel>>(messageTask.Result);
        }
    }

    public class CourseViewModel
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int NumberOfLesson { get; set; }
        public string Target { get; set; }
        public string Content { get; set; }
        public string AssessmentForm { get; set; }
        public string CalculatesPointGuide { get; set; }
        public List<int>? AccountIds { get; set; }
    }
}
