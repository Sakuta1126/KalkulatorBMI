using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KalkulatorBMI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZapisaneWyniki : ContentPage
    {
        public ZapisaneWyniki()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            string path = App.DbPath;

            //if (File.Exists(path))
            //{
            //    string text = File.ReadAllText(path);


            //    List<BMIwynik> results = App.ReadData();

            //  listViewBMI.ItemsSource = results;
            //}
            listViewBMI.ItemsSource = App.ReadData();
        }



        private void usun_Clicked(object sender, EventArgs e)
        {
            //string path = App.DbPath;
            BMIwynik delete = ((Button)sender).BindingContext as BMIwynik;
            //string text = File.ReadAllText(path);
            List<BMIwynik> results = App.ReadData();
            foreach (var item in results)
            {
                if (item.ID == delete.ID)
                {
                    results.Remove(item);
                    break;
                }
            }
            listViewBMI.ItemsSource = results;
            //string savedresult = JsonConvert.SerializeObject(results);
            //File.WriteAllText(path, savedresult);
            App.WriteToFile(results);

        }

        private void usun_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}
