using LabTwo.View;

namespace LabTwo.ViewInteractors.Handlers.ShowHandlers
{
    public class SubjectsOfDepartmentInfoPanelViewHandler : IPanelHandler
    {
        private Form1 itsMainWindow;

        public SubjectsOfDepartmentInfoPanelViewHandler(Form1 mainWindow)
        {
            itsMainWindow = mainWindow;
            AddColumnsToListView();
        }
        private void AddColumnsToListView()
        {
            itsMainWindow.showSubjectsOfDepartmentListView.Columns.Add("Subject");
            itsMainWindow.showSubjectsOfDepartmentListView.Columns.Add("Credit");
        }

        public void ShowPanel()
        {
            itsMainWindow.showSubjectsOfDepartmentPanel.Show();
            itsMainWindow.showSubjectsOfDepartmentListView.Items.Clear();
            UniversityView.ShowSubjectsInfo(itsMainWindow.departmentsInfoPanelViewHandler.GetChosenDepartment().Subjects
                , itsMainWindow.showSubjectsOfDepartmentListView);
        }
        public void HidePanel()
        {
            itsMainWindow.showSubjectsOfDepartmentPanel.Hide();
        }
    }
}