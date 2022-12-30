using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System;
using TraniningSystemAPI.Entity;
using TraniningSystemAPI.Dto;

namespace TraningSystemAdminWEB.Pages.Admin
{
    public class FilterbyDepartmentModel : PageModel
    {

        static readonly HttpClient client = new HttpClient();
        public int DepartmentID { get; set; }
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
            var url = "https://localhost:44321/api/department/";
            var response = client.GetAsync(url + DepartmentID + "/trainingprogram");
            response.Wait();
            HttpResponseMessage result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var messageTask = result.Content.ReadAsStringAsync();
                messageTask.Wait();
                ListTrainingProgram = JsonConvert.DeserializeObject<List<TrainingProgramDto>>(messageTask.Result);
            }
        }

        public void OnGet()
        {

            DepartmentID = Int32.Parse((string)RouteData.Values["DepartmentID"]);
            ApitoGetListData("job-position");
            ApitoGetListData("department");
            ApitoGetListTP();
        }
    }
}
