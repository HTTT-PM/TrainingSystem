using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TraniningSystemAPI.Dto;

namespace TrainingSystemTrainerWEB.Pages.Trainer
{
    public class SubmitListModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int ExerciseID { get; set; }
        public List<SubmitDto> SubmitList { get; set; }
        public void OnGet()
        {
            ExerciseID = Int32.Parse((string)RouteData.Values["ExerciseID"]);

            var url = "https://localhost:44321/api/exercise";
            var responseTask = client.GetAsync(url + "/" + ExerciseID + "/submit");
            responseTask.Wait();
            HttpResponseMessage resultl = responseTask.Result;
            if (resultl.IsSuccessStatusCode)
            {
                var messageTask = resultl.Content.ReadAsStringAsync();
                messageTask.Wait();
                SubmitList = JsonConvert.DeserializeObject<List<SubmitDto>>(messageTask.Result);
            }
        }
    }
}
