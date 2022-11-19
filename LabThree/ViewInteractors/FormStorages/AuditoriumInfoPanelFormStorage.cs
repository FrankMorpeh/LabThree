using LabThree.Controllers;
using LabTwo.Models.Auditoriums;

namespace LabTwo.ViewInteractors.FormStorages
{
    public class AuditoriumInfoPanelFormStorage
    {
        private AuditoriumController itsAuditoriumController;

        public AuditoriumInfoPanelFormStorage() { itsAuditoriumController = new AuditoriumController(); }
        public List<Auditorium> Auditoriums { get { return itsAuditoriumController.Auditoriums; } set { itsAuditoriumController.Auditoriums = value; } }
    }
}