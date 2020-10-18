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
        public readonly string _name;

        /// <summary>
        /// yield stress
        /// </summary>
        public readonly double _Fy;

        #endregion

        #region constructor
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

