using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace TabbedDemo.Renderers
{
    public class BottomTabbed : Xamarin.Forms.TabbedPage
    {
        public BottomTabbed()
        {
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Android>().SetIsSwipePagingEnabled(false);
            On<Android>().SetIsLegacyColorModeEnabled(false);
            On<Android>().SetIsSmoothScrollEnabled(false);
            // Number of pages that should be retained to either side of the current page in the view hierarchy in an idle state
            On<Android>().SetOffscreenPageLimit(5);

            BarTextColor = Color.Green;
        }
    }
}
