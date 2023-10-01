using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using TechODayApp.Models;
using TechODayApp.Services;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace TechODayApp.ViewModels
{
    public class PassengerProfileViewModel : BaseViewModel
    {
        public PassengerProfileViewModel()
        {
            Reset();

            SaveCommand = new Command(OnSave, AreFilled);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private string itemId;
        public string Id { get; set; }

        private string clientName;
        private int rating;
        private ObservableCollection<Tag> tags;

        public ObservableCollection<Tag> Tags
        {
            get { return tags; }
            set => SetProperty(ref tags, value);
        }

        public void AddTag(string newValue)
        {
            var newTag = new Tag(newValue);
            if (!Tags.Contains(newTag))
                Tags.Add(newTag);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
            }
        }

        public string ClientName
        {
            get => clientName;
            set => SetProperty(ref clientName, value);
        }


        public int Rating { get => rating; set { if (value <= 5 && value > 0) SetProperty(ref rating, value); } }

        public bool AreFilled()
        {
            if (
                String.IsNullOrEmpty(ClientName))
                return false;
            return true;
        }

        public void Reset()
        {
            Id = Guid.NewGuid().ToString();
            ClientName = "Anonymous";
            Tags = new ObservableCollection<Tag>();
            Rating = Driver.RatingDefault;
        }

        public Command SaveCommand { get; }

        private async void OnSave()
        {
            Client newItem = new Client()
            {
                Id = itemId,
                ClientName = clientName,
                Rating = rating,
                Tags = tags
            };

            if(ClientStore.GetItemAsync(Id) != null)
                await ClientStore.UpdateItemAsync(newItem);
            else
                await ClientStore.AddItemAsync(newItem);

            MessagingCenter.Send<App, string>(App.Current as App, "ClientEnter", "");

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        public async void LoadItem()
        {
            try
            {
                var item = await ClientStore.GetLastItem();
                ClientName = item.ClientName;
                Tags = item.Tags;
                Rating = item.Rating;
                Id = item.Id;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
