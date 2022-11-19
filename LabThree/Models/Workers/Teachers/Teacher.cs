using LabTwo.Models.Students;

namespace LabTwo.Models.Workers.Teachers
{
    public class Teacher : Worker, IEquatable<Teacher>
    {
        private List<Student> itsStudents;

        public List<Student> Students { get { return itsStudents; } set { itsStudents = value; } }
        
        public Teacher()
        {
            itsStudents = null;
        }
        public Teacher(string name, int age, string passport, List<Student> students) 
            : base(name, age, passport)
        {
            itsStudents = students;
        }

        public bool AddStudent(Student student) 
        {
            if (itsStudents.Count < 10)
            {
                itsStudents.Add(student);
                return true;
            }
            else
                return false;
        }
        public void RemoveStudent(Student student)
        {
            itsStudents.Remove(student);
        }


        public bool Equals(Teacher rhs)
        {
            return itsName == rhs.itsName && itsAge == rhs.itsAge && itsPassport == rhs.itsPassport && itsStudents.Equals(rhs);
        }
    }
}