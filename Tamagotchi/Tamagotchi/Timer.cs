using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Timers;
using Tamagotchi.Views;

namespace Tamagotchi
{ 
    public static class Timer
    {
        private static System.Timers.Timer aTimer;

        public delegate void TimeEvents(object obj, EventArgs e);
        public static TimeEvents timeEvents;

        private static float tickTime = 5000;

       
        public static void Main()
        {
            SetTimer();
        }
        public static void SetTimer()
        {
            aTimer = new System.Timers.Timer(tickTime);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            App.timeAsleep = new TimeSpan();
        }

        public static void UpdateCreature(TimeSpan timeAsleep = new TimeSpan())
        {
            int invokeAount = Convert.ToInt32(Math.Round((timeAsleep.TotalMilliseconds / tickTime), 0));

            Console.WriteLine("[TIMER] Total secons asleep: " + timeAsleep.TotalMilliseconds + " Invoke Amount: " + invokeAount);

            for (int i = 0; i < invokeAount; i++)
            {
                timeEvents.Invoke(null, null);
            }
        }
        public static void StopTimer()
        {
            aTimer.Stop();
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            timeEvents(source, e);
            Console.WriteLine("[TIMEREVENT]:" + timeEvents.ToString());
        }

        
    }





}