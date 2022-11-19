using LabTwo.View;

namespace LabTwo.ViewInteractors.Handlers.ShowHandlers
{
    public class AuditoriumsInfoPanelViewHandler : IPanelHandler
    {
        private Form1 itsMainWindow;

        public AuditoriumsInfoPanelViewHandler(Form1 mainWindow)
        {
            itsMainWindow = mainWindow;
            AddColumnsToListView();
        }
        private void AddColumnsToListView()
        {
            itsMainWindow.showAuditorimsListView.Columns.Add("Type");
            itsMainWindow.showAuditorimsListView.Columns.Add("Code name");
            itsMainWindow.showAuditorimsListView.Columns.Add("Capacity");
            itsMainWindow.showAuditorimsListView.Columns.Add("Engineers");
        }

        public void ShowPanel()
        {
            itsMainWindow.showAuditoriumsPanel.Show();
            itsMainWindow.showAuditorimsListView.Items.Clear();
            UniversityView.ShowAuditoriumsInfo(itsMainWindow.universityToDisplay.Auditoriums, itsMainWindow.showAuditorimsListView);
        }
        public void HidePanel()
        {
            itsMainWindow.showAuditoriumsPanel.Hide();
        }
    }
}