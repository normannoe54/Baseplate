using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class Baseplate
    {

        public double Width { get; set; } = 12;

        public double Height { get; set; } = 12;

        public double Thickness { get; set; } = 1;

        public string _name = string.Empty;

        public Steel _steel = new Steel();

        public Baseplate()
        {
        }

            public Baseplate(string name, double thickness, double width, double height, Steel steel)
        {
            _name = name;
            Width = width;
            Height = height;
            Thickness = thickness;
            _steel = steel;
        }

    }
}
