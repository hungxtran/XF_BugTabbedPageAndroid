using System;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;

namespace TabbedDemo.ViewModels
{
    public class ViewModelBase : BindableBase
    {
        protected INavigationService _navigationService { get; set; }

        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
