using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ResourceIdlePersonal.Model;

namespace ResourceIdlePersonal.ViewModel
{
    public partial class MainWindowViewModel
    {
        public static void CheckPrices(Dictionary<string, Machine> machines, Dictionary<string, Resource> resources)
        {
            foreach (var machineEntry in machines)
            {
                string machineName = machineEntry.Key;
                Machine machine  = machineEntry.Value;
                bool isAffordable = true;

                foreach (var costEntry in machine.Cost)
                {
                    string resourceName = costEntry.Key;
                    int cost = costEntry.Value;

                    if (cost > resources[resourceName].Quantity)
                    {
                        isAffordable = false;
                        break;
                    }
                }
                machines[machineName].IsAffordable = isAffordable;
            }
        } 
    }
}
