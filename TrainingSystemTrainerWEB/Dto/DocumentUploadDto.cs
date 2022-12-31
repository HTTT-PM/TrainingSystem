using Microsoft.AspNetCore.Http;

namespace TraniningSystemAPI.Dto
{
    public class DocumentUploadDto
    {
        public string DocumentName { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public int ContentID { get; set; }
    }
}
