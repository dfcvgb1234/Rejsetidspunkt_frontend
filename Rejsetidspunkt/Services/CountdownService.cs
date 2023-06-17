using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Rejsetidspunkt.Services
{
    internal class CountdownService
    {
        public static CountdownService Instance
        {
            get
            {
                return instance;
            }
        }

        public static void Dispose()
        {
            instance.timer.Dispose();
            instance.timer = null;
            instance.IsRunning = false;
            instance = new CountdownService();
        }

        private static CountdownService instance = new CountdownService();

        public bool IsRunning { get; private set; }

        private TimeSpan Duration { get; set; }

        private System.Timers.Timer timer = new System.Timers.Timer();

        private CountdownService() { }

        public delegate Task SecondTickAsync(TimeSpan timeLeft);
        public delegate Task CountdownFinishedAsync();
        public event SecondTickAsync OnSecondTickAsync;
        public event CountdownFinishedAsync OnCountdownFinishedAsync;

        public void Start(TimeSpan duration)
        {
            if (duration.TotalSeconds > 0)
            {
                Duration = duration;
                timer.Interval = 1000;
                timer.AutoReset = true;
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
                IsRunning = true;
            }
            else
            {
                OnCountdownFinishedAsync?.Invoke();
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Duration = Duration.Subtract(TimeSpan.FromSeconds(1));
            OnSecondTickAsync?.Invoke(Duration);

            if (Duration.TotalSeconds <= 0)
            {
                timer.Stop();
                timer.Elapsed -= Timer_Elapsed;
                IsRunning = false;
                OnCountdownFinishedAsync?.Invoke();
            }
        }
    }
}
