using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;

namespace TrainingSystemManagerWEB.Pages.Manager
{
    public class TrainingResultFilterByJobModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int JobPositionID { get; set; }
        public List<EvaluateDto> TrainingResults { get; set; }
        public List<Skill> ListSkill { get; set; }
        public List<Knowledge> ListKnowledge { get; set; }
        public List<JobPosition> ListJobPosition { get; set; }
        public void GetListSkill()
        {
            var url = "https://localhost:44321/api/skill";
            var response = client.GetAsync(url);
            response.Wait();
            HttpResponseMessage result = response.Result;
            var messageTask = result.Content.ReadAsStringAsync();
            messageTask.Wait();
            ListSkill = JsonConvert.DeserializeObject<List<Skill>>(messageTask.Result);
        }

        public void GetTrainingResults()
        {
            var urlTrainingProgram = "https://localhost:44321/api/course-participant/job/";
            var responseTaskTrainingProgram = client.GetAsync(urlTrainingProgram+ JobPositionID);
            responseTaskTrainingProgram.Wait();
            HttpResponseMessage resultTrainingProgram = responseTaskTrainingProgram.Result;
            if (resultTrainingProgram.IsSuccessStatusCode)
            {
                var messageTask = resultTrainingProgram.Content.ReadAsStringAsync();
                messageTask.Wait();
                TrainingResults = JsonConvert.DeserializeObject<List<EvaluateDto>>(messageTask.Result);
            }
        }

        public void GetListKnowledge()
        {
            var url = "https://localhost:44321/api/knowledge";
            var response = client.GetAsync(url);
            response.Wait();
            HttpResponseMessage result = response.Result;
            var messageTask = result.Content.ReadAsStringAsync();
            messageTask.Wait();
            ListKnowledge = JsonConvert.DeserializeObject<List<Knowledge>>(messageTask.Result);
        }

        public void GetListJobPosition()
        {
            var url = "https://localhost:44321/api/job-position";
            var response = client.GetAsync(url);
            response.Wait();
            HttpResponseMessage result = response.Result;
            var messageTask = result.Content.ReadAsStringAsync();
            messageTask.Wait();
            ListJobPosition = JsonConvert.DeserializeObject<List<JobPosition>>(messageTask.Result);
        }

        public void OnGet()
        {
            JobPositionID = Int32.Parse((string)RouteData.Values["JobPositionID"]);

            GetListKnowledge();
            GetListSkill();
            GetTrainingResults();
            GetListJobPosition();
        }
    }
}
