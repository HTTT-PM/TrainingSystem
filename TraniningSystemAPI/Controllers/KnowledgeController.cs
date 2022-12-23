using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Entity;

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
