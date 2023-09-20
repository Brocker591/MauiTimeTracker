namespace MauiTimeTracker;

public class TimeTracker : BaseModel
{
    public DateTime start;
    public DateTime Start
    {
        get => start;
        set
        {
            if (start == value)
                return;
            start = value;
            this.OnPropertyChanged();
        }
    }

    public DateTime end;
    public DateTime End
    {
        get => end;
        set
        {
            if (end == value)
                return;
            end = value;
            this.OnPropertyChanged();
        }
    }

    public TimeSpan trackingTime;
    public TimeSpan TrackingTime
    {
        get => trackingTime;
        set
        {
            if (trackingTime == value)
                return;
            trackingTime = value;
            this.OnPropertyChanged();
        }
    }
}

