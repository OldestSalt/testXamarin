using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AwesomeApp {
    public partial class MainPage : ContentPage {
        private static Dictionary<string, Color> pickerColors = new Dictionary<string, Color> {
            {"White", Color.White},
            {"Blue", Color.Blue},
            {"Red", Color.Red},
            {"Yellow", Color.Yellow},
            {"Green", Color.Green},
            {"Orange", Color.Orange}
        };

        public static ObservableCollection<MyBox> Boxes = new ObservableCollection<MyBox>();

        public static Frame selectedBox;
        public static MyBox selectedBoxObj;
        public static RelativeLayout f;
        public static Stepper leftAndRight;
        public static Stepper upAndDown;
        public static Slider r;
        public static Entry t;

        public MainPage() {
            InitializeComponent();

            f = field;
            leftAndRight = LAR;
            upAndDown = UAD;
            r = rotation;
            t = entry;


            colors.ItemsSource = pickerColors.Keys.ToList();
            colors.SelectedIndex = 0;

            var pinchEvent = new PinchGestureRecognizer();

            pinchEvent.PinchUpdated += (s, e) => {
                if (selectedBox != null) {
                    if (selectedBox.Scale > 0.1 || e.Scale > 0) {
                        selectedBox.Scale += e.Scale - 1;
                    }
                }
            };
            field.GestureRecognizers.Add(pinchEvent);

        }

        private void colors_SelectedIndexChanged(object sender, EventArgs e) {
            if (selectedBox != null) {
                selectedBox.BackgroundColor = pickerColors[colors.SelectedItem.ToString()];
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e) {
            //await DisplayAlert("Hey, Paha!", "( ° ͜ʖ͡°)╭∩╮\nPal'chik", "Ok...");
            var boxesPage = new BoxesPage();

            Navigation.PushAsync(boxesPage);

        }
    }
}
