using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TraniningSystemAPI.Dto;

namespace TrainingSystemManagerWEB.Pages.Manager
{ 
    public class TrainingResultDetailModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int CourseID { get; set; }
        public int TraineeID { get; set; }
        public List<EvaluateSkillDto> ListSkill { get; set; }
        public List<EvaluateKnowledgeDto> ListKnowledge { get; set; }
        public void CallApiToGetList(string type)
        {
            var url = "https://localhost:44321/api/course-participant";
            var response = client.GetAsync(url + '/' + CourseID + '/' + TraineeID+'/'+type);
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
        public void OnGet()
        {
            CourseID = Int32.Parse((string)RouteData.Values["CourseID"]);
            TraineeID = Int32.Parse((string)RouteData.Values["TraineeID"]);

            this.CallApiToGetList("skill");
            this.CallApiToGetList("knowledge");
        }
    }
}
