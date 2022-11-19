using LabTwo.Models.Auditoriums;

namespace LabThree.Controllers
{
    public class AuditoriumController
    {
        private List<Auditorium> itsAuditoriums;

        public List<Auditorium> Auditoriums { get { return itsAuditoriums; } set { itsAuditoriums = value; } }
        public int LectureAuditoriumsCount { get { return itsAuditoriums.OfType<LectureAuditorium>().Count(); } }
        public int LabAuditoriumsCount { get { return itsAuditoriums.OfType<LabAuditorium>().Count(); } }

        public AuditoriumController()
        {
            itsAuditoriums = new List<Auditorium>();
        }
    }
}