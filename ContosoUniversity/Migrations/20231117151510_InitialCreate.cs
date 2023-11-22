using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContosoUniversity.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Budget = table.Column<decimal>(type: "money", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Department_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OfficeAssignment",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeAssignment", x => x.InstructorID);
                    table.ForeignKey(
                        name: "FK_OfficeAssignment_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Course_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseAssignment",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssignment", x => new { x.CourseID, x.InstructorID });
                    table.ForeignKey(
                        name: "FK_CourseAssignment_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseAssignment_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "ID", "FirstName", "HireDate", "LastName" },
                values: new object[,]
                {
                    { 1, "Kim", new DateTime(1995, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abercrombie" },
                    { 2, "Fadi", new DateTime(2002, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fakhouri" },
                    { 3, "Roger", new DateTime(1998, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harui" },
                    { 4, "Candace", new DateTime(2001, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kapoor" },
                    { 5, "Roger", new DateTime(2004, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zheng" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "ID", "EnrollmentDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2010, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carson", "Alexander" },
                    { 2, new DateTime(2012, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meredith", "Alonso" },
                    { 3, new DateTime(2013, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arturo", "Anand" },
                    { 4, new DateTime(2012, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gytis", "Barzdukas" },
                    { 5, new DateTime(2012, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yan", "Li" },
                    { 6, new DateTime(2011, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peggy", "Justice" },
                    { 7, new DateTime(2013, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "Norman" },
                    { 8, new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nino", "Olivetto" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentID", "Budget", "InstructorID", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, 350000m, 1, "English", new DateTime(2007, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 100000m, 2, "Mathematics", new DateTime(2007, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 350000m, 3, "Engineering", new DateTime(2007, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 100000m, 4, "Economics", new DateTime(2007, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OfficeAssignment",
                columns: new[] { "InstructorID", "Location" },
                values: new object[,]
                {
                    { 2, "Smith 17" },
                    { 3, "Gowan 27" },
                    { 4, "Thompson 304" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseID", "Credits", "DepartmentID", "Title" },
                values: new object[,]
                {
                    { 1045, 4, 2, "Calculus" },
                    { 1050, 3, 3, "Chemistry" },
                    { 2021, 3, 1, "Composition" },
                    { 2042, 4, 1, "Literature" },
                    { 3141, 4, 2, "Trigonometry" },
                    { 4022, 3, 4, "Microeconomics" },
                    { 4041, 3, 4, "Macroeconomics" }
                });

            migrationBuilder.InsertData(
                table: "CourseAssignment",
                columns: new[] { "CourseID", "InstructorID" },
                values: new object[,]
                {
                    { 1045, 2 },
                    { 1050, 3 },
                    { 1050, 4 },
                    { 2021, 1 },
                    { 2042, 1 },
                    { 3141, 3 },
                    { 4022, 5 },
                    { 4041, 5 }
                });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "EnrollmentID", "CourseID", "Grade", "StudentID" },
                values: new object[,]
                {
                    { 1, 1050, 0, 1 },
                    { 2, 4022, 2, 1 },
                    { 3, 4041, 1, 1 },
                    { 4, 1045, 1, 2 },
                    { 5, 3141, 1, 2 },
                    { 6, 2021, 1, 2 },
                    { 7, 1050, null, 3 },
                    { 8, 4022, 1, 3 },
                    { 9, 1050, 1, 4 },
                    { 10, 2021, 1, 5 },
                    { 11, 2042, 1, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentID",
                table: "Course",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignment_InstructorID",
                table: "CourseAssignment",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_InstructorID",
                table: "Department",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseID",
                table: "Enrollment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentID",
                table: "Enrollment",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAssignment");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "OfficeAssignment");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Instructor");
        }
    }
}
