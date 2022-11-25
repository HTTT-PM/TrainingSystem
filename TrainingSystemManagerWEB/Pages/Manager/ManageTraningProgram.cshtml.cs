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
        public List<TrainingProgramDto> TrainingPrograms;
        public void OnGet()
        {
            var url = "https://localhost:44321/api/training";

            var responseTask = client.GetAsync(url);
            responseTask.Wait();

            HttpResponseMessage result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var messageTask = result.Content.ReadAsStringAsync();
                messageTask.Wait();

                TrainingPrograms = JsonConvert.DeserializeObject<List<TrainingProgramDto>>(messageTask.Result);
            }
        }
    }
}
