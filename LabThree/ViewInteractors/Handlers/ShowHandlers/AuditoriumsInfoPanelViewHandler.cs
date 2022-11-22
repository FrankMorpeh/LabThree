using LabTwo.View;
using LabTwo.Warnings;

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
        public void ChangeAuditoriumType()
        {
            if (itsMainWindow.showAuditorimsListView.SelectedIndices.Count > 0)
            {
                itsMainWindow.universityToDisplay.ChangeAuditoriumType(itsMainWindow.showAuditorimsListView.SelectedIndices[0]);
                UniversityView.ShowAuditoriumsInfo(itsMainWindow.universityToDisplay.Auditoriums, itsMainWindow.showAuditorimsListView);
            }
            else
                WarningDisplayer.ShowWarning(itsMainWindow.warningPanel2, itsMainWindow.warningTextBox2, new List<IWarning>() { new AuditoriumNotChosen() });
        }
        public void ShowSuitabilityOfAuditorium()
        {
            if (itsMainWindow.showAuditorimsListView.SelectedIndices.Count > 0)
            {
                if (itsMainWindow.universityToDisplay.AuditoriumIsSuitableForLessons(itsMainWindow.showAuditorimsListView.SelectedIndices[0]))
                    itsMainWindow.warningTextBox2.Text = "Auditorium is suitable for lessons";
                else
                    itsMainWindow.warningTextBox2.Text = "Auditorium is not suitable for lessons";
                itsMainWindow.warningPanel2.Show();
            }
            else
                WarningDisplayer.ShowWarning(itsMainWindow.warningPanel2, itsMainWindow.warningTextBox2, new List<IWarning>() { new AuditoriumNotChosen() });
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