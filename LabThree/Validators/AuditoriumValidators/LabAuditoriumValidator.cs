using LabTwo.Warnings;

namespace LabTwo.Validators.AuditoriumValidators
{
    public static class LabAuditoriumValidator
    {
        public static List<IWarning> CheckLabAuditorium(string codeName, string capacity, string numberOfDevices)
        {
            List<IWarning> warnings = AuditoriumValidator.CheckAuditorium(codeName, capacity);
            if (CommonValidator.NumberBiggerThanZero(numberOfDevices) == false)
                warnings.Add(new IncorrectNumberOfDevicesInAuditorium());
            return warnings;
        }
    }
}