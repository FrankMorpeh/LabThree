using LabTwo.Warnings;

namespace LabTwo.Validators.TeacherValidators
{
    public static class TeacherValidator
    {
        public static List<IWarning> CheckTeacher(string name, string age, string salary)
        {
            List<IWarning> warnings = new List<IWarning>();
            if (CommonValidator.PersonNameIsValid(name) == false)
                warnings.Add(new IncorrectPersonName());
            if (CommonValidator.PersonAgeIsValid(age) == false)
                warnings.Add(new IncorrectPersonAge());
            if (CommonValidator.WorkerSalaryIsValid(salary) == false)
                warnings.Add(new IncorrectSalary());
            return warnings;
        }
    }
}