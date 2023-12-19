using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceIdlePersonal.Model
{
    public class Machine
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int ProductionRate { get; set; }
        public Dictionary<string, int> Cost { get; set; } = new Dictionary<string, int>();
    }
}
