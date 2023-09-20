using MauiTimeTracker.ViewModel;

namespace MauiTimeTracker;

public partial class MainPage : ContentPage
{
    MainViewModel ViewModel { get; set; }



    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        BindingContext = viewModel;
    }


    private void StartTrackerrBtn_Clicked(object sender, EventArgs e)
    {
        ViewModel.StartTracker();
    }

    private void StopTrackerBtn_Clicked(object sender, EventArgs e)
    {
        ViewModel.StopTracker();
    }

    private void ResetTrackerBtn_Clicked(object sender, EventArgs e)
    {
        ViewModel.ResetTracker();
    }
}

