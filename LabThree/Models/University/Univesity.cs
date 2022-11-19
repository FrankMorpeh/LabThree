using LabTwo.Models.Students;
using LabTwo.Models.Workers;
using LabTwo.Models.Auditoriums;
using LabTwo.Models.Departments;

namespace LabTwo.Models.University
{
    public class University : IEqualityComparer<University>
    {
        private string itsName;
        private int itsFoundationYear;
        private double itsRank;
        private List<Department> itsDepartments;
        private List<Worker> itsWorkers;
        private List<Student> itsStudents;
        private List<Auditorium> itsAuditoriums;

        public string Name { get { return itsName; } set { itsName = value; } }
        public int FoundationYear { get { return itsFoundationYear; } set { itsFoundationYear = value; } }
        public double Rank { get { return itsRank; } set { itsRank = value; } }
        public List<Department> Departments { get { return itsDepartments; } set { itsDepartments = value; } }
        public List<Worker> Workers { get { return itsWorkers; } set { itsWorkers = value; } }
        public List<Student> Students { get { return itsStudents; } set { itsStudents = value; } }
        public List<Auditorium> Auditoriums { get { return itsAuditoriums; } set { itsAuditoriums = value; } }


        public University()
        {
            itsName = string.Empty;
            itsFoundationYear = 0;
            itsRank = 0;
            itsWorkers = null;
            itsStudents = null;
            itsAuditoriums = null;
        }
        public University(string name, int foundationYear, double rank, List<Department> departments, List<Worker> workers
            , List<Student> students, List<Auditorium> auditoriums)
        {
            itsName = name;
            itsFoundationYear = foundationYear;
            itsRank = rank;
            itsDepartments = departments;
            itsWorkers = workers;
            itsStudents = students;
            itsAuditoriums = auditoriums;
        }
        public University(University rhs)
        {
            itsName = rhs.itsName;
            itsFoundationYear = rhs.itsFoundationYear;
            itsRank = rhs.itsRank;
            itsDepartments = rhs.itsDepartments;
            itsWorkers = rhs.itsWorkers;
            itsStudents = rhs.itsStudents;
            itsAuditoriums = rhs.itsAuditoriums;
        }

        
        /*
            Data handling 
        */

        // Workers 
        public void AddWorker(Worker worker) { itsWorkers.Add(worker); }
        public void RemoveWorkerAt(int index) { itsWorkers.RemoveAt(index); }

        // Students
        public void AddStudent(Student student) { itsStudents.Add(student); }
        public void RemoveStudentAt(int index) { itsStudents.RemoveAt(index); }
        
        // Auditoriums
        public void AddAuditorium(Auditorium auditorium) { itsAuditoriums.Add(auditorium); }
        public void RemoveAuditoriumAt(int index) { itsAuditoriums.RemoveAt(index); }

        // Indexer
        public int this[Type auditoriumType]
        {
            get 
            {
                if (auditoriumType == typeof(LectureAuditorium))
                    return GetNumberOfLectureAuditoriums();
                else
                    return GetNumberOfLabAuditoriums();
            }
        }
        private int GetNumberOfLectureAuditoriums()
        {
            return GetNumberOfChosenAuditoriums(IsLectureAuditorium);
        }
        private int GetNumberOfLabAuditoriums()
        {
            return GetNumberOfChosenAuditoriums(IsLabAuditorium);
        }
        private int GetNumberOfChosenAuditoriums(Func<Auditorium, bool> isOfChosenTypeDelegate)
        {
            int numberOfChosenAuditoriums = 0;
            foreach (Auditorium auditorium in itsAuditoriums)
            {
                if (isOfChosenTypeDelegate(auditorium))
                    numberOfChosenAuditoriums++;
            }
            return numberOfChosenAuditoriums;
        }
        private bool IsLectureAuditorium(Auditorium auditorium)
        {
            return auditorium is LectureAuditorium;
        }
        private bool IsLabAuditorium(Auditorium auditorium)
        {
            return auditorium is LabAuditorium;
        }


        /* 
            IEqualityComparer
        */
        public bool Equals(University lhs, University rhs)
        {
            return lhs.itsName == rhs.itsName && lhs.itsFoundationYear == rhs.itsFoundationYear && lhs.itsRank == rhs.itsRank
                && lhs.itsWorkers.Equals(rhs.itsWorkers) && lhs.itsStudents.Equals(rhs.itsStudents)
                && lhs.itsAuditoriums.Equals(rhs.itsAuditoriums);
        }
        public int GetHashCode(University university)
        {
            return university.itsName.GetHashCode() + university.itsFoundationYear.GetHashCode() - university.itsRank.GetHashCode();
        }


        /*
            Operators
        */
        public static University operator+(University lhs, University rhs)
        {
            return new University(lhs.Name + " and " + rhs.Name, 2022, (lhs.Rank + rhs.Rank) / 2
                , lhs.Departments.Concat(rhs.Departments).ToList(), lhs.Workers.Concat(rhs.Workers).ToList()
                , lhs.Students.Concat(rhs.Students).ToList(), lhs.Auditoriums.Concat(rhs.Auditoriums).ToList());
        }
    }
}