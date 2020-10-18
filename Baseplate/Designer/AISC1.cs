using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectModel;

namespace Designer
{
    public static class AISC11
    {
        public static DesignResults DesignGravity(BPDesign bpdesign)
        {

            Column col = bpdesign.column;
            

            DesignResults desresult = new DesignResults();
            desresult.MaximumBendingCapacity = 10;

            //gravity baseplate design here

            return desresult;
        }

        public static DesignResults DesignLateral(BPDesign input)
        {
            //perform shear lug and other stuff here
        }
    }
}
