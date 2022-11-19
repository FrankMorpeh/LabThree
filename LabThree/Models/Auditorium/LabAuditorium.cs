using LabTwo.Models.Workers.Engineers;

namespace LabTwo.Models.Auditoriums
{
    public class LabAuditorium : Auditorium, IEquatable<LabAuditorium>
    {
        private int itsNumberOfDevices;
        private double itsWifiSpeed;

        public int NumberOfDevices { get { return itsNumberOfDevices; } set { itsNumberOfDevices = value; } }
        public double WifiSpeed { get { return itsWifiSpeed;} set { itsWifiSpeed = value; } }

        public LabAuditorium()
        {
            itsNumberOfDevices = 0;
            itsWifiSpeed = 0.0;
        }
        public LabAuditorium(string codeName, int capacity, List<Engineer> engineers, int numberOfDevices, double wifiSpeed) 
            : base(codeName, capacity, engineers)
        {
            itsNumberOfDevices = numberOfDevices;
            itsWifiSpeed = wifiSpeed;
        }


        public bool Equals(LabAuditorium rhs)
        {
            return itsCodeName == rhs.itsCodeName && itsCapacity == rhs.itsCapacity && itsEngineers.Equals(rhs.itsEngineers)
                && itsNumberOfDevices == rhs.itsNumberOfDevices && itsWifiSpeed == rhs.itsWifiSpeed;
        }
    }
}