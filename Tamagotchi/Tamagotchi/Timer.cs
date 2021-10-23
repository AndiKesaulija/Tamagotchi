using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Timers;

namespace Tamagotchi
{ 
    public static class Timer
    {
        private static System.Timers.Timer aTimer;

        public delegate void TimeEvents(object obj, EventArgs e);
        public static TimeEvents timeEvents;

        public static void Main()
        {
            SetTimer();
        }
        public static void SetTimer()
        {
            
            aTimer = new System.Timers.Timer(6000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        public static void StopTimer()
        {
            aTimer.Stop();
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            timeEvents(source, e);
        }

        
    }





}