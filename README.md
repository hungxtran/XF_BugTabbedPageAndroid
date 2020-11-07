# XF_BugTabbedPageAndroid
This sample project demonstrates a bug in Xamarin Forms update 4.4.0.936621 (4.4.0 Pre Release 1)
## Detailed Description
_**1. Prerequisites:**_
   - The [TabbedPageRenderer creates its list of tabs](https://github.com/xamarin/Xamarin.Forms/blob/4a9037e57c10613ba314264842599f669d6df9f5/Xamarin.Forms.Platform.Android/AppCompat/TabbedPageRenderer.cs#L636) and initializes a tab's **Enabled/Disabled state** with the Enabled/Disabled state of the **ContentPage associated** with that tab. See following code:
   ```c#
      List<(string title, ImageSource icon, bool tabEnabled)> CreateTabList()
      {
        var items = new List<(string title, ImageSource icon, bool tabEnabled)>();

        for (int i = 0; i < Element.Children.Count; i++)
        {
          var item = Element.Children[i]; // This is the ContentPage associated with tab[i].
          items.Add((item.Title, item.IconImageSource, item.IsEnabled)); // If the ContentPage is disabled, the tab is also disabled.
        }

        return items;
      }
   ```
   - In my case, I need to disable the ContentPage first to show a tutorial popup (a tip on startup). It takes some time initializing components and the tutorial popup. Meanwhile, if the ContentPage is enabled, user can fast tapping on the page to navigate to another page. Then the tutorial popup will show up on the wrong page. 
   - The problem for me is if I disables the ContentPage for the above purpose, the tab associated with it will also be disabled and there's no way to turn it back on. Except when I initialize all the tabs as enabled in my renderer, see the work around below.
   - The change was made in this PR: [xamarin/Xamarin.Forms#5904](https://github.com/xamarin/Xamarin.Forms/pull/5904/files#), or we can also see in the following commit: [xamarin/Xamarin.Forms@5cb2f01](https://github.com/xamarin/Xamarin.Forms/pull/5904/commits/5cb2f014b248de96c0e9872fb35ba45b9498eca6)

_**2. Bug Content:**_
   - OS: Android.
   - Precondition: 
     - Install the app the first time.
   - Steps of reproduction
     - Tap button **LOGIN** on the initial screen.
     - After logged in, the app displays a tutorial (tips on startup) as a popup.
     - Tap on the tutorial and the popup closed.
     - Switch to tab: Page 2, Page 3, Page 4 or Page 5.
     - Try switch back to tab: Page 1.
   - Actual Result:
     - Can't select tab Page 1 and the icon is greyed out, suggesting this tab is disabled.
   - Expected Result:
     - Can switch to tab Page 1 normally on the first time installation of the app.
 
 _**3. Work around:**_
   - Initialize the disabled tab (or all tabs in case we need to make sure no tab is accidentally disabled). See following code:
   ```c#
    int numberOfTabs = _bottomNavigationView.Menu.Size();
    for (int i = 0; i < numberOfTabs - 1; i++)
    {
        var bottomTab = _bottomNavigationView.Menu.GetItem(i);
        if (!bottomTab.IsEnabled)
            bottomTab.SetEnabled(true);
    }
   ```
   
_**4. Proposed Solution:**_
  - Solution 1: In my humble opinion, I think we should remove `bool tabEnabled` and create all the tabs only with its title and IconImageSource, its default states is of course enabled. 
  - Solution 2: Provides a public variable of some sort that linked to the states of tabs. This way in our client code we can control the state of each independent tabs.
