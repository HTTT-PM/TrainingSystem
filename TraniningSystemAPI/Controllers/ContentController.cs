using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Entity;

namespace TraniningSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly ModelContext _context;

        public ContentController(ModelContext context)
        {
            _context = context;
        }

        // PUT: api/content/{contentID}
        [HttpPut("{ContentID:int}")]
        public string Update([FromRoute] int ContentID, string ContentName, int TrainingTime, [FromBody] string Description)
        {
            Content checkContent = _context.Content.Where(x=>x.ContentID== ContentID).FirstOrDefault();
            if (checkContent != null)
            {
                checkContent.ContentName = ContentName;
                checkContent.TrainingTime = TrainingTime;
                checkContent.Description = Description;
                _context.SaveChanges();
                return "OK";
            }
            return "NOTOK";
        }

        //DELETE: api/content/{ContentID}
        [HttpDelete("{ContentID:int}")]
        public string DeleteContent([FromRoute] int ContentID)
        {
            Content content = _context.Content.Find(ContentID);

            if (content != null)
            {
                _context.Content.Remove(content);
                _context.SaveChanges();
            }
            return "OK";
        }
    }
}
