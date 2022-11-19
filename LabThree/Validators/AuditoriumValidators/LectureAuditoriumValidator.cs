using LabTwo.Warnings;

namespace LabTwo.Validators.AuditoriumValidators
{
    public static class LectureAuditoriumValidator
    {
        public static List<IWarning> CheckLectureAuditorium(string codeName, string capacity, string numberOfRows)
        {
            List<IWarning> warnings = AuditoriumValidator.CheckAuditorium(codeName, capacity);
            if (CommonValidator.NumberBiggerThanZero(numberOfRows) == false)
                warnings.Add(new IncorrectNumberOfRowsInAuditorium());
            return warnings;
        }
    }
}