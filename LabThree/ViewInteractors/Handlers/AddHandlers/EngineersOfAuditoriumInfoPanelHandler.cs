using LabTwo.Converters.WorkerConverters;
using LabTwo.Models.Workers.Engineers;
using LabTwo.Validators.EngineerValidators;
using LabTwo.View;
using LabTwo.Warnings;

namespace LabTwo.ViewInteractors.Handlers
{
    public class EngineersOfAuditoriumInfoPanelHandler : IPanelHandler
    {
        private Form1 itsMainWindow;
        private event Action<List<Engineer>> itsEngineersForAuditoriumChosenEvent;

        public EngineersOfAuditoriumInfoPanelHandler(Form1 mainWindow, AuditoriumInfoPanelHandler auditoriumInfoPanelHandler)
        {
            itsMainWindow = mainWindow;
            itsEngineersForAuditoriumChosenEvent += auditoriumInfoPanelHandler.OnAddEngineers;
            AddColumnsToListView();
        }
        private void AddColumnsToListView()
        {
            itsMainWindow.engineersOfAuditoriumListView.Columns.Clear();
            itsMainWindow.engineersOfAuditoriumListView.Columns.Add("Name");
            itsMainWindow.engineersOfAuditoriumListView.Columns.Add("Age");
            itsMainWindow.engineersOfAuditoriumListView.Columns.Add("Passport");
            itsMainWindow.engineersOfAuditoriumListView.Columns.Add("Has certificate");
            itsMainWindow.engineersOfAuditoriumListView.Columns.Add("Working years");
        }

        public void ChooseEngineers()
        {
            List<Engineer> engineersOfAuditorium = EngineerConverter.ToEngineerList(itsMainWindow.engineerInfoPanelHandler.GetEngineers()
                , itsMainWindow.engineersOfAuditoriumListView.SelectedIndices);
            List<IWarning> warnings = EngineerValidator.CheckEngineersForAuditorium(engineersOfAuditorium);
            if (warnings.Count == 0)
                itsEngineersForAuditoriumChosenEvent(engineersOfAuditorium);
            else
                WarningDisplayer.ShowWarning(itsMainWindow.warningPanel3, itsMainWindow.warningTextBox3, warnings);

        }
        public void ShowPanel()
        {
            itsMainWindow.engineersOfAuditoriumPanel.Show();
            UniversityView.ShowEngineersInfo(itsMainWindow.engineerInfoPanelHandler.GetEngineers(), itsMainWindow.engineersOfAuditoriumListView);
        }
        public void HidePanel()
        {
            itsMainWindow.engineersOfAuditoriumPanel.Hide();
        }
    }
}