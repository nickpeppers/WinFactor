using WinFactor.Services;
using WinFactor.Services.Interfaces;

namespace WinFactor.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            ServiceContainer.Register<IWinCalculationService>(() => new WinCalculationService());

            LoadApplication(new WinFactor.App());
        }
    }
}