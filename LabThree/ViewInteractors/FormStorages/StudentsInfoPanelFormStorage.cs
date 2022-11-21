using LabTwo.Models.Students;

namespace LabTwo.ViewInteractors.FormStorages
{
    public class StudentsInfoPanelFormStorage
    {
        public StudentsInfoPanelFormStorage() { Students = new List<Student>(); }
        public List<Student> Students { get; set; }
    }
}