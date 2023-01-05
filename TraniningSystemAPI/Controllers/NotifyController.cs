using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Entity;


namespace TraniningSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : Controller
    {
        private readonly ModelContext _context;

        public NotifyController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(bool status = false)
        {
            var query = _context.Notify.AsQueryable();
            if (status)
            {
                query = query.Where(item => item.Status);
            }
            var data = query.ToList();           
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create([FromBody] NotifyViewModel model)
        {
            _context.Notify.Add(new Notify()
            {
                Message = model.Message,
                ReciveId = model.ReciveId,
                CreateTime = DateTime.Now
            });
            _context.SaveChanges();
            return Ok(model);
        }
        
        [HttpPut("{id}")]
        public IActionResult confirm(int id)
        {
            var model = _context.Notify.Where(item => item.Id == id).First();
            model.Status = true;
            _context.SaveChanges();
            return Ok(model);
        }
    }
    
    public class NotifyViewModel
    {
        public string Message { get; set; }
        public int ReciveId { get; set; }
    }
}