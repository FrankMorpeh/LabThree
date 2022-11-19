using LabTwo.Models.Departments;
using LabTwo.Models.Subjects;

namespace LabTwo.Converters.DepartmentConverters
{
    public static class DepartmentConverter
    {
        public static Department ToDepartment(string departmentName, string deaneryCabinetNumber, List<Subject> subjects)
        {
            return new Department(departmentName, Convert.ToInt32(deaneryCabinetNumber), subjects);
        }
    }
}