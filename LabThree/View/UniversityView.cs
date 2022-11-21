using LabTwo.Controllers.UniversityController;
using LabTwo.Models.Auditoriums;
using LabTwo.Models.Departments;
using LabTwo.Models.Students;
using LabTwo.Models.Subjects;
using LabTwo.Models.University;
using LabTwo.Models.Workers;
using LabTwo.Models.Workers.Engineers;
using LabTwo.Models.Workers.Teachers;

namespace LabTwo.View
{
    public class UniversityView
    {
        private UniversityController itsUniversityController;

        public UniversityView() { itsUniversityController = null; }
        public UniversityView(UniversityController universityController) { itsUniversityController = universityController; }


        /*
            Displaying info
        */
        public void ShowPreviewInfo(ComboBox comboBox) // shows the names of the unis in the combobox
        {
            foreach (University university in itsUniversityController.Universities)
                comboBox.Items.Add(university.Name);
        }
        public void ShowBasicInfo(int index, Label label) // shows Name, Year, and Rank in the label
        {
            label.Text = string.Empty;
            label.Text += "Name: " + itsUniversityController[index].Name + "\r\n";
            label.Text += "Foundation year: " + itsUniversityController[index].FoundationYear + "\r\n";
            label.Text += "Rank: " + itsUniversityController[index].Rank + "\r\n";
        }
        public void ShowBasicInfo(ListView listView)
        {
            foreach (University university in itsUniversityController.Universities)
                listView.Items.Add(new ListViewItem(new string[] { university.Name, Convert.ToString(university.FoundationYear)
                        , Convert.ToString(university.Rank) }));

            listView.Refresh();
        }
        public void ShowWorkersInfo(int index, ListView listView)
        {
            foreach (Worker worker in itsUniversityController[index].Workers)
                listView.Items.Add(new ListViewItem(new string[] { worker.Name, Convert.ToString(worker.Age)
                        , Convert.ToString(worker.Passport) }));

            listView.Refresh();
        }
        public static void ShowTeachersInfo(List<Teacher> teachers, ListView listView)
        {
            listView.Items.Clear();

            foreach (Teacher teacher in teachers)
            {
                listView.Items.Add(new ListViewItem(new string[] { teacher.Name, Convert.ToString(teacher.Age)
                        , Convert.ToString(teacher.Passport), Convert.ToString(teacher.NumberOfSubjects)
                        , Convert.ToString(teacher.NumberOfScientificWorks)}));
            }

            listView.Refresh();
        }
        public void ShowTeachersInfo(int index, ListView listView)
        {
            ShowTeachersInfo(itsUniversityController[index].Workers.OfType<Teacher>().ToList(), listView);
        }
        public static void ShowStudentsInfo(List<Student> students, ListView listView)
        {
            listView.Items.Clear();
            foreach (Student student in students)
                listView.Items.Add(new ListViewItem(new string[] { student.Name, Convert.ToString(student.Age)
                    , student.RecordBookNumber, Convert.ToString(student.YearInUniversity) }));

            listView.Refresh();
        }
        public void ShowStudentsInfo(int index, ListView listView)
        {
            ShowStudentsInfo(itsUniversityController[index].Students, listView);
        }
        public void ShowStudentsOfTeacherInfo(int index, int teacherIndex, ListView listView)
        {
            ShowStudentsInfo(itsUniversityController[index].Workers.OfType<Teacher>().ToList()[teacherIndex].Students, listView);
        }
        public static void ShowEngineersInfo(List<Engineer> engineers, ListView listView)
        {
            listView.Items.Clear();

            foreach (Engineer engineer in engineers)
            {
                listView.Items.Add(new ListViewItem(new string[] { engineer.Name, Convert.ToString(engineer.Age)
                    , Convert.ToString(engineer.Passport), engineer.HasEngineerCertificate.ToString(), Convert.ToString(engineer.YearsWorking) }));
            }

            listView.Refresh();
        }
        public void ShowEngineersInfo(int index, ListView listView)
        {
            ShowEngineersInfo(itsUniversityController[index].Workers.OfType<Engineer>().ToList(), listView);
        }
        public void ShowDepartmentsInfo(int index, ListView listView)
        {
            ShowDepartmentsInfo(itsUniversityController[index].Departments, listView);
        }
        public static void ShowDepartmentsInfo(List<Department> departments, ListView listView)
        {
            listView.Items.Clear();

            foreach (Department department in departments)
                listView.Items.Add(new ListViewItem(new string[] { department.Name
                    , Convert.ToString(department.DeaneryCabinetNumber) }));

            listView.Refresh();
        }
        public void ShowSubjectsInfo(int index, int depIndex, ListView listView)
        {
            ShowSubjectsInfo(itsUniversityController[index].Departments[depIndex].Subjects, listView);
        }
        public static void ShowSubjectsInfo(List<Subject> subjects, ListView listView)
        {
            listView.Items.Clear();
            foreach (Subject subject in subjects)
                listView.Items.Add(new ListViewItem(new string[] { subject.Name, Convert.ToString(subject.Credit) }));

            listView.Refresh();
        }
        public static void ShowAuditoriumsInfo(List<Auditorium> auditoriums, ListView listView)
        {
            foreach (Auditorium auditorium in auditoriums)
            {
                listView.Items.Add(new ListViewItem(new string[] { auditorium.GetType().Name, auditorium.CodeName
                , Convert.ToString(auditorium.Capacity), auditorium.NamesOfEngineers }));
            }

            listView.Refresh();
        }
        public void ShowAuditoriumsInfo(int index, ListView listView)
        {
            ShowAuditoriumsInfo(itsUniversityController[index].Auditoriums, listView);
        }
    }
}