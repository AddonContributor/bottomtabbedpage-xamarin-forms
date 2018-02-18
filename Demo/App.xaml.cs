/*
* Complying with Apache Licence Version 2.0 that the original version of this 
* has been distributed I declare herewith that this file has been modified by
* me, Marc Lohrer.
* 
* I moved the layout in xaml files.
*/

using System;
using System.Linq;
using Naxam.Controls.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Naxam.Demo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new BottomTabbedPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
