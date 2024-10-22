using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarpenTech.Models.Models
{
    public class PropertyListing2 : INotifyPropertyChanged
    {
        private string address;
        private decimal rent;
        private string description;

        public string Address
        {
            get => address;
            set
            {
                if (address != value)
                {
                    address = value;
                    OnPropertyChanged(nameof(address));
                }
            }
        }

        public decimal Rent
        {
            get => rent;
            set
            {
                if (rent != value)
                {
                    rent = value;
                    OnPropertyChanged(nameof(rent));
                }
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged(nameof(description));
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
