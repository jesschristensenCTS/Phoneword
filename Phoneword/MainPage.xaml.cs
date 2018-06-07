using System;
using Xamarin.Forms;

namespace Phoneword
{
    //test
    public partial class MainPage : ContentPage
    {
        string translatedNumber;

        public MainPage()
        {
            //load in the components in the xaml
            InitializeComponent();
        }

        //when the translate button (created in xaml file) is clicked
        void OnTranslate(object sender, EventArgs e)
        {
            translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text); //Sends the text of the text field to the class in PhoneTranslator to be converted to numbers
            if (!string.IsNullOrWhiteSpace(translatedNumber)) //if the field is not empty
            {
                callButton.IsEnabled = true; //enables the call button
                callButton.Text = "Call " + translatedNumber; //changes the button text to call (the number translated)
            }
            else //if the field is empty
            {
                callButton.IsEnabled = false; //disable the button
                callButton.Text = "Call"; //change the text
            }
        }

        //when the call button is clicked
        async void OnCall(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                    "Dial a Number",
                    "Would you like to call " + translatedNumber + "?",
                    "Yes",
                    "No")) //creates an alert with text and a button for yes and no. Returns true if yes is pressed, false if no is pressed. Cannot do anything until a response is recieved
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                    dialer.Dial(translatedNumber); //send number to dial class
            }
        }
    }
}