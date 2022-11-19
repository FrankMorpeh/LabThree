using LabTwo.Models.Subjects;

namespace LabTwo.Converters.SubjectsConverters
{
    public static class SubjectConverter
    {
        public static Subject ToSubject(string subjectName, string subjectCredit)
        {
            return new Subject(subjectName, Convert.ToDouble(subjectCredit));
        }
    }
}