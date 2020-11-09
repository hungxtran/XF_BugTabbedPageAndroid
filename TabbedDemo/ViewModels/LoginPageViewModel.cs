﻿using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using TabbedDemo.Views;

namespace TabbedDemo.ViewModels
{
    public class LoginPageViewModel
    {
        INavigationService _navigationService;
        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private DelegateCommand _loginCommand;

        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(async () => await LoginCommandExecute()));

        private async Task LoginCommandExecute()
        {
            try
            {
                await _navigationService.NavigateAsync(PageConstants.Main);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
