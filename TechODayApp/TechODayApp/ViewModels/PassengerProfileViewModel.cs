using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TechODayApp.Models;

namespace TechODayApp.ViewModels
{
    public class PassengerProfileViewModel : INotifyPropertyChanged
    {
        public PassengerProfileViewModel()
        {
            userName = "Anonymous";
            Tags = new ObservableCollection<Tag>();
        }
        private ObservableCollection<Tag> tags;
        public ObservableCollection<Tag> Tags
        {
            get { return tags; }
            set
            {
                tags = value;
                OnPropertyChanged(nameof(Tags));
            }
        }

        public void AddTag(string newValue)
        {
            var newTag = new Tag(newValue);
            if (!Tags.Contains(newTag))
                Tags.Add(newTag);
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                if (UserName != value)
                {
                    userName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }

        private int rating;
        public int Rating { get => rating; set{ if(value <= 5 && value > 0) rating = value; } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool AreFilled()
        {
            if (
                !String.IsNullOrEmpty(UserName))
                return true;
            return false;
        }

        public void Reset()
        {
            UserName = String.Empty;
            Tags = new ObservableCollection<Tag>();
        }
    }
}
