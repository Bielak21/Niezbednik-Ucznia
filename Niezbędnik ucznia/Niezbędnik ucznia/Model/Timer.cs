using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Niezbędnik_ucznia.Model
{
    public class Timer
    {
        private bool isTimerRunning;
        private readonly int intervalSeconds = 1;
        private readonly MainPage mainPage;
        private readonly List<Lekcja> listaLekcji = Lista.listaLekcji;

        public Timer(MainPage mainPage)
        {
            this.mainPage = mainPage;
        }

        
        public void StartTimer()
        {
            if (!isTimerRunning)
            {
                isTimerRunning = true;
                Device.StartTimer(TimeSpan.FromSeconds(intervalSeconds), () =>
                {
                    UpdateRemainingTime();
                    return isTimerRunning;
                });
            }
        }

        public void StopTimer()
        {
            isTimerRunning = false;
        }

        private void UpdateRemainingTime()
        {
            TimeSpan remainingTime;
            Lekcja currentLesson = GetCurrentLesson();
            if (currentLesson == null)
            {
                // Lekcja obecnie nie trwa
                Lekcja nextLesson = GetNextLesson();
                //sprawdź czy są jeszcze lekcje danego dnia
                if (nextLesson == null)
                {
                    // Brak lekcji
                    this.mainPage.PozostalyCzasText.Text = "Koniec lekcji na dziś";
                }
                else
                {
                    // Wyświetl czas do kolejnej lekcji
                    remainingTime = nextLesson.poczatekLekcji - DateTime.Now.TimeOfDay;
                    if (Settings.Switch3State == true)
                    {
                        remainingTime += TimeSpan.FromMinutes(Settings.Delay[0]) + TimeSpan.FromSeconds(Settings.Delay[1]);
                    }
                    this.mainPage.PozostalyCzasText.Text = $"Do następnej lekcji zostało {remainingTime:mm\\:ss}";
                    Settings.CzyWyswietlicPowiadomienie($"{remainingTime:mm\\:ss}", "Zostało do następnej lekcji");
                }
                
            }
            else
            {
                // Lekcja trwa
                remainingTime = currentLesson.koniecLekcji - DateTime.Now.TimeOfDay;
                if(Settings.Switch3State == true)
                {
                    remainingTime += TimeSpan.FromMinutes(Settings.Delay[0]) + TimeSpan.FromSeconds(Settings.Delay[1]);
                }
                this.mainPage.PozostalyCzasText.Text = $"Zostało {remainingTime:mm\\:ss} do końca lekcji {currentLesson.nrLekcji}";
                //this.mainPage.UcieczkaText.Text = $"Do ucieczki zostało {remainingTime}";
                Settings.CzyWyswietlicPowiadomienie($"{remainingTime:mm\\:ss}", "Zostało do następnej przerwy");
                //powiadomienie o uciekaniu
                if (Settings.SwitchState == true && Math.Abs(remainingTime.TotalSeconds - TimeSpan.FromMinutes(30).TotalSeconds) < 1)
                {
                    Powiadomienie.SentNotification("Uciekaj z lekcji", "15 minut minęło, więc SPIERDALAJ", 1337);
                }
            }
        }

        private Lekcja GetCurrentLesson()
        {
            var teraz = DateTime.Now.TimeOfDay;
            if (Settings.Switch3State == true)
            {
                teraz = teraz.Subtract(new TimeSpan(0, Settings.Delay[0], Settings.Delay[1]));
            }
            foreach (var lekcja in listaLekcji)
            {
                if (teraz >= lekcja.poczatekLekcji && teraz < lekcja.koniecLekcji)
                {
                    return lekcja;
                }
            }

            // Zwraca null, jeśli obecnie nie odbywa się żadna lekcja
            return null;
        }

        private Lekcja GetNextLesson()
        {
            var teraz = DateTime.Now.TimeOfDay;

            foreach (var lekcja in listaLekcji)
            {
                if (teraz < lekcja.poczatekLekcji)
                {
                    return lekcja;
                }
            }

            // Zwraca null, jeśli nie ma już żadnej lekcji w dniu
            return null;
        }

    }
}
