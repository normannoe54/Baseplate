using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class Foundation
    {
        public string _name { get; set; }

        public double _width { get; set; }

        public double _height { get; set; }

        public Concrete _concrete;
    }
}
