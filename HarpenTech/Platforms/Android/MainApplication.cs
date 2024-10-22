﻿using Android.App;
using Android.OS;
using Android.Runtime;

namespace HarpenTech
{
    [Application(UsesCleartextTraffic = true)]
    public class MainApplication : MauiApplication
    {
        public static readonly string ChannelId = "exampleServiceChannel";
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override void OnCreate()
        {
            base.OnCreate();

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
#pragma warning disable CA1416
                var serviceChannel =
                   new NotificationChannel(ChannelId, "Example Service Channel", NotificationImportance.Default);

                if (GetSystemService(NotificationService) is NotificationManager manager)
                {
                    manager.CreateNotificationChannel(serviceChannel);
                }
#pragma warning restore CA1416
            }

        }
    }
}