using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System;
using TraniningSystemAPI.Entity;

namespace TrainingSystemManagerWEB.Pages.Manager
{
    public class KnowledgeResultFilterByDepartmentModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int DepartmentID { get; set; }
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
            var url = "https://localhost:44321/api/knowledge/Department/";
            var response = client.GetAsync(url + DepartmentID);
            response.Wait();
            HttpResponseMessage result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var messageTask = result.Content.ReadAsStringAsync();
                messageTask.Wait();
                ListKnowledge = JsonConvert.DeserializeObject<List<Knowledge>>(messageTask.Result);
            }
        }



        public void OnGet()
        {
            DepartmentID = Int32.Parse((string)RouteData.Values["DepartmentID"]);
            ApitoGetListKnowledge();
            ApitoGetListData("training");
            ApitoGetListData("department");
        }
    }
}

