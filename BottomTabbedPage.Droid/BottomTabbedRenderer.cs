﻿﻿/*
* Complying with Apache Licence Version 2.0 that the original version of this 
* has been distributed I declare herewith that this file has been modified by
* me, Marc Lohrer.
* 
* The change added a new class called BottomTabbedConfiguration that is used to 
* configure how the BottomTabbedRenderer renders the buttons of the TabbedPage.
* 
* I changed the base class from BottomTabbedPage to TabbedPage.
*/
using System;
using Android.Widget;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Naxam.Controls.Droid;
using System.ComponentModel;
using Com.Ittianyu.Bottomnavigationviewex;
using Naxam.Controls;
using Android.Support.Design.Internal;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(Naxam.Demo.BottomTabbedPage), typeof(Naxam.Controls.Droid.BottomTabbedRenderer))]
namespace Naxam.Controls.Droid
{
    using RelativeLayout = Android.Widget.RelativeLayout;
    using Platform = Xamarin.Forms.Platform.Android.Platform;

    public class BottomTabbedConfiguration
    {
        private readonly bool tabItemTextVisible;
        private readonly bool tabShiftingModeEnabled;
        private readonly bool tabItemShiftingModeEnabled;
        private readonly bool tabAnimationEnabled;

        public BottomTabbedConfiguration(bool tabItemTextVisible, bool tabShiftingModeEnabled, bool tabItemShiftingModeEnabled, bool tabAnimationEnabled)
        {
            this.tabItemTextVisible = tabItemTextVisible;
            this.tabShiftingModeEnabled = tabShiftingModeEnabled;
            this.tabItemShiftingModeEnabled = tabItemShiftingModeEnabled;
            this.tabAnimationEnabled = tabAnimationEnabled;
        }
    }

    public partial class BottomTabbedRenderer : VisualElementRenderer<TabbedPage>
	{
        public static readonly Action<IMenuItem, FileImageSource, bool> DefaultMenuItemIconSetter = (menuItem, icon, selected) =>
		{
			var tabIconId = ResourceManagerEx.IdFromTitle(icon, ResourceManager.DrawableClass);
			menuItem.SetIcon(tabIconId);
		};

		public static bool ShouldUpdateSelectedIcon;
		public static Action<IMenuItem, FileImageSource, bool> MenuItemIconSetter;
		public static float? BottomBarHeight;

        RelativeLayout rootLayout;
        FrameLayout pageContainer;
        BottomNavigationViewEx bottomNav;
        readonly int barId;

        IPageController TabbedController => Element as IPageController;

        public int LastSelectedIndex { get; internal set; }

        public BottomTabbedRenderer()
        {
            AutoPackage = false;

            barId = GenerateViewId();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                e.OldElement.ChildAdded -= PagesChanged;
                e.OldElement.ChildRemoved -= PagesChanged;
                e.OldElement.ChildrenReordered -= PagesChanged;
            }

            if (e.NewElement == null)
            {
                return;
            }

            UpdateIgnoreContainerAreas();

            if (rootLayout == null)
            {
                SetupNativeView();
            }


            this.HandlePagesChanged();
            SwitchContent(Element.CurrentPage);
            
            Element.ChildAdded += PagesChanged;
            Element.ChildRemoved += PagesChanged;
            Element.ChildrenReordered += PagesChanged;
        }

        void PagesChanged(object sender, EventArgs e)
        {
            this.HandlePagesChanged();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(TabbedPage.CurrentPage))
            {
                SwitchContent(Element.CurrentPage);
            }
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            TabbedController?.SendAppearing();
        }

        protected override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();
            TabbedController?.SendDisappearing();
        }

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            var width = right - left;
            var height = bottom - top;

            base.OnLayout(changed, left, top, right, bottom);

            if (width <= 0 || height <= 0)
            {
                return;
            }

            this.Layout(width, height);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
				Element.ChildAdded -= PagesChanged;
				Element.ChildRemoved -= PagesChanged;
				Element.ChildrenReordered -= PagesChanged;

                if (rootLayout != null)
                {
                    //TODO Cleanup
                    RemoveAllViews();
                    foreach (Page pageToRemove in Element.Children)
                    {
                        IVisualElementRenderer pageRenderer = Platform.GetRenderer(pageToRemove);

                        if (pageRenderer != null)
                        {
                            pageRenderer.ViewGroup.RemoveFromParent();
                            pageRenderer.Dispose();
                        }
                    }

                    if (bottomNav != null)
                    {
                        bottomNav.SetOnNavigationItemSelectedListener(null);
                        bottomNav.Dispose();
                        bottomNav = null;
                    }
                    rootLayout.Dispose();
                    rootLayout = null;
                }
            }

            base.Dispose(disposing);
        }

        internal void SetupNativeView()
        {
            rootLayout = this.CreateRoot(barId, GenerateViewId(),out pageContainer);

            AddView(rootLayout);
        }

        void SwitchContent(Page page)
        {
            this.ChangePage(pageContainer, page);
        }

        void UpdateIgnoreContainerAreas()
        {
            foreach (IPageController child in Element.Children)
            {
                child.IgnoresContainerArea = false;
            }
        }
    }
}