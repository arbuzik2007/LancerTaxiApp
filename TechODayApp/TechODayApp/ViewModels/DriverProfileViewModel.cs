﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TechODayApp.ViewModels
{
    public class DriverProfileViewModel : INotifyPropertyChanged
    {
        private string driverName;
        private string carModel;
        private string carBrand;
        private string plateNumber;

        public string DriverName
        {
            get { return driverName; }
            set
            {
                if (driverName != value)
                {
                    driverName = value;
                    OnPropertyChanged(nameof(DriverName));
                }
            }
        }
        public string CarBrand
        {
            get { return carBrand; }
            set
            {
                if (carBrand != value)
                {
                    carBrand = value;
                    OnPropertyChanged(nameof(CarBrand));
                }
            }
        }

        public string PlateNumber
        {
            get { return plateNumber; }
            set
            {
                if (plateNumber != value)
                {
                    plateNumber = value;
                    OnPropertyChanged(nameof(PlateNumber));
                }
            }
        }

        public string CarModel
        {
            get { return carModel; }
            set
            {
                if (carModel != value)
                {
                    carModel = value;
                    OnPropertyChanged(nameof(CarModel));
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