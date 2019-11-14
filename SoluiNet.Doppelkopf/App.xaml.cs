// <copyright file="App.xaml.cs" company="SoluiNet">
// Copyright (c) SoluiNet. All rights reserved.
// </copyright>

namespace SoluiNet.Doppelkopf
{
    using System;
    using SoluiNet.Doppelkopf.Services;
    using SoluiNet.Doppelkopf.Views;
    using Xamarin.Essentials;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

            if (UseMockDataStore)
            {
                DependencyService.Register<MockDataStore>();
            }
            else
            {
                DependencyService.Register<AzureDataStore>();
            }

            this.MainPage = new MainPage();
        }

        // TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        // To debug on Android emulators run the web backend against .NET Core not IIS
        // If using other emulators besides stock Google images you may need to adjust the IP address
        public static string AzureBackendUrl { get; } = DeviceInfo.Platform == DevicePlatform.Android
            ? "http://10.0.2.2:5000"
            : "http://localhost:5000";

        public static bool UseMockDataStore { get; } = true;

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
