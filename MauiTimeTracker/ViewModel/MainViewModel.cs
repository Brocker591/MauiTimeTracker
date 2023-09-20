using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MauiTimeTracker.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        IDispatcherTimer tracker = Application.Current.Dispatcher.CreateTimer();
        public ObservableCollection<TimeTracker> TimeTrackers { get; set; } = new();




        private TimeSpan runningTotal;
        public TimeSpan RunningTotal
        {
            get => runningTotal;
            set
            {
                if (runningTotal == value)
                    return;

                runningTotal = value;
                OnPropertyChanged();
            }
        }

        private bool isTimerRunning;
        public bool IsTimerRunning
        {
            get => isTimerRunning;
            set
            {
                if (isTimerRunning == value)
                    return;

                isTimerRunning = value;
                OnPropertyChanged();
            }
        }

        private bool isNotTimerRunning;
        public bool IsNotTimerRunning
        {
            get => isNotTimerRunning;
            set
            {
                if (isNotTimerRunning == value)
                    return;

                isNotTimerRunning = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {

            RunningTotal = new TimeSpan(0, 0, 0);
            IsTimerRunning = false;
            IsNotTimerRunning = true;


            tracker.Interval = TimeSpan.FromSeconds(1);
            tracker.Tick += (s, e) => DoSomething();


        }


        void DoSomething()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                //Update view here
                //DateEnd = DateTime.Now;
                //RunningTotal = DateEnd - DateNow;
                RunningTotal = new TimeSpan(0, 0, 0);

                for(int i = 0; i < (TimeTrackers.Count-1); i++)
                {
                    RunningTotal += TimeTrackers[i].TrackingTime;
                }

                var currentTime = DateTime.Now;

                var currenttimeSpan = currentTime - TimeTrackers[TimeTrackers.Count-1].Start;

                RunningTotal = RunningTotal + currenttimeSpan;

            });
        }

        public void StopTracker()
        {
            tracker.Stop();
            TimeTrackers[TimeTrackers.Count-1].End = DateTime.Now;
            TimeTrackers[TimeTrackers.Count - 1].TrackingTime = TimeTrackers[TimeTrackers.Count - 1].End - TimeTrackers[TimeTrackers.Count - 1].Start;
            IsTimerRunning = false;
            IsNotTimerRunning = true;
        }

        public void StartTracker()
        {
            TimeTracker newTracker = new TimeTracker();
            newTracker.Start = DateTime.Now;
            TimeTrackers.Add(newTracker);
            IsTimerRunning = true;
            IsNotTimerRunning = false;

            tracker.Start();


        }

        public void ResetTracker()
        {
            tracker.Stop();
            TimeTrackers.Clear();
            RunningTotal = new TimeSpan(0, 0, 0);
            IsTimerRunning = false;
            IsNotTimerRunning = true;
        }

    }
}
