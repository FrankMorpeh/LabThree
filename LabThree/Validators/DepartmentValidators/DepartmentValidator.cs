using LabTwo.Warnings;
using LabTwo.Validators.SubjectsValidators;

namespace LabTwo.Validators.DepartmentValidators
{
    public static class DepartmentValidator
    {
        public static List<IWarning> CheckDepartment(string name, string deaneryCabinetNumber, List<string> subjectNames
            , List<string> subjectCredits)
        {
            List<IWarning> warnings = new List<IWarning>();
            if (CommonValidator.UniversityNameIsValid(name) == false)
                warnings.Add(new IncorrectDepartmentName());
            if (IsDeaneryCabinetNumberValid(deaneryCabinetNumber) == false)
                warnings.Add(new IncorrectDeaneryCabinetNumber());
            warnings.AddRange(SubjectValidator.CheckSubjects(subjectNames, subjectCredits));
            return warnings;
        }
        private static bool IsDeaneryCabinetNumberValid(string deaneryCabinetNumber)
        {
            return CommonValidator.MakeStringConversionCheck(deaneryCabinetNumber, ConvertAndCheckDeaneryCabinetNumber);
        }
        private static void ConvertAndCheckDeaneryCabinetNumber(string strDeaneryCabinetNumber, ref bool isValid)
        {
            int deaneryCabinetNumber = Convert.ToInt32(strDeaneryCabinetNumber);
            if (deaneryCabinetNumber < 0)
                isValid = false;
        }
    }
}