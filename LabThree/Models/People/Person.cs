namespace LabTwo.Models.People
{
    public abstract class Person
    {
        protected string itsName;
        protected int itsAge;

        public string Name { get { return itsName; } set { itsName = value; } }
        public int Age { get { return itsAge; } set { itsAge = value; } }

        public Person()
        {
            itsName = string.Empty;
            itsAge = 0;
        }
        public Person(string name, int age)
        {
            itsName = name;
            itsAge = age;
        }
    }
}