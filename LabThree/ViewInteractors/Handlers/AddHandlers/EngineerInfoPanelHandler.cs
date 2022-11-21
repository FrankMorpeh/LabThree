using LabTwo.Converters.WorkerConverters;
using LabTwo.Models.Workers.Engineers;
using LabTwo.Validators.EngineerValidators;
using LabTwo.View;
using LabTwo.ViewInteractors.FormStorages;
using LabTwo.Warnings;

namespace LabTwo.ViewInteractors.Handlers
{
    public class EngineerInfoPanelHandler : IPanelHandler
    {
        private Form1 itsMainWindow;
        private EngineerInfoPanelFormStorage itsEngineerInfoPanelFormStorage;

        public EngineerInfoPanelFormStorage EngineerInfoPanelFormStorage { get { return itsEngineerInfoPanelFormStorage; } }

        public EngineerInfoPanelHandler(Form1 mainWindow)
        {
            itsMainWindow = mainWindow;
            itsEngineerInfoPanelFormStorage = new EngineerInfoPanelFormStorage();
            AddColumnsToListView();
            AddVariantsToComboBox();
        }
        private void AddColumnsToListView()
        {
            itsMainWindow.engineerListView.Columns.Clear();
            itsMainWindow.engineerListView.Columns.Add("Name");
            itsMainWindow.engineerListView.Columns.Add("Age");
            itsMainWindow.engineerListView.Columns.Add("Salary");
            itsMainWindow.engineerListView.Columns.Add("Has certificate");
            itsMainWindow.engineerListView.Columns.Add("Years working");
        }
        private void AddVariantsToComboBox()
        {
            itsMainWindow.engineerHasCertificateComboBox.Items.Clear();
            itsMainWindow.engineerHasCertificateComboBox.Items.Add("true");
            itsMainWindow.engineerHasCertificateComboBox.Items.Add("false");
        }

        public List<Engineer> GetEngineers()
        {
            return itsEngineerInfoPanelFormStorage.Engineers;
        }
        public void ShowPanel()
        {
            itsMainWindow.engineerPanel.Show();
            UniversityView.ShowEngineersInfo(itsEngineerInfoPanelFormStorage.Engineers, itsMainWindow.engineerListView);
        }
        public void HidePanel()
        {
            itsMainWindow.engineerPanel.Hide();
        }
        public void AddEngineer()
        {
            List<IWarning> warnings = EngineerValidator.CheckEngineer(itsMainWindow.engineerNameTextBox.Text, itsMainWindow.engineerAgeTextBox.Text
                , itsMainWindow.engineerPassportTextBox.Text, ((string)itsMainWindow.engineerHasCertificateComboBox.SelectedItem));
            if (warnings.Count == 0)
            {
                itsEngineerInfoPanelFormStorage.Engineers.Add(EngineerConverter.ToEngineer(itsMainWindow.engineerNameTextBox.Text
                    , itsMainWindow.engineerAgeTextBox.Text, itsMainWindow.engineerPassportTextBox.Text
                    , ((string)itsMainWindow.engineerHasCertificateComboBox.SelectedItem), itsMainWindow.engineerYearsWorkingTextBox.Text));
                UniversityView.ShowEngineersInfo(itsEngineerInfoPanelFormStorage.Engineers, itsMainWindow.engineerListView);
            }
            else
                WarningDisplayer.ShowWarning(itsMainWindow.warningPanel3, itsMainWindow.warningTextBox3, warnings);
        }
    }
}