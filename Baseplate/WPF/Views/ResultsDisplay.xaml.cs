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
    /// Interaction logic for ResultsDisplay.xaml
    /// </summary>
    public partial class ResultsDisplay : UserControl
    {
        public ResultsDisplay()
        {
            InitializeComponent();
            this.DataContext = State.instance;
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            //create bpdesign object
            BPDesign bpdes = new BPDesign();
            bpdes._bp = State.instance.basePlate;
            bpdes._exres = State.instance.exportedresults;
            bpdes._fndn = State.instance.foundation;

            ISection isection = Collection.GetISectionbyName(State.instance.exportedresults._column._section.ToUpper());

            bpdes._column = isection;
            DesignResults desres = Designer.AISCDG1.DesignGravity(bpdes);
            State.instance.designResults = desres;
            //State.instance.designResults.AnchorRodTension = desres.AnchorRodTension;
            //State.instance.designResults.BearingCapacity = desres.BearingCapacity;
        }
    }
}
