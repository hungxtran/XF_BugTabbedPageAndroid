using System;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using TabbedDemo.ViewModels;
using TabbedDemo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedDemo
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            // Navigate to the first page
            NavigationService.NavigateAsync(PageConstants.Login);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
