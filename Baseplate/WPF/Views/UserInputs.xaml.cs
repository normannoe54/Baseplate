using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
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
    /// Interaction logic for UserInputs.xaml
    /// </summary>
    public partial class UserInputs : UserControl
    {

        public UserInputs()
        {
            InitializeComponent();
            this.DataContext = State.instance;
        }
    }
}
