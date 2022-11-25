using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using TraniningSystemAPI.Dto;

namespace TrainingSystemManagerWEB.Pages.Manager
{
    public class TraningProgramDetailModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int TrainingProgramID { get; set; }
        public List<CourseDto> Course { get; set; }
        public List<KnowledgeDto> Knowledge { get; set; }
        public List<SkillDto> Skill { get; set; }
        public void CallApiToGetData(string url, string type)
        {
            var responseTask = client.GetAsync(url+"/"+ TrainingProgramID + "/"+ type);
            responseTask.Wait();
            HttpResponseMessage resultl = responseTask.Result;

            if (resultl.IsSuccessStatusCode)
            {
                var messageTask = resultl.Content.ReadAsStringAsync();
                messageTask.Wait();
                switch (type)
                {
                    case "skill":
                        Skill = JsonConvert.DeserializeObject<List<SkillDto>>(messageTask.Result);
                        break;
                    case "knowledge":
                        Knowledge = JsonConvert.DeserializeObject<List<KnowledgeDto>>(messageTask.Result);
                        break;
                    case "course":
                        Course = JsonConvert.DeserializeObject<List<CourseDto>>(messageTask.Result);
                        break;
                    default:
                        break;
                }
            }
        }
        public void OnGet()
        {
            TrainingProgramID = Int32.Parse((string)RouteData.Values["TrainingProgramID"]);
            var url = "https://localhost:44321/api/training";

            this.CallApiToGetData(url, "skill");
            this.CallApiToGetData(url, "knowledge");
            this.CallApiToGetData(url, "course");
        }
    }
}
