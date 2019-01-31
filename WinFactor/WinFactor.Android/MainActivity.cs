using Android.App;
using Android.Content.PM;
using Android.OS;
using WinFactor.Services;
using WinFactor.Services.Interfaces;

namespace WinFactor.Droid
{
    [Activity(Label = "WinFactor", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            ServiceContainer.Register<IWinCalculationService>(() => new WinCalculationService());

            LoadApplication(new App());
        }
    }
}