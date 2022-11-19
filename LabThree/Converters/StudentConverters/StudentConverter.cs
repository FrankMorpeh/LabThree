using LabTwo.Models.Students;
using static System.Windows.Forms.ListView;

namespace LabTwo.Converters.StudentConverters
{
    public static class StudentConverter
    {
        public static Student ToStudent(string name, string age, string recordBookNumber, string yearInUniversity)
        {
            return new Student(name, Convert.ToInt32(age), recordBookNumber, Convert.ToInt32(yearInUniversity));
        }
        public static List<Student> ToStudentList(List<Student> initialStudents, SelectedIndexCollection selectedIndexCollection)
            // forms a collection of students (for a particular teacher) based on the selected items in listview
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < selectedIndexCollection.Count; i++)
                students.Add(initialStudents[selectedIndexCollection[i]]);
            return students;
        }
    }
}