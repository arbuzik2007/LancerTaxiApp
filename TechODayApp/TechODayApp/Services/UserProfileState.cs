using System.ComponentModel;

namespace TechODayApp.Services
{
    public class UserProfileState : INotifyPropertyChanged
    {
        private static UserProfileState instance;

        public static UserProfileState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserProfileState();
                }
                return instance;
            }
        }
        private UserProfileState() { isUserDriver = false; }

        private static bool isUserDriver;

        public bool IsDriverProfileVisible
        {
            get => isUserDriver;
            set
            {
                if (isUserDriver != value)
                {
                    isUserDriver = value;
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
