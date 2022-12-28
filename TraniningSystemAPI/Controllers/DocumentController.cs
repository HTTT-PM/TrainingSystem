using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;

namespace TraniningSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : Controller
    {
        private readonly ModelContext _context;

        public DocumentController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get(string path)
        {
            return File(System.IO.File.OpenRead(path), "application/pdf");
        }

        [HttpPost]
        public string Upload([FromForm] DocumentUploadDto file)
        {
            var folderName = Path.Combine("Documents");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = ContentDispositionHeaderValue.Parse(file.File.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.File.CopyTo(stream);
            }

            Document document = new Document { DocumentName = file.DocumentName, Description = file.Description, Link= folderName+'/'+ fileName, ContentID=file.ContentID};
            _context.Document.Add(document);
            _context.SaveChanges();
            return "oke";
        }

        [HttpDelete("{DocumentID:int}")]
        public string Delete([FromRoute] int DocumentID)
        {
            Document document = _context.Document.Find(DocumentID);

            if (document != null)
            {
                _context.Document.Remove(document);
                _context.SaveChanges();
            }
            return "OK";
        }
    }
}
