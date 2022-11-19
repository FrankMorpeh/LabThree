using System.Diagnostics;

namespace LabTwo.Validators
{
    public delegate void StringConversionDelegate(string value, ref bool isValid);
    public static class CommonValidator
    {
        public static bool UniversityNameIsValid(string name)
        {
            return name != string.Empty && name.Any(s => Char.IsLetter(s));
        }
        public static bool PersonNameIsValid(string name)
        {
            return name != string.Empty && name.All(s => Char.IsLetter(s) || Char.IsWhiteSpace(s));
        }
        public static bool PersonAgeIsValid(string age)
        {
            return MakeStringConversionCheck(age, ConvertAndCheckPersonAge);
        }
        private static void ConvertAndCheckPersonAge(string strAge, ref bool isValid)
        {
            int age = Convert.ToInt32(strAge);
            if (age < 0 || age > 150)
                isValid = false;
        }
        public static bool WorkerSalaryIsValid(string salary)
        {
            return MakeStringConversionCheck(salary, ConvertAndCheckSalary);
        }
        private static void ConvertAndCheckSalary(string strSalary, ref bool isValid)
        {
            double salary = Convert.ToDouble(strSalary);
            if (salary < 0)
                isValid = false;
        }

        public static bool NumberBiggerThanZero(string number)
        {
            return MakeStringConversionCheck(number, ConvertAndCheckNumberForBiggerThanZero);
        }
        private static void ConvertAndCheckNumberForBiggerThanZero(string strNumber, ref bool isValid)
        {
            int number = Convert.ToInt32(strNumber);
            if (number < 0)
                isValid = false;
        }
        public static bool MakeStringConversionCheck(string value, StringConversionDelegate stringConversionDelegate)
        {
            bool isValid = true;
            try
            {
                stringConversionDelegate(value, ref isValid);
            }
            catch (Exception)
            {
                isValid = false;
            }
            return isValid;
        }
        public static bool NameIsEmpty(string name)
        {
            return name == string.Empty;
        }
    }
}
