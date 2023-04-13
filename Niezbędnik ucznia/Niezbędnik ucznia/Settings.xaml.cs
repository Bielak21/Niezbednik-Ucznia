using Niezbędnik_ucznia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Niezbędnik_ucznia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public static bool SwitchState { get; set; }
        public static bool Switch2State { get; set; }
        public static bool Switch3State { get; set; }
        public static int[] Delay = { 0, 0 };

        //słicze
        private void SwitchToggled(object sender, ToggledEventArgs e)
        {
            SwitchState = e.Value;
        }

        private void Switch2Toggled(object sender, ToggledEventArgs e)
        {
            Switch2State = e.Value;
        }
        private void Switch3Toggled(object sender, ToggledEventArgs e)
        {
            Switch3State = e.Value;
        }
        
        //Delay logic
        private void NewDelay(object sender, EventArgs args)
        {
            string minutyValue = minuty.Text, sekundyValue = sekundy.Text;
            int minuty_int, sekundy_int;

            if (int.TryParse(minutyValue, out minuty_int))
            {
                if (int.TryParse(sekundyValue, out sekundy_int))
                {
                    Delay[0] = minuty_int;
                    Delay[1] = sekundy_int;
                }
                else
                {
                    DisplayAlert("Błąd", "Sekundy powinny być liczbą", "OK");
                }
            }
            else
            {
                DisplayAlert("Błąd", "Minuty powinny być liczbą", "OK");
            }
        }

        //Button info
        private void Delay_info(object sender, EventArgs args)
        {
            DisplayAlert("Opóźnienie", "Dzwonek przeważnie się spóźnia. Tutaj możesz to dostosować.", "OK");
        }

        private void Allert_info(object sender, EventArgs args)
        {
            DisplayAlert("15 minut", "Kiedy magiczne 15 minut od rozpoczęcia lekcji minie, da ci znać.", "Zajebiście");
        }

        private void Notification_info(object sender, EventArgs e)
        {
            DisplayAlert("Powiadomienie", "Wysyła czas jako powiadomienie.", "OK");
        }

        //Notifications logic
        public static void CzyWyswietlicPowiadomienie(string czas, string lekcjaPrzerwa)
        {
            if(Switch2State == true)
            {
                Powiadomienie.SentNotification(czas, lekcjaPrzerwa, 1338);
            }
        }
        public Settings()
        {
            InitializeComponent();
            sw1.IsToggled = SwitchState;
            sw2.IsToggled = Switch2State;
            sw3.IsToggled = Switch3State;
            string slowo = Delay[1] <=4 ? "sekundy" : "sekund";
            CurrentDelay.Text = $"Obecne opóźnienie to {Delay[0]} minut i {Delay[1]} {slowo}";
        }
    }
}