using Niezbędnik_ucznia.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Niezbędnik_ucznia
{
    public partial class MainPage : ContentPage
    {
        public Label PozostalyCzasText
        {
            get { return pozostalyCzasText; }
        }
        public MainPage()
        {
            InitializeComponent();

            Timer timer = new Timer(this);
            timer.StartTimer();
        }

        
        async private void OnSettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings());
        }

        async private void Easter_egg(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Egg());
        }
    }
}