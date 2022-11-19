namespace LabTwo.ViewInteractors.Handlers.ShowHandlers
{
    public class MainInfoPanelViewHandler : IPanelHandler
    {
        private Form1 itsMainWindow;

        public MainInfoPanelViewHandler(Form1 mainWindow)
        {
            itsMainWindow = mainWindow;
        }

        public void ShowPanel()
        {
            itsMainWindow.showMainInfoAboutUniversityPanel.Show();
            itsMainWindow.universityNameLabel.Text = itsMainWindow.universityToDisplay.Name;
            itsMainWindow.foundationYearLabel.Text = Convert.ToString(itsMainWindow.universityToDisplay.FoundationYear);
            itsMainWindow.rankLabel.Text = Convert.ToString(itsMainWindow.universityToDisplay.Rank);
        }
        public void HidePanel()
        {
            itsMainWindow.showMainInfoAboutUniversityPanel.Hide();
        }
    }
}