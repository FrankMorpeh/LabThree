using LabTwo.Models.University;

namespace LabTwo.Controllers.UniversityController
{
    public class UniversityController // stores different universities
    {
        private List<University> itsUniversities;

        public List<University> Universities { get { return itsUniversities; } set { itsUniversities = value; } }
        public int Count { get { return itsUniversities.Count; } }

        public UniversityController() { itsUniversities = new List<University>(); }
        public UniversityController(List<University> universities) { itsUniversities = universities; }

        public void AddUniversity(University university) { itsUniversities.Add(university); }
        public void RemoveUniverstityAt(int index) { itsUniversities.RemoveAt(index); }
        public University this[int index] { get { return itsUniversities[index]; } set { itsUniversities[index] = value; } }
    }
}