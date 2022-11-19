using LabTwo.Warnings;

namespace LabTwo.Validators.SubjectsValidators
{
    public static class SubjectValidator
    {
        public static List<IWarning> CheckSubject(string subjectName, string subjectCredit)
        {
            List<IWarning> warnings = new List<IWarning>();
            if (CommonValidator.UniversityNameIsValid(subjectName) == false)
                warnings.Add(new IncorrectSubjectName());
            if (CreditIsValid(subjectCredit) == false)
                warnings.Add(new IncorrectSubjectCredit());
            return warnings;
        }
        public static List<IWarning> CheckSubjects(List<string> subjectNames, List<string> subjectCredits)
        {
            List<IWarning> warnings = new List<IWarning>();
            CheckSubjectNames(subjectNames, warnings);
            CheckSubjectCredits(subjectCredits, warnings);
            return warnings;
        }
        private static void CheckSubjectNames(List<string> subjectNames, List<IWarning> warnings)
        {
            foreach (string subjectName in subjectNames)
            {
                if (CommonValidator.UniversityNameIsValid(subjectName) == false)
                {
                    warnings.Add(new IncorrectSubjectName());
                    break;
                }
            }
        }
        private static void CheckSubjectCredits(List<string> subjectCredits, List<IWarning> warnings)
        {
            foreach (string subjectCredit in subjectCredits)
            {
                if (CreditIsValid(subjectCredit) == false)
                {
                    warnings.Add(new IncorrectSubjectCredit());
                    break;
                }
            }
        }
        private static bool CreditIsValid(string credit)
        {
            return CommonValidator.MakeStringConversionCheck(credit, ConvertAndCheckCredit);
        }
        private static void ConvertAndCheckCredit(string strCredit, ref bool isValid)
        {
            double credit = Convert.ToDouble(strCredit);
            if (credit < 0)
                isValid = false;
        }
    }
}