using CoronaClient.Services.API;
using Microsoft.UI.Xaml;

namespace CoronaClient;

public partial class App : Application
{

    public App()
    {
        this.InitializeComponent();
    }

    protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        APICoronaCountryService countryService =  new APICoronaCountryService();

        var result = await countryService.GetTopCases(10);

        m_window = new MainWindow();
        m_window.Activate();
    }

    private Window m_window;
}
