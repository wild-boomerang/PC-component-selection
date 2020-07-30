using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Plugin.Settings;
using Project.Pages;

namespace Project
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "project.db";

        // Синхронная версия бд

        public static Database<CPU> cpuDatabase;
        public static Database<VideoCard> videoCardDatabase;
        public static Database<Motherboard> motherboardDatabase;
        public static Database<RAM> ramDatabase;
        public static Database<HDD> hddDatabase;
        public static Database<PowerSupply> powerSupplyDatabase;
        public static Database<Case> caseDatabase;

        //public static ItemsRepository<CPU> cpuDatabase;
        //public static ItemsRepository<CPU> CPUDatabase
        //{
        //    get
        //    {
        //        if (cpuDatabase == null)
        //        {
        //            cpuDatabase = new ItemsRepository<CPU>(DATABASE_NAME);
        //        }

        //        return cpuDatabase;
        //    }
        //}

        //public static ItemsRepository<VideoCard> videoCardDatabase;
        //public static ItemsRepository<VideoCard> VideoCardDatabase
        //{
        //    get
        //    {
        //        if (videoCardDatabase == null)
        //        {
        //            videoCardDatabase = new ItemsRepository<VideoCard>(DATABASE_NAME);
        //        }

        //        return videoCardDatabase;
        //    }
        //}








        //public static ItemsRepository<ComputerPart> dataBase;
        //public static ItemsRepository<ComputerPart> DataBase
        //{
        //    get
        //    {
        //        if (dataBase == null)
        //        {
        //            dataBase = new ItemsRepository<ComputerPart>(DATABASE_NAME);
        //        }

        //        return dataBase;
        //    }
        //}
        public App()
        {
            InitializeComponent();

            //SettingsItem settingsItem = new SettingsItem();
            //CrossSettings.Current.AddOrUpdateValue("user_settings", JsonConvert.SerializeObject(settingsItem));
            string jsonStr = CrossSettings.Current.GetValueOrDefault("user_settings", "null");

            if (jsonStr != "null")
            {
                SettingsItem settingsItem = JsonConvert.DeserializeObject<SettingsItem>(jsonStr);
                if (settingsItem.Language == "en" || settingsItem.Language == "ru")
                    CultureInfo.CurrentUICulture = new CultureInfo(settingsItem.Language);
            }

            //if (Device.OS != TargetPlatform.WinPhone)
            //{
            //    Resource.Culture = DependencyService.Get<ILocalize>()
            //                        .GetCurrentCultureInfo();
            //}

            MainPage = new MainPage();

            cpuDatabase = new Database<CPU>();
            videoCardDatabase = new Database<VideoCard>();
            motherboardDatabase = new Database<Motherboard>();
            ramDatabase = new Database<RAM>();
            hddDatabase = new Database<HDD>();
            powerSupplyDatabase = new Database<PowerSupply>();
            caseDatabase = new Database<Case>();
        }

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
