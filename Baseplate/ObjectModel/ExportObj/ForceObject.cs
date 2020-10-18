using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class ForceObject
    {
        public readonly double _Fx;
        public readonly double _Fy;
        public readonly double _Fz;
        public readonly double _Mx;
        public readonly double _My;
        public readonly double _Mz;

        public ForceObject(double Fx, double Fy, double Fz, double Mx, double My, double Mz)
        {
            _Fx = Fx;
            _Fy = Fy;
            _Fz = Fz;
            _Mx = Mx;
            _My = My;
            _Mz = Mz;
        }

        
    }
}
