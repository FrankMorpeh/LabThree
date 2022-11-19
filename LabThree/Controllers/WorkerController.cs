using LabTwo.Models.Workers;
using LabTwo.Models.Workers.Engineers;
using LabTwo.Models.Workers.Teachers;

namespace LabThree.Controllers
{
    public class WorkerController
    {
        private List<Worker> itsWorkers;
        private Dictionary<string, Worker> itsWorkerDictionary;

        public List<Worker> Workers 
        { 
            get { return itsWorkers; } 
            set 
            { 
                itsWorkers = value;
                ToWorkerDictionary();
            } 
        }
        public int TeachersCount { get { return itsWorkers.OfType<Teacher>().Count(); } }
        public int EngineersCount { get { return itsWorkers.OfType<Engineer>().Count(); } }

        public WorkerController() { itsWorkers = new List<Worker>(); itsWorkerDictionary = new Dictionary<string, Worker>(); }

        public void Add(Worker worker)
        {
            itsWorkers.Add(worker);
            itsWorkerDictionary.Add(worker.Passport, worker);
        }
        public void RemoveAt(int index)
        {
            itsWorkerDictionary.Remove(itsWorkers[index].Passport);
            itsWorkers.RemoveAt(index);
        }
        public Worker GetWorkerByPassport(string passport)
        {
            return itsWorkerDictionary[passport];
        }

        private void ToWorkerDictionary()
        {
            foreach (Worker worker in itsWorkers)
                itsWorkerDictionary.Add(worker.Passport, worker);
        }
    }
}