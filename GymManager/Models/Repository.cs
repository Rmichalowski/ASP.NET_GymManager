using System.Collections.Generic;

namespace GymManager.Models
{
    public static class Repository
    {
        private static List<Client> allClients = new List<Client>();
        private static List<Trainer> allTrainers = new List<Trainer>();

        public static IEnumerable<Client> AllClients
        {
            get { return allClients; }
        }

        public static IEnumerable<Trainer> AllTrainers
        {
            get { return allTrainers; }
        }

        public static void Create(Client client)
        {
            allClients.Add(client);
        }

        public static void Create(Trainer trainer)
        {
            allTrainers.Add(trainer);
        }

        public static void Delete(Client client)
        {
            allClients.Remove(client);
        }

        public static void Delete(Trainer trainer)
        {
            allTrainers.Remove(trainer);
        }
    }
}
