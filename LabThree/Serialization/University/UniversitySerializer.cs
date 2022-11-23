using LabTwo;
using LabTwo.Controllers.UniversityController;
using System.Text.Json;

namespace LabThree.Serialization
{
    public static class UniversitySerializer
    {
        public static void SerializeUniversities(UniversityController universityController)
        {
            if (!Directory.Exists(Form1.initialLocation + "\\University")) // create directory 'University' if it doesn't exist
                Directory.CreateDirectory(Form1.initialLocation + "\\University");
            try
            {
                string serializedUniversityController = JsonSerializer.Serialize(universityController);
                File.WriteAllText(Form1.initialLocation + "\\University\\UniversityController.json", serializedUniversityController);
            }
            catch (Exception) {}
        }
        public static UniversityController DeserializeUniversities()
        {
            if (!Directory.Exists(Form1.initialLocation + "\\University")) // if the directory doesn't exist, just create it for the future and return null
            {
                Directory.CreateDirectory(Form1.initialLocation + "\\University");
                return null;
            }
            else
            {
                try
                {
                    FileStream fileStream = new FileStream(Form1.initialLocation + "\\University\\UniversityController.json", FileMode.Open);
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
}