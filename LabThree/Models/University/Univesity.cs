using LabTwo.Models.Students;
using LabTwo.Models.Workers;
using LabTwo.Models.Auditoriums;
using LabTwo.Models.Departments;
using LabThree.Controllers;
using LabTwo.Models.Workers.Teachers;
using System.Linq;
using System.Text.Json.Serialization;
using LabTwo.Models.Workers.Engineers;

namespace LabTwo.Models.University
{
    public class University : IEqualityComparer<University>
    {
        private string itsName;
        private int itsFoundationYear;
        private double itsRank;
        private List<Department> itsDepartments;
        private WorkerController itsWorkers;
        private List<Teacher> itsTeachers;
        private List<Engineer> itsEngineers;
        private List<Student> itsStudents;
        private List<Auditorium> itsAuditoriums;
        private List<LectureAuditorium> itsLectureAuditoriums;
        private List<LabAuditorium> itsLabAuditoriums;

        public string Name { get { return itsName; } set { itsName = value; } }
        public int FoundationYear { get { return itsFoundationYear; } set { itsFoundationYear = value; } }
        public double Rank { get { return itsRank; } set { itsRank = value; } }
        public List<Department> Departments { get { return itsDepartments; } set { itsDepartments = value; } }
        public List<Teacher> Teachers { get { return itsTeachers; } set { itsTeachers = value; AddWorkersFromTeachers(); } } // for serialization
        public List<Engineer> Engineers { get { return itsEngineers; } set { itsEngineers = value; AddWorkersFromEngineers(); } } // for serialization
        [JsonIgnore]
        public List<Worker> Workers 
        { 
            get { return itsWorkers.Workers; } 
            set 
            { 
                itsWorkers.Workers = value;
                Teachers = itsWorkers.Workers.OfType<Teacher>().ToList();
                Engineers = itsWorkers.Workers.OfType<Engineer>().ToList();
            } 
        }
        public List<Student> Students { get { return itsStudents; } set { itsStudents = value; } }
        public List<LectureAuditorium> LectureAuditoriums 
        { 
            get { return itsLectureAuditoriums; } 
            set { itsLectureAuditoriums = value; AddAuditoriumsFromLectureAuditoriums(); } 
        }
        public List<LabAuditorium> LabAuditoriums 
        { 
            get { return itsLabAuditoriums; }
            set { itsLabAuditoriums = value; AddAuditoriumsFromLabAuditoriums(); }
        }
        [JsonIgnore]
        public List<Auditorium> Auditoriums 
        { 
            get { return itsAuditoriums; } 
            set 
            { 
                itsAuditoriums = value;
                itsLectureAuditoriums = itsAuditoriums.OfType<LectureAuditorium>().ToList();
                itsLabAuditoriums = itsAuditoriums.OfType<LabAuditorium>().ToList();
            } 
        }


        public University()
        {
            itsName = string.Empty;
            itsFoundationYear = 0;
            itsRank = 0;
            itsWorkers = new WorkerController();
            itsTeachers = new List<Teacher>();
            itsEngineers = new List<Engineer>();
            itsStudents = new List<Student>();
            itsAuditoriums = new List<Auditorium>();
        }
        public University(string name, int foundationYear, double rank, List<Department> departments, WorkerController workers
            , List<Student> students, List<Auditorium> auditoriums)
        {
            itsName = name;
            itsFoundationYear = foundationYear;
            itsRank = rank;
            itsDepartments = departments;
            itsWorkers = workers;
            itsTeachers = itsWorkers.Workers.OfType<Teacher>().ToList();
            itsEngineers = itsWorkers.Workers.OfType<Engineer>().ToList();
            itsStudents = students;
            itsAuditoriums = auditoriums;
            itsLectureAuditoriums = itsAuditoriums.OfType<LectureAuditorium>().ToList();
            itsLabAuditoriums = itsAuditoriums.OfType<LabAuditorium>().ToList();
        }
        public University(University rhs)
        {
            itsName = rhs.itsName;
            itsFoundationYear = rhs.itsFoundationYear;
            itsRank = rhs.itsRank;
            itsDepartments = rhs.itsDepartments;
            itsWorkers = rhs.itsWorkers;
            itsTeachers = itsWorkers.Workers.OfType<Teacher>().ToList();
            itsEngineers = itsWorkers.Workers.OfType<Engineer>().ToList();
            itsStudents = rhs.itsStudents;
            itsAuditoriums = rhs.itsAuditoriums;
            itsLectureAuditoriums = rhs.itsLectureAuditoriums;
            itsLabAuditoriums = rhs.itsLabAuditoriums;
        }

        
        /*
            Data handling 
        */

        // Workers 
        public void AddWorker(Worker worker) { itsWorkers.Add(worker); }
        public void RemoveWorkerAt(int index) { itsWorkers.RemoveAt(index); }
        private void AddWorkersFromTeachers()
        {
            foreach (Teacher teacher in itsTeachers)
                itsWorkers.Add(teacher);
        }
        private void AddWorkersFromEngineers()
        {
            foreach (Engineer engineer in itsEngineers)
                itsWorkers.Add(engineer);
        }
        public Worker GetWorkerByPassport(string passport)
        {
            if (WorkerHasSuchPassport(passport))
                return itsWorkers.GetWorkerByPassport(passport);
            else
                return null;
        }
        private bool WorkerHasSuchPassport(string passport) { return itsWorkers.WorkerHasSuchPassport(passport); }

        // Students
        public void AddStudent(Student student) { itsStudents.Add(student); }
        public void RemoveStudentAt(int index) { itsStudents.RemoveAt(index); }
        
        // Auditoriums
        public void AddAuditorium(Auditorium auditorium) { itsAuditoriums.Add(auditorium); }
        public void RemoveAuditoriumAt(int index) { itsAuditoriums.RemoveAt(index); }
        public void ChangeAuditoriumType(int index) // changes lab to lecture, lecture to lab
        {
            if (itsAuditoriums[index] is LectureAuditorium)
                itsAuditoriums[index] = ToLabFromLecture((LectureAuditorium)itsAuditoriums[index]);
            else
                itsAuditoriums[index] = ToLectureFromLab((LabAuditorium)itsAuditoriums[index]);
        }
        private LabAuditorium ToLabFromLecture(LectureAuditorium lectureAuditorium)
        {
            return new LabAuditorium("Lab", lectureAuditorium.Capacity, lectureAuditorium.Engineers, 0, 0);
        }
        private LectureAuditorium ToLectureFromLab(LabAuditorium labAuditorium)
        {
            return new LectureAuditorium("LC", labAuditorium.Capacity, labAuditorium.Engineers, 0, true);
        }
        public bool AuditoriumIsSuitableForLessons(int auditoriumIndex)
        {
            if (itsAuditoriums[auditoriumIndex] is LabAuditorium)
                return itsAuditoriums[auditoriumIndex].Engineers != null && itsAuditoriums[auditoriumIndex].Engineers.Count == 2;
            else
                return itsAuditoriums[auditoriumIndex].Engineers != null && itsAuditoriums[auditoriumIndex].Engineers.Count >= 1;
        }
        private void AddAuditoriumsFromLectureAuditoriums()
        {
            foreach (LectureAuditorium lectureAuditorium in itsLectureAuditoriums)
                itsAuditoriums.Add(lectureAuditorium);
        }
        private void AddAuditoriumsFromLabAuditoriums()
        {
            foreach (LabAuditorium labAuditorium in itsLabAuditoriums)
                itsAuditoriums.Add(labAuditorium);
        }

        // Teachers
        public int GetPotentialNumberOfSubjects(int teacherIndex)
        {
            return 5 - itsWorkers.Workers.OfType<Teacher>().ToList()[teacherIndex].NumberOfSubjects;
        }


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
                , lhs.Departments.Concat(rhs.Departments).ToList(), new WorkerController() { Workers = lhs.Workers.Concat(rhs.Workers).ToList() }
                , lhs.Students.Concat(rhs.Students).ToList(), lhs.Auditoriums.Concat(rhs.Auditoriums).ToList());
        }
    }
}