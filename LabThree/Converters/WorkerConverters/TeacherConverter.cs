using LabTwo.Models.Students;
using LabTwo.Models.Workers.Teachers;

namespace LabTwo.Converters.WorkerConverters
{
    public static class TeacherConverter
    {
        public static Teacher ToTeacher(string name, string age, string passport, List<Student> students)
        {
            return new Teacher(name, Convert.ToInt32(age), passport, students);
        }
    }
}