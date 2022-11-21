namespace LabTwo.Models.Workers.Engineers
{
    public class Engineer : Worker, IEquatable<Engineer>
    {
        private bool itsHasEngineerCertificate;
        private int itsYearsWorking;
        
        public bool HasEngineerCertificate { get { return itsHasEngineerCertificate; } set { itsHasEngineerCertificate = value; } }
        public int YearsWorking { get { return itsYearsWorking; } set { itsYearsWorking = value; } }

        public Engineer()
        {
            itsHasEngineerCertificate = true;
            itsYearsWorking = 0;
        }
        public Engineer(string name, int age, string passport, bool hasEngineerCertificate, int yearsWorking) : base(name, age, passport)
        {
            itsHasEngineerCertificate = hasEngineerCertificate;
            itsYearsWorking = yearsWorking;
        }


        public bool Equals(Engineer rhs)
        {
            return itsName == rhs.itsName && itsAge == rhs.itsAge && itsPassport == rhs.itsPassport 
                && itsHasEngineerCertificate == rhs.itsHasEngineerCertificate && itsYearsWorking == rhs.itsYearsWorking;
        }
    }
}