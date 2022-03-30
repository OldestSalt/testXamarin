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

        private Frame selectedBox;
        private MyBox selectedBoxObj;
        public MainPage() {
            InitializeComponent();
            colors.ItemsSource = pickerColors.Keys.ToList();
            colors.SelectedIndex = 0;
        }

        private void userText_TextChanged(object sender, TextChangedEventArgs e) {
            if (selectedBox != null) {
                (selectedBox.Content as Label).Text = (sender as Entry).Text;
                selectedBoxObj.text = (sender as Entry).Text;
            }
        }

        private void colors_SelectedIndexChanged(object sender, EventArgs e) {
            if (selectedBox != null) {
                selectedBox.BackgroundColor = pickerColors[colors.SelectedItem.ToString()];
                selectedBoxObj.color = pickerColors[colors.SelectedItem.ToString()];
            }
        }

        private void StepperLeftAndRight_ValueChanged(object sender, ValueChangedEventArgs e) {
            if (selectedBox != null) {
                selectedBox.TranslationX = (sender as Stepper).Value;
                selectedBoxObj.xTranslate = (sender as Stepper).Value;
            }
        }

        private void StepperUpAndDown_ValueChanged(object sender, ValueChangedEventArgs e) {
            if (selectedBox != null) {
                selectedBox.TranslationY = (sender as Stepper).Value;
                selectedBoxObj.yTranslate = (sender as Stepper).Value;
            }
        }

        private void rotation_ValueChanged(object sender, ValueChangedEventArgs e) {
            if (selectedBox != null) {
                selectedBox.Rotation = (sender as Slider).Value;
                selectedBoxObj.rot = (sender as Slider).Value;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e) {
            LAR.Value = 0;
            UAD.Value = 0;
            rotation.Value = 0;
            await DisplayAlert("Successfully!", "Chosen box has been reset, idiot.", "Ok...");
        }

        private void Button_Clicked_1(object sender, EventArgs e) {
            //await DisplayAlert("Hey, Paha!", "( ° ͜ʖ͡°)╭∩╮\nPal'chik", "Ok...");
            var boxesPage = new BoxesPage();
            boxesPage.Disappearing += (biba, boba) => {
                field.Children.Clear();
                foreach (var b in Boxes) {
                    Frame frm = new Frame() {
                        BackgroundColor = b.color,
                        ClassId = b.id.ToString(),
                        TranslationX = b.xTranslate,
                        TranslationY = b.yTranslate,
                        Rotation = b.rot
                    };
                    frm.Content = new Label() {
                        Text = b.text,
                        TextColor = Color.Black,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalTextAlignment = TextAlignment.Center
                    };

                    var ev = new TapGestureRecognizer();
                    ev.Tapped += (aboba, abeba) => {
                        if (selectedBox != null) {
                            selectedBox.BorderColor = Color.Transparent;
                        }
                        selectedBox = frm;
                        selectedBoxObj = Boxes.Where(i => i.id == Int32.Parse(frm.ClassId)).FirstOrDefault();
                        frm.BorderColor = Color.Red;

                        colors.SelectedItem = pickerColors.Where(i => i.Value == frm.BackgroundColor).FirstOrDefault().Key;
                        entry.Text = (frm.Content as Label).Text;
                        LAR.Value = frm.TranslationX;
                        UAD.Value = frm.TranslationY;
                        rotation.Value = frm.Rotation;
                    };
                    ev.NumberOfTapsRequired = 1;
                    frm.GestureRecognizers.Add(ev);

                    field.Children.Add(frm,
                        Constraint.RelativeToParent(p => {
                            return p.Width * 0.5 - 75;
                        }),
                        Constraint.RelativeToParent(p => {
                            return p.Height * 0.5 - 75;
                        }),
                        Constraint.Constant(150),
                        Constraint.Constant(150)
                    );
                }
            };

            Navigation.PushAsync(boxesPage);

        }

        private void boxChosen(object sender, EventArgs e) {
            selectedBox = sender as Frame;
        }
    }

    public class MyBox {
        private static int counter = 0;
        public Color color {
            get; set;
        } = Color.White;

        public string text {
            get; set;
        } = "Hello world!";

        public double xTranslate {
            get; set;
        } = 0;

        public double yTranslate {
            get; set;
        } = 0;

        public double rot {
            get; set;
        } = 0.0;

        public int id {
            get;
        }

        public MyBox() {
            ++counter;
            id = counter;
        }
    }
}
