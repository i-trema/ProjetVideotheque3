﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

namespace ProjetVideotheque3.Droid
{
    [Activity(Label = "ProjetVideotheque3", 
        Icon = "@mipmap/icon",
        Theme = "@style/SplashscreenTheme", // Affectation du thème pour le splashscreen
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.Window.RequestFeature(Android.Views.WindowFeatures.ActionBar);
            base.SetTheme(Resource.Style.MainTheme);

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}