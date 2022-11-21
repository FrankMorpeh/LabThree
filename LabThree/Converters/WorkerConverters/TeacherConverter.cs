using LabTwo.Models.Students;
using LabTwo.Models.Workers.Teachers;

namespace LabTwo.Converters.WorkerConverters
{
    public static class TeacherConverter
    {
        public static Teacher ToTeacher(string name, string age, string passport, List<Student> students, string numberOfSubjects
            , string numberOfScientificWorks)
        {
            return new Teacher(name, Convert.ToInt32(age), passport, students, Convert.ToInt32(numberOfSubjects), Convert.ToInt32(numberOfScientificWorks));
        }
    }
}