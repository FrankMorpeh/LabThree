using LabThree.Converters;
using LabTwo.Models.Workers.Engineers;
using static System.Windows.Forms.ListView;

namespace LabTwo.Converters.WorkerConverters
{
    public static class EngineerConverter
    {
        public static Engineer ToEngineer(string name, string age, string passport, string hasEngineerCertificate, string yearsWorking)
        {
            return new Engineer(name, Convert.ToInt32(age), passport, CommonConverter.ToBoolValue(hasEngineerCertificate), Convert.ToInt32(yearsWorking));
        }
        public static List<Engineer> ToEngineerList(List<Engineer> intitialEngineers, SelectedIndexCollection selectedIndexCollection)
        // forms a collection of students (for a particular teacher) based on the selected items in listview
        {
            List<Engineer> engineers = new List<Engineer>();
            for (int i = 0; i < selectedIndexCollection.Count; i++)
                engineers.Add(intitialEngineers[selectedIndexCollection[i]]);
            return engineers;
        }
    }
}