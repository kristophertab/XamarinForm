using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace SimpleRESTclient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void mainPageSetOutputText(String text)
        {
            outputLabel.Text = text;
        }

        private void triggerButton_Clicked(object sender, EventArgs e)
        {
            String something = App.service.getResoultOfSomething();
            mainPageSetOutputText(something);
        }

        private void getBtn_Clicked(object sender, EventArgs e)
        {
            App.service.GetRest(urlEntry.Text);
            String response = App.service.GetRestResoult();
            mainPageSetOutputText(response);
        }

        private void postBtn_Clicked(object sender, EventArgs e)
        {
            App.service.PostRest();
        }

        private void putBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void deleteBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}
