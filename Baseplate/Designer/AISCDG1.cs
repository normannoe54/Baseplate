using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectModel;

namespace Designer
{

    public static class AISCDG1
    {

        public static float PHI_C = 0.65;
        public static float PHI_B = 0.9;
         
        public static DesignResults DesignGravity(BPDesign bpdesign)
        {

            Column col = bpdesign.column;
            Foundation fndn = bpdesign.fndn;
            Baseplate bp = bpdesign.bp;
            ForceObject fo = bpdesign.fo;
            AnchorRod anchors = bpdesign.anchors;

            DesignResults desresult = new DesignResults(col, fndn, bp, fo);
            desresult.MaximumBendingCapacity = 10;
            desresult.MaximumShearCapacity = 5;

            //gravity baseplate design here
            double Pu;
            double fprimec;
            double bpArea;
            double fndnArea;
            double sqrtA2A1;
            double Pp;
            double phiPn;
            double m;
            double n;
            double d = col.d;
            double bf = col.bf;
            double X;
            double lambda;
            double lambdaNprime;
            double l;
            double tMin;
            double fy = bp.steel.fy;
            double B = bp.width;
            double N = bp.height;

            //Axial checks
            Pu = fo.Fz;
            fprimec = fndn.concrete.fprimec;
            bpArea = B*N;
            fndnArea = fndn.width*fndn.thickness;
            sqrtA2A1 = Math.Min(Math.Sqrt(fndnArea/bpArea),2);   
            Pp = Math.Min(0.85*fprimec*bpArea*sqrtA2A1, 1.7*fprimec*bpArea);
            phiPn = Math.Round(PHI_C*Pp,2);
            desresult.BearingCapacity = phiPn;
            desresult.BearingDCR = Math.Round(Pu/phiPn,2);

            //Min baseplate thickness

            m = (bp.height - 0.95*d)/2;
            n = (bp.width - 0.8*bf)/2;
            X = ((4*d*bf)/Math.Pow((d+bf),2))*desresult.BearingDCR;
            lambda = Math.Min((2*Math.Sqrt(X))/(1+(Math.Sqrt(1-X))),1);
            lambdaNprime = lambda*(Math.Sqrt(d*bf)/4);
            l = Math.Max(m, n, lambdaNprime);
            tMin = Math.Round(l*Math.Sqrt((2*Pu)/(PHI_B*fy*B*N)),2);
            desresult.MinReqdThickness = tMin;


            // Anchor Rod Checks
            

            return desresult;
        }

        public static DesignResults DesignLateral(BPDesign input)
        {
            //perform shear lug and other stuff here
        }
    }
}
