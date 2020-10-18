using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class Point : IEquatable<Point>
    {
        #region readonly properties
        /// <summary>
        /// x location
        /// </summary>
        public readonly double _x;

        /// <summary>
        /// y location
        /// </summary>
        public readonly double _y;

        /// <summary>
        /// z location
        /// </summary>
        public readonly double _z;
        #endregion

        #region constructor
        /// <summary>
        /// Joint Object constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point(double x, double y, double z)
        {
            //readable properties
            _x = x;
            _y = y;
            _z = z;
        }

        /// <summary>
        /// 2d point constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y)
        {
            //readable properties
            _x = x;
            _y = y;

            //x-y coordinate system
            _z = 0;
        }
        #endregion

        #region Interface Properties
        /// <summary>
        /// Determine if points are equal
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Equals(Point point)
        {
            return this._x == point._x &&
                   this._y == point._y &&
                   this._z == point._z;
        }
        #endregion
    }
}
