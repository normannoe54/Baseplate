using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class Steel
    {
        #region readonly property
        /// <summary>
        /// name
        /// </summary>
        public readonly string _name = "A992";

        /// <summary>
        /// yield stress
        /// </summary>
        public readonly double _Fy = 50.0;

        #endregion

        #region constructor

        public Steel()
        {
        }

        /// <summary>
        /// base class constructor
        /// </summary>
        /// <param name="name"></param>
        public Steel(string name, double Fy)
        {
            _name = name;
            _Fy = Fy;
        }
        #endregion

    }
}

