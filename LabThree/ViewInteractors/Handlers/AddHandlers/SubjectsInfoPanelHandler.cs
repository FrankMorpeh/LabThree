using LabTwo.Converters.SubjectsConverters;
using LabTwo.Validators.SubjectsValidators;
using LabTwo.View;
using LabTwo.ViewInteractors.FormStorages;
using LabTwo.Warnings;

namespace LabTwo.ViewInteractors.Handlers
{
    public class SubjectsInfoPanelHandler : IPanelHandler
    {
        private Form1 itsMainWindow;
        private SubjectsInfoPanelFormStorage itsSubjectsInfoPanelFormStorage;

        public SubjectsInfoPanelHandler(Form1 mainWindow)
        {
            itsMainWindow = mainWindow;
            itsSubjectsInfoPanelFormStorage = new SubjectsInfoPanelFormStorage();
            AddColumnsToListView();
        }
        private void AddColumnsToListView()
        {
            itsMainWindow.subjectsListView.Columns.Clear();
            itsMainWindow.subjectsListView.Columns.Add("Name");
            itsMainWindow.subjectsListView.Columns.Add("Credit");
        }

        public SubjectsInfoPanelFormStorage GetTemporarySubjects()
        {
            return itsSubjectsInfoPanelFormStorage;
        }
        public void ShowPanel()
        {
            itsSubjectsInfoPanelFormStorage.Subjects = new List<Models.Subjects.Subject>();
            EmptyOldValues();
            itsMainWindow.subjectsPanel.Show();
        }
        private void EmptyOldValues()
        {
            itsMainWindow.subjectsListView.Items.Clear();
            itsMainWindow.subjectNameTextBox.Text = string.Empty;
            itsMainWindow.subjectCreditTextBox.Text = string.Empty;
        }
        public void HidePanel()
        {
            itsMainWindow.subjectsPanel.Hide();
        }
        public void AddSubject()
        {
            List<IWarning> warnings = SubjectValidator.CheckSubject(itsMainWindow.subjectNameTextBox.Text, itsMainWindow.subjectCreditTextBox.Text);
            if (warnings.Count == 0)
            {
                itsSubjectsInfoPanelFormStorage.Subjects.Add(SubjectConverter.ToSubject(itsMainWindow.subjectNameTextBox.Text
                    , itsMainWindow.subjectCreditTextBox.Text));
                UniversityView.ShowSubjectsInfo(itsSubjectsInfoPanelFormStorage.Subjects, itsMainWindow.subjectsListView);
            }
            else
                WarningDisplayer.ShowWarning(itsMainWindow.warningPanel3, itsMainWindow.warningTextBox3, warnings);
        }
    }
}