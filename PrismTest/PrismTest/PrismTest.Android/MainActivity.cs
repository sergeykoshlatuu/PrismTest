using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism;
using Prism.Ioc;
using Prism.Events;
using PrismTest.Droid.Services;
using PrismTestClassLibrary.Interfaces;
using PrismTestClassLibrary.Events;

namespace PrismTest.Droid
{
    [Activity(Label = "PrismTest", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IPlatformInitializer
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            var application = new App(this);
            var ea = application.Container.Resolve<IEventAggregator>().GetEvent<NativeEvent>().Subscribe(OnNameChangedEvent);
            
            LoadApplication(application);
        }

        private void OnNameChangedEvent(NativeEventArgs args)
        {
            Toast.MakeText(this,  args.Message, ToastLength.Long).Show();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<IDatabaseConnectionService>(new DatabaseConnectionService());
        }

    }

}

