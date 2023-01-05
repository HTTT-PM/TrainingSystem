using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Entity;


namespace TraniningSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly ModelContext _context;

        public RegisterController(ModelContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] RegisterViewModel model)
        {

            var account = new Account()
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                Fullname = model.FullName,
                Role = "trainee"
            };
            _context.Account.Add(account);
            _context.SaveChanges();
            _context.Trainee.Add(new Trainee()
            {
                AccountId = account.Id,
                TraineeName = model.FullName
            });
            _context.SaveChanges();
            return Ok(model);
        }
    }

    public class RegisterViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
