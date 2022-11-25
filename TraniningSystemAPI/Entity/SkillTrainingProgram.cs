﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraniningSystemAPI.Entity
{
    public class SkillTrainingProgram
    {
        public int TrainingProgramKey { get; set; }
        public TrainingProgram TrainingProgram { get; set; }
        public int SkillKey { get; set; }
        public Skill Skill { get; set; }
    }
}
