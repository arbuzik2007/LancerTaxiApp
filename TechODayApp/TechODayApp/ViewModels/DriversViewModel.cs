using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TechODayApp.Models;
using TechODayApp.Services;
using Xamarin.Forms;

namespace TechODayApp.ViewModels
{
    public class DriverInfo
    {
        public string Name { get; set; }
        public string StarRating { get; set; }
    }

    public class DriversViewModel : BaseViewModel
    {
        private Driver _selectedItem;

        public ObservableCollection<Driver> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<Driver> ItemTapped { get; }
        public ObservableCollection<DriverInfo> DriverInfos { get; private set; }

        public void UpdateDriverInfos()
        {
            DriverInfos = new ObservableCollection<DriverInfo>();
            foreach (var item in Items)
            {
                int maxRating = 5; // Assuming a maximum rating of 5 stars
                int fullStars = item.Rating;
                int emptyStars = maxRating - item.Rating;

                string ratingString = new string('★', fullStars) + new string('☆', emptyStars);

                DriverInfos.Add(new DriverInfo() { Name = item.DriverName, StarRating = ratingString });
            }
        }

        public DriversViewModel()
        {
            Items = new ObservableCollection<Driver>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Driver>(OnItemSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DriverStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Driver SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        void OnItemSelected(Driver item)
        {
            if (item == null)
                return;

            //DriverDataService.Instance.DriveRequest = new DriveRequest() { SelectedDriver = item };

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}