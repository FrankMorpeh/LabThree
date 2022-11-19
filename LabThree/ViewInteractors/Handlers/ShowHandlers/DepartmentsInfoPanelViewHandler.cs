using LabTwo.Models.Departments;
using LabTwo.View;
using LabTwo.Warnings;

namespace LabTwo.ViewInteractors.Handlers.ShowHandlers
{
    public class DepartmentsInfoPanelViewHandler : IPanelHandler
    {
        private Form1 itsMainWindow;
        private Department itsChosenDepartment;

        public DepartmentsInfoPanelViewHandler(Form1 mainWindow)
        {
            itsMainWindow = mainWindow;
            AddColumnsToListView();
        }
        private void AddColumnsToListView()
        {
            itsMainWindow.showDepartmentsListView.Columns.Add("Name");
            itsMainWindow.showDepartmentsListView.Columns.Add("Deanery cabinet");
        }

        public Department GetChosenDepartment()
        {
            return itsChosenDepartment;
        }
        public void ShowPanel()
        {
            itsMainWindow.showInfoAboutDepartmentsPanel.Show();
            itsMainWindow.showDepartmentsListView.Items.Clear();
            UniversityView.ShowDepartmentsInfo(itsMainWindow.universityToDisplay.Departments, itsMainWindow.showDepartmentsListView);
        }
        public void HidePanel()
        {
            itsMainWindow.showInfoAboutDepartmentsPanel.Hide();
        }
        public void ShowSubjectsOfDepartment()
        {
            if (itsMainWindow.showDepartmentsListView.SelectedIndices.Count > 0)
            {
                itsChosenDepartment = itsMainWindow.universityToDisplay.Departments[itsMainWindow.showDepartmentsListView.SelectedIndices[0]];
                itsMainWindow.showInfoPanelController.ShowPanel(itsMainWindow.subjectsOfDepartmentInfoPanelViewHandler);
            }
            else
                WarningDisplayer.ShowWarning(itsMainWindow.warningPanel2, itsMainWindow.warningTextBox2, new List<IWarning>() { new DepartmentNotChosen() });
        }
    }
}