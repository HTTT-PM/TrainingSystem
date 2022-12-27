using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;

namespace TrainingSystemTrainerWEB.Pages.Trainer
{
    public class CourseDetailModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int CourseID { get; set; }
        public List<KnowledgeDto> Knowledge { get; set; }
        public List<SkillDto> Skill { get; set; }
        public List<KnowledgeDto> KnowledgeList { get; set; }
        public List<SkillDto> SkillList { get; set; }
        public Course Course { get; set; }
        public void CallAPIGetCourse()
        {
            var url = "https://localhost:44321/api/course";
            var responseTask = client.GetAsync(url + "/" + CourseID);
            responseTask.Wait();
            HttpResponseMessage resultl = responseTask.Result;
            if (resultl.IsSuccessStatusCode)
            {
                var messageTask = resultl.Content.ReadAsStringAsync();
                messageTask.Wait();
                Course = JsonConvert.DeserializeObject<Course>(messageTask.Result);
            }
        }

        public void CallApiToGetSkillAndKnowledgeOfCourse (string type)
        {
            var url = "https://localhost:44321/api/course";
            var responseTask = client.GetAsync(url + "/" + CourseID + "/" + type);
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
                    default:
                        break;
                }
            }
        }

        public void CallApiToGetListForSearch(string type)
        {
            var url = "https://localhost:44321/api/";
            var response = client.GetAsync(url + type);
            response.Wait();
            HttpResponseMessage result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var messageTask = result.Content.ReadAsStringAsync();
                messageTask.Wait();
                switch (type)
                {
                    case "skill":
                        SkillList = JsonConvert.DeserializeObject<List<SkillDto>>(messageTask.Result);
                        break;
                    case "knowledge":
                        KnowledgeList = JsonConvert.DeserializeObject<List<KnowledgeDto>>(messageTask.Result);
                        break;
                    default:
                        break;
                }
            }
        }

        public void OnGet()
        {
            CourseID = Int32.Parse((string)RouteData.Values["CourseID"]);
            this.CallAPIGetCourse();
            this.CallApiToGetSkillAndKnowledgeOfCourse("skill");
            this.CallApiToGetSkillAndKnowledgeOfCourse("knowledge");
            this.CallApiToGetListForSearch("skill");
            this.CallApiToGetListForSearch("knowledge");
        }
    }
}
