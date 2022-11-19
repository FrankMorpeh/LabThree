namespace LabTwo.Models.Workers.Engineers
{
    public class Engineer : Worker, IEquatable<Engineer>
    {
        private EngineerClass itsEngineerClass;
        
        public EngineerClass EngineerClass { get { return itsEngineerClass; } set { itsEngineerClass = value; } }

        public Engineer()
        {
            itsEngineerClass = EngineerClass.Third;
        }
        public Engineer(string name, int age, string passport, EngineerClass engineerClass) : base(name, age, passport)
        {
            itsEngineerClass = engineerClass;
        }


        public bool Equals(Engineer rhs)
        {
            return itsName == rhs.itsName && itsAge == rhs.itsAge && itsPassport == rhs.itsPassport && itsEngineerClass == rhs.itsEngineerClass;
        }
    }
}