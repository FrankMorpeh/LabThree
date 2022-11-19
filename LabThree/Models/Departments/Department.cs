using LabTwo.Models.Subjects;

namespace LabTwo.Models.Departments
{
    public class Department : IEquatable<Department>
    {
        private string itsDepartmentName;
        private int itsDeaneryCabinetNumber;
        private List<Subject> itsSubjects;

        public string Name { get { return itsDepartmentName; } set { itsDepartmentName = value; } }
        public int DeaneryCabinetNumber { get { return itsDeaneryCabinetNumber; } set { itsDeaneryCabinetNumber = value; } }
        public List<Subject> Subjects { get { return itsSubjects; } set { itsSubjects = value; } }

        public Department()
        {
            itsDepartmentName = string.Empty;
            itsDeaneryCabinetNumber = 0;
            itsSubjects = null;
        }
        public Department(string departmentName, int deaneryCabinetNumber, List<Subject> subjects)
        {
            itsDepartmentName = departmentName;
            itsDeaneryCabinetNumber = deaneryCabinetNumber;
            itsSubjects = subjects;
        }


        public bool Equals(Department rhs)
        {
            return itsDepartmentName == rhs.itsDepartmentName && itsDeaneryCabinetNumber == rhs.itsDeaneryCabinetNumber 
                && itsSubjects.Equals(rhs.itsSubjects);
        }
    }
}