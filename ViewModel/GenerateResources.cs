using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceIdlePersonal.Model;

namespace ResourceIdlePersonal.ViewModel
{
    public partial class MainWindowViewModel
    {
        public static void GenerateResources(Dictionary<string, Machine> machines, Dictionary<string, Resource> resources)
        {
            resources["Wood"].AddAmount(machines["WoodCutter"].ProductionRate * machines["WoodCutter"].Quantity);
            resources["Stone"].AddAmount(machines["StoneMine"].ProductionRate * machines["StoneMine"].Quantity);
        }
    }
}
