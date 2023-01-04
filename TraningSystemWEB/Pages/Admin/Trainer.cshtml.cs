using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using TraniningSystemAPI.Entity;
using System.Linq;
using TraniningSystemAPI.Dto;
using TraningSystemAdminWEB.Dto;

namespace TraningSystemAdminWEB.Pages.Admin
{
    public class TrainerModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public List<TrainerDto> ListTrainer = new List<TrainerDto>();
        public void ApitoGetListData()
        {
            var url = "https://localhost:44321/api/trainer";
            var response = client.GetAsync(url);
            response.Wait();
            HttpResponseMessage result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var messageTask = result.Content.ReadAsStringAsync();
                messageTask.Wait();
                ListTrainer = JsonConvert.DeserializeObject<List<TrainerDto>>(messageTask.Result);
            }
        }

        public void OnGet()
        {
            ApitoGetListData();
        }
    }
}
