using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System;
using TraniningSystemAPI.Entity;
using TraniningSystemAPI.Dto;

namespace TrainingSystemManagerWEB.Pages.Manager
{
    public class CourseRelatedToSkillModel : PageModel
    {

        static readonly HttpClient client = new HttpClient();
        public int SkillID { get; set; }
        public List<Course> ListCourse { get; set; }
        public List<Skill> ListSkill { get; set; }

        public void ApitoGetListSkill()
        {
            var url = "https://localhost:44321/api/skill";
            var response = client.GetAsync(url);
            response.Wait();
            HttpResponseMessage result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var messageTask = result.Content.ReadAsStringAsync();
                messageTask.Wait();
                ListSkill = JsonConvert.DeserializeObject<List<Skill>>(messageTask.Result);
            }
        }



        public void ApitoGetListCourse()
        {
            var url = "https://localhost:44321/api/course/skill/";
            var response = client.GetAsync(url + SkillID);
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
            SkillID = Int32.Parse((string)RouteData.Values["SkillID"]);
            ApitoGetListSkill();
            ApitoGetListCourse();
        }
    }
}
