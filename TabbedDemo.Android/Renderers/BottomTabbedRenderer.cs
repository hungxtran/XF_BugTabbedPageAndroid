using System;
using Android.Content;
using Android.Support.Design.Widget;
using Android.Views;
using TabbedDemo.Droid.Renderers;
using TabbedDemo.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(BottomTabbed), typeof(BottomTabbedRenderer))]
namespace TabbedDemo.Droid.Renderers
{
    public class BottomTabbedRenderer : TabbedPageRenderer, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        BottomNavigationView _bottomNavigationView;

        public BottomTabbedRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                _bottomNavigationView = FindChildOfType<BottomNavigationView>(ViewGroup);
                // call the workaround code here
                //EnableTabsIfAccidentallyDisabled();
            }
        }

        // The following is the workaround code. which enables all tabs when initializes them.
        private void EnableTabsIfAccidentallyDisabled()
        {
            int numberOfTabs = _bottomNavigationView.Menu.Size();
            for (int i = 0; i < numberOfTabs - 1; i++)
            {
                var bottomTab = _bottomNavigationView.Menu.GetItem(i);
                if (!bottomTab.IsEnabled)
                    bottomTab.SetEnabled(true);
            }
        }

        /// <summary>
        /// Finds the type of the child of.
        /// </summary>
        /// <returns>The child of type.</returns>
        /// <param name="viewGroup">View group.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        private T FindChildOfType<T>(ViewGroup viewGroup) where T : Android.Views.View
        {
            if (viewGroup == null || viewGroup.ChildCount == 0) return null;

            for (var i = 0; i < viewGroup.ChildCount; i++)
            {
                var child = viewGroup.GetChildAt(i);

                if (child is T typedChild) return typedChild;

                if (!(child is ViewGroup)) continue;

                var result = FindChildOfType<T>(child as ViewGroup);

                if (result != null) return result;
            }
            return null;
        }
    }
}
