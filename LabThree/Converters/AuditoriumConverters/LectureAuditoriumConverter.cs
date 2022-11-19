using LabThree.Converters;
using LabTwo.Models.Auditoriums;
using LabTwo.Models.Workers.Engineers;

namespace LabTwo.Converters.AuditoriumConverters
{
    public static class LectureAuditoriumConverter
    {
        public static LectureAuditorium ToLectureAuditorium(string codeName, string capacity, List<Engineer> engineers, string numberOfRows, string hasProjector)
        {
            return new LectureAuditorium(codeName, Convert.ToInt32(capacity), engineers, Convert.ToInt32(numberOfRows)
                , CommonConverter.ToBoolValue(hasProjector));
        }
    }
}