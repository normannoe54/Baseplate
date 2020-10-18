using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.Views
{
    /// <summary>
    /// Interaction logic for Diagram.xaml
    /// </summary>
    public partial class Diagram : UserControl
    {
        public double proWidth = 30;
        public double proHeight = 50;
        public double proThick = 3;

        public Diagram()
        {
            InitializeComponent();

            double Width = DiagramCanvas.Width/2;
            double Height = DiagramCanvas.Height/2;

            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;
            SolidColorBrush purpleBrush = new SolidColorBrush();
            purpleBrush.Color = Color.FromArgb(255,103,58,183);

            //FOUNDATION
            Rectangle foundation = new Rectangle
            {
                Width = 150,
                Height = 150,
                StrokeThickness = 1,
                Stroke = blackBrush,
                StrokeDashArray = new DoubleCollection(new double[] { 1.0, 2.0 }),
            };

            DiagramCanvas.Children.Add(foundation);
            Canvas.SetTop(foundation, Height-foundation.Height/2);
            Canvas.SetLeft(foundation, Width - foundation.Width / 2);

            //FOUNDATION
            Rectangle basePlate = new Rectangle
            {
                Width = 100,
                Height = 100,
                StrokeThickness = 2,
                Stroke = purpleBrush,
            };

            DiagramCanvas.Children.Add(basePlate);
            Canvas.SetTop(basePlate, Height - basePlate.Height / 2);
            Canvas.SetLeft(basePlate, Width - basePlate.Width / 2);

            //PROFILE

            Path myPath = new Path();
            myPath.Fill = purpleBrush;

            PathGeometry geometry = new PathGeometry();

            PathSegmentCollection collection = new PathSegmentCollection();
            collection.Add(new LineSegment(new Point(Width + proWidth / 2, Height + proHeight / 2), true));
            collection.Add(new LineSegment(new Point(Width + proWidth / 2, Height - proHeight / 2), true));
            collection.Add(new LineSegment(new Point(Width - proWidth / 2, Height - proHeight / 2), true));

            PathFigure figure = new PathFigure(new Point(Width - proWidth / 2, Height + proHeight / 2), collection,true);

            geometry.Figures.Add(figure);

            myPath.Data = geometry;
            DiagramCanvas.Children.Add(myPath);
            
            //Canvas.SetTop(myPath, Width / 2);
        }
        

    }
}
