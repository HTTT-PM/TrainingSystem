using Microsoft.EntityFrameworkCore;
using TraniningSystemAPI.Entity;

namespace TraniningSystemAPI.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options) { }

        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<ClassroomDetail> ClassroomDetail { get; set; }
        public DbSet<TrainingProgram> TrainingProgram { get; set; }
        public DbSet<Knowledge> Knowledge { get; set; }
        public DbSet<Skill> Skill { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Knowledge>().ToTable("Knowledge");
            modelBuilder.Entity<TrainingProgram>().ToTable("TrainingProgram");
            modelBuilder.Entity<Skill>().ToTable("Skill");
            modelBuilder.Entity<Trainer>().ToTable("Trainer");
            modelBuilder.Entity<Classroom>().ToTable("Classroom");
            modelBuilder.Entity<Document>().ToTable("Document");
            modelBuilder.Entity<Exercise>().ToTable("Exercise");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<ClassroomDetail>().HasKey(x => new { x.ClassroomKey, x.CourseKey });
            modelBuilder.Entity<ClassroomDetail>()
                .HasOne(t => t.Classroom)
                .WithMany(t => t.ClassroomDetails)
                .HasForeignKey(t => t.ClassroomKey);

            modelBuilder.Entity<ClassroomDetail>()
                .HasOne(t => t.Course)
                .WithMany(t => t.ClassroomDetails)
                .HasForeignKey(t => t.CourseKey);

        }
    }
}

