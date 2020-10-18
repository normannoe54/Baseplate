using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class Column
    {
        #region readonly property
        /// <summary>
        /// name
        /// </summary>
        public readonly string _section;

        /// <summary>
        /// yield stress
        /// </summary>
        public readonly Steel _Fy;

        #endregion

        #region constructor
        /// <summary>
        /// base class constructor
        /// </summary>
        /// <param name="name"></param>
        public Column(string section, Steel Fy)
        {
            _section = section;
            _Fy = Fy;
        }
        #endregion
    }
}

