using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using TraniningSystemAPI.Entity;
using System.Linq;

namespace TraningSystemAdminWEB.Pages.Admin
{
    public class ManageTrainingProgramModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
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
                    case "training":
                        ListTrainingProgram = JsonConvert.DeserializeObject<List<TrainingProgram>>(messageTask.Result);
                        break;
                    default:
                        break;
                }
            }
        }


        public void OnGet()
        {
            ApitoGetListData("job-positions");
            ApitoGetListData("departments");
            ApitoGetListData("training");

        }
    }
}
