using LabTwo.Models.Students;
using LabTwo.Warnings;

namespace LabTwo.Validators.StudentValidators
{
    public static class StudentValidator
    {
        public static List<IWarning> CheckStudent(string name, string age, string recordBookNumber, string yearInUniversity)
        {
            List<IWarning> warnings = new List<IWarning>();
            if (CommonValidator.PersonNameIsValid(name) == false)
                warnings.Add(new IncorrectPersonName());
            if (CommonValidator.PersonAgeIsValid(age) == false)
                warnings.Add(new IncorrectPersonAge());
            if (RecordBookNumberIsValid(recordBookNumber) == false)
                warnings.Add(new IncorrectRecordBookNumber());
            if (YearInUniversityIsValid(yearInUniversity) == false)
                warnings.Add(new IncorrectYearInUniversity());
            return warnings;
        }
        private static bool RecordBookNumberIsValid(string recordBookNumber)
        {
            return recordBookNumber != string.Empty && recordBookNumber.All(r => char.IsLetter(r)); // if it is not empty, and all characters are digits 
        }
        private static bool YearInUniversityIsValid(string yearInUniversity)
        {
            return CommonValidator.MakeStringConversionCheck(yearInUniversity, ConvertAndCheckYearInUniversity);
        }
        private static void ConvertAndCheckYearInUniversity(string strYearInUniversity, ref bool isValid)
        {
            int yearInUniversity = Convert.ToInt32(strYearInUniversity);
            if (yearInUniversity < 1 || yearInUniversity > 6)
                isValid = false;
        }
        public static List<IWarning> CheckStudentsOfTeacher(List<Student> students)
        {
            if (students.Count <= 10)
                return new List<IWarning>();
            else
                return new List<IWarning>() { new IncorrectStudentsForTeacher() };
        }
    }
}