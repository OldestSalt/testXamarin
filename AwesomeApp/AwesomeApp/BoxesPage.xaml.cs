using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoxesPage : ContentPage {
        public BoxesPage() {
            InitializeComponent();
            BindableLayout.SetItemsSource(boxes, MainPage.Boxes);
        }

        private void Button_Clicked(object sender, EventArgs e) {
            var b = new MyBox();
            MainPage.Boxes.Add(b);

            Frame frm = new Frame() {
                BackgroundColor = b.color,
                ClassId = b.id.ToString(),
                TranslationX = b.xTranslate,
                TranslationY = b.yTranslate,
                Rotation = b.rot,
                Scale = b.scale
            };

            frm.Content = new Label() {
                Text = b.text,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            frm.SetBinding(BackgroundColorProperty, new Binding { Source = b, Path = "color", Mode = BindingMode.TwoWay });
            frm.SetBinding(TranslationXProperty, new Binding { Source = b, Path = "xTranslate", Mode = BindingMode.TwoWay });
            frm.SetBinding(TranslationYProperty, new Binding { Source = b, Path = "yTranslate", Mode = BindingMode.TwoWay });
            frm.SetBinding(RotationProperty, new Binding { Source = b, Path = "rot", Mode = BindingMode.TwoWay });
            frm.SetBinding(ScaleProperty, new Binding { Source = b, Path = "scale", Mode = BindingMode.TwoWay });
            frm.Content.SetBinding(Label.TextProperty, new Binding { Source = b, Path = "text", Mode = BindingMode.TwoWay });

            var ev = new TapGestureRecognizer();
            ev.Tapped += (aboba, abeba) => {
                if (MainPage.selectedBox != frm) {
                    if (MainPage.selectedBox != null) {
                        MainPage.selectedBox.BorderColor = Color.Transparent;
                        MainPage.selectedBox.RemoveBinding(TranslationXProperty);
                        MainPage.selectedBox.RemoveBinding(TranslationYProperty);
                        MainPage.selectedBox.RemoveBinding(RotationProperty);
                        MainPage.selectedBox.Content.RemoveBinding(Label.TextProperty);
                    }
                    MainPage.selectedBox = frm;
                    frm.BorderColor = Color.Red;

                    MainPage.leftAndRight.SetBinding(Stepper.ValueProperty, new Binding { Source = MainPage.selectedBox, Path = "TranslationX", Mode = BindingMode.TwoWay });
                    MainPage.upAndDown.SetBinding(Stepper.ValueProperty, new Binding { Source = MainPage.selectedBox, Path = "TranslationY", Mode = BindingMode.TwoWay });
                    MainPage.r.SetBinding(Slider.ValueProperty, new Binding { Source = MainPage.selectedBox, Path = "Rotation", Mode = BindingMode.TwoWay });
                    MainPage.t.SetBinding(Entry.TextProperty, new Binding { Source = MainPage.selectedBox.Content, Path = "Text", Mode = BindingMode.TwoWay });
                }
            };

            ev.NumberOfTapsRequired = 1;
            frm.GestureRecognizers.Add(ev);

            MainPage.f.Children.Add(frm,
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

        private void resetBox(object sender, EventArgs e) {
            var box = MainPage.Boxes.Where(i => i.id == Int32.Parse((sender as Button).ClassId)).FirstOrDefault();
            box.xTranslate = 0.0;
            box.yTranslate = 0.0;
            box.rot = 0.0;
            box.scale = 1.0;
        }

        private void removeBox(object sender, EventArgs e) {
            MainPage.Boxes.Remove(MainPage.Boxes.Where(i => i.id == Int32.Parse((sender as Button).ClassId)).FirstOrDefault());
        }
    }
}