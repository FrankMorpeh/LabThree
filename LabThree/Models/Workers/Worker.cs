using LabTwo.Models.People;

namespace LabTwo.Models.Workers
{
    public abstract class Worker : Person
    {
        protected string itsPassport;

        public string Passport { get { return itsPassport; } set { itsPassport = value; } }

        public Worker()
        {
            itsPassport = string.Empty;
        }
        public Worker(string name, int age, string passport) : base(name, age)
        {
            itsPassport = passport;
        }
    }
}