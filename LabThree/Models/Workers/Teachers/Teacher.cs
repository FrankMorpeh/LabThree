using LabTwo.Models.Students;

namespace LabTwo.Models.Workers.Teachers
{
    public class Teacher : Worker, IEquatable<Teacher>
    {
        private List<Student> itsStudents;
        private int itsNumberOfSubjects;
        private int itsNumberOfScientificWorks;

        public List<Student> Students { get { return itsStudents; } set { itsStudents = value; } }
        public int NumberOfSubjects { get { return itsNumberOfSubjects; } set { itsNumberOfSubjects = value; } }
        public int NumberOfScientificWorks { get { return itsNumberOfScientificWorks; } set { itsNumberOfScientificWorks = value; } }
        
        public Teacher()
        {
            itsStudents = null;
            itsNumberOfSubjects = 0;
            itsNumberOfScientificWorks = 0;
        }
        public Teacher(string name, int age, string passport, List<Student> students, int numberOfSubjects, int numberOfScientificWorks) 
            : base(name, age, passport)
        {
            itsStudents = students;
            itsNumberOfSubjects = numberOfSubjects;
            itsNumberOfScientificWorks = numberOfScientificWorks;
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
            return itsName == rhs.itsName && itsAge == rhs.itsAge && itsPassport == rhs.itsPassport && itsStudents.Equals(rhs)
                && itsNumberOfSubjects == rhs.itsNumberOfSubjects && itsNumberOfScientificWorks == rhs.itsNumberOfScientificWorks;
        }
    }
}