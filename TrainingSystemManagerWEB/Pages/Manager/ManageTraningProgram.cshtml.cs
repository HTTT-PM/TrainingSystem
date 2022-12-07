using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using TraniningSystemAPI.Dto;

namespace TrainingSystemManagerWEB.Pages.Manager
{
    public class ManagerTraningProgramModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public List<TrainingProgramDto> TrainingPrograms = new List<TrainingProgramDto>();
        public void OnGet()
        {
            var urlTrainingProgram = "https://localhost:44321/api/training";
            var responseTaskTrainingProgram = client.GetAsync(urlTrainingProgram);
            responseTaskTrainingProgram.Wait();
            HttpResponseMessage resultTrainingProgram = responseTaskTrainingProgram.Result;
            if (resultTrainingProgram.IsSuccessStatusCode)
            {
                var messageTask = resultTrainingProgram.Content.ReadAsStringAsync();
                messageTask.Wait();
                TrainingPrograms = JsonConvert.DeserializeObject<List<TrainingProgramDto>>(messageTask.Result);
                System.Diagnostics.Debug.WriteLine(TrainingPrograms);
            }
        }
    }
}
