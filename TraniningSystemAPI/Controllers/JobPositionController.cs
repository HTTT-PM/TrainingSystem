using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;

namespace TraniningSystemAPI.Controllers
{
    [Route("api/job-position")]
    [ApiController]
    public class JobPositionController : ControllerBase
    {
        private readonly ModelContext _context;

        public JobPositionController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/JobPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobPosition>>> GetJobPosition()
        {
            return await _context.JobPosition.ToListAsync();
        }

        // GET: api/JobPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobPosition>> GetJobPosition(int id)
        {
            var jobPosition = await _context.JobPosition.FindAsync(id);

            if (jobPosition == null)
            {
                return NotFound();
            }

            return jobPosition;
        }


        [HttpGet("{JobPositionID:int}/trainingprogram")]
        public IEnumerable<TrainingProgramDto> GetTPfilterByJob([FromRoute] int JobPositionID)
        {

            var result = from t in _context.TrainingProgram.AsQueryable()
                         where t.JobPositionID == JobPositionID
                         select new TrainingProgramDto()
                         {
                             TrainingID = t.TrainingID,
                             TrainingName = t.TrainingName,
                             JobPositionName = t.JobPosition.JobPositionName,
                             DepartmentName = t.Department.DepartmentName,

                         };
            return result.ToList();
        }

        [HttpGet("{JobPositionID:int}/trainee")]
        public IEnumerable<TraineeDto> GetTraineefilterByJob([FromRoute] int JobPositionID)
        {
            var result = from t in _context.Trainee.AsQueryable()
                         where t.JobPositionId == JobPositionID
                         select new TraineeDto()
                         {
                             TraineeID = t.TraineeID,
                             TraineeName = t.TraineeName,
                             JobPositionName = t.JobPosition.JobPositionName,
                             DepartmentName = t.Department.DepartmentName,
                             GetAccessToHCMData = t.GetAccessToHCMData
                         };
            return result.ToList();
        }


        // PUT: api/JobPositions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobPosition(int id, JobPosition jobPosition)
        {
            if (id != jobPosition.JobPositionID)
            {
                return BadRequest();
            }

            _context.Entry(jobPosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobPositionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<JobPosition>> AddJobPosition(JobPosition jobPosition)
        {
            _context.JobPosition.Add(jobPosition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobPosition", new { id = jobPosition.JobPositionID }, jobPosition);
        }

        // DELETE: api/JobPositions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobPosition>> DeleteJobPosition(int id)
        {
            var jobPosition = await _context.JobPosition.FindAsync(id);
            if (jobPosition == null)
            {
                return NotFound();
            }

            _context.JobPosition.Remove(jobPosition);
            await _context.SaveChangesAsync();

            return jobPosition;
        }

        private bool JobPositionExists(int id)
        {
            return _context.JobPosition.Any(e => e.JobPositionID == id);
        }
    }
}
