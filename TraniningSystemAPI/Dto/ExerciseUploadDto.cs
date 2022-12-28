using Microsoft.AspNetCore.Http;

namespace TraniningSystemAPI.Dto
{
    public class ExerciseUploadDto
    {
        public string ExerciseName { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public int Weight { get; set; }
        public int ContentID { get; set; }
        public int? SkillID { get; set; }
        public int? KnowledgeID { get; set; }
    }
}
