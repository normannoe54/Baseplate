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
using ObjectModel;

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
            this.DataContext = State.instance;

            //this.FoundationRect.SetBinding(Rectangle.WidthProperty, new Binding() { Path = new PropertyPath("Width"), Source = State.instance.basePlate, });
            //this.FoundationRect.SetBinding(Rectangle.HeightProperty, new Binding() { Path = new PropertyPath("Height"), Source = State.instance.basePlate, });

            double Width = DiagramCanvas.Width / 2;
            double Height = DiagramCanvas.Height / 2;

            //Canvas.SetTop(this.FoundationRect, Height - this.FoundationRect.Height / 2);
            //Canvas.SetLeft(this.FoundationRect, Width - this.FoundationRect.Width / 2);
            

            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;
            SolidColorBrush purpleBrush = new SolidColorBrush();
            purpleBrush.Color = Color.FromArgb(255,103,58,183);

            //FOUNDATION
            Rectangle foundationRect = new Rectangle
            {
                Width = 150,
                Height = 150,
                StrokeThickness = 1,
                Stroke = blackBrush,
                StrokeDashArray = new DoubleCollection(new double[] { 1.0, 2.0 }),
            };

            DiagramCanvas.Children.Add(foundationRect);
            Canvas.SetTop(foundationRect, Height - foundationRect.Height/2);
            Canvas.SetLeft(foundationRect, Width - foundationRect.Width / 2);

            //FOUNDATION
            Rectangle basePlateRect = new Rectangle
            {
                Width = 100,
                Height = 100,
                StrokeThickness = 2,
                Stroke = purpleBrush,
            };
            
            DiagramCanvas.Children.Add(basePlateRect);
            Canvas.SetTop(basePlateRect, Height - basePlateRect.Height / 2);
            Canvas.SetLeft(basePlateRect, Width - basePlateRect.Width / 2);

            //PROFILE

            Path myPath = new Path();
            myPath.Fill = purpleBrush;

            PathGeometry geometry = new PathGeometry();

            PathSegmentCollection collection = new PathSegmentCollection();
            collection.Add(new LineSegment(new System.Windows.Point(Width + proWidth / 2, Height + proHeight / 2), true));
            collection.Add(new LineSegment(new System.Windows.Point(Width + proWidth / 2, Height - proHeight / 2), true));
            collection.Add(new LineSegment(new System.Windows.Point(Width - proWidth / 2, Height - proHeight / 2), true));

            PathFigure figure = new PathFigure(new System.Windows.Point(Width - proWidth / 2, Height + proHeight / 2), collection,true);

            geometry.Figures.Add(figure);

            myPath.Data = geometry;
            DiagramCanvas.Children.Add(myPath);
            
            //Canvas.SetTop(myPath, Width / 2);
        }


    }
}
