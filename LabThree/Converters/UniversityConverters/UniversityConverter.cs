using LabTwo.Models.Auditoriums;
using LabTwo.Models.Departments;
using LabTwo.Models.Students;
using LabTwo.Models.University;
using LabTwo.Models.Workers;
using LabTwo.Models.Workers.Engineers;
using LabTwo.Models.Workers.Teachers;

namespace LabTwo.Converters.UniversityConverters
{
    public static class UniversityConverter
    {
        public static University ToUniversity(string name, string foundationYear, string rank, List<Department> departments, List<Teacher> teachers
            , List<Engineer> engineers, List<Student> students, List<Auditorium> auditoriums)
        {
            return new University(name, Convert.ToInt32(foundationYear), Convert.ToDouble(rank), departments
                , teachers.Cast<Worker>().Concat(engineers.Cast<Worker>()).ToList(), students
                , auditoriums);
        }
    }
}
