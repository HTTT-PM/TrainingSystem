using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TraniningSystemAPI.Entity;
//using XTLAB;

namespace TraningSystemWEB.Pages
{
    public class CreateClassModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public List<Course> CourseItems;
        public void OnGet()
        {
        }

    }
}
