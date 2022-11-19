using LabTwo.Models.Workers.Engineers;

namespace LabTwo.Models.Auditoriums
{
    public abstract class Auditorium
    {
        protected string itsCodeName;
        protected int itsCapacity;
        protected List<Engineer> itsEngineers;

        public string CodeName { get { return itsCodeName; } set { itsCodeName = value; } }
        public int Capacity { get { return itsCapacity; } set { itsCapacity = value; } }
        public string NamesOfEngineers { get { return EngineersToString(); } }
        public List<Engineer> Engineers { get { return itsEngineers; } set { itsEngineers = value; } }

        public Auditorium()
        {
            itsCodeName = string.Empty;
            itsCapacity = 0;
            itsEngineers = new List<Engineer>();
        }
        public Auditorium(string name, int capacity, List<Engineer> engineers)
        {
            itsCodeName = name;
            itsCapacity = capacity;
            itsEngineers = engineers;
        }

        public bool AddEngineer(Engineer engineer) 
        {
            if (itsEngineers.Count + 1 > 2) // there can be no more than two engineers for one auditorium
                return false;
            else
            {
                itsEngineers.Add(engineer);
                return true;
            }
        }
        public void RemoveEngineer(Engineer engineer) { itsEngineers.Remove(engineer); }

        private string EngineersToString()
        {
            string engineers = string.Empty;
            if (itsEngineers != null && itsEngineers.Count > 0)
            {
                for (int i = 0; i < itsEngineers.Count; i++)
                {
                    engineers += itsEngineers[i].Name;
                    if (i + 1 < itsEngineers.Count)
                        engineers += ", ";
                }
            }
            return engineers;
        }
    }
}