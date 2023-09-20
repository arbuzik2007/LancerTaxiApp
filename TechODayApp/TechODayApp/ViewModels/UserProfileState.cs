using System.ComponentModel;

namespace TechODayApp.ViewModels
{
    public class UserProfileState : INotifyPropertyChanged
    {
        public UserProfileState() { isUserDriver = false; }
        private bool isUserDriver;

        public bool IsDriverProfileVisible
        {
            get { return isUserDriver; }
            set
            {
                if (isUserDriver != value)
                {
                    isUserDriver = value;
                    OnPropertyChanged(nameof(IsDriverProfileVisible));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
