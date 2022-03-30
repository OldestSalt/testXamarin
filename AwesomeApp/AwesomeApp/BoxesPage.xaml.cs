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
            MainPage.Boxes.Add(new MyBox());
        }

        private void resetBox(object sender, EventArgs e) {
            var box = MainPage.Boxes.Where(i => i.id == Int32.Parse((sender as Button).ClassId)).FirstOrDefault();
            box.xTranslate = 0.0;
            box.yTranslate = 0.0;
            box.rot = 0.0;
        }

        private void removeBox(object sender, EventArgs e) {
            MainPage.Boxes.Remove(MainPage.Boxes.Where(i => i.id == Int32.Parse((sender as Button).ClassId)).FirstOrDefault());
        }
    }
}