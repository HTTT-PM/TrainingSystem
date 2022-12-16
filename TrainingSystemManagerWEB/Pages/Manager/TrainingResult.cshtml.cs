using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TraniningSystemAPI.Dto;

namespace TrainingSystemManagerWEB.Pages.Manager
{
    public class TrainingResultModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public List<EvaluateDto> TrainingResults = new List<EvaluateDto>();
        public void OnGet()
        {
            var urlTrainingProgram = "https://localhost:44321/api/course-participant";
            var responseTaskTrainingProgram = client.GetAsync(urlTrainingProgram);
            responseTaskTrainingProgram.Wait();
            HttpResponseMessage resultTrainingProgram = responseTaskTrainingProgram.Result;
            if (resultTrainingProgram.IsSuccessStatusCode)
            {
                var messageTask = resultTrainingProgram.Content.ReadAsStringAsync();
                messageTask.Wait();
                TrainingResults = JsonConvert.DeserializeObject<List<EvaluateDto>>(messageTask.Result);
            }
        }
    }
}
