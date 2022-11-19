using LabTwo.Models.Students;
using LabTwo.Models.Workers.Teachers;

namespace LabTwo.Converters.WorkerConverters
{
    public static class TeacherConverter
    {
        public static Teacher ToTeacher(string name, string age, string salary, List<Student> students)
        {
            return new Teacher(name, Convert.ToInt32(age), Convert.ToDouble(salary), students);
        }
    }
}