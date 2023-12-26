using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Command;
using ResourceIdlePersonal.Model;

namespace ResourceIdlePersonal.ViewModel
{
    public partial class MainWindowViewModel : INotifyPropertyChanged
    { 
        public Dictionary<string, Element> Elements { get; set; }
        public Dictionary<string, Compound> Compounds { get; set; }

        private DispatcherTimer timer;
        private int seconds;

        public MainWindowViewModel()
        {
            InitializeResources();
            InitializeMachines();
            InitializeCommands();
            InitializeTimer();
        }

        public ICommand IncrementH { get; private set; }
        public ICommand IncrementLi { get; private set; }
        public ICommand IncrementBe { get; private set; }

        public ICommand IncrementLiH { get; private set; }
        public ICommand IncrementBeH2 { get; private set; }

        public void InitializeCommands()
        {
            IncrementH = new RelayCommand(() => IncrementElement(Elements["H"], 1));
            IncrementLi = new RelayCommand(() => IncrementElement(Elements["Li"], 1));
            IncrementBe = new RelayCommand(() => IncrementElement(Elements["Be"], 1));

            IncrementLiH = new RelayCommand(() => IncrementCompound(Compounds["LiH"], 1));
            IncrementBeH2 = new RelayCommand(() => IncrementCompound(Compounds["BeH2"], 1));
        }

        public void InitializeResources()
        {
            Elements = new Dictionary<string, Element>
            {
                { "H", new Element { Name = "H", Quantity = 0 } },
                { "Li", new Element { Name = "Li", Quantity = 0 } },
                { "Be", new Element { Name = "Be", Quantity = 0 } }
            };
        }

        public void InitializeMachines()
        {
            Compounds = new Dictionary<string, Compound>
            {
                {
                    "LiH", new Compound 
                    { 
                        Name = "LiH",
                        Quantity = 0,
                        ProductionRate = 2,
                        Cost = {{ "Li", 1 }, { "H", 1 }}
                    }
                },
                {
                    "BeH2", new Compound
                    {
                        Name = "BeH2",
                        Quantity = 0,
                        ProductionRate = 1,
                        Cost = {{ "Be", 1 }, { "H", 2 }}
                    }
                },
            };
        }

        public Compound LiHCompound => Compounds["LiH"];
        public Compound BeH2Compound => Compounds["BeH2"];
        public Element HElement => Elements["H"];
        public Element LiElement => Elements["Li"];
        public Element BeElement => Elements["Be"];


        public void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerTick;
            seconds = 0;
            timer.Start();
        }

        public void TimerTick(object sender, EventArgs e)
        {
            seconds++;
            GenerateResources(Compounds, Elements);
            CheckPrices(Compounds, Elements);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
