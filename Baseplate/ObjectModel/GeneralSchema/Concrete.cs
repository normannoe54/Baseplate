using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class Concrete
    {
        #region readonly property
        /// <summary>
        /// name
        /// </summary>
        public readonly string _name;

        /// <summary>
        /// yield stress
        /// </summary>
        public readonly double _fprimec;
        #endregion

        #region constructor
        /// <summary>
        /// base class constructor
        /// </summary>
        /// <param name="name"></param>
        public Concrete(string name, double fprimec)
        {
            _name = name;
            _fprimec = fprimec;
        }
        #endregion

    }
}

