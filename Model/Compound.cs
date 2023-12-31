﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceIdlePersonal.Model
{
    public class Compound : INotifyPropertyChanged
    {
        public string Name { get; set; } = "";
        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        private bool _isAffordable;
        public bool IsAffordable
        {
            get { return _isAffordable; }
            set
            {
                if (_isAffordable != value)
                {
                    _isAffordable = value;
                    OnPropertyChanged(nameof(IsAffordable));
                }
            }
        }
        public int ProductionRate { get; set; }
        public Dictionary<string, int> Cost { get; set; } = new Dictionary<string, int>();

        public void AddAmount(int amountToAdd)
        {
            Quantity += amountToAdd;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
