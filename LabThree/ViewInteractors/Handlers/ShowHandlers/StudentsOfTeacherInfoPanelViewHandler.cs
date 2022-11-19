using LabTwo.View;

namespace LabTwo.ViewInteractors.Handlers.ShowHandlers
{
    public class StudentsOfTeacherInfoPanelViewHandler : IPanelHandler
    {
        private Form1 itsMainWindow;

        public StudentsOfTeacherInfoPanelViewHandler(Form1 mainWindow)
        {
            itsMainWindow = mainWindow;
            AddColumnsToListView();
        }
        private void AddColumnsToListView()
        {
            itsMainWindow.showStudentsOfTeaherListView.Columns.Add("Name");
            itsMainWindow.showStudentsOfTeaherListView.Columns.Add("Age");
            itsMainWindow.showStudentsOfTeaherListView.Columns.Add("Record book");
            itsMainWindow.showStudentsOfTeaherListView.Columns.Add("Year in university");
        }

        public void ShowPanel()
        {
            itsMainWindow.showStudentsOfTeacherPanel.Show();
            itsMainWindow.showStudentsOfTeaherListView.Items.Clear();
            UniversityView.ShowStudentsInfo(itsMainWindow.teachersInfoPanelViewHandler.GetChosenTeacher().Students
                , itsMainWindow.showStudentsOfTeaherListView);
        }
        public void HidePanel()
        {
            itsMainWindow.showStudentsOfTeacherPanel.Hide();
        }
    }
}