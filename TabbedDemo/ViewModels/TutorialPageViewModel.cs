using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using TabbedDemo.Views;

namespace TabbedDemo.ViewModels
{
    public class TutorialPageViewModel : ViewModelBase
    {
        public TutorialPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private DelegateCommand _closeTutorialCommand;
        public DelegateCommand CloseTutorialCommand => _closeTutorialCommand ?? (_closeTutorialCommand = new DelegateCommand(async () => await CloseTutorialCommandExecute()));

        private async Task CloseTutorialCommandExecute()
        {
            try
            {
                NavigationParameters pr = new NavigationParameters();
                pr.Add(PageConstants.Tutorial, "");
                await _navigationService.GoBackAsync(pr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
