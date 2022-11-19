using LabTwo.Models.Auditoriums;
using LabTwo.Models.Workers.Engineers;

namespace LabTwo.Converters.AuditoriumConverters
{
    public static class LabAuditoriumConverter
    {
        public static LabAuditorium ToLabAuditorium(string codeName, string capacity, List<Engineer> engineers, string numberOfDevices)
        {
            return new LabAuditorium(codeName, Convert.ToInt32(capacity), engineers, Convert.ToInt32(numberOfDevices));
        }
    }
}