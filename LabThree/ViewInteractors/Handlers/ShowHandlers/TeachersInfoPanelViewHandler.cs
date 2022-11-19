using LabTwo.Models.Workers.Teachers;
using LabTwo.View;
using LabTwo.Warnings;

namespace LabTwo.ViewInteractors.Handlers.ShowHandlers
{
    public class TeachersInfoPanelViewHandler : IPanelHandler
    {
        private Form1 itsMainWindow;
        private Teacher itsChosenTeacher;

        public TeachersInfoPanelViewHandler(Form1 mainWindow)
        {
            itsMainWindow = mainWindow;
            AddColumnsToListView();
        }
        private void AddColumnsToListView()
        {
            itsMainWindow.showTeachersListView.Columns.Add("Name");
            itsMainWindow.showTeachersListView.Columns.Add("Age");
            itsMainWindow.showTeachersListView.Columns.Add("Salary");
        }

        public Teacher GetChosenTeacher()
        {
            return itsChosenTeacher;
        }
        public void ShowPanel()
        {
            itsMainWindow.showTeacherPanel.Show();
            itsMainWindow.showTeachersListView.Items.Clear();
            UniversityView.ShowTeachersInfo(itsMainWindow.universityToDisplay.Workers.OfType<Teacher>().ToList()
                , itsMainWindow.showTeachersListView);
        }
        public void HidePanel()
        {
            itsMainWindow.showTeacherPanel.Hide();
        }
        public void ShowStudentsOfTeacher()
        {
            if (itsMainWindow.showTeachersListView.SelectedIndices.Count > 0)
            {
                itsChosenTeacher = itsMainWindow.universityToDisplay.Workers.OfType<Teacher>().ToList()
                    [itsMainWindow.showTeachersListView.SelectedIndices[0]];
                itsMainWindow.showInfoPanelController.ShowPanel(itsMainWindow.studentsOfTeacherInfoPanelViewHandler);
            }
            else
                WarningDisplayer.ShowWarning(itsMainWindow.warningPanel2, itsMainWindow.warningTextBox2, new List<IWarning>() { new TeacherNotChosen() });
        }
    }
}