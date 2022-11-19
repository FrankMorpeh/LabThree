using LabTwo.Models.People;

namespace LabTwo.Models.Workers
{
    public abstract class Worker : Person
    {
        protected double itsSalary;

        public double Salary { get { return itsSalary; } set { itsSalary = value; } }

        public Worker()
        {
            itsSalary = 0.0;
        }
        public Worker(string name, int age, double salary) : base(name, age)
        {
            itsSalary = salary;
        }
    }
}