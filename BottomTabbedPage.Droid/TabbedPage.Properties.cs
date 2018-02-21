/*
* Complying with Apache Licence Version 2.0 that the original version of this 
* has been distributed I declare herewith that this file has been modified by
* me, Marc Lohrer.
* 
* I added this file and all of its content.
*/
using System;
using Naxam.Controls.Droid;
using Xamarin.Forms;

namespace Naxam.Controls.Platform.Droid
{
    public static class TabbedPageBehavior
    {
        #region BackgroundColor

        private static Android.Graphics.Color defaultBackgroundColor = new Android.Graphics.Color(0x7F, 0x7F, 0x7F);

        public static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.CreateAttached(
                "BackgroundColor",
                typeof(Android.Graphics.Color),
                typeof(TabbedPage),
                defaultBackgroundColor,
                propertyChanged: OnAttachedBackgroundColorBehaviorChanged);

        public static Android.Graphics.Color GetAttachedBackgroundColorBehavior(BindableObject view)
        {
            return (Android.Graphics.Color)view.GetValue(BackgroundColorProperty);
        }

        public static void SetAttachedBackgroundColorBehavior(BindableObject view, Android.Graphics.Color value)
        {
            view.SetValue(BackgroundColorProperty, value);
        }

        static void OnAttachedBackgroundColorBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            var tabbedPage = view as TabbedPage;
            if (tabbedPage == null)
            {
                return;
            }
            BottomTabbedRenderer.BackgroundColor = (Android.Graphics.Color?)newValue;
        }

        #endregion

        #region FontSize

        static double defaultFontSize = 8.0;

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.CreateAttached(
                "FontSize",
                typeof(double),
                typeof(TabbedPage),
                defaultFontSize,
                propertyChanged: OnFontSizePropertyChanged);

        public static double GetFontSize(BindableObject view)
        {
            return (double)view.GetValue(FontSizeProperty);
        }

        public static void SetFontSize(BindableObject view, double value)
        {
            view.SetValue(FontSizeProperty, value);
        }

        static void OnFontSizePropertyChanged(BindableObject view, object oldValue, object newValue)
        {
            var tabbedPage = view as TabbedPage;
            if (tabbedPage == null)
            {
                return;
            }

            if (newValue != null && oldValue != newValue)
            {
                BottomTabbedRenderer.FontSize = Convert.ToSingle(newValue);
            }
        }

        #endregion

        #region IconSize

        static double defaultIconSize = 24.0;

        public static readonly BindableProperty IconSizeProperty =
            BindableProperty.CreateAttached(
                "IconSize",
                typeof(double),
                typeof(TabbedPage),
                defaultIconSize,
                propertyChanged: OnIconSizeChanged);

        public static double GetIconSize(BindableObject view)
        {
            return (double)view.GetValue(IconSizeProperty);
        }

        public static void SetIconSize(BindableObject view, double value)
        {
            view.SetValue(IconSizeProperty, value);
        }

        static void OnIconSizeChanged(BindableObject view, object oldValue, object newValue)
        {
            var tabbedPage = view as TabbedPage;
            if (tabbedPage == null)
            {
                return;
            }

            if (newValue != null && oldValue != newValue)
            {
                BottomTabbedRenderer.IconSize = Convert.ToSingle(newValue);
            }
        }

        #endregion

        #region ItemSpacing

        static double defaultItemSpacing = 4.0;

        public static readonly BindableProperty ItemSpacingProperty =
            BindableProperty.CreateAttached(
                "ItemSpacing",
                typeof(double),
                typeof(TabbedPage),
                defaultItemSpacing,
                propertyChanged: OnItemSpacingChanged);

        public static double GetItemSpacing(BindableObject view)
        {
            return (double)view.GetValue(ItemSpacingProperty);
        }

        public static void SetItemSpacing(BindableObject view, double value)
        {
            view.SetValue(ItemSpacingProperty, value);
        }

        static void OnItemSpacingChanged(BindableObject view, object oldValue, object newValue)
        {
            var tabbedPage = view as TabbedPage;
            if (tabbedPage == null)
            {
                return;
            }

            if (newValue != null && oldValue != newValue)
            {
                BottomTabbedRenderer.ItemSpacing = Convert.ToSingle(newValue);
            }
        }

        #endregion

        #region BottomBarHeight

        static double defaultBottomBarHeight = 56.0;

        public static readonly BindableProperty BottomBarHeightProperty =
            BindableProperty.CreateAttached(
                "BottomBarHeight",
                typeof(double),
                typeof(TabbedPage),
                defaultBottomBarHeight,
                propertyChanged: OnBottomBarHeightChanged);

        public static double GetBottomBarHeight(BindableObject view)
        {
            return (double)view.GetValue(BottomBarHeightProperty);
        }

        public static void SetBottomBarHeight(BindableObject view, double value)
        {
            view.SetValue(BottomBarHeightProperty, value);
        }

        static void OnBottomBarHeightChanged(BindableObject view, object oldValue, object newValue)
        {
            var tabbedPage = view as TabbedPage;
            if (tabbedPage == null)
            {
                return;
            }

            if (newValue != null && oldValue != newValue)
            {
                BottomTabbedRenderer.BottomBarHeight = Convert.ToSingle(newValue);
            }
        }

        #endregion
    }
}
