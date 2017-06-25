using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mar31Fire
{
    public partial class MainPage : ContentPage
    {
        public  MainPage()
        {
            InitializeComponent();

            
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            valInfo input = new valInfo();
            input.valString = "0d5f4879-8290-413d-ab78-2a471813c7be";
            List<Building> FirstCheck = await App.BuildManager.GetTasksAsync(input);
            if (FirstCheck[0].buildingStatus == "NO BUILDINGS")
            {
                listText.IsVisible = true;
                listView.IsVisible = false;
            }
            else
            {
                listText.IsVisible = false;
                listView.ItemsSource = FirstCheck;//await App.BuildManager.GetTasksAsync(input);
                listView.IsVisible = true;
            }
            //listView.ItemsSource = await App.BuildManager.GetTasksAsync(input);
            //listView.IsVisible = true;
        }
    }
}
