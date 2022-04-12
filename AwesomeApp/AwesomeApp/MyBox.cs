using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AwesomeApp {
    public class MyBox : BindableObject {
        private static int counter = 0;
        public static readonly BindableProperty colorProperty = BindableProperty.Create("color", typeof(Color), typeof(MyBox), Color.White);
        public Color color {
            get {
                return (Color)GetValue(colorProperty);
            }
            set {
                SetValue(colorProperty, value);
            }
        }

        public static readonly BindableProperty textProperty = BindableProperty.Create("text", typeof(string), typeof(MyBox), "Hello world!");
        public string text {
            get {
                return (string)GetValue(textProperty);
            }
            set {
                SetValue(textProperty, value);
            }
        }

        public static readonly BindableProperty xTranslateProperty = BindableProperty.Create("xTranslate", typeof(double), typeof(MyBox), 0.0);
        public double xTranslate {
            get {
                return (double)GetValue(xTranslateProperty);
            }
            set {
                SetValue(xTranslateProperty, value);
            }
        }

        public static readonly BindableProperty yTranslateProperty = BindableProperty.Create("yTranslate", typeof(double), typeof(MyBox), 0.0);
        public double yTranslate {
            get {
                return (double)GetValue(yTranslateProperty);
            }
            set {
                SetValue(yTranslateProperty, value);
            }
        }

        public static readonly BindableProperty rotProperty = BindableProperty.Create("rot", typeof(double), typeof(MyBox), 0.0);
        public double rot {
            get {
                return (double)GetValue(rotProperty);
            }
            set {
                SetValue(rotProperty, value);
            }
        }

        public static readonly BindableProperty scaleProperty = BindableProperty.Create("scale", typeof(double), typeof(MyBox), 1.0);
        public double scale {
            get {
                return (double)GetValue(scaleProperty);
            }
            set {
                SetValue(scaleProperty, value);
            }
        }

        public int id {
            get;
        }

        public MyBox() {
            ++counter;
            id = counter;
        }
    }
}
