
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
        public void OnGet()
        {
            var url = "https://localhost:44321/api/knowledge";
            var response = client.GetAsync(url);
            response.Wait();
            HttpResponseMessage result = response.Result;
            var messageTask = result.Content.ReadAsStringAsync();
            messageTask.Wait();
            ListKnowledge = JsonConvert.DeserializeObject<List<Knowledge>>(messageTask.Result);
        }
    }
}
