using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using TraniningSystemAPI.Entity;

namespace TraningSystemAdminWEB.Pages.Admin
{
    public class FIlterByJPModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int JobPositionID { get; set; }
        public List<JobPosition> ListJobPosition { get; set; }
        public List<Department> ListDepartment { get; set; }
        public List<TrainingProgram> ListTrainingProgram { get; set; }

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
                    case "job-positions":
                        ListJobPosition = JsonConvert.DeserializeObject<List<JobPosition>>(messageTask.Result);
                        break;
                    case "departments":
                        ListDepartment = JsonConvert.DeserializeObject<List<Department>>(messageTask.Result);
                        break;
                    default:
                        break;
                }
            }
        }

        public void ApitoGetListTP()
        {
            var url = "https://localhost:44321/api/job-positions/";
            var response = client.GetAsync(url + JobPositionID + "/trainingprogram");
            response.Wait();
            HttpResponseMessage result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var messageTask = result.Content.ReadAsStringAsync();
                messageTask.Wait();
                ListTrainingProgram = JsonConvert.DeserializeObject<List<TrainingProgram>>(messageTask.Result);
                
            }
        }
        public void OnGet()
        {

            JobPositionID = Int32.Parse((string)RouteData.Values["JobPositionID"]);
            ApitoGetListData("job-positions");
            ApitoGetListData("departments");
            ApitoGetListTP();
        }
    }
}
