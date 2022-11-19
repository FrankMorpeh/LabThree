using LabTwo.Converters.AuditoriumConverters;
using LabTwo.Models.Workers.Engineers;
using LabTwo.Validators.AuditoriumValidators;
using LabTwo.View;
using LabTwo.ViewInteractors.FormStorages;
using LabTwo.Warnings;

namespace LabTwo.ViewInteractors.Handlers
{
    public class AuditoriumInfoPanelHandler : IPanelHandler
    {
        private Form1 itsMainWindow;
        private AuditoriumInfoPanelFormStorage itsAuditoriumInfoPanelFormStorage;
        private List<Engineer> itsEngineersOfAuditorium;

        public AuditoriumInfoPanelFormStorage AuditoriumInfoPanelFormStorage { get { return itsAuditoriumInfoPanelFormStorage; } }

        public AuditoriumInfoPanelHandler(Form1 mainWindow)
        {
            itsMainWindow = mainWindow;
            itsAuditoriumInfoPanelFormStorage = new AuditoriumInfoPanelFormStorage();
            AddColumnsToListView();
            AddComboBoxVariants();
        }
        private void AddColumnsToListView()
        {
            itsMainWindow.auditoriumsListView.Columns.Clear();
            itsMainWindow.auditoriumsListView.Columns.Add("Type");
            itsMainWindow.auditoriumsListView.Columns.Add("Code name");
            itsMainWindow.auditoriumsListView.Columns.Add("Capacity");
            itsMainWindow.auditoriumsListView.Columns.Add("Engineers");
        }
        private void AddComboBoxVariants()
        {
            itsMainWindow.auditoriumTypeComboBox.Items.Clear();
            itsMainWindow.auditoriumTypeComboBox.Items.Add("Lecture");
            itsMainWindow.auditoriumTypeComboBox.Items.Add("Lab");

            itsMainWindow.hasProjectorComboBox.Items.Clear();
            itsMainWindow.hasProjectorComboBox.Items.Add("true");
            itsMainWindow.hasProjectorComboBox.Items.Add("false");
        }

        public void ShowPanel()
        {
            itsMainWindow.auditoriumPanel.Show();
        }
        public void HidePanel()
        {
            itsMainWindow.auditoriumPanel.Hide();
        }
        public void ChangeLabelAccordingToCurrentAuditoriumType()
        {
            if (itsMainWindow.auditoriumTypeComboBox.SelectedIndex == 0) // lecture
            {
                itsMainWindow.auditoriumNumberOfDevicesLabel.Hide();
                itsMainWindow.auditoriumNumberOfRowsLabel.Show();

                itsMainWindow.wifiSpeedLabel.Hide();
                itsMainWindow.wifiSpeedTextBox.Hide();
                itsMainWindow.hasProjectorLabel.Show();
                itsMainWindow.hasProjectorComboBox.Show();
            }
            else // lab
            {
                itsMainWindow.auditoriumNumberOfRowsLabel.Hide();
                itsMainWindow.auditoriumNumberOfDevicesLabel.Show();

                itsMainWindow.wifiSpeedLabel.Show();
                itsMainWindow.wifiSpeedTextBox.Show();
                itsMainWindow.hasProjectorLabel.Hide();
                itsMainWindow.hasProjectorComboBox.Hide();
            }
        }
        public void OnAddEngineers(List<Engineer> engineers)
        {
            itsEngineersOfAuditorium = engineers;
        }
        public void BlockEngineerAddingButton()
        {
            itsMainWindow.auditoriumAddEngineersButton.Enabled = false;
        }
        public void AddAuditorium()
        {
            List<IWarning> warnings = new List<IWarning>();
            if (itsMainWindow.auditoriumTypeComboBox.SelectedIndex == 0) // lecture auditorium
            {
                warnings = LectureAuditoriumValidator.CheckLectureAuditorium(itsMainWindow.auditoriumCodeNameTextBox.Text
                    , itsMainWindow.auditoriumCapacityTextBox.Text, itsMainWindow.auditoriumNumberOfRowsOrDevicesTextBox.Text);
                if (warnings.Count == 0)
                {
                    itsAuditoriumInfoPanelFormStorage.Auditoriums.Add(LectureAuditoriumConverter.ToLectureAuditorium(
                        itsMainWindow.auditoriumCodeNameTextBox.Text, itsMainWindow.auditoriumCapacityTextBox.Text
                        , itsEngineersOfAuditorium, itsMainWindow.auditoriumNumberOfRowsOrDevicesTextBox.Text, itsMainWindow.hasProjectorComboBox.SelectedText));
                    UniversityView.ShowAuditoriumsInfo(itsAuditoriumInfoPanelFormStorage.Auditoriums, itsMainWindow.auditoriumsListView);
                    itsMainWindow.auditoriumAddEngineersButton.Enabled = true;
                }
                else
                    WarningDisplayer.ShowWarning(itsMainWindow.warningPanel3, itsMainWindow.warningTextBox3, warnings);

            }
            else // lab auditorium
            {
                warnings = LabAuditoriumValidator.CheckLabAuditorium(itsMainWindow.auditoriumCodeNameTextBox.Text
                    , itsMainWindow.auditoriumCapacityTextBox.Text, itsMainWindow.auditoriumNumberOfRowsOrDevicesTextBox.Text
                    , itsMainWindow.wifiSpeedTextBox.Text);
                if (warnings.Count == 0)
                {
                    itsAuditoriumInfoPanelFormStorage.Auditoriums.Add(LabAuditoriumConverter.ToLabAuditorium(itsMainWindow.auditoriumCodeNameTextBox.Text
                        , itsMainWindow.auditoriumCapacityTextBox.Text, itsEngineersOfAuditorium
                        , itsMainWindow.auditoriumNumberOfRowsOrDevicesTextBox.Text, itsMainWindow.wifiSpeedTextBox.Text));
                    UniversityView.ShowAuditoriumsInfo(itsAuditoriumInfoPanelFormStorage.Auditoriums, itsMainWindow.auditoriumsListView);
                    itsMainWindow.auditoriumAddEngineersButton.Enabled = true;
                }
                else
                    WarningDisplayer.ShowWarning(itsMainWindow.warningPanel, itsMainWindow.warningTextBox, warnings);
            }
        }
    }
}