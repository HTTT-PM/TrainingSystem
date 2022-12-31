using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using TraniningSystemAPI.Entity;
using System.Linq;
using TraniningSystemAPI.Dto;

namespace TraningSystemAdminWEB.Pages.Admin
{
    public class TraineeModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public List<JobPosition> ListJobPosition { get; set; }
        public List<Department> ListDepartment { get; set; }
        public List<TraineeDto> ListTrainee = new List<TraineeDto>();
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
                    case "trainee":
                        ListTrainee = JsonConvert.DeserializeObject<List<TraineeDto>>(messageTask.Result);
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
            ApitoGetListData("trainee");
        }
    }
}
