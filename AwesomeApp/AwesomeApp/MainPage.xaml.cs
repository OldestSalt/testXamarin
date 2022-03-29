using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AwesomeApp {
    public partial class MainPage : ContentPage {
        private Dictionary<string, Color> pickerColors = new Dictionary<string, Color> {
            {"White", Color.White},
            {"Blue", Color.Blue},
            {"Red", Color.Red},
            {"Yellow", Color.Yellow},
            {"Green", Color.Green},
            {"Orange", Color.Orange}
        };
        public MainPage() {
            InitializeComponent();

            colors.ItemsSource = pickerColors.Keys.ToList();
            colors.SelectedIndex = 0;
        }

        private void userText_TextChanged(object sender, TextChangedEventArgs e) {
            text.Text = (sender as Entry).Text;
        }

        private void colors_SelectedIndexChanged(object sender, EventArgs e) {
            box.BackgroundColor = pickerColors[colors.SelectedItem.ToString()];
        }

        private void StepperLeftAndRight_ValueChanged(object sender, ValueChangedEventArgs e) {
            box.TranslationX = (sender as Stepper).Value;
        }

        private void StepperUpAndDown_ValueChanged(object sender, ValueChangedEventArgs e) {
            box.TranslationY = (sender as Stepper).Value;
        }

        private async void Button_Clicked(object sender, EventArgs e) {
            LAR.Value = 0;
            UAD.Value = 0;
            await DisplayAlert("Successfully!", "Your box has been reset, idiot.", "Ok...");
        }

        private async void Button_Clicked_1(object sender, EventArgs e) {
            await DisplayAlert("Hey, Paha!", "( ° ͜ʖ͡°)╭∩╮\nPal'chik", "Ok...");
        }
    }
}
