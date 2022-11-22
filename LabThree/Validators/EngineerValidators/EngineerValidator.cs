using LabTwo.Models.Workers.Engineers;
using LabTwo.Warnings;

namespace LabTwo.Validators.EngineerValidators
{
    public static class EngineerValidator
    {
        public static List<IWarning> CheckEngineer(string name, string age, string passport, string yearsWorking, bool universityHasWorkerWithSuchPassport)
        {
            List<IWarning> warnings = new List<IWarning>();
            if (CommonValidator.PersonNameIsValid(name) == false)
                warnings.Add(new IncorrectPersonName());
            if (CommonValidator.PersonAgeIsValid(age) == false)
                warnings.Add(new IncorrectPersonAge());
            if (CommonValidator.WorkerPassportIsValid(passport) == false)
                warnings.Add(new IncorrectPassport());
            if (universityHasWorkerWithSuchPassport)
                warnings.Add(new PassportAlreadyExists());
            if (CommonValidator.NumberBiggerThanZero(yearsWorking))
                warnings.Add(new IncorrectYearsWorking());
            return warnings;
        }
        public static List<IWarning> CheckEngineersForAuditorium(List<Engineer> engineers)
        {
            if (engineers.Count <= 2)
                return new List<IWarning>();
            else
                return new List<IWarning>() { new IncorrectEngineersForAuditorium() };
        }
    }
}