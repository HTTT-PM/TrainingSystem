using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;

namespace TraningSystemAdminWEB.Pages.Admin
{
    public class FIlterByJPModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int JobPositionID { get; set; }
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
                    default:
                        break;
                }
            }
        }

        public void ApitoGetListTP()
        {
            var url = "https://localhost:44321/api/job-position/";
            var response = client.GetAsync(url + JobPositionID + "/trainingprogram");
            response.Wait();
            HttpResponseMessage result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var messageTask = result.Content.ReadAsStringAsync();
                messageTask.Wait();
                ListTrainingProgram = JsonConvert.DeserializeObject<List<TrainingProgramDto>>(messageTask.Result);
                System.Diagnostics.Debug.WriteLine(ListTrainingProgram);

            }
        }
        public void OnGet()
        {

            JobPositionID = Int32.Parse((string)RouteData.Values["JobPositionID"]);
            ApitoGetListData("job-position");
            ApitoGetListData("department");
            ApitoGetListTP();
        }
    }
}
