using LabTwo.Converters.StudentConverters;
using LabTwo.Models.Students;
using LabTwo.Validators.StudentValidators;
using LabTwo.View;
using LabTwo.ViewInteractors.FormStorages;
using LabTwo.Warnings;

namespace LabTwo.ViewInteractors.Handlers
{
    public class StudentsInfoPanelHandler : IPanelHandler
    {
        private Form1 itsMainWindow;
        private StudentsInfoPanelFormStorage itsStudentsInfoPanelFormStorage;

        public StudentsInfoPanelHandler(Form1 mainWindow)
        {
            itsMainWindow = mainWindow;
            itsStudentsInfoPanelFormStorage = new StudentsInfoPanelFormStorage();
            AddColumnsToListView();
        }
        private void AddColumnsToListView()
        {
            itsMainWindow.studentsListView.Columns.Clear();
            itsMainWindow.studentsListView.Columns.Add("Name");
            itsMainWindow.studentsListView.Columns.Add("Age");
            itsMainWindow.studentsListView.Columns.Add("Record book");
            itsMainWindow.studentsListView.Columns.Add("Year in university");
        }

        public List<Student> GetStudents()
        {
            return itsStudentsInfoPanelFormStorage.Students;
        }
        public void ShowPanel()
        {
            itsMainWindow.studentsPanel.Show();
        }
        public void HidePanel()
        {
            itsMainWindow.studentsPanel.Hide();
        }
        public void AddStudent()
        {
            List<IWarning> warnings = StudentValidator.CheckStudent(itsMainWindow.studentNameTextBox.Text, itsMainWindow.studentAgeTextBox.Text
                , itsMainWindow.studentRecordBookTextBox.Text, itsMainWindow.studentYearInUniversityTextBox.Text);
            if (warnings.Count == 0)
            {
                itsStudentsInfoPanelFormStorage.Students.Add(StudentConverter.ToStudent(itsMainWindow.studentNameTextBox.Text
                    , itsMainWindow.studentAgeTextBox.Text, itsMainWindow.studentRecordBookTextBox.Text
                    , itsMainWindow.studentYearInUniversityTextBox.Text));
                UniversityView.ShowStudentsInfo(itsStudentsInfoPanelFormStorage.Students, itsMainWindow.studentsListView);
            }
            else
                WarningDisplayer.ShowWarning(itsMainWindow.warningPanel3, itsMainWindow.warningTextBox3, warnings);
        }
    }
}