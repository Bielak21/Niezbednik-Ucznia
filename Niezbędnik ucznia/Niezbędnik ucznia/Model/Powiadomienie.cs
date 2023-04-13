using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms.PlatformConfiguration;
using static System.Net.Mime.MediaTypeNames;

namespace Niezbędnik_ucznia.Model
{
    public class Powiadomienie
    {
        public static int argb = Color.FromArgb(255, 0, 255, 255).ToArgb();
        public static void SentNotification(string title, string tekst, int NotId)
        {
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = tekst,
                Title = title,
                NotificationId = NotId,
                Sound = DeviceInfo.Platform == DevicePlatform.Android ? "silence_2.5s" : "silence_2.5s.mp3",
                Android = {
                    Color = new AndroidColor(argb)
                }
            };
            LocalNotificationCenter.Current.Show(notification);
        }
    }
}
