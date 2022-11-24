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
            itsMainWindow.showTeachersListView.Columns.Clear();
            itsMainWindow.showTeachersListView.Columns.Add("Name");
            itsMainWindow.showTeachersListView.Columns.Add("Age");
            itsMainWindow.showTeachersListView.Columns.Add("Passport");
            itsMainWindow.showTeachersListView.Columns.Add("Subjects' number");
            itsMainWindow.showTeachersListView.Columns.Add("Scientific works' number");
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
        public void ShowPotentialNumberOfSubjects()
        {
            if (itsMainWindow.showTeachersListView.SelectedIndices.Count > 0)
            {
                itsMainWindow.warningTextBox2.Text = "The teacher can take " + itsMainWindow.universityToDisplay.
                GetPotentialNumberOfSubjects(itsMainWindow.showTeachersListView.SelectedIndices[0]) + " more subjects";
                itsMainWindow.warningPanel2.Show();
            }
            else
                WarningDisplayer.ShowWarning(itsMainWindow.warningPanel2, itsMainWindow.warningTextBox2, new List<IWarning>() { new TeacherNotChosen() });
        }
    }
}