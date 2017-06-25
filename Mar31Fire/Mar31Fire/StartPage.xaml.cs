using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Mar31Fire;


namespace Mar31Fire
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public List<Building> buildingList { get; private set; } 

        public StartPage()
        {
            InitializeComponent();
        }

        async  void OnSaveActivated(object sender, EventArgs e)
        {
            //var EmailTest = (eMail)BindingContext;
            eMail EmailTest = new eMail();
            eMailStatus  EmailStat = new eMailStatus();
            EmailTest.emailAddress = emailEntry.Text;
            try
            {
                EmailStat = await App.BuildManager.SendEmailAsync(EmailTest);

                if (EmailStat.statusCode.ToString() == "200")
                {
                    emailEntry.Text = "Email Successfully Sent";
                }
                if (EmailStat.statusCode.ToString() == "404")
                {
                    emailEntry.Text = "Email Address Not Found - Must be in our database to continue - check entry";
                }
                if (EmailStat.statusCode.ToString() == "500")
                {
                    emailEntry.Text = "Issue sending email - please try again later";
                }


                //enterButton.IsVisible = false;
                //confirmButton.IsVisible = true;
                //confirmEntry.IsVisible = true;
                //emailEntry.IsVisible = false;



                new NavigationPage(new StartPage());
            }
            catch
            {  }
             
            //await Navigation.PopToRootAsync();
        }

        //private async void OnDeleteActivated(object sender, EventArgs e)
        //{
        //    confirmEntry.Text = "This button pressed";
        //    valInfo input = new valInfo();
        //    input.valString = "3800745c-f10c-4d11-a6df-3296df27ee0e";
        //     List<Building> content = await App.BuildManager.GetTasksAsync(input);
        //    //List<Building> testList = await App.BuildManager.GetTasksAsync(input);

        //    buildingList = JsonConvert.DeserializeObject<List<Building>>(content.ToString());
        //}

        private async void confirmButton_Clicked(object sender, EventArgs e)
        {

            userValidation confVal = new userValidation();
            confVal.Token = confirmEntry.Text;
            confVal.cookieInfo = null;
            confirmEntry.Text = "Confirmation Code Sent";
            confirmStatus confirmCheck = new confirmStatus();
            confirmCheck = await App.BuildManager.SendConfirmAsync(confVal);
            bool sometest = confirmCheck.statusCode;
            //           confirmEntry.Text = confirmCheck.statusCode.ToString();
            if (sometest)
            {
                var buildPage = new MainPage();
                await Navigation.PushAsync(buildPage);
            }
            else { confirmEntry.Text = "Confirmation Code Not Accepted"; }
        }
    }
}
