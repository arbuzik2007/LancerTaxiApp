using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TechODayApp.Models;
using TechODayApp.Services;
using Xamarin.Forms;

namespace TechODayApp.ViewModels
{
    public class DriversViewModel : BaseViewModel
    {
        private Driver _selectedItem;

        public ObservableCollection<Driver> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<Driver> ItemTapped { get; }

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
                var items = await DataStore.GetItemsAsync(true);
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

        private string locationCallBack;
        public string LocationCallBack
        {
            get => locationCallBack;
            set
            {
                SetProperty(ref locationCallBack, value);
                DriveRequest.Location = locationCallBack;
            }
        }
        private string directionCallBack;
        public string DirectionCallBack
        {
            get => directionCallBack;
            set
            {
                SetProperty(ref directionCallBack, value);
                DriveRequest.Location = directionCallBack;
            }
        }

        async void OnItemSelected(Driver item)
        {
            if (item == null)
                return;

            DataService.Instance.DriveRequest = new DriveRequest() { SelectedDriver = item };

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}