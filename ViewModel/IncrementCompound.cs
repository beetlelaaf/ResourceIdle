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
        public static void IncrementCompound(Compound compound, int amountToAdd)
        {
            compound.AddAmount(amountToAdd);
        }
    }
}
