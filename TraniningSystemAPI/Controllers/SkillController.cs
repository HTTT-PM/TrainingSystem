using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;

namespace TraniningSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : Controller
    {
        private readonly ModelContext _context;

        public SkillController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Skill> Get()
        {
            return _context.Skill.ToList();
        }

        [HttpPost]
        public int Add(string SkillName)
        {
            Skill skill = new Skill { SkillName = SkillName };
            _context.Skill.Add(skill);
            _context.SaveChanges();
            return skill.SkillID;
        }

        [HttpGet("department/{DepartmentID:int}")]
        public IEnumerable<SkillDto> GetSkillfilterByDepartment([FromRoute] int DepartmentID)
        {

            var result = from S in _context.Skill
                         join STP in _context.SkillTrainingProgram on S.SkillID equals STP.SkillKey
                         join TP in _context.TrainingProgram on STP.TrainingProgramKey equals TP.TrainingID
                         join D in _context.Department on TP.DepartmentID equals D.DepartmentID
                         where D.DepartmentID == DepartmentID
                         select new SkillDto()
                         {
                             SkillID = S.SkillID,
                             SkillName = S.SkillName,

                         };
            return result.Distinct().ToList();
        }


        [HttpGet("jobposition/{JobPositionID:int}")]
        public IEnumerable<SkillDto> GetSkillfilterByJobPosition([FromRoute] int JobPositionID)
        {

            var result = from S in _context.Skill
                         join STP in _context.SkillTrainingProgram on S.SkillID equals STP.SkillKey
                         join TP in _context.TrainingProgram on STP.TrainingProgramKey equals TP.TrainingID
                         join J in _context.JobPosition on TP.JobPositionID equals J.JobPositionID
                         where J.JobPositionID == JobPositionID
                         select new SkillDto()
                         {
                             SkillID = S.SkillID,
                             SkillName = S.SkillName,

                         };
            return result.Distinct().ToList();
        }


        [HttpGet("TrainingProgram/{TrainingID:int}")]
        public IEnumerable<SkillDto> GetSkillfilterByTP([FromRoute] int TrainingID)
        {

            var result = from S in _context.Skill
                         join STP in _context.SkillTrainingProgram on S.SkillID equals STP.SkillKey
                         join TP in _context.TrainingProgram on STP.TrainingProgramKey equals TP.TrainingID
                         where TP.TrainingID == TrainingID
                         select new SkillDto()
                         {
                             SkillID = S.SkillID,
                             SkillName = S.SkillName

                         };
            return result.Distinct().ToList();
        }

        [HttpPut("{SkillID:int}")]
        public string Update([FromRoute] int SkillID, string SkillName)
        {
            Skill checkSkill = _context.Skill.Find(SkillID);
            if (checkSkill != null)
            { 

                checkSkill.SkillName = SkillName;
                _context.SaveChanges();
                return "OK";
            }
            return "NOTOK";
        }

        [HttpDelete("{SkillID:int}")]
        public string Delete([FromRoute] int SkillID)
        {
            Skill skill = _context.Skill.Find(SkillID);
            if (skill != null)
            {
                _context.Skill.Remove(skill);
                _context.SaveChanges();
            }
            return "oke";
        }
    }
}
