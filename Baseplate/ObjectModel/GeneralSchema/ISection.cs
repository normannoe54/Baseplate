using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class ISection
    {
        #region private fields
        private double _flangey;
        private double _weby;
        private double _flangex;
        private double _webx;
        private double _dflangey;
        private double _dweby;
        private double _dflangex;
        private double _dwebx;
        private double _flangearea;
        private double _webarea;
        #endregion

        #region readonly properties
        public readonly string _name;
        public readonly double _A;
        public readonly double _Ix;
        public readonly double _Iy;
        public readonly double _Sx;
        public readonly double _Sy;
        public readonly double _Zx;
        public readonly double _Zy;
        public readonly double _Rx;
        public readonly double _Ry;
        public readonly double _J;
        public readonly double _bf;
        public readonly double _tf;
        public readonly double _tw;
        public readonly double _d;
        public readonly double _k;
        #endregion

        #region constructors
        /// <summary>
        /// IShape Constructor
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="d"></param>
        /// <param name="bf"></param>
        /// <param name="tf"></param>
        /// <param name="tw"></param>
        /// <param name="k"></param>
        /// <param name="A"></param>
        /// <param name="Ix"></param>
        /// <param name="Iy"></param>
        /// <param name="Sx"></param>
        /// <param name="Sy"></param>
        /// <param name="Zx"></param>
        /// <param name="Zy"></param>
        /// <param name="Rx"></param>
        /// <param name="Ry"></param>
        /// <param name="J"></param>
        public ISection(string Name, double d, double bf, double tf, double tw, double k, double A, double Ix, double Iy, double Sx, double Sy, double Zx, double Zy, double Rx, double Ry, double J)
        {
            _name = Name;
            _bf = bf;
            _tf = tf;
            _tw = tw;
            _d = d;
            _k = k;
            _A = A;
            _Ix = Ix;
            _Iy = Iy;
            _Sx = Sx;
            _Sy = Sy;
            _Rx = Rx;
            _Ry = Ry;
            _Zx = Zx;
            _Zy = Zy;
            _J = J;

            _flangearea = _bf * _tf;
            _webarea = (_d - (2 * _tf)) * _tw;

            //private fields
            _flangey = _tf / 2;
            _weby = _d / 2;

            _flangex = _bf / 2;
            _webx = _bf / 2;

            _dflangey = Math.Abs(Centroidy - _flangey);
            _dweby = Math.Abs(_weby - Centroidy);

            _dflangex = Math.Abs(Centroidx - _flangex);
            _dwebx = Math.Abs(_webx - Centroidx);
        }
        #endregion

        /// <summary>
        /// centroid (x)
        /// </summary>
        public double Centroidx
        {
            get
            {
                //Dont use centroid object -> much simpler to use this
                return _bf / 2;
            }
        }

        /// <summary>
        /// centroid (y)
        /// </summary>
        public double Centroidy
        {
            get
            {
                //Dont use centroid object -> much simpler to use this
                return _d / 2;
            }
        }


        /// <summary>
        /// vertices
        /// </summary>
        public List<Point> Vertices
        {
            get
            {
                List<Point> OutputVertices = new List<Point>();
                OutputVertices.Add(new Point(0, _d));
                OutputVertices.Add(new Point(_bf, _d));
                OutputVertices.Add(new Point(_bf, _d - _tf));
                OutputVertices.Add(new Point(_bf / 2 + _tw / 2, _d - _tf));
                OutputVertices.Add(new Point(_bf / 2 + _tw / 2, _tf));
                OutputVertices.Add(new Point(_bf, _tf));
                OutputVertices.Add(new Point(_bf, 0));
                OutputVertices.Add(new Point(0, 0));
                OutputVertices.Add(new Point(0, _tf));
                OutputVertices.Add(new Point(_bf / 2 - _tw / 2, _tf));
                OutputVertices.Add(new Point(_bf / 2 - _tw / 2, _d - _tf));
                OutputVertices.Add(new Point(0, _d - _tf));

                //close the loop
                OutputVertices.Add(new Point(0, _d));

                return OutputVertices;
            }
        }
    }
}
