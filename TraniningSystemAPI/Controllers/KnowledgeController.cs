using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Entity;
using TraniningSystemAPI.Dto;

namespace TraniningSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeController : Controller
    {
        private readonly ModelContext _context;

        public KnowledgeController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public IEnumerable<Knowledge> Get()
        {
            return _context.Knowledge.ToList();
        }

        [HttpPost]
        public int Add(string KnowledgeName)
        {
            Knowledge knowledge = new Knowledge { KnowledgeName = KnowledgeName };
            _context.Knowledge.Add(knowledge);
            _context.SaveChanges();
            return knowledge.KnowledgeID;
        }

        [HttpGet("Department/{DepartmentID:int}")]
        public IEnumerable<KnowledgeDto> GetKnowledgeFilterByDepartment([FromRoute] int DepartmentID)
        {

            var result = from K in _context.Knowledge
                         join KTP in _context.KnowledgeTrainingProgram on K.KnowledgeID equals KTP.KnowledgeKey
                         join TP in _context.TrainingProgram on KTP.TrainingProgramKey equals TP.TrainingID
                         join D in _context.Department on TP.DepartmentID equals D.DepartmentID
                         where D.DepartmentID == DepartmentID
                         select new KnowledgeDto()
                         {
                             KnowledgeID = K.KnowledgeID,
                             KnowledgeName = K.KnowledgeName

                         };
            return result.Distinct().ToList();
        }


        [HttpGet("jobposition/{JobPositionID:int}")]
        public IEnumerable<KnowledgeDto> GetKnowledgeFilterByJobPosition([FromRoute] int JobPositionID)
        {
            var result = from K in _context.Knowledge
                         join KTP in _context.KnowledgeTrainingProgram on K.KnowledgeID equals KTP.KnowledgeKey
                         join TP in _context.TrainingProgram on KTP.TrainingProgramKey equals TP.TrainingID
                         join J in _context.JobPosition on TP.JobPositionID equals J.JobPositionID
                         where J.JobPositionID == JobPositionID
                         select new KnowledgeDto()
                         {
                             KnowledgeID = K.KnowledgeID,
                             KnowledgeName = K.KnowledgeName,

                         };
            return result.Distinct().ToList();
        }


        [HttpGet("trainingprogram/{TrainingID:int}")]
        public IEnumerable<KnowledgeDto> GetKnowledgeFilterByTP([FromRoute] int TrainingID)
        {

            var result = from K in _context.Knowledge
                         join KTP in _context.KnowledgeTrainingProgram on K.KnowledgeID equals KTP.KnowledgeKey
                         join TP in _context.TrainingProgram on KTP.TrainingProgramKey equals TP.TrainingID
                         where TP.TrainingID == TrainingID
                         select new KnowledgeDto()
                         {
                             KnowledgeID = K.KnowledgeID,
                             KnowledgeName = K.KnowledgeName

                         };
            return result.Distinct().ToList();
        }


        [HttpGet("{DepartmentID:int}/trainingprogram")]
        public IEnumerable<TrainingProgramDto> GetTPfilterByDepartment([FromRoute] int DepartmentID)
        {

            var result = from t in _context.TrainingProgram.AsQueryable()
                         where t.DepartmentID == DepartmentID
                         select new TrainingProgramDto()
                         {
                             TrainingID = t.TrainingID,
                             TrainingName = t.TrainingName,
                             JobPositionName = t.JobPosition.JobPositionName,
                             DepartmentName = t.Department.DepartmentName,

                         };
            return result.ToList();
        }

        [HttpPut("{KnowledgeID:int}")]
        public string Update([FromRoute] int KnowledgeID, string KnowledgeName)
        {
            Knowledge checkKnowledge = _context.Knowledge.Find(KnowledgeID);
            if (checkKnowledge != null)
            {
                checkKnowledge.KnowledgeName = KnowledgeName;
                _context.SaveChanges();
                return "OK";
            }
            return "NOTOK";
        }

        [HttpDelete("{KnowledgeID:int}")]
        public string Delete([FromRoute] int KnowledgeID)
        {
            Knowledge knowledge = _context.Knowledge.Find(KnowledgeID);
            if (knowledge != null)
            {
                _context.Knowledge.Remove(knowledge);
                _context.SaveChanges();
            }
            return "oke";
        }
    }
}
