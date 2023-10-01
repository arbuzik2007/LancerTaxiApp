using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechODayApp.Models;
using TechODayApp.ViewModels;

namespace TechODayApp.Services
{
    public class DriverDataService : IDataStore<Driver>
    {
        private static DriverDataService instance;

        readonly List<Driver> drivers;

        // Private constructor to prevent external instantiation
        public DriverDataService()
        {
            drivers = new List<Driver>()
            {
                new Driver() { CarBrand="BYD", CarModel="HAN I", DriverName="Driver1", PlateNumber="c706"},
                new Driver() { CarBrand="HONDA", CarModel="STS 123", DriverName="Driver2", PlateNumber="c345"}
            };
        }
        public async Task<bool> AddItemAsync(Driver item)
        {
            drivers.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Driver item)
        {
            var oldItem = drivers.Where((Driver arg) => arg.PlateNumber == item.PlateNumber).FirstOrDefault();
            drivers.Remove(oldItem);
            drivers.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = drivers.Where((Driver arg) => arg.PlateNumber == id).FirstOrDefault();
            drivers.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Driver> GetLastItem()
        {
            return await Task.FromResult(drivers.LastOrDefault());
        }

        public Driver GetLastItemSimple()
        {
            return drivers.Last();
        }

        public async Task<Driver> GetItemAsync(string id)
        {
            return await Task.FromResult(drivers.FirstOrDefault(s => s.PlateNumber == id));
        }

        public async Task<IEnumerable<Driver>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(drivers);
        }

        public static DriverDataService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DriverDataService();
                }
                return instance;
            }
        }
        public DriveRequest DriveRequest { get; set; }
    }
}
