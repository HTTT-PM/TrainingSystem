using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System;
using TraniningSystemAPI.Dto;

namespace TrainingSystemTraineeWEB.Pages.Trainee
{
    public class DetailEvaluationCompletedCourseModel : PageModel
    {

        static readonly HttpClient client = new HttpClient();
        public int CourseID { get; set; }
        public int TraineeID { get; set; }
        public List<TraineeExerciseDto> ListResulExercise { get; set; }
        public List<EvaluateDto> CourseResult { get; set; }
        public List<EvaluateSkillDto> ListSkill { get; set; }
        public List<EvaluateKnowledgeDto> ListKnowledge { get; set; }
        public void CallApiToGetList(string type)
        {
            var url = "https://localhost:44321/api/course-participant";
            var response = client.GetAsync(url + '/' + CourseID + '/' + TraineeID + '/' + type);
            response.Wait();
            HttpResponseMessage result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var messageTask = result.Content.ReadAsStringAsync();
                messageTask.Wait();
                switch (type)
                {
                    case "skill":
                        ListSkill = JsonConvert.DeserializeObject<List<EvaluateSkillDto>>(messageTask.Result);
                        break;
                    case "knowledge":
                        ListKnowledge = JsonConvert.DeserializeObject<List<EvaluateKnowledgeDto>>(messageTask.Result);
                        break;
                    default:
                        break;
                }
            }
        }

        public void GetCourseResults()
        {
            var urlTrainingProgram = "https://localhost:44321/api/course/completed/trainee/";
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
        public void GetExerciseesults()
        {
            var urlTrainingProgram = "https://localhost:44321/api/trainee/";
            var responseTaskTrainingProgram = client.GetAsync(urlTrainingProgram + TraineeID + "/course/" + CourseID +"/exercise");
            responseTaskTrainingProgram.Wait();
            HttpResponseMessage resultTrainingProgram = responseTaskTrainingProgram.Result;
            if (resultTrainingProgram.IsSuccessStatusCode)
            {
                var messageTask = resultTrainingProgram.Content.ReadAsStringAsync();
                messageTask.Wait();
                ListResulExercise = JsonConvert.DeserializeObject<List<TraineeExerciseDto>>(messageTask.Result);
            }
        }
        public void OnGet()
        {
            CourseID = Int32.Parse((string)RouteData.Values["CourseID"]);
            TraineeID = Int32.Parse((string)RouteData.Values["TraineeID"]);

            this.CallApiToGetList("skill");
            this.CallApiToGetList("knowledge");
            this.GetExerciseesults();
            this.GetCourseResults();
        }
    }
}
