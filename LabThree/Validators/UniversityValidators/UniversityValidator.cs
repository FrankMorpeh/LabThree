using LabTwo.Warnings;

namespace LabTwo.Validators.UniversityValidators
{
    public static class UniversityValidator
    {
        public static List<IWarning> CheckUniversity(string name, string foundationYear, string rank)
        {
            List<IWarning> warnings = new List<IWarning>();
            if (CommonValidator.UniversityNameIsValid(name) == false)
                warnings.Add(new IncorrectUniversityName());
            if (FoundationYearIsValid(foundationYear) == false)
                warnings.Add(new IncorrectFoundationYear());
            if (RankIsValid(rank) == false)
                warnings.Add(new IncorrectRank());
            return warnings;
        }
        private static bool FoundationYearIsValid(string strFoundationYear)
        {
            return CommonValidator.MakeStringConversionCheck(strFoundationYear, ConvertAndCheckFoundationYear);
        }
        private static bool RankIsValid(string strRank)
        {
            return CommonValidator.MakeStringConversionCheck(strRank, ConvertAndCheckRank);
        }
        private static void ConvertAndCheckFoundationYear(string strFoundationYear, ref bool isValid)
        {
            int foundationYear = Convert.ToInt32(strFoundationYear);
            if (foundationYear < 0)
                isValid = false;
        }
        private static void ConvertAndCheckRank(string strRank, ref bool isValid)
        {
            double rank = Convert.ToDouble(strRank);
            if (rank < 0 || rank > 100)
                isValid = false;
        }
    }
}