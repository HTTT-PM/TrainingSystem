using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System;
using TraniningSystemAPI.Entity;

namespace TrainingSystemManagerWEB.Pages.Manager
{
    public class CourseRelatedToKnowledgeModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int KnowledgeID { get; set; }
        public List<Course> ListCourse { get; set; }
        public List<Knowledge> ListKnowledge{ get; set; }

        public void ApitoGetListSkill()
        {
            var url = "https://localhost:44321/api/knowledge";
            var response = client.GetAsync(url);
            response.Wait();
            HttpResponseMessage result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var messageTask = result.Content.ReadAsStringAsync();
                messageTask.Wait();
                ListKnowledge = JsonConvert.DeserializeObject<List<Knowledge>>(messageTask.Result);
            }
        }



        public void ApitoGetListCourse()
        {
            var url = "https://localhost:44321/api/course/knowledge/";
            var response = client.GetAsync(url + KnowledgeID);
            response.Wait();
            HttpResponseMessage result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var messageTask = result.Content.ReadAsStringAsync();
                messageTask.Wait();
                ListCourse = JsonConvert.DeserializeObject<List<Course>>(messageTask.Result);
            }
        }



        public void OnGet()
        {
            KnowledgeID = Int32.Parse((string)RouteData.Values["KnowledgeID"]);
            ApitoGetListSkill();
            ApitoGetListCourse();
        }
    }
}
