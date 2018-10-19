using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SimpleRESTclient
{
    public partial class App : Application
    {
        public static RestService service; 

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            service = new RestService();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            service.GetSomethingString();

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
