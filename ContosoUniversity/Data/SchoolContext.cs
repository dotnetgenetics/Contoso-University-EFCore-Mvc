using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var students = new Student[]
            {
                new Student { ID=1, FirstMidName = "Carson",   LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { ID=2, FirstMidName = "Meredith", LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { ID=3, FirstMidName = "Arturo",   LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { ID=4, FirstMidName = "Gytis",    LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { ID=5, FirstMidName = "Yan",      LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { ID=6, FirstMidName = "Peggy",    LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { ID=7, FirstMidName = "Laura",    LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { ID=8, FirstMidName = "Nino",     LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-09-01") }
            };
            modelBuilder.Entity<Student>().HasData(students);

            var instructors = new Instructor[]
            {
                new Instructor { ID=1, FirstMidName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { ID=2, FirstMidName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { ID=3, FirstMidName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { ID=4, FirstMidName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { ID=5, FirstMidName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };
            modelBuilder.Entity<Instructor>().HasData(instructors);

            var departments = new Department[]
            {
                new Department { DepartmentID=1, Name = "English",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
                new Department { DepartmentID=2, Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
                new Department { DepartmentID=3, Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
                new Department { DepartmentID=4, Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID }
            };
            modelBuilder.Entity<Department>().HasData(departments);

            var courses = new Course[]
            {
                new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                },
                new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new Course {CourseID = 1045, Title = "Calculus",       Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Course {CourseID = 2021, Title = "Composition",    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                },
                new Course {CourseID = 2042, Title = "Literature",     Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                },
            };
            modelBuilder.Entity<Course>().HasData(courses);

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Harui").ID,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID,
                    Location = "Thompson 304" }
            };
            modelBuilder.Entity<OfficeAssignment>().HasData(officeAssignments);

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Kapoor").ID
                    },
                new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Fakhouri").ID
                    },
                new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                    },
                new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Literature" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                    },
            };
            modelBuilder.Entity<CourseAssignment>().HasData(courseInstructors);
            
            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    EnrollmentID = 1,
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    Grade = Grade.A
                },
                new Enrollment {
                    EnrollmentID = 2,
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                    Grade = Grade.C
                },
                new Enrollment {
                    EnrollmentID = 3,
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    EnrollmentID = 4,
                    StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    EnrollmentID = 5,
                    StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    EnrollmentID = 6,
                    StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    EnrollmentID = 7,
                    StudentID = students.Single(s => s.LastName == "Anand").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
                },
                new Enrollment {
                    EnrollmentID = 8,
                    StudentID = students.Single(s => s.LastName == "Anand").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    EnrollmentID = 9,
                    StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    EnrollmentID = 10,
                    StudentID = students.Single(s => s.LastName == "Li").ID,
                    CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    EnrollmentID = 11,
                    StudentID = students.Single(s => s.LastName == "Justice").ID,
                    CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                    Grade = Grade.B
                }
            };
            modelBuilder.Entity<Enrollment>().HasData(enrollments);

            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");
            modelBuilder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });
            modelBuilder.Entity<Department>()
                .Property(p => p.RowVersion).IsConcurrencyToken();

            base.OnModelCreating(modelBuilder);
        }
    }
}