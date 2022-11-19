using LabTwo.Models.Workers.Engineers;

namespace LabTwo.Models.Auditoriums
{
    public class LectureAuditorium : Auditorium, IEquatable<LectureAuditorium>
    {
        private int itsNumberOfRows;

        public int NumberOfRows { get { return itsNumberOfRows; } set { itsNumberOfRows = value; } }

        public LectureAuditorium(string codeName, int capacity, List<Engineer> engineers, int numberOfRows)
            : base(codeName, capacity, engineers)
        {
            itsNumberOfRows = numberOfRows;
        }


        public bool Equals(LectureAuditorium rhs)
        {
            return itsCodeName == rhs.itsCodeName && itsCapacity == rhs.itsCapacity && itsEngineers.Equals(rhs.itsEngineers)
                && itsNumberOfRows == rhs.itsNumberOfRows;
        }
    }
}