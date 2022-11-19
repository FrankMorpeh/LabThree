using LabTwo.Converters.StudentConverters;
using LabTwo.Models.Students;
using LabTwo.Validators.StudentValidators;
using LabTwo.View;
using LabTwo.Warnings;

namespace LabTwo.ViewInteractors.Handlers
{
    public class StudentsOfTeacherInfoPanelHandler : IPanelHandler
    {
        private Form1 itsMainWindow;
        private event Action<List<Student>> itsStudentsForTeacherChosenEvent;

        public StudentsOfTeacherInfoPanelHandler(Form1 mainWindow, TeacherInfoPanelHandler teacherInfoPanelHandler)
        {
            itsMainWindow = mainWindow;
            itsStudentsForTeacherChosenEvent += teacherInfoPanelHandler.OnAddStudents;
            AddColumnsToListView();
        }
        private void AddColumnsToListView()
        {
            itsMainWindow.studentsOfTeacherListView.Columns.Clear();
            itsMainWindow.studentsOfTeacherListView.Columns.Add("Name");
            itsMainWindow.studentsOfTeacherListView.Columns.Add("Age");
            itsMainWindow.studentsOfTeacherListView.Columns.Add("Record book");
            itsMainWindow.studentsOfTeacherListView.Columns.Add("Year in university");
        }

        public void ShowPanel()
        {
            itsMainWindow.studentsOfTeacherPanel.Show();
            UniversityView.ShowStudentsInfo(itsMainWindow.studentsInfoPanelHandler.GetStudents(), itsMainWindow.studentsOfTeacherListView);
        }
        public void HidePanel()
        {
            itsMainWindow.studentsOfTeacherPanel.Hide();
        }

        public void ChooseStudentsForTeacher()
        {
            List<Student> studentsOfTeacher = StudentConverter.ToStudentList(itsMainWindow.studentsInfoPanelHandler.GetStudents()
                , itsMainWindow.studentsOfTeacherListView.SelectedIndices);
            List<IWarning> warnings = StudentValidator.CheckStudentsOfTeacher(studentsOfTeacher);
            if (warnings.Count == 0)
                itsStudentsForTeacherChosenEvent(studentsOfTeacher);
            else
                WarningDisplayer.ShowWarning(itsMainWindow.warningPanel3, itsMainWindow.warningTextBox3, warnings);
        }
    }
}