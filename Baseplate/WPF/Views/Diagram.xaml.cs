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
        public Diagram()
        {
            InitializeComponent();
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;

            Rectangle rectangle = new Rectangle
            {
                Width = 100,
                Height = 100,
                StrokeThickness = 1,
                Stroke = blackBrush,
            };

            DiagramGrid.Children.Add(rectangle);

            Canvas.SetTop(rectangle, Height/2);
            Canvas.SetLeft(rectangle, Width/2);

        }
    }
}
