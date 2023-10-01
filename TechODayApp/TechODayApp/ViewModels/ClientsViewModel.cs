using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using TechODayApp.Models;
using TechODayApp.Services;
using Xamarin.Forms;

namespace TechODayApp.ViewModels
{
    public class ClientsViewModel : BaseViewModel
    {
        private Client _selectedItem;

        public ObservableCollection<Client> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<Client> ItemTapped { get; }

        public ClientsViewModel()
        {
            Items = new ObservableCollection<Client>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Client>(OnItemSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await ClientStore.GetItemsAsync(true);
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

        public Client SelectedItem
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

        void OnItemSelected(Client item)
        {
            if (item == null)
                return;


            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}
