namespace TraniningSystemAPI.Entity
{
    public class KnowledgeTrainingProgram
    {
        public int TrainingProgramKey { get; set; }
        public TrainingProgram TrainingProgram { get; set; }
        public int KnowledgeKey { get; set; }
        public Knowledge Knowledge { get; set; }
    }
}
