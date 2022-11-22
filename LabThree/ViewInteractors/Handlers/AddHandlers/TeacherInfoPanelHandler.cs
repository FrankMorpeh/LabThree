using LabTwo.Converters.WorkerConverters;
using LabTwo.Models.Students;
using LabTwo.Validators.TeacherValidators;
using LabTwo.View;
using LabTwo.ViewInteractors.FormStorages;
using LabTwo.Warnings;

namespace LabTwo.ViewInteractors.Handlers
{
    public class TeacherInfoPanelHandler : IPanelHandler
    {
        private Form1 itsMainWindow;
        private TeacherInfoPanelFormStorage itsTeacherInfoPanelFormStorage;
        private List<Student> itsStudentsOfTeacher;

        public TeacherInfoPanelFormStorage TeacherInfoPanelFormStorage { get { return itsTeacherInfoPanelFormStorage; } }

        public TeacherInfoPanelHandler(Form1 mainWindow)
        {
            itsMainWindow = mainWindow;
            itsTeacherInfoPanelFormStorage = new TeacherInfoPanelFormStorage();
            itsStudentsOfTeacher = new List<Student>();
            AddColumnsToListView();
        }
        private void AddColumnsToListView()
        {
            itsMainWindow.teachersListView.Columns.Clear();
            itsMainWindow.teachersListView.Columns.Add("Name");
            itsMainWindow.teachersListView.Columns.Add("Age");
            itsMainWindow.teachersListView.Columns.Add("Salary");
            itsMainWindow.teachersListView.Columns.Add("Subjects' number");
            itsMainWindow.teachersListView.Columns.Add("Scientific works' number");
        }

        public void OnAddStudents(List<Student> students) // called from StudentsOfTeacherInfoPanelHandler
        {
            itsStudentsOfTeacher = students;
            itsMainWindow.addStudentToTeacherButton.Enabled = false;
        }
        public void AddTeacher()
        {
            List<IWarning> warnings = TeacherValidator.CheckTeacher(itsMainWindow.teacherNameTextBox.Text, itsMainWindow.teacherAgeTextBox.Text
                , itsMainWindow.teacherPassportTextBox.Text, itsMainWindow.teacherNumberOfSubjectsTextBox.Text
                , itsMainWindow.teacherNumberOfScientificWorksTextBox.Text
                , itsTeacherInfoPanelFormStorage.Teachers.Exists(t => t.Passport == itsMainWindow.teacherPassportTextBox.Text));
            if (warnings.Count == 0)
            {
                itsTeacherInfoPanelFormStorage.Teachers.Add(TeacherConverter.ToTeacher(itsMainWindow.teacherNameTextBox.Text
                    , itsMainWindow.teacherAgeTextBox.Text, itsMainWindow.teacherPassportTextBox.Text, itsStudentsOfTeacher
                    , itsMainWindow.teacherNumberOfSubjectsTextBox.Text, itsMainWindow.teacherNumberOfScientificWorksTextBox.Text));
                UniversityView.ShowTeachersInfo(itsTeacherInfoPanelFormStorage.Teachers, itsMainWindow.teachersListView);
                itsMainWindow.addStudentToTeacherButton.Enabled = true;
            }
            else
                WarningDisplayer.ShowWarning(itsMainWindow.warningPanel3, itsMainWindow.warningTextBox3, warnings);
        }
        public void ShowPanel()
        {
            itsMainWindow.teachersPanel.Show();
        }
        public void HidePanel()
        {
            itsMainWindow.teachersPanel.Hide();
        }
    }
}