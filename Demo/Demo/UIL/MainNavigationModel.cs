using DevExpress.Mvvm;

namespace Demo.UIL
{
   public class MainNavigationModel:ViewModelBase
    {
        public MainNavigationModel()
        {
            GoToNewOffer = new DelegateCommand(() => NavigationService.Navigate(typeof(NewOfferView).FullName, null, this));
            GoToOffersPage = new DelegateCommand(() => NavigationService.Navigate(typeof(OffersView).FullName, null, this)); 
            GoToHomePage =new DelegateCommand(() => NavigationService.Navigate(typeof(HomeView).FullName, null, this));
            LoadedCommand = new DelegateCommand(() => NavigationService.Navigate(typeof(HomeView).FullName, null, this));
        }

      

        public DelegateCommand GoToHomePage { get; }
        public DelegateCommand LoadedCommand { get; }
        public DelegateCommand GoToNewOffer { get; }
        public DelegateCommand GoToOffersPage { get; }
        private INavigationService NavigationService => GetService<INavigationService>();

    }




}
