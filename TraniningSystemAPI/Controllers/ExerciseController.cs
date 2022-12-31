using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;
using System.Linq;

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

        [HttpGet("{ExerciseKey:int}/submit")]
        public IEnumerable<SubmitDto> GetSubmit([FromRoute] int ExerciseKey)
        {
            var result = from te in _context.TraineeExercise
                         join e in _context.Exercise on te.ExerciseKey equals e.ExerciseID
                         join t in _context.Trainee on te.TraineeKey equals t.TraineeID
                         where te.ExerciseKey == ExerciseKey
                         select new SubmitDto()
                         {
                             ExerciseID = e.ExerciseID,
                             ExerciseName = e.ExerciseName,
                             TraineeID = t.TraineeID,
                             TraineeName = t.TraineeName,
                             Link = te.Link,
                             Point = te.Point
                         };
            return result;
        }

        [HttpPost("{ExerciseKey:int}/submit/{TraineeKey:int}")]
        public string ChangePointForSubmit ([FromRoute] int ExerciseKey, [FromRoute] int TraineeKey, int Point)
        {
            var CheckSubmit = _context.TraineeExercise.Find(ExerciseKey, TraineeKey);
            if (CheckSubmit != null)
            {
                CheckSubmit.Point = Point;
                _context.SaveChanges();
            }
            return "OKE";
        }

        [HttpPost("{CourseID:int}")]
        public RedirectResult Upload([FromForm] ExerciseUploadDto file, [FromRoute] int CourseID)
        {
            Directory.CreateDirectory("Exercises");
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
            return RedirectPermanent("https://localhost:44331/trainer/course-detail/" + CourseID);
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
