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
        public static double PHI_C = 0.65;
        public static double PHI_B = 0.9;
        public static DesignResults DesignGravity(BPDesign bpdesign)
        {
            ISection col = bpdesign._column;
            Foundation fndn = bpdesign._fndn;
            Baseplate bp = bpdesign._bp;
            
            double Pu;
            double fprimec;
            double bpArea;
            double fndnArea;
            double sqrtA2A1;
            double Pp;
            double phiPn;
            double m;
            double n;
            double d = col._d;
            double bf = col._bf;
            double X;
            double lambda;
            double lambdaNprime;
            double l;
            double tMin;
            double fy = bp._steel._Fy;
            double B = bp.Width;
            double N = bp.Height;

            DesignResults desresult = new DesignResults();

            foreach (ForceObject fobj in bpdesign._exres._exportedforces)
            {
                //Axial checks
                Pu = fobj._Fz;
                fprimec = 4;
                bpArea = B * N;
                fndnArea = fndn._width * fndn._height;
                sqrtA2A1 = Math.Min(Math.Sqrt(fndnArea / bpArea), 2);
                Pp = Math.Min(0.85 * fprimec * bpArea * sqrtA2A1, 1.7 * fprimec * bpArea);
                phiPn = Math.Round(PHI_C * Pp, 2);

                if (desresult.BearingCapacity < phiPn)
                {
                    desresult.BearingCapacity = phiPn;
                    desresult.BearingDCR = Math.Round(Pu / phiPn, 2);
                }

                desresult.BearingCapacity = phiPn;
                desresult.BearingDCR = Math.Round(Pu / phiPn, 2);
                //Min baseplate thickness
                m = (bp.Height - 0.95 * d) / 2;
                n = (bp.Width - 0.8 * bf) / 2;

                X = ((4 * d * bf) / Math.Pow((d + bf), 2)) * Math.Round(Pu / phiPn, 2);

                lambda = Math.Min((2 * Math.Sqrt(X)) / (1 + (Math.Sqrt(1 - X))), 1);
                lambdaNprime = lambda * (Math.Sqrt(d * bf) / 4);
                l = Math.Max(m, Math.Max(n, lambdaNprime));
                tMin = Math.Round(l * Math.Sqrt((2 * Pu) / (PHI_B * fy * B * N)), 2);

                if (desresult.MinReqdThickness < tMin)
                {
                    desresult.MinReqdThickness = tMin;
                }
                
            }
            
            // Anchor Rod Checks
            return desresult;
        }
    }
}