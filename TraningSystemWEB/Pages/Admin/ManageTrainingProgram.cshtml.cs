using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using TraniningSystemAPI.Entity;
using System.Linq;
using TraniningSystemAPI.Dto;

namespace TraningSystemAdminWEB.Pages.Admin
{
    public class ManageTrainingProgramModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public List<JobPosition> ListJobPosition { get; set; }
        public List<Department> ListDepartment { get; set; }
        public List<TrainingProgramDto> ListTrainingProgram = new List<TrainingProgramDto>();

        public void ApitoGetListData(string type)
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
                    case "job-position":
                        ListJobPosition = JsonConvert.DeserializeObject<List<JobPosition>>(messageTask.Result);
                        break;
                    case "department":
                        ListDepartment = JsonConvert.DeserializeObject<List<Department>>(messageTask.Result);
                        break;
                    case "training":
                        ListTrainingProgram = JsonConvert.DeserializeObject<List<TrainingProgramDto>>(messageTask.Result);
                        break;
                    default:
                        break;
                }
            }
        }


        public void OnGet()
        {
            ApitoGetListData("job-position");
            ApitoGetListData("department");
            ApitoGetListData("training");

        }
    }
}
