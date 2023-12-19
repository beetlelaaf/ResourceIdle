using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceIdlePersonal.Model;

namespace ResourceIdlePersonal.ViewModel
{
    public class MainWindowViewModel
    { 
        public Dictionary<string, Resource> Resources { get; set; }
        public Dictionary<string, Machine> Machines { get; set; }

        public MainWindowViewModel()
        {
            InitializeResources();
            InitializeMachines();
        }

        public void InitializeResources()
        {
            Resources = new Dictionary<string, Resource>
            {
                { "Wood", new Resource { Name = "Wood", Quantity = 0 } },
                { "Stone", new Resource { Name = "Stone", Quantity = 0 } }
            };
        }

        public void InitializeMachines()
        {
            Machines = new Dictionary<string, Machine>
            {
                { 
                    "WoodCutter", new Machine 
                    { 
                        Name = "WoodCutter", 
                        Quantity = 0, 
                        ProductionRate = 2,
                        Cost = new Dictionary<string, int>
                        {
                            { "Wood", 20 },
                            { "Stone", 10 }
                        }
                    }
                },
                {
                    "StoneMine", new Machine
                    {
                        Name = "StoneMine",
                        Quantity = 0,
                        ProductionRate = 1,
                        Cost = new Dictionary<string, int>
                        {
                            { "Wood", 40 },
                            { "Stone", 40 }
                        }
                    }
                },
            };
        }

        public Machine WoodCutterMachine => Machines["WoodCutter"];
        public Machine StoneMineMachine => Machines["StoneMine"];
        public Resource WoodResource => Resources["Wood"];
        public Resource StoneResource => Resources["Stone"];
    }
}
