using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;

namespace TrainingSystemManagerWEB.Pages.Manager
{
    public class TraningProgramDetailModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int TrainingProgramID { get; set; }
        public List<CourseDto> Course { get; set; }
        public List<KnowledgeDto> Knowledge { get; set; }
        public List<SkillDto> Skill { get; set; }
        public List<Skill> ListSkill { get; set; }
        public List<Knowledge> ListKnowledge { get; set; }
        public List<Course> ListCourse { get; set; }
        public void CallApiToGetData(string type)
        {
            var url = "https://localhost:44321/api/training";
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

        public void CallApiToGetList(string type)
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
                        ListSkill = JsonConvert.DeserializeObject<List<Skill>>(messageTask.Result);
                        break;
                    case "knowledge":
                        ListKnowledge = JsonConvert.DeserializeObject<List<Knowledge>>(messageTask.Result);
                        break;
                    case "course":
                        ListCourse = JsonConvert.DeserializeObject<List<Course>>(messageTask.Result);
                        break;
                    default:
                        break;
                }
            }
        }


        public void OnGet()
        {
            TrainingProgramID = Int32.Parse((string)RouteData.Values["TrainingProgramID"]);
            this.CallApiToGetData("skill");
            this.CallApiToGetData("knowledge");
            this.CallApiToGetData("course");

            this.CallApiToGetList("skill");
            this.CallApiToGetList("knowledge");
            this.CallApiToGetList("course");
        }
    }
}
