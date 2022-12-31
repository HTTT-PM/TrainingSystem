using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;

namespace TrainingSystemTrainerWEB.Pages.Trainer
{
    public class AssignmentListModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int CourseID { get; set; }
        public List<TraineeInCourse> TraineeList { get; set; }
        public List<ExerciseDto> ExerciseList { get; set; }
        public void CallAPIGetListTrainee()
        {
            var url = "https://localhost:44321/api/course";
            var responseTask = client.GetAsync(url + "/" + CourseID+"/trainee");
            responseTask.Wait();
            HttpResponseMessage resultl = responseTask.Result;
            if (resultl.IsSuccessStatusCode)
            {
                var messageTask = resultl.Content.ReadAsStringAsync();
                messageTask.Wait();
                TraineeList = JsonConvert.DeserializeObject<List<TraineeInCourse>>(messageTask.Result);
            }
        }
        public void CallAPIGetListExercise()
        {
            var url = "https://localhost:44321/api/course";
            var responseTask = client.GetAsync(url + "/" + CourseID + "/exercise");
            responseTask.Wait();
            HttpResponseMessage resultl = responseTask.Result;
            if (resultl.IsSuccessStatusCode)
            {
                var messageTask = resultl.Content.ReadAsStringAsync();
                messageTask.Wait();
                ExerciseList = JsonConvert.DeserializeObject<List<ExerciseDto>>(messageTask.Result);
            }
        }
        public void OnGet()
        {
            CourseID = Int32.Parse((string)RouteData.Values["CourseID"]);

            this.CallAPIGetListTrainee();
            this.CallAPIGetListExercise();
        }
    }
}
