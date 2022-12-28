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
    public class ExerciseController : Controller
    {
        private readonly ModelContext _context;

        public ExerciseController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get(string path)
        {
            return File(System.IO.File.OpenRead(path), "application/pdf");
        }

        [HttpPost]
        public string Upload([FromForm] ExerciseUploadDto file)
        {
            var folderName = Path.Combine("Exercises");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = ContentDispositionHeaderValue.Parse(file.File.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.File.CopyTo(stream);
            }

            if (file.SkillID == 0) file.SkillID = null;
            if (file.KnowledgeID == 0) file.KnowledgeID = null;

            Exercise exercise = new Exercise
            {
                ExerciseName = file.ExerciseName,
                Description = file.Description,
                Link = folderName + '/' + fileName,
                ContentID = file.ContentID,
                Weight = file.Weight,
                SkillID = file.SkillID,
                KnowledgeID = file.KnowledgeID
            };

            _context.Exercise.Add(exercise);
            _context.SaveChanges();
            return "oke";
        }

        [HttpDelete("{ExerciseID:int}")]
        public string Delete([FromRoute] int ExerciseID)
        {
            Exercise exercise = _context.Exercise.Find(ExerciseID);

            if (exercise != null)
            {
                _context.Exercise.Remove(exercise);
                _context.SaveChanges();
            }
            return "OK";
        }
    }
}
