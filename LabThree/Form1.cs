using LabThree.Serialization;
using LabTwo.Controllers;
using LabTwo.Controllers.UniversityController;
using LabTwo.Models.University;
using LabTwo.View;
using LabTwo.ViewInteractors.Handlers;
using LabTwo.ViewInteractors.Handlers.ShowHandlers;
using LabTwo.Warnings;
using System.Windows.Forms;

namespace LabTwo
{
    public partial class Form1 : Form
    {
        public static string initialLocation;

        public MainPanelHandler mainPanelHandler;
        public CombineUniversititesHandler combineUniversititesHandler;
        public MainInfoPanelHandler mainInfoPanelHandler;
        public DepartmentsInfoPanelHandler departmentsInfoPanelHandler;
        public SubjectsInfoPanelHandler subjectsInfoPanelHandler;
        public StudentsInfoPanelHandler studentsInfoPanelHandler;
        public TeacherInfoPanelHandler teacherInfoPanelHandler;
        public StudentsOfTeacherInfoPanelHandler studentsOfTeacherInfoPanelHandler;
        public EngineerInfoPanelHandler engineerInfoPanelHandler;
        public AuditoriumInfoPanelHandler auditoriumInfoPanelHandler;
        public EngineersOfAuditoriumInfoPanelHandler engineersOfAuditoriumInfoPanelHandler;

        public MainInfoPanelViewHandler mainInfoPanelViewHandler;
        public DepartmentsInfoPanelViewHandler departmentsInfoPanelViewHandler;
        public SubjectsOfDepartmentInfoPanelViewHandler subjectsOfDepartmentInfoPanelViewHandler;
        public TeachersInfoPanelViewHandler teachersInfoPanelViewHandler;
        public StudentsOfTeacherInfoPanelViewHandler studentsOfTeacherInfoPanelViewHandler;
        public AuditoriumsInfoPanelViewHandler auditoriumsInfoPanelViewHandler;

        public PanelController panelController;
        public ShowInfoPanelController showInfoPanelController;
        public UniversityController universityController;
        public UniversityView universityView;
        public University universityToDisplay;
        static Form1()
        {
            initialLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            initialLocation = System.IO.Path.GetDirectoryName(initialLocation);
        }
        public Form1()
        {
            InitializeComponent();
            InitializeExtraViewComponents();

            //universityController = UniversitySerializer.DeserializeUniversities();
            //if (universityController == null) // if deserialization isn't successful, then just create a controller
            universityController = new UniversityController();
            universityView = new UniversityView(universityController);

            universityView.ShowPreviewInfo(universityComboBox);
        }
        private void InitializeExtraViewComponents()
        {
            mainPanelHandler = new MainPanelHandler(this);
            combineUniversititesHandler = new CombineUniversititesHandler(this);
            mainInfoPanelHandler = new MainInfoPanelHandler(this);
            departmentsInfoPanelHandler = new DepartmentsInfoPanelHandler(this);
            subjectsInfoPanelHandler = new SubjectsInfoPanelHandler(this);
            studentsInfoPanelHandler = new StudentsInfoPanelHandler(this);
            teacherInfoPanelHandler = new TeacherInfoPanelHandler(this);
            studentsOfTeacherInfoPanelHandler = new StudentsOfTeacherInfoPanelHandler(this, teacherInfoPanelHandler);
            engineerInfoPanelHandler = new EngineerInfoPanelHandler(this);
            auditoriumInfoPanelHandler = new AuditoriumInfoPanelHandler(this);
            engineersOfAuditoriumInfoPanelHandler = new EngineersOfAuditoriumInfoPanelHandler(this, auditoriumInfoPanelHandler);
            
            mainInfoPanelViewHandler = new MainInfoPanelViewHandler(this);
            departmentsInfoPanelViewHandler = new DepartmentsInfoPanelViewHandler(this);
            subjectsOfDepartmentInfoPanelViewHandler = new SubjectsOfDepartmentInfoPanelViewHandler(this);
            teachersInfoPanelViewHandler = new TeachersInfoPanelViewHandler(this);
            studentsOfTeacherInfoPanelViewHandler = new StudentsOfTeacherInfoPanelViewHandler(this);
            auditoriumsInfoPanelViewHandler = new AuditoriumsInfoPanelViewHandler(this);

            panelController = new PanelController(this);
            showInfoPanelController = new ShowInfoPanelController(this);
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            WarningDisplayer.CloseWarning(warningPanel, warningTextBox);
            combineUniversitiesPanel.Hide();
            addUniversityPanel.Hide();
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json Files (*.json)|*.json";
            openFileDialog.InitialDirectory = Form1.initialLocation;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                universityController = UniversitySerializer.DeserializeUniversities(openFileDialog.FileName);
                universityView = new UniversityView(universityController);
                mainPanelHandler.LoadUniversitiesToComboBox();
            }
        }

        private void addUniversityButton_Click(object sender, EventArgs e)
        {
            //panelController.ShowPanel(addUniversityPanelHandler);
            addUniversityPanel.Show();
        }

        private void mainInfoButton_Click(object sender, EventArgs e)
        {
            panelController.ShowPanel(mainInfoPanelHandler);
        }

        private void okWarningButton_Click(object sender, EventArgs e)
        {
            WarningDisplayer.CloseWarning(warningPanel, warningTextBox);
        }

        private void okWarningButton2_Click(object sender, EventArgs e)
        {
            WarningDisplayer.CloseWarning(warningPanel2, warningTextBox2);
        }

        private void okWarningButton3_Click(object sender, EventArgs e)
        {
            WarningDisplayer.CloseWarning(warningPanel3, warningTextBox3);
        }

        private void saveMainInfoButton_Click(object sender, EventArgs e)
        {
            mainInfoPanelHandler.SaveChanges();
        }

        private void addDepartmentButton_Click(object sender, EventArgs e)
        {
            departmentsInfoPanelHandler.AddDepartment(subjectsInfoPanelHandler.GetTemporarySubjects());
            departmentsInfoPanelHandler.UnblockSubjectAddingButton();
        }

        private void departmentsButton_Click(object sender, EventArgs e)
        {
            panelController.ShowPanel(departmentsInfoPanelHandler);
        }

        private void addSubjectsButton_Click(object sender, EventArgs e)
        {
            panelController.ShowPanel(subjectsInfoPanelHandler);
        }
        
        private void addSubjectButton_Click(object sender, EventArgs e)
        {
            subjectsInfoPanelHandler.AddSubject();
        }

        private void saveSubjectsButton_Click(object sender, EventArgs e)
        {
            panelController.ShowPanel(departmentsInfoPanelHandler);
            departmentsInfoPanelHandler.BlockSubjectAddingButton();
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            studentsInfoPanelHandler.AddStudent();
        }

        private void studentsButton_Click(object sender, EventArgs e)
        {
            panelController.ShowPanel(studentsInfoPanelHandler);
        }

        private void chooseStudentsOfTeacherButton_Click(object sender, EventArgs e)
        {
            studentsOfTeacherInfoPanelHandler.ChooseStudentsForTeacher();
            panelController.ShowPanel(teacherInfoPanelHandler);
        }

        private void addTeacherButton_Click(object sender, EventArgs e)
        {
            teacherInfoPanelHandler.AddTeacher();
        }

        private void teachersButton_Click(object sender, EventArgs e)
        {
            panelController.ShowPanel(teacherInfoPanelHandler);
        }

        private void addStudentToTeacherButton_Click(object sender, EventArgs e)
        {
            panelController.ShowPanel(studentsOfTeacherInfoPanelHandler);
        }

        private void addEngineerButton_Click(object sender, EventArgs e)
        {
            engineerInfoPanelHandler.AddEngineer();
        }

        private void engineersButton_Click(object sender, EventArgs e)
        {
            panelController.ShowPanel(engineerInfoPanelHandler);
        }

        private void auditoriumTypeComboBox_Changed(object sender, EventArgs e)
        {
            auditoriumInfoPanelHandler.ChangeLabelAccordingToCurrentAuditoriumType();
        }

        private void auditoriumAddEngineersButton_Click(object sender, EventArgs e)
        {
            panelController.ShowPanel(engineersOfAuditoriumInfoPanelHandler);
        }

        private void chooseEngineersOfAuditoriumButton_Click(object sender, EventArgs e)
        {
            engineersOfAuditoriumInfoPanelHandler.ChooseEngineers();
            auditoriumInfoPanelHandler.BlockEngineerAddingButton();
            panelController.ShowPanel(auditoriumInfoPanelHandler);
        }

        private void auditoriumsButton_Click(object sender, EventArgs e)
        {
            panelController.ShowPanel(auditoriumInfoPanelHandler);
        }

        private void auditoriumCreateButton_Click(object sender, EventArgs e)
        {
            auditoriumInfoPanelHandler.AddAuditorium();
        }

        private void createUniversityButton_Click(object sender, EventArgs e)
        {
            mainPanelHandler.AddUniversity();
            mainInfoPanel.Hide();
            departmentsPanel.Hide();
            studentsPanel.Hide();
            teachersPanel.Hide();
            studentsOfTeacherPanel.Hide();
            engineerPanel.Hide();
            auditoriumPanel.Hide();
            engineersOfAuditoriumPanel.Hide();
            addUniversityPanel.Hide();
            mainPanel.Show();
        }

        private void combineUniversitiesButton_Click(object sender, EventArgs e)
        {
            combineUniversitiesPanel.Show();
            combineUniversititesHandler.ShowPanel();
        }

        private void chooseFirstUniversityOfCombineBothButton_Click(object sender, EventArgs e)
        {
            combineUniversititesHandler.ChooseFirstUniversityOrCombineBothUniversities();
        }

        private void openUniversityButton_Click(object sender, EventArgs e)
        {
            if (universityComboBox.SelectedIndex != -1)
            {
                universityToDisplay = universityController[universityComboBox.SelectedIndex];
                mainPanel.Hide();
                showUniversityPanel.Show();
            }
            else
                WarningDisplayer.ShowWarning(warningPanel, warningTextBox, new List<IWarning>() { new UniversityNotChosen() });
        }

        private void showMainInfoAboutUniversityButton_Click(object sender, EventArgs e)
        {
            showInfoPanelController.ShowPanel(mainInfoPanelViewHandler);
        }

        private void showDepartmentsOfUniversityPanel_Click(object sender, EventArgs e)
        {
            showInfoPanelController.ShowPanel(departmentsInfoPanelViewHandler);
        }

        private void showSubjectsButton_Click(object sender, EventArgs e)
        {
            departmentsInfoPanelViewHandler.ShowSubjectsOfDepartment();
        }

        private void backToDepartmentsButton_Click(object sender, EventArgs e)
        {
            showInfoPanelController.ShowPanel(departmentsInfoPanelViewHandler);
        }

        private void showStudentsButton_Click(object sender, EventArgs e)
        {
            teachersInfoPanelViewHandler.ShowStudentsOfTeacher();
        }

        private void showTeachersOfUniversityButton_Click(object sender, EventArgs e)
        {
            showInfoPanelController.ShowPanel(teachersInfoPanelViewHandler);
        }

        private void goBackToShowingTeachersButton_Click(object sender, EventArgs e)
        {
            showInfoPanelController.ShowPanel(teachersInfoPanelViewHandler);
        }

        private void showAuditoriumsOfUniversityButton_Click(object sender, EventArgs e)
        {
            showInfoPanelController.ShowPanel(auditoriumsInfoPanelViewHandler);
        }

        private void backToMainMenuButton_Click(object sender, EventArgs e)
        {
            showUniversityPanel.Hide();
            mainPanel.Show();
        }

        private void changeAuditoriumTypeButton_Click(object sender, EventArgs e)
        {
            auditoriumsInfoPanelViewHandler.ChangeAuditoriumType();
        }

        private void showTeacherNumberOfPotentialSubjectsButton_Click(object sender, EventArgs e)
        {
            teachersInfoPanelViewHandler.ShowPotentialNumberOfSubjects();
        }

        private void auditoriumIsSuitableForLessonsButton_Click(object sender, EventArgs e)
        {
            auditoriumsInfoPanelViewHandler.ShowSuitabilityOfAuditorium();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to save progress before quitting?", "Exit"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Json Files (*.json)|*.json";
                saveFileDialog.InitialDirectory = Form1.initialLocation;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    UniversitySerializer.SerializeUniversities(saveFileDialog.FileName, universityController);
            }
        }
    }
}