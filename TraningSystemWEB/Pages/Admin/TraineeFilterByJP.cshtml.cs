using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using TraniningSystemAPI.Entity;
using System.Linq;
using TraniningSystemAPI.Dto;
using System;

namespace TraningSystemAdminWEB.Pages.Admin
{
    public class TraineeFilterByJPModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int JobPositionID { get; set; }
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

        public void ApitoGetListTrainee()
        {
            var url = "https://localhost:44321/api/job-position/";
            var response = client.GetAsync(url + JobPositionID + "/trainee");
            response.Wait();
            HttpResponseMessage result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var messageTask = result.Content.ReadAsStringAsync();
                messageTask.Wait();
                ListTrainee = JsonConvert.DeserializeObject<List<TraineeDto>>(messageTask.Result);

            }
        }

        public void OnGet()
        {
            JobPositionID = Int32.Parse((string)RouteData.Values["JobPositionID"]);
            ApitoGetListData("job-position");
            ApitoGetListData("trainee");
            ApitoGetListTrainee();
        }
    }
}
