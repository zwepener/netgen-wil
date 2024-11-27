using CodeCraft.Data.Models;

namespace CodeCraft.Web.AdminPortal.Models
{
    public class DashboardModel
    {
        public List<Admin> Admins { get; set; } = [];
        public int TotalAdmins
        {
            get
            {
                return Admins.Count;
            }
        }
        public List<Admin> NewAdmins
        {
            get
            {
                List<Admin> result = [];
                foreach (Admin admin in Admins)
                {
                    if (admin.CreatedAt > DateTime.Now.AddMonths(-1))
                    {
                        result.Add(admin);
                    }
                }
                return result;
            }
        }
        public int TotalNewAdmins
        {
            get
            {
                return NewAdmins.Count;
            }
        }

        public List<Course> Courses { get; set; } = [];
        public int TotalCourses
        {
            get
            {
                return Courses.Count;
            }
        }
        public List<Course> NewCourses
        {
            get
            {
                List<Course> result = [];
                foreach (Course course in Courses)
                {
                    if (course.CreatedAt > DateTime.Now.AddMonths(-1))
                    {
                        result.Add(course);
                    }
                }
                return result;
            }
        }
        public int TotalNewCourses
        {
            get
            {
                return NewCourses.Count;
            }
        }

        public List<Instructor> Instructors { get; set; } = [];
        public int TotalInstructors
        {
            get
            {
                return Instructors.Count;
            }
        }
        public List<Instructor> NewInstructors
        {
            get
            {
                List<Instructor> result = [];
                foreach (Instructor instructor in Instructors)
                {
                    if (instructor.CreatedAt > DateTime.Now.AddMonths(-1))
                    {
                        result.Add(instructor);
                    }
                }
                return result;
            }
        }
        public int TotalNewInstructors
        {
            get
            {
                return NewInstructors.Count;
            }
        }

        public List<Student> Students { get; set; } = [];
        public int TotalStudents
        {
            get
            {
                return Students.Count;
            }
        }
        public List<Student> NewStudents
        {
            get
            {
                List<Student> result = [];
                foreach (Student student in Students)
                {
                    if (student.CreatedAt > DateTime.Now.AddMonths(-1))
                    {
                        result.Add(student);
                    }
                }
                return result;
            }
        }
        public int TotalNewStudents
        {
            get
            {
                return NewStudents.Count;
            }
        }
    }
}
