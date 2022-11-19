using LabTwo.Models.Workers.Engineers;

namespace LabTwo.Models.Auditoriums
{
    public class LectureAuditorium : Auditorium, IEquatable<LectureAuditorium>
    {
        private int itsNumberOfRows;
        private bool itsHasProjector;

        public int NumberOfRows { get { return itsNumberOfRows; } set { itsNumberOfRows = value; } }
        public bool HasProjector { get { return itsHasProjector; } set { itsHasProjector = value; } }

        public LectureAuditorium(string codeName, int capacity, List<Engineer> engineers, int numberOfRows, bool hasProjector)
            : base(codeName, capacity, engineers)
        {
            itsNumberOfRows = numberOfRows;
            itsHasProjector = hasProjector;
        }


        public bool Equals(LectureAuditorium rhs)
        {
            return itsCodeName == rhs.itsCodeName && itsCapacity == rhs.itsCapacity && itsEngineers.Equals(rhs.itsEngineers)
                && itsNumberOfRows == rhs.itsNumberOfRows && itsHasProjector == rhs.itsHasProjector;
        }
    }
}