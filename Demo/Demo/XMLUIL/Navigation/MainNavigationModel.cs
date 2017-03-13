using Demo.XMLUIL.Analyse;
using Demo.XMLUIL.Help;
using Demo.XMLUIL.Info;
using DevExpress.Mvvm;

namespace XMLAnalyzer.XMLUIL.Navigation
{
   public class MainNavigationModel:ViewModelBase
    {
        public MainNavigationModel()
        {
            GoToHelpPage = new DelegateCommand(() => NavigationService.Navigate(typeof(HelpView).FullName, null, this));
            GoToInfoPage = new DelegateCommand(() => NavigationService.Navigate(typeof(InfoView).FullName, null, this));
            GoToHomePage = new DelegateCommand(() => NavigationService.Navigate(typeof(AnalyseView).FullName, null, this));
            LoadedCommand = new DelegateCommand(() => NavigationService.Navigate(typeof(AnalyseView).FullName, null, this));
        }

        public DelegateCommand GoToHomePage { get; }
        public DelegateCommand LoadedCommand { get; }
        public DelegateCommand GoToHelpPage { get; }
        public DelegateCommand GoToInfoPage { get; }
        private INavigationService NavigationService => GetService<INavigationService>();

    }




}
