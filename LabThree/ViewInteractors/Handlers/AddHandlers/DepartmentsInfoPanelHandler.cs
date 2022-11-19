using LabTwo.ViewInteractors.FormStorages;
using LabTwo.Validators.DepartmentValidators;
using LabTwo.Warnings;
using LabTwo.Converters.DepartmentConverters;
using LabTwo.View;

namespace LabTwo.ViewInteractors.Handlers
{
    public class DepartmentsInfoPanelHandler : IPanelHandler
    {
        private Form1 itsMainWindow;
        DepartmentsInfoPanelFormStorage itsDepartmentsInfoPanelFormStorage;
        public DepartmentsInfoPanelFormStorage DepartmentsInfoPanelFormStorage { get { return itsDepartmentsInfoPanelFormStorage; } }

        public DepartmentsInfoPanelHandler(Form1 mainWindow)
        {
            itsMainWindow = mainWindow;
            itsDepartmentsInfoPanelFormStorage = new DepartmentsInfoPanelFormStorage() { Departments = new List<Models.Departments.Department>() };
            AddColumnsToListView();
        }
        private void AddColumnsToListView()
        {
            itsMainWindow.departmentsListView.Columns.Clear();
            itsMainWindow.departmentsListView.Columns.Add("Name");
            itsMainWindow.departmentsListView.Columns.Add("Deanery cabinet");
        }

        public void ShowPanel()
        {
            itsMainWindow.departmentsPanel.Show();
            ShowDepartments();
        }
        public void HidePanel()
        {
            itsMainWindow.departmentsPanel.Hide();
        }
        public DepartmentsInfoPanelFormStorage GetTemporaryDepartments()
        {
            return itsDepartmentsInfoPanelFormStorage;
        }
        private void ShowDepartments()
        {
            itsMainWindow.departmentsListView.Items.Clear();
            UniversityView.ShowDepartmentsInfo(itsDepartmentsInfoPanelFormStorage.Departments, itsMainWindow.departmentsListView);
        }
        public void AddDepartment(SubjectsInfoPanelFormStorage subjectsInfoPanelFormStorage)
        {
            if (AddDepartmentToList(subjectsInfoPanelFormStorage) == true)
                ShowDepartments();
        }
        private bool AddDepartmentToList(SubjectsInfoPanelFormStorage subjectsInfoPanelFormStorage)
        {
            List<IWarning> warnings = DepartmentValidator.CheckDepartment(itsMainWindow.departmentNameTextBox.Text
                , itsMainWindow.deaneryCabinetNumberTextBox.Text, new List<string>(), new List<string>());
            if (warnings.Count == 0)
            {
                itsDepartmentsInfoPanelFormStorage.Departments.Add(DepartmentConverter.ToDepartment(itsMainWindow.departmentNameTextBox.Text
                    , itsMainWindow.deaneryCabinetNumberTextBox.Text, subjectsInfoPanelFormStorage.Subjects));
                return true;
            }
            else
            {
                WarningDisplayer.ShowWarning(itsMainWindow.warningPanel3, itsMainWindow.warningTextBox3, warnings);
                return false;
            }
        }
        public void BlockSubjectAddingButton()
        {
            itsMainWindow.addSubjectsButton.Enabled = false;
        }
        public void UnblockSubjectAddingButton()
        {
            itsMainWindow.addSubjectsButton.Enabled = true;
        }
    }
}