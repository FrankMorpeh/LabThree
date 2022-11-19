using LabTwo.Warnings;

namespace LabTwo.Validators.AuditoriumValidators
{
    public static class AuditoriumValidator
    {
        public static List<IWarning> CheckAuditorium(string codeName, string capacity)
        {
            List<IWarning> warnings = new List<IWarning>();
            if (CodeNameIsValid(codeName) == false)
                warnings.Add(new IncorrectAuditoriumName());
            if (CommonValidator.NumberBiggerThanZero(capacity) == false)
                warnings.Add(new IncorrectCapacity());
            return warnings;
        }
        private static bool CodeNameIsValid(string codeName)
        {
            return codeName != string.Empty;
        }
        private static bool CapacityIsValid(string capacity)
        {
            return CommonValidator.MakeStringConversionCheck(capacity, ConvertAndCheckCapacity);
        }
        private static void ConvertAndCheckCapacity(string strCapacity, ref bool isValid)
        {
            int capacity = Convert.ToInt32(strCapacity);
            if (capacity < 0)
                isValid = false;
        }
    }
}