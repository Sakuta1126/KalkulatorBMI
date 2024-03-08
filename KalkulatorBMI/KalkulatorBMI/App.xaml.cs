using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KalkulatorBMI
{
    public partial class App : Application
    {
        public static List<BMIwynik> ReadData()
        {
            if (File.Exists(App.DbPath))
            {
                List<string> lines = File.ReadLines(App.DbPath).ToList();
                List<BMIwynik> bMIwyniks = new List<BMIwynik>();
                foreach (var line in lines)
                {
                    string[] entries = line.Split(';');
                    if (entries.Length == 7)
                    {
                        BMIwynik newbMIwyniks = new BMIwynik();
                        newbMIwyniks.Title = entries[0];
                        newbMIwyniks.Date = DateTime.Parse(entries[1]);
                        newbMIwyniks.Weight = int.Parse(entries[2]);
                        newbMIwyniks.Height = int.Parse(entries[3]);
                        newbMIwyniks.Gender = entries[4];
                        newbMIwyniks.Score = float.Parse(entries[5]);
                        newbMIwyniks.Result = entries[6];

                        bMIwyniks.Add(newbMIwyniks);

                    }
                }
                return bMIwyniks;

            }
            else
                return null;
        }
        public static void WriteToFile(List<BMIwynik> bMIwyniks)
        {
            List<string> outputFile = new List<string>();
            foreach (var bmibMIwynik in bMIwyniks)
            {
                string line = $"{bmibMIwynik.Title};{bmibMIwynik.Date};{bmibMIwynik.Weight};{bmibMIwynik.Height};{bmibMIwynik.Gender};{bmibMIwynik.Score};{bmibMIwynik.Result}";
                outputFile.Add(line);
            }
            File.WriteAllLines(App.DbPath, outputFile);
        }
        public static string DbPath
        {
            get
            {
                var x = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BMIDatabasee.txt");
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BMIDatabasee.txt");
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
