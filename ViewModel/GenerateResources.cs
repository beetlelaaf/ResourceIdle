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
        public static void GenerateResources(Dictionary<string, Compound> compounds, Dictionary<string, Element> elements)
        {
            elements["H"].AddAmount(compounds["LiH"].ProductionRate * compounds["LiH"].Quantity);
            elements["Li"].AddAmount(compounds["BeH2"].ProductionRate * compounds["BeH2"].Quantity);
        }
    }
}
