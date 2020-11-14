using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using TabbedDemo.Views;

namespace TabbedDemo.ViewModels
{
    public class CoffeePageViewModel : ViewModelBase, IInitializeAsync, INavigationAware
    {
        private bool _hasShownTutorial = false;
        private bool _isEnableContentPage = true;
        public bool IsEnabledContentPage
        {
            get { return _isEnableContentPage; }
            set { SetProperty(ref _isEnableContentPage, value); }
        }

        public CoffeePageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            if (!_hasShownTutorial)
            {
                // If the tutorial has not shown, we disable the content page
                IsEnabledContentPage = false;
                await _navigationService.NavigateAsync(PageConstants.Tutorial);
                // After the tutorial has show, set the flag to true so it won't show again.
                _hasShownTutorial = true;
            }
        }

        private DelegateCommand _logoutCommand;
        public DelegateCommand LogoutCommand => _logoutCommand ?? (_logoutCommand = new DelegateCommand(async () => await LogoutCommandExecute()));

        private async Task LogoutCommandExecute()
        {
            try
            {
                await _navigationService.NavigateAsync(PageConstants.Login);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            // Currently do nothing here
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(PageConstants.Tutorial))
            {
                IsEnabledContentPage = true;
                _hasShownTutorial = true;
            }
        }
    }
}
