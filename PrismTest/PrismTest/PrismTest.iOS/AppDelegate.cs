﻿using Foundation;
using Prism;
using Prism.Events;
using Prism.Ioc;
using PrismTest.iOS.Services;
using PrismTestClassLibrary.Events;
using PrismTestClassLibrary.Interfaces;
using UIKit;


namespace PrismTest.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IPlatformInitializer
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            var application = new App(this);

            var ea = application.Container.Resolve<IEventAggregator>().GetEvent<NativeEvent>().Subscribe(OnNameChangedEvent);

            LoadApplication(application);

            return base.FinishedLaunching(app, options);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
            containerRegistry.RegisterInstance<IDatabaseConnectionService>(new DatabaseConnectionService());
        }


        private void OnNameChangedEvent(NativeEventArgs args)
        {
            var alertView = new UIAlertView
            {
                Title = "Native Alert",
                Message = args.Message
            };
            alertView.AddButton("OK");
            alertView.Show();
        }
    }


}
