using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TechODayApp.Models;
using TechODayApp.ViewModels;

namespace TechODayApp.Services
{
    public class ClientDataService : IDataStore<Client>
    {
        private static ClientDataService instance;

        readonly List<Client> clients;

        public ClientDataService()
        {
            clients = new List<Client>()
            {
                new Client() { ClientDestination = "dest", ClientLocation = "loc", ClientName = "name", Id = Guid.NewGuid().ToString(), Rating = 4,
                    Tags = new ObservableCollection<Tag>() { new Tag("Roar") } },
                 new Client() { ClientDestination = "dest", ClientLocation = "loc", ClientName = "name2", Id = Guid.NewGuid().ToString(), Rating = 2,
                    Tags = new ObservableCollection<Tag>() { new Tag("Deaf") } },

            };
        }

        public PassengerProfileViewModel passengerProfile { get; set; } = new PassengerProfileViewModel();

        public async Task<bool> AddItemAsync(Client item)
        {
            clients.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = clients.Where((Client arg) => arg.Id == id).FirstOrDefault();
            clients.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Client> GetItemAsync(string id)
        {
            return await Task.FromResult(clients.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Client>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(clients);
        }

        public async Task<Client> GetLastItem()
        {
            return await Task.FromResult(clients.LastOrDefault());
        }

        public Client GetLastItemSimple()
        {
            return clients.Last();
        }

        public async Task<bool> UpdateItemAsync(Client item)
        {
            var oldItem = clients.Where((Client arg) => arg.Id == item.Id).FirstOrDefault();
            clients.Remove(oldItem);
            clients.Add(item);

            return await Task.FromResult(true);
        }

        public static ClientDataService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientDataService();
                }
                return instance;
            }
        }
    }
}