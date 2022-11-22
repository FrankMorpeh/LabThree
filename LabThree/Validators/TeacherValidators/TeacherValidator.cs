using LabTwo.Warnings;

namespace LabTwo.Validators.TeacherValidators
{
    public static class TeacherValidator
    {
        public static List<IWarning> CheckTeacher(string name, string age, string passport, string numberOfSubjects, string numberOfScientificWorks)
        {
            List<IWarning> warnings = new List<IWarning>();
            if (CommonValidator.PersonNameIsValid(name) == false)
                warnings.Add(new IncorrectPersonName());
            if (CommonValidator.PersonAgeIsValid(age) == false)
                warnings.Add(new IncorrectPersonAge());
            if (CommonValidator.WorkerPassportIsValid(passport) == false)
                warnings.Add(new IncorrectPassport());
            if (NumberOfSubjectsIsCorrect(numberOfSubjects) == false)
                warnings.Add(new IncorrectNumberOfSubjects());
            if (CommonValidator.NumberBiggerThanZero(numberOfScientificWorks) == false)
                warnings.Add(new IncorrectNumberOfScientificWorks());
            return warnings;
        }
        private static bool NumberOfSubjectsIsCorrect(string numberOfSubjects)
        {
            return CommonValidator.MakeStringConversionCheck(numberOfSubjects, CheckNumberOfSubjects);
        }
        private static void CheckNumberOfSubjects(string strNumberOfSubjects, ref bool isValid)
        {
            double numberOfSubjects = Convert.ToDouble(strNumberOfSubjects);
            if (numberOfSubjects < 0 || numberOfSubjects > 5)
                isValid = false;
        }
    }
}