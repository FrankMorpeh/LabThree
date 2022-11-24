using LabTwo;
using LabTwo.Controllers.UniversityController;
using System.Text.Json;

namespace LabThree.Serialization
{
    public static class UniversitySerializer
    {
        public static void SerializeUniversities(string fileName, UniversityController universityController)
        {
            try
            {
                string serializedUniversityController = JsonSerializer.Serialize(universityController);
                File.WriteAllText(fileName, serializedUniversityController);
            }
            catch (Exception) {}
        }
        public static UniversityController DeserializeUniversities(string fileName)
        {
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Open);
                UniversityController universityController = JsonSerializer.Deserialize<UniversityController>(fileStream);
                return universityController;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}