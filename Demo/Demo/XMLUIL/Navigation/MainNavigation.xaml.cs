using System;
using System.Windows.Controls;
using XMLAnalyzer.XMLUIL.Navigation;

namespace Demo.XMLUIL.Navigation
{
    /// <summary>
    /// Interaction logic for MainNavigation.xaml
    /// </summary>
    public partial class MainNavigation : UserControl
    {
        public MainNavigation()
        {
            InitializeComponent();
            DataContext=new MainNavigationModel();
        }

      
    }
}
