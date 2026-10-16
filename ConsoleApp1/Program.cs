using System.Xml.Linq;

namespace ConsoleApp1
{
    class Student
    {
        public int StudentId;
        public string Name;
        public int Age;
        public List<Course> Courses = new List<Course>();
        public bool Enroll(Course course)
        {
            Courses.Add(course);
            return true;
        }
        public string PrintDetails()
        {
            string CourseDetail = "";
            foreach (var course in Courses)
            {
                CourseDetail += course.Title+", ";
            }
            return $"StudentId = {StudentId} Name = {Name} Age = {Age} courses = {CourseDetail}";
        }
    }

    class Instructor
    {
        public int InstructorId;
        public string Name;
        public string Specialization;

        public string PrintDetails()
        {
            return $"InstructorId = {InstructorId} Name = {Name} Specialization = {Specialization}";
        }
    }
    class Course
    {
        public int CourseId;
        public string Title;
        public Instructor Instructor = new Instructor();
        public string PrintDetails()
        {
            return $"CourseId = {CourseId} Title = {Title}";

        }
    }
    class StudentManager
    {
        public List<Student> Students = new List<Student>();
        public List<Course> Courses = new List<Course>();
        public List<Instructor> Instructors = new List<Instructor>();

    }

    internal class Program
    {

        static void Main(string[] args)
        {
            string Choice;
            List<Student> StudentsList = new List<Student>();
            List<Course> CoursesList = new List<Course>();
            List<Instructor> InstructorsList = new List<Instructor>();
            do
            {
                Console.WriteLine("*****Student Management System*****");
                Console.WriteLine("1. Add Student ");
                Console.WriteLine("2. Add Instructor ");
                Console.WriteLine("3. Add Course ");
                Console.WriteLine("4. Enroll Student in Course ");
                Console.WriteLine("5. Show All Students ");
                Console.WriteLine("6. Show All Courses ");
                Console.WriteLine("7. Show All Instructors ");
                Console.WriteLine("8. Find the student by id or name  ");
                Console.WriteLine("9. Fine the course by id or name ");
                Console.WriteLine("10. Exit");
                Console.WriteLine("11. Check if the student enrolled in specific course");
                Console.WriteLine("12. Return the instructor name by course name");
                Console.WriteLine("13. Update Student Information");
                Console.WriteLine("14. Delete a Student");

                Choice = Console.ReadLine();

                switch (Choice)
                {
                    case "1":
                        Console.WriteLine("Enter Student Id:");
                        int StudentId= Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Student Name:");
                        string Name = Console.ReadLine();
                        Console.WriteLine("Enter Student Age:");
                        int Age = Convert.ToInt32(Console.ReadLine());

                        Student student = new Student();
                        student.StudentId = StudentId;
                        student.Name = Name;
                        student.Age = Age;
                        StudentsList.Add(student);
                        break;
                    case "2":
                        Console.WriteLine("Enter Instructor Id:");
                        int InstructorId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Instructor Name:");
                        string InstructorName = Console.ReadLine();
                        Console.WriteLine("Enter Instructor Specialization:");
                        string Specialization = Console.ReadLine();

                        Instructor instructor = new Instructor();
                        instructor.InstructorId = InstructorId;
                        instructor.Name = InstructorName;
                        instructor.Specialization = Specialization;
                        InstructorsList.Add(instructor);
                        break;
                    case "3":
                        Console.WriteLine("Enter Course Id:");
                        int CourseId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Course Title:");
                        string Title = Console.ReadLine();

                        Console.WriteLine("Enter Instructor Id :");
                        int InstructorRelationId = Convert.ToInt32(Console.ReadLine());

                        Course course = new Course();
                        course.CourseId = CourseId;
                        course.Title = Title;

                        bool isInstructorFound = false;
                        for (int i = 0; i < InstructorsList.Count; i++)
                        {
                            if (InstructorsList[i].InstructorId == InstructorRelationId)
                            {
                                course.Instructor = InstructorsList[i]; 
                                isInstructorFound = true;
                                break;
                            }
                        }

                        if (isInstructorFound)
                        {
                            Console.WriteLine("Course Added and Linked with Instructor ");
                        }
                        else
                        {
                            Console.WriteLine("Instructor Not Found");
                        }

                        CoursesList.Add(course);
                        break;
                    case "4":
                        Console.WriteLine("Enter Student Id:");
                        int EnrollStudentId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Course Id:");
                        int EnrollCourseId = Convert.ToInt32(Console.ReadLine());

                        bool FoundStudent = false;
                        bool FoundCourse = false;

                        int StudentIndex = -1 ;
                        int CourseIndex = -1;

                        for (int i=0;i<StudentsList.Count;i++)
                        {
                            if (StudentsList[i].StudentId == EnrollStudentId)
                            {
                                FoundStudent = true;
                                StudentIndex = i;
                                break;

                            }
                           
                        }
                        for (int c = 0; c < CoursesList.Count; c++)
                        {
                            if (CoursesList[c].CourseId == EnrollCourseId)
                            {
                                FoundCourse = true;
                                CourseIndex = c;
                                break;
                            }
                           
                        }

                        if(FoundStudent)
                        {
                            if(FoundCourse)
                            {
                                Console.WriteLine("Course Found");
                                StudentsList[StudentIndex].Enroll(CoursesList[CourseIndex]);
                            }
                            else
                            {
                                Console.WriteLine("Course Not Found");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Student Not Found");
                        }

                        break;
                    case "5":
                        for(int i =0;i < StudentsList.Count; i++)
                        {
                            
                            Console.WriteLine(StudentsList[i].PrintDetails());
                            Console.WriteLine("===================================================");

                        }
                        break;
                    case "6":
                        for (int i = 0; i < CoursesList.Count; i++)
                        {

                            Console.WriteLine(CoursesList[i].PrintDetails());
                            Console.WriteLine("===================================================");

                        }
                        break;
                    case "7":
                        for (int i = 0; i < InstructorsList.Count; i++)
                        {

                            Console.WriteLine(InstructorsList[i].PrintDetails());
                            Console.WriteLine("===================================================");

                        }
                        break;
                    case "8":
                        string SearchStudent = Console.ReadLine();

                        bool IsFoundStudent = false;
                        int IndexSearchStudent = -1;
                        int searchStudentId;

                        bool IsNumberStudent = int.TryParse(SearchStudent, out searchStudentId);
                        if (IsNumberStudent)
                        {
                            for (int i = 0; i < StudentsList.Count; i++)
                            {
                                if (StudentsList[i].StudentId == searchStudentId)
                                {
                                    IsFoundStudent = true;
                                    IndexSearchStudent = i;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < StudentsList.Count; i++)
                            {
                                if (StudentsList[i].Name == SearchStudent)
                                {
                                    IsFoundStudent = true;
                                    IndexSearchStudent = i;
                                    break;
                                }
                            }
                        }

                      
                        if (IsFoundStudent)
                        {
                            Console.WriteLine("Student Found");
                            Console.WriteLine(StudentsList[IndexSearchStudent].PrintDetails());
                        }
                        else
                        {
                            Console.WriteLine("Student Not Found");
                        }

                        break;


                    case "9":
                        string SearchCourse = Console.ReadLine();

                        bool IsFoundCourse = false;
                        int IndexSearchCourse = -1;
                        int searchCourseId;

                        bool IsNumberCourse = int.TryParse(SearchCourse, out searchCourseId);
                        if (IsNumberCourse)
                        {
                            for (int i = 0; i < CoursesList.Count; i++)
                            {
                                if (CoursesList[i].CourseId == searchCourseId)
                                {
                                    IsFoundCourse = true;
                                    IndexSearchCourse = i;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < CoursesList.Count; i++)
                            {
                                if (CoursesList[i].Title == SearchCourse)
                                {
                                    IsFoundCourse = true;
                                    IndexSearchCourse = i;
                                    break;
                                }
                            }
                        }


                        if (IsFoundCourse)
                        {
                            Console.WriteLine("Course Found");
                            Console.WriteLine(CoursesList[IndexSearchCourse].PrintDetails());
                        }
                        else
                        {
                            Console.WriteLine("Course Not Found");
                        }
                        break;
                    case "10":
                        Console.WriteLine("Exit");
                        break;
                    case "11":
                        Console.WriteLine("Enter Student Id:");
                        int  SpecificStudentId = Convert.ToInt32(Console.ReadLine());
                        bool SpecificFoundStudent = false;
                        int  SpecificStudentIndex = -1;

                        Console.WriteLine("Enter Course Id:");
                        int SpecificCourseId = Convert.ToInt32(Console.ReadLine());
                        bool SpecificFoundCourse = false;
                        int SpecificIndexCourse = -1;

                        for (int i = 0; i < StudentsList.Count; i++)
                        {
                            if (StudentsList[i].StudentId == SpecificStudentId)
                            {
                                SpecificFoundStudent = true;
                                SpecificStudentIndex = i;
                                break;

                            }

                        }
                        for (int i = 0; i < CoursesList.Count; i++)
                        {
                            if (CoursesList[i].CourseId == SpecificCourseId)
                            {
                                SpecificFoundCourse = true;
                                SpecificIndexCourse = i;
                                break;
                            }
                        }

                      
                        if (SpecificFoundStudent)
                        {
                            if (SpecificFoundCourse)
                            {
                                bool isEnrolled = StudentsList[SpecificStudentIndex].Courses.Contains(CoursesList[SpecificIndexCourse]);
                                if (isEnrolled)
                                {
                                    Console.WriteLine("Yes, the student is enrolled in this course.");
                                }
                                else
                                {
                                    Console.WriteLine("No, the student is not enrolled in this course.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Course Not Found");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Student Not Found");
                        }

                        break;


                    case "12":
                        Console.WriteLine("Return the instructor name by course name");
                        Console.WriteLine("Enter Course Name:");

                        string CourseTitle = Console.ReadLine();                   
                        bool ExtractFoundCourse = false;
                        int  ExtractIndexCourse = -1;

                        for (int i = 0; i < CoursesList.Count; i++)
                        {
                            if (CoursesList[i].Title == CourseTitle)
                            {
                                ExtractFoundCourse = true;
                                ExtractIndexCourse = i;
                                break;
                            }
                        }
                        if (ExtractFoundCourse)
                        {
                            Instructor FoundInstructor = CoursesList[ExtractIndexCourse].Instructor;
                            if (!string.IsNullOrEmpty(FoundInstructor.Name))
                            {
                                Console.WriteLine($"The Instructor for course '{CourseTitle}' is: {FoundInstructor.Name}");
                            }
                            else
                            {
                                Console.WriteLine("This course has no instructor assigned yet.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Course Not Found");
                        }
                        break;
                    case "13":
                        Console.WriteLine("Enter Student Id:");
                        int UpdateStudentId = Convert.ToInt32(Console.ReadLine());
                     

                        bool UpdateFoundStudent = false;

                        int UpdateStudentIndex = -1;

                        for (int i = 0; i < StudentsList.Count; i++)
                        {
                            if (StudentsList[i].StudentId == UpdateStudentId)
                            {
                                UpdateFoundStudent = true;
                                UpdateStudentIndex = i;
                                break;

                            }

                        }
                        if (UpdateFoundStudent)
                        {   
                            Console.WriteLine("Update name Enter 1 or Update Age Enter 2 ");
                            int UpdateChoice = Convert.ToInt32(Console.ReadLine());
                            switch(UpdateChoice)
                            {
                                case 1:
                                    Console.WriteLine("Enter New Student Name:");
                                    string UpdateName = Console.ReadLine();
                                    StudentsList[UpdateStudentIndex].Name = UpdateName;
                                    break;
                                case 2:
                                    Console.WriteLine("Enter New Student Age:");
                                    int UpdateAge = Convert.ToInt32(Console.ReadLine());
                                    StudentsList[UpdateStudentIndex].Age = UpdateAge;
                                    break;
                                default:
                                    Console.WriteLine("Invalid Choice");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Student Not Found");
                        }

                        break;
                    case "14":
                        Console.WriteLine("Enter Student Id:");
                        int DeleteStudentId = Convert.ToInt32(Console.ReadLine());


                        bool DeleteFoundStudent = false;

                        int DeleteStudentIndex = -1;

                        for (int i = 0; i < StudentsList.Count; i++)
                        {
                            if (StudentsList[i].StudentId == DeleteStudentId)
                            {
                                DeleteFoundStudent = true;
                                DeleteStudentIndex = i;
                                break;

                            }

                        }
                        if (DeleteFoundStudent)
                        {
                            StudentsList.RemoveAt(DeleteStudentIndex);
                            Console.WriteLine("Student Deleted Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Student Not Found");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;

                }
            }
            while (Choice != "10");



        }


    }
}
