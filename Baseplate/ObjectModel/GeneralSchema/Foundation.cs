using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class Foundation
    {
        public readonly string _name;

        public readonly double _width;

        public readonly double _height;

        public readonly Concrete _concrete;

        public Foundation(string name, double width, double height, Concrete concrete)
        {
            _name = name;
            _width = width;
            _height = height;
            _concrete = concrete;
        }
    }
}
