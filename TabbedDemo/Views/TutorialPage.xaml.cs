using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace TabbedDemo.Views
{
    public partial class TutorialPage : PopupPage
    {
        public TutorialPage()
        {
            InitializeComponent();
            tutorialPopup.BackgroundColor = Color.FromRgba(0, 0, 0, 0.2);
        }

        protected override bool OnBackButtonPressed()
        {
            // Don't use Method back default on Android
            return true;
        }
    }
}
