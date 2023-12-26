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
        public static void CheckPrices(Dictionary<string, Compound> compounds, Dictionary<string, Element> elements)
        {
            foreach (var compoundEntry in compounds)
            {
                string compoundName = compoundEntry.Key;
                Compound compound  = compoundEntry.Value;
                bool isAffordable = true;

                foreach (var costEntry in compound.Cost)
                {
                    string elementName = costEntry.Key;
                    int cost = costEntry.Value;

                    if (cost > elements[elementName].Quantity)
                    {
                        isAffordable = false;
                        break;
                    }
                }
                compounds[compoundName].IsAffordable = isAffordable;
            }
        } 
    }
}
