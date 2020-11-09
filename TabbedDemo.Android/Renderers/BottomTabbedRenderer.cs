using System;
using Android.Content;
using Android.Support.Design.Widget;
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
        private Context _context;

        public BottomTabbedRenderer(Context context) : base(context)
        {
            _context = context;
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);
        }
    }
}
