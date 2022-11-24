using LabTwo;
using LabTwo.Models.Workers;
using LabTwo.ViewInteractors.Handlers;
using LabTwo.Warnings;

namespace LabThree.ViewInteractors.Handlers.ShowHandlers
{
    public class WorkerByPassportInfoPanelViewHandler : IPanelHandler
    {
        private Form1 itsMainWindow;

        public WorkerByPassportInfoPanelViewHandler(Form1 mainWindow)
        {
            itsMainWindow = mainWindow;
        }

        public void ShowPanel()
        {
            itsMainWindow.showWorkerByPassportPanel.Show();
        }
        public void HidePanel()
        {
            itsMainWindow.showWorkerByPassportPanel.Hide();
        }
        public void ShowWorkerByPassport()
        {
            Worker worker = itsMainWindow.universityToDisplay.GetWorkerByPassport(itsMainWindow.showWorkerByPassportTextBox.Text);
            if (worker == null)
                WarningDisplayer.ShowWarning(itsMainWindow.warningPanel2, itsMainWindow.warningTextBox2, new List<IWarning>() { new NoWorkerWithSuchPassport() });
            else
            {
                itsMainWindow.showPassportOfWorkerLabel.Text = worker.Passport;
                itsMainWindow.showNameOfWorkerLabel.Text = worker.Name;
                itsMainWindow.showAgeOfWorkerLabel.Text = Convert.ToString(worker.Age);
            }
        }
    }
}