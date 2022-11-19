using LabTwo.Models.Workers.Engineers;

namespace LabTwo.Models.Auditoriums
{
    public class LabAuditorium : Auditorium, IEquatable<LabAuditorium>
    {
        private int itsNumberOfDevices;

        public int NumberOfDevices { get { return itsNumberOfDevices; } set { itsNumberOfDevices = value; } }

        public LabAuditorium()
        {
            itsNumberOfDevices = 0;
        }
        public LabAuditorium(string codeName, int capacity, List<Engineer> engineers, int numberOfDevices) 
            : base(codeName, capacity, engineers)
        {
            itsNumberOfDevices = numberOfDevices;
        }


        public bool Equals(LabAuditorium rhs)
        {
            return itsCodeName == rhs.itsCodeName && itsCapacity == rhs.itsCapacity && itsEngineers.Equals(rhs.itsEngineers)
                && itsNumberOfDevices == rhs.itsNumberOfDevices;
        }
    }
}