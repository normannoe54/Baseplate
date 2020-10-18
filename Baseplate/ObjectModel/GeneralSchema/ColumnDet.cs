using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class ColumnDet
    {
        #region readonly property
        /// <summary>
        /// name
        /// </summary>
        public readonly ISection _section;

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
        public ColumnDet(ISection section, Steel Fy)
        {
            _section = section;
            _Fy = Fy;
        }
        #endregion
    }
}

