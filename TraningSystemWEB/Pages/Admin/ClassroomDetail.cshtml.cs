using System.Net.Http;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TraningSystemAdminWEB.Pages.Admin
{
    public class PageNameModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int ClassroomID;
        public void OnGet()
        {
            var url = "https://localhost:44321/api/classroom/newest";

            var responseTask = client.GetAsync(url);
            responseTask.Wait();

            HttpResponseMessage result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var messageTask = result.Content.ReadAsStringAsync();
                messageTask.Wait();

                ClassroomID = int.Parse(messageTask.Result);
            }
        }
    }
}
