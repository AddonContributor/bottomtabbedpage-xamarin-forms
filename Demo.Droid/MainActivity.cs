/*
* Complying with Apache Licence Version 2.0 that the original version of this 
* has been distributed I declare herewith that this file has been modified by
* me, Marc Lohrer.
* 
* The change largely affects the value of the properties of class BottomTabbedRenderer.
* 
* I removed a comment.
* I removed the command that changed the value of properties BackgroundColor, FontSize, IconSize, ItemSpacing, BottomBarHeight, ItemTextColor, ItemIconTintList
* I now set Typeface architep.ttf and ItemPadding to 5 explicitly
*/

using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Naxam.Controls.Droid;

namespace Naxam.Demo.Droid
{
    [Activity(Label = "BottomTabbedQs", Icon = "@mipmap/ic_launcher", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            SetupBottomTabs();

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }

        void SetupBottomTabs()
        {
			var stateList = new Android.Content.Res.ColorStateList(
				new int[][] {
					new int[] { Android.Resource.Attribute.StateChecked
				},
				new int[] { Android.Resource.Attribute.StateEnabled
				}
				},
				new int[] {
                    Color.DarkRed, //Selected
                    Color.White //Normal
                });

			BottomTabbedRenderer.Typeface = Typeface.CreateFromAsset(this.Assets, "architep.ttf");
			BottomTabbedRenderer.ItemBackgroundResource = Resource.Drawable.bnv_selector;
			BottomTabbedRenderer.ItemPadding = new Xamarin.Forms.Thickness(5);
			BottomTabbedRenderer.ItemAlign = ItemAlignFlags.Center;
			BottomTabbedRenderer.MenuItemIconSetter = (menuItem, iconSource, selected) => {
                var resId = Resources.GetIdentifier(iconSource.File, "drawable", PackageName);
                menuItem.SetIcon(resId);
			};
        }
    }
}
