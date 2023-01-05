﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TraniningSystemAPI.Data;

namespace TraniningSystemAPI.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20230102145037_create_table_notify_1")]
    partial class create_table_notify_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("CourseDocument", b =>
                {
                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("DocumentsDocumentID")
                        .HasColumnType("int");

                    b.HasKey("CourseID", "DocumentsDocumentID");

                    b.HasIndex("DocumentsDocumentID");

                    b.ToTable("CourseDocument");
                });

            modelBuilder.Entity("CourseExercise", b =>
                {
                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("ExercisesExerciseID")
                        .HasColumnType("int");

                    b.HasKey("CourseID", "ExercisesExerciseID");

                    b.HasIndex("ExercisesExerciseID");

                    b.ToTable("CourseExercise");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Classroom", b =>
                {
                    b.Property<int>("ClassroomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClassroomName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desciption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Goal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TrainerID")
                        .HasColumnType("int");

                    b.HasKey("ClassroomID");

                    b.HasIndex("TrainerID");

                    b.ToTable("Classroom");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.ClassroomDetail", b =>
                {
                    b.Property<int>("ClassroomKey")
                        .HasColumnType("int");

                    b.Property<int>("CourseKey")
                        .HasColumnType("int");

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("StudyForm")
                        .HasColumnType("bit");

                    b.HasKey("ClassroomKey", "CourseKey");

                    b.HasIndex("CourseKey");

                    b.ToTable("ClassroomDetail");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.ClassroomParticipant", b =>
                {
                    b.Property<int>("ClassroomKey")
                        .HasColumnType("int");

                    b.Property<int>("TraineeKey")
                        .HasColumnType("int");

                    b.HasKey("ClassroomKey", "TraineeKey");

                    b.HasIndex("TraineeKey");

                    b.ToTable("ClassroomParticipant");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AssessmentForm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CalculatesPointGuide")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfLesson")
                        .HasColumnType("int");

                    b.Property<string>("Target")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.CourseParticipant", b =>
                {
                    b.Property<int>("CourseKey")
                        .HasColumnType("int");

                    b.Property<int>("TraineeKey")
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<string>("ResultOfEvaluation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseKey", "TraineeKey");

                    b.HasIndex("AccountId");

                    b.HasIndex("TraineeKey");

                    b.ToTable("CourseParticipant");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.CourseTrainingProgram", b =>
                {
                    b.Property<int>("CourseKey")
                        .HasColumnType("int");

                    b.Property<int>("TrainingProgramKey")
                        .HasColumnType("int");

                    b.HasKey("CourseKey", "TrainingProgramKey");

                    b.HasIndex("TrainingProgramKey");

                    b.ToTable("CourseTrainingProgram");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desciption")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Document", b =>
                {
                    b.Property<int>("DocumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocumentID");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Exercise", b =>
                {
                    b.Property<int>("ExerciseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExerciseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExerciseID");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.JobPosition", b =>
                {
                    b.Property<int>("JobPositionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Desciption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobPositionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobPositionID");

                    b.ToTable("JobPosition");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Knowledge", b =>
                {
                    b.Property<int>("KnowledgeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("KnowledgeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KnowledgeID");

                    b.ToTable("Knowledge");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.KnowledgeCourse", b =>
                {
                    b.Property<int>("KnowledgeKey")
                        .HasColumnType("int");

                    b.Property<int>("CourseKey")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("KnowledgeKey", "CourseKey");

                    b.HasIndex("CourseKey");

                    b.ToTable("KnowledgeCourse");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.KnowledgeTrainingProgram", b =>
                {
                    b.Property<int>("KnowledgeKey")
                        .HasColumnType("int");

                    b.Property<int>("TrainingProgramKey")
                        .HasColumnType("int");

                    b.HasKey("KnowledgeKey", "TrainingProgramKey");

                    b.HasIndex("TrainingProgramKey");

                    b.ToTable("KnowledgeTrainingProgram");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Notify", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ConfirmId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReciveId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ConfirmId");

                    b.HasIndex("ReciveId");

                    b.ToTable("Notify");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Skill", b =>
                {
                    b.Property<int>("SkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("SkillName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillID");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.SkillCourse", b =>
                {
                    b.Property<int>("SkillKey")
                        .HasColumnType("int");

                    b.Property<int>("CourseKey")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("SkillKey", "CourseKey");

                    b.HasIndex("CourseKey");

                    b.ToTable("SkillCourse");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.SkillTrainingProgram", b =>
                {
                    b.Property<int>("SkillKey")
                        .HasColumnType("int");

                    b.Property<int>("TrainingProgramKey")
                        .HasColumnType("int");

                    b.HasKey("SkillKey", "TrainingProgramKey");

                    b.HasIndex("TrainingProgramKey");

                    b.ToTable("SkillTrainingProgram");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Trainee", b =>
                {
                    b.Property<int>("TraineerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("JobPositionId")
                        .HasColumnType("int");

                    b.Property<int?>("TraineeAge")
                        .HasColumnType("int");

                    b.Property<string>("TraineeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TraineerID");

                    b.HasIndex("AccountId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("JobPositionId");

                    b.ToTable("Trainee");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.TraineeCourseKnowledge", b =>
                {
                    b.Property<int>("KnowledgeKey")
                        .HasColumnType("int");

                    b.Property<int>("CourseKey")
                        .HasColumnType("int");

                    b.Property<int>("TraineeKey")
                        .HasColumnType("int");

                    b.Property<string>("Evaluate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.HasKey("KnowledgeKey", "CourseKey", "TraineeKey");

                    b.HasIndex("CourseKey");

                    b.HasIndex("TraineeKey");

                    b.ToTable("TraineeCourseKnowledge");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.TraineeCourseSkill", b =>
                {
                    b.Property<int>("SkillKey")
                        .HasColumnType("int");

                    b.Property<int>("CourseKey")
                        .HasColumnType("int");

                    b.Property<int>("TraineeKey")
                        .HasColumnType("int");

                    b.Property<string>("Evaluate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.HasKey("SkillKey", "CourseKey", "TraineeKey");

                    b.HasIndex("CourseKey");

                    b.HasIndex("TraineeKey");

                    b.ToTable("TraineeCourseSkill");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Trainer", b =>
                {
                    b.Property<int>("TrainerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("TrainerAge")
                        .HasColumnType("int");

                    b.Property<string>("TrainerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainerID");

                    b.ToTable("Trainer");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.TrainingProgram", b =>
                {
                    b.Property<int>("TrainingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<int?>("JobPositionID")
                        .HasColumnType("int");

                    b.Property<string>("TrainingName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainingID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("JobPositionID");

                    b.ToTable("TrainingProgram");
                });

            modelBuilder.Entity("CourseDocument", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraniningSystemAPI.Entity.Document", null)
                        .WithMany()
                        .HasForeignKey("DocumentsDocumentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseExercise", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraniningSystemAPI.Entity.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesExerciseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Classroom", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Trainer", null)
                        .WithMany("Classroom")
                        .HasForeignKey("TrainerID");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.ClassroomDetail", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Classroom", "Classroom")
                        .WithMany("ClassroomDetails")
                        .HasForeignKey("ClassroomKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraniningSystemAPI.Entity.Course", "Course")
                        .WithMany("ClassroomDetails")
                        .HasForeignKey("CourseKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.ClassroomParticipant", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Classroom", "Classroom")
                        .WithMany("ClassroomParticipants")
                        .HasForeignKey("ClassroomKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraniningSystemAPI.Entity.Trainee", "Trainee")
                        .WithMany("ClassroomParticipants")
                        .HasForeignKey("TraineeKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.CourseParticipant", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Account", "Account")
                        .WithMany("CourseParticipants")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraniningSystemAPI.Entity.Course", "Course")
                        .WithMany("CourseParticipant")
                        .HasForeignKey("CourseKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraniningSystemAPI.Entity.Trainee", "Trainee")
                        .WithMany("CourseParticipant")
                        .HasForeignKey("TraineeKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.CourseTrainingProgram", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Course", "Course")
                        .WithMany("CourseTrainingProgram")
                        .HasForeignKey("CourseKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraniningSystemAPI.Entity.TrainingProgram", "TrainingProgram")
                        .WithMany("CourseTrainingProgram")
                        .HasForeignKey("TrainingProgramKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("TrainingProgram");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.KnowledgeCourse", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Course", "Course")
                        .WithMany("KnowledgeCourse")
                        .HasForeignKey("CourseKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraniningSystemAPI.Entity.Knowledge", "Knowledge")
                        .WithMany("KnowledgeCourse")
                        .HasForeignKey("KnowledgeKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Knowledge");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.KnowledgeTrainingProgram", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Knowledge", "Knowledge")
                        .WithMany("KnowledgeTrainingProgram")
                        .HasForeignKey("KnowledgeKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraniningSystemAPI.Entity.TrainingProgram", "TrainingProgram")
                        .WithMany("KnowledgeTrainingProgram")
                        .HasForeignKey("TrainingProgramKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Knowledge");

                    b.Navigation("TrainingProgram");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Notify", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Account", "Confirm")
                        .WithMany()
                        .HasForeignKey("ConfirmId");

                    b.HasOne("TraniningSystemAPI.Entity.Account", "Recive")
                        .WithMany()
                        .HasForeignKey("ReciveId");

                    b.Navigation("Confirm");

                    b.Navigation("Recive");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.SkillCourse", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Course", "Course")
                        .WithMany("SkillCourse")
                        .HasForeignKey("CourseKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraniningSystemAPI.Entity.Skill", "Skill")
                        .WithMany("SkillCourse")
                        .HasForeignKey("SkillKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.SkillTrainingProgram", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Skill", "Skill")
                        .WithMany("SkillTrainingProgram")
                        .HasForeignKey("SkillKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraniningSystemAPI.Entity.TrainingProgram", "TrainingProgram")
                        .WithMany("SkillTrainingProgram")
                        .HasForeignKey("TrainingProgramKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("TrainingProgram");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Trainee", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("TraniningSystemAPI.Entity.Department", "Department")
                        .WithMany("Trainees")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("TraniningSystemAPI.Entity.JobPosition", "JobPosition")
                        .WithMany("Trainees")
                        .HasForeignKey("JobPositionId");

                    b.Navigation("Account");

                    b.Navigation("Department");

                    b.Navigation("JobPosition");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.TraineeCourseKnowledge", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Course", "Course")
                        .WithMany("TraineeCourseKnowledge")
                        .HasForeignKey("CourseKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraniningSystemAPI.Entity.Knowledge", "Knowledge")
                        .WithMany("TraineeCourseKnowledge")
                        .HasForeignKey("KnowledgeKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraniningSystemAPI.Entity.Trainee", "Trainee")
                        .WithMany("TraineeCourseKnowledge")
                        .HasForeignKey("TraineeKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Knowledge");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.TraineeCourseSkill", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Course", "Course")
                        .WithMany("TraineeCourseSkill")
                        .HasForeignKey("CourseKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraniningSystemAPI.Entity.Skill", "Skill")
                        .WithMany("TraineeCourseSkill")
                        .HasForeignKey("SkillKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TraniningSystemAPI.Entity.Trainee", "Trainee")
                        .WithMany("TraineeCourseSkill")
                        .HasForeignKey("TraineeKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Skill");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.TrainingProgram", b =>
                {
                    b.HasOne("TraniningSystemAPI.Entity.Department", "Department")
                        .WithMany("TrainingPrograms")
                        .HasForeignKey("DepartmentID");

                    b.HasOne("TraniningSystemAPI.Entity.JobPosition", "JobPosition")
                        .WithMany("TrainingPrograms")
                        .HasForeignKey("JobPositionID");

                    b.Navigation("Department");

                    b.Navigation("JobPosition");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Account", b =>
                {
                    b.Navigation("CourseParticipants");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Classroom", b =>
                {
                    b.Navigation("ClassroomDetails");

                    b.Navigation("ClassroomParticipants");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Course", b =>
                {
                    b.Navigation("ClassroomDetails");

                    b.Navigation("CourseParticipant");

                    b.Navigation("CourseTrainingProgram");

                    b.Navigation("KnowledgeCourse");

                    b.Navigation("SkillCourse");

                    b.Navigation("TraineeCourseKnowledge");

                    b.Navigation("TraineeCourseSkill");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Department", b =>
                {
                    b.Navigation("Trainees");

                    b.Navigation("TrainingPrograms");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.JobPosition", b =>
                {
                    b.Navigation("Trainees");

                    b.Navigation("TrainingPrograms");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Knowledge", b =>
                {
                    b.Navigation("KnowledgeCourse");

                    b.Navigation("KnowledgeTrainingProgram");

                    b.Navigation("TraineeCourseKnowledge");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Skill", b =>
                {
                    b.Navigation("SkillCourse");

                    b.Navigation("SkillTrainingProgram");

                    b.Navigation("TraineeCourseSkill");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Trainee", b =>
                {
                    b.Navigation("ClassroomParticipants");

                    b.Navigation("CourseParticipant");

                    b.Navigation("TraineeCourseKnowledge");

                    b.Navigation("TraineeCourseSkill");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.Trainer", b =>
                {
                    b.Navigation("Classroom");
                });

            modelBuilder.Entity("TraniningSystemAPI.Entity.TrainingProgram", b =>
                {
                    b.Navigation("CourseTrainingProgram");

                    b.Navigation("KnowledgeTrainingProgram");

                    b.Navigation("SkillTrainingProgram");
                });
#pragma warning restore 612, 618
        }
    }
}
