using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TraniningSystemAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfLesson = table.Column<int>(type: "int", nullable: false),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssessmentForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalculatesPointGuide = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocumentID);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ExerciseID);
                });

            migrationBuilder.CreateTable(
                name: "JobPosition",
                columns: table => new
                {
                    JobPositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobPositionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosition", x => x.JobPositionID);
                });

            migrationBuilder.CreateTable(
                name: "Knowledge",
                columns: table => new
                {
                    KnowledgeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KnowledgeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knowledge", x => x.KnowledgeID);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillID);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    TrainerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainerAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.TrainerID);
                });

            migrationBuilder.CreateTable(
                name: "CourseDocument",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    DocumentsDocumentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDocument", x => new { x.CourseID, x.DocumentsDocumentID });
                    table.ForeignKey(
                        name: "FK_CourseDocument_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDocument_Document_DocumentsDocumentID",
                        column: x => x.DocumentsDocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseExercise",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    ExercisesExerciseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseExercise", x => new { x.CourseID, x.ExercisesExerciseID });
                    table.ForeignKey(
                        name: "FK_CourseExercise_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseExercise_Exercise_ExercisesExerciseID",
                        column: x => x.ExercisesExerciseID,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    TraineerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraineeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TraineeAge = table.Column<int>(type: "int", nullable: true),
                    JobPositionId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee", x => x.TraineerID);
                    table.ForeignKey(
                        name: "FK_Trainee_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainee_JobPosition_JobPositionId",
                        column: x => x.JobPositionId,
                        principalTable: "JobPosition",
                        principalColumn: "JobPositionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProgram",
                columns: table => new
                {
                    TrainingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobPositionID = table.Column<int>(type: "int", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingProgram", x => x.TrainingID);
                    table.ForeignKey(
                        name: "FK_TrainingProgram_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingProgram_JobPosition_JobPositionID",
                        column: x => x.JobPositionID,
                        principalTable: "JobPosition",
                        principalColumn: "JobPositionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeCourse",
                columns: table => new
                {
                    CourseKey = table.Column<int>(type: "int", nullable: false),
                    KnowledgeKey = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeCourse", x => new { x.KnowledgeKey, x.CourseKey });
                    table.ForeignKey(
                        name: "FK_KnowledgeCourse_Course_CourseKey",
                        column: x => x.CourseKey,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KnowledgeCourse_Knowledge_KnowledgeKey",
                        column: x => x.KnowledgeKey,
                        principalTable: "Knowledge",
                        principalColumn: "KnowledgeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillCourse",
                columns: table => new
                {
                    CourseKey = table.Column<int>(type: "int", nullable: false),
                    SkillKey = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCourse", x => new { x.SkillKey, x.CourseKey });
                    table.ForeignKey(
                        name: "FK_SkillCourse_Course_CourseKey",
                        column: x => x.CourseKey,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillCourse_Skill_SkillKey",
                        column: x => x.SkillKey,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classroom",
                columns: table => new
                {
                    ClassroomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassroomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Goal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classroom", x => x.ClassroomID);
                    table.ForeignKey(
                        name: "FK_Classroom_Trainer_TrainerID",
                        column: x => x.TrainerID,
                        principalTable: "Trainer",
                        principalColumn: "TrainerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseParticipant",
                columns: table => new
                {
                    CourseKey = table.Column<int>(type: "int", nullable: false),
                    TraineeKey = table.Column<int>(type: "int", nullable: false),
                    ResultOfEvaluation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseParticipant", x => new { x.CourseKey, x.TraineeKey });
                    table.ForeignKey(
                        name: "FK_CourseParticipant_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseParticipant_Course_CourseKey",
                        column: x => x.CourseKey,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseParticipant_Trainee_TraineeKey",
                        column: x => x.TraineeKey,
                        principalTable: "Trainee",
                        principalColumn: "TraineerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TraineeCourseKnowledge",
                columns: table => new
                {
                    CourseKey = table.Column<int>(type: "int", nullable: false),
                    TraineeKey = table.Column<int>(type: "int", nullable: false),
                    KnowledgeKey = table.Column<int>(type: "int", nullable: false),
                    Evaluate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeCourseKnowledge", x => new { x.KnowledgeKey, x.CourseKey, x.TraineeKey });
                    table.ForeignKey(
                        name: "FK_TraineeCourseKnowledge_Course_CourseKey",
                        column: x => x.CourseKey,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeCourseKnowledge_Knowledge_KnowledgeKey",
                        column: x => x.KnowledgeKey,
                        principalTable: "Knowledge",
                        principalColumn: "KnowledgeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeCourseKnowledge_Trainee_TraineeKey",
                        column: x => x.TraineeKey,
                        principalTable: "Trainee",
                        principalColumn: "TraineerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TraineeCourseSkill",
                columns: table => new
                {
                    CourseKey = table.Column<int>(type: "int", nullable: false),
                    TraineeKey = table.Column<int>(type: "int", nullable: false),
                    SkillKey = table.Column<int>(type: "int", nullable: false),
                    Evaluate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeCourseSkill", x => new { x.SkillKey, x.CourseKey, x.TraineeKey });
                    table.ForeignKey(
                        name: "FK_TraineeCourseSkill_Course_CourseKey",
                        column: x => x.CourseKey,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeCourseSkill_Skill_SkillKey",
                        column: x => x.SkillKey,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeCourseSkill_Trainee_TraineeKey",
                        column: x => x.TraineeKey,
                        principalTable: "Trainee",
                        principalColumn: "TraineerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTrainingProgram",
                columns: table => new
                {
                    TrainingProgramKey = table.Column<int>(type: "int", nullable: false),
                    CourseKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTrainingProgram", x => new { x.CourseKey, x.TrainingProgramKey });
                    table.ForeignKey(
                        name: "FK_CourseTrainingProgram_Course_CourseKey",
                        column: x => x.CourseKey,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTrainingProgram_TrainingProgram_TrainingProgramKey",
                        column: x => x.TrainingProgramKey,
                        principalTable: "TrainingProgram",
                        principalColumn: "TrainingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeTrainingProgram",
                columns: table => new
                {
                    TrainingProgramKey = table.Column<int>(type: "int", nullable: false),
                    KnowledgeKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeTrainingProgram", x => new { x.KnowledgeKey, x.TrainingProgramKey });
                    table.ForeignKey(
                        name: "FK_KnowledgeTrainingProgram_Knowledge_KnowledgeKey",
                        column: x => x.KnowledgeKey,
                        principalTable: "Knowledge",
                        principalColumn: "KnowledgeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KnowledgeTrainingProgram_TrainingProgram_TrainingProgramKey",
                        column: x => x.TrainingProgramKey,
                        principalTable: "TrainingProgram",
                        principalColumn: "TrainingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillTrainingProgram",
                columns: table => new
                {
                    TrainingProgramKey = table.Column<int>(type: "int", nullable: false),
                    SkillKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTrainingProgram", x => new { x.SkillKey, x.TrainingProgramKey });
                    table.ForeignKey(
                        name: "FK_SkillTrainingProgram_Skill_SkillKey",
                        column: x => x.SkillKey,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillTrainingProgram_TrainingProgram_TrainingProgramKey",
                        column: x => x.TrainingProgramKey,
                        principalTable: "TrainingProgram",
                        principalColumn: "TrainingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassroomDetail",
                columns: table => new
                {
                    ClassroomKey = table.Column<int>(type: "int", nullable: false),
                    CourseKey = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudyForm = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomDetail", x => new { x.ClassroomKey, x.CourseKey });
                    table.ForeignKey(
                        name: "FK_ClassroomDetail_Classroom_ClassroomKey",
                        column: x => x.ClassroomKey,
                        principalTable: "Classroom",
                        principalColumn: "ClassroomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassroomDetail_Course_CourseKey",
                        column: x => x.CourseKey,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassroomParticipant",
                columns: table => new
                {
                    ClassroomKey = table.Column<int>(type: "int", nullable: false),
                    TraineeKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomParticipant", x => new { x.ClassroomKey, x.TraineeKey });
                    table.ForeignKey(
                        name: "FK_ClassroomParticipant_Classroom_ClassroomKey",
                        column: x => x.ClassroomKey,
                        principalTable: "Classroom",
                        principalColumn: "ClassroomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassroomParticipant_Trainee_TraineeKey",
                        column: x => x.TraineeKey,
                        principalTable: "Trainee",
                        principalColumn: "TraineerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_TrainerID",
                table: "Classroom",
                column: "TrainerID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomDetail_CourseKey",
                table: "ClassroomDetail",
                column: "CourseKey");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomParticipant_TraineeKey",
                table: "ClassroomParticipant",
                column: "TraineeKey");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDocument_DocumentsDocumentID",
                table: "CourseDocument",
                column: "DocumentsDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseExercise_ExercisesExerciseID",
                table: "CourseExercise",
                column: "ExercisesExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseParticipant_AccountId",
                table: "CourseParticipant",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseParticipant_TraineeKey",
                table: "CourseParticipant",
                column: "TraineeKey");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTrainingProgram_TrainingProgramKey",
                table: "CourseTrainingProgram",
                column: "TrainingProgramKey");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeCourse_CourseKey",
                table: "KnowledgeCourse",
                column: "CourseKey");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeTrainingProgram_TrainingProgramKey",
                table: "KnowledgeTrainingProgram",
                column: "TrainingProgramKey");

            migrationBuilder.CreateIndex(
                name: "IX_SkillCourse_CourseKey",
                table: "SkillCourse",
                column: "CourseKey");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTrainingProgram_TrainingProgramKey",
                table: "SkillTrainingProgram",
                column: "TrainingProgramKey");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_AccountId",
                table: "Trainee",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_DepartmentId",
                table: "Trainee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_JobPositionId",
                table: "Trainee",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeCourseKnowledge_CourseKey",
                table: "TraineeCourseKnowledge",
                column: "CourseKey");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeCourseKnowledge_TraineeKey",
                table: "TraineeCourseKnowledge",
                column: "TraineeKey");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeCourseSkill_CourseKey",
                table: "TraineeCourseSkill",
                column: "CourseKey");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeCourseSkill_TraineeKey",
                table: "TraineeCourseSkill",
                column: "TraineeKey");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgram_DepartmentID",
                table: "TrainingProgram",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgram_JobPositionID",
                table: "TrainingProgram",
                column: "JobPositionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassroomDetail");

            migrationBuilder.DropTable(
                name: "ClassroomParticipant");

            migrationBuilder.DropTable(
                name: "CourseDocument");

            migrationBuilder.DropTable(
                name: "CourseExercise");

            migrationBuilder.DropTable(
                name: "CourseParticipant");

            migrationBuilder.DropTable(
                name: "CourseTrainingProgram");

            migrationBuilder.DropTable(
                name: "KnowledgeCourse");

            migrationBuilder.DropTable(
                name: "KnowledgeTrainingProgram");

            migrationBuilder.DropTable(
                name: "SkillCourse");

            migrationBuilder.DropTable(
                name: "SkillTrainingProgram");

            migrationBuilder.DropTable(
                name: "TraineeCourseKnowledge");

            migrationBuilder.DropTable(
                name: "TraineeCourseSkill");

            migrationBuilder.DropTable(
                name: "Classroom");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "TrainingProgram");

            migrationBuilder.DropTable(
                name: "Knowledge");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "JobPosition");
        }
    }
}
