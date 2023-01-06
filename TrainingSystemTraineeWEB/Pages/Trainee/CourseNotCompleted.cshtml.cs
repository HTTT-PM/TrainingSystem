using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System;
using TraniningSystemAPI.Dto;

namespace TrainingSystemTraineeWEB.Pages.Trainee
{
    public class CourseNotCompletedModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int TraineeID { get; set; }
        public List<EvaluateDto> CourseResult { get; set; }


        public void GetCourseResults()
        {
            var urlTrainingProgram = "https://localhost:44321/api/course/notcompleted/trainee/";
            var responseTaskTrainingProgram = client.GetAsync(urlTrainingProgram + TraineeID);
            responseTaskTrainingProgram.Wait();
            HttpResponseMessage resultTrainingProgram = responseTaskTrainingProgram.Result;
            if (resultTrainingProgram.IsSuccessStatusCode)
            {
                var messageTask = resultTrainingProgram.Content.ReadAsStringAsync();
                messageTask.Wait();
                CourseResult = JsonConvert.DeserializeObject<List<EvaluateDto>>(messageTask.Result);
            }
        }

        public void OnGet()
        {
            TraineeID = Int32.Parse((string)RouteData.Values["TraineeID"]);

            this.GetCourseResults();
        }
    }
}
