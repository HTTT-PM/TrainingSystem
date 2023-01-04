
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TraniningSystemAPI.Entity;

namespace TrainingSystemManagerWEB.Pages.Manager
{
    public class ManageKnowledgeModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public List<Knowledge> ListKnowledge { get; set; }
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
                    case "training":
                        ListTrainingProgram = JsonConvert.DeserializeObject<List<TrainingProgram>>(messageTask.Result);
                        break;
                    case "department":
                        ListDepartment = JsonConvert.DeserializeObject<List<Department>>(messageTask.Result);
                        break;
                    default:
                        break;
                }
            }
        }



        public void ApitoGetListKnowledge()
        {
            var url = "https://localhost:44321/api/knowledge";
            var response = client.GetAsync(url);
            response.Wait();
            HttpResponseMessage result = response.Result;
            var messageTask = result.Content.ReadAsStringAsync();
            messageTask.Wait();
            ListKnowledge = JsonConvert.DeserializeObject<List<Knowledge>>(messageTask.Result);
        }


        public void OnGet()
        {
            ApitoGetListData("training");
            ApitoGetListData("department");
            ApitoGetListKnowledge();
        }
    }
}
