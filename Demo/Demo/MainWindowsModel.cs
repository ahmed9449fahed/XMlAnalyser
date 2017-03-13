using DevExpress.Mvvm;

namespace XMLAnalyzer
{
   public class MainWindowsModel:ViewModelBase
   {
       private INavigationService NavigationService => GetService<INavigationService>();

       internal void Navigate(string key)
       {
           NavigationService.Navigate(key,null,this);
       }
   }
}
