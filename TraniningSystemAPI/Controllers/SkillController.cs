using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
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
