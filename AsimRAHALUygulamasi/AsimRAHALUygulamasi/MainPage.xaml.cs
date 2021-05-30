using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AsimRAHALUygulamasi
{
    public partial class MainPage : ContentPage
    {
        //Label hataMsglbl = new Label() { 
        //    Text = "",
        //    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
        //    TextColor = Color.Red,
        //    VerticalTextAlignment = TextAlignment.Center,
        //    HorizontalTextAlignment = TextAlignment.Start,
        //    HorizontalOptions = LayoutOptions.Start
        //};   
        public MainPage()
        {
            InitializeComponent();
            OdevVizeNotuYuzdesi.Value = 40;
            FinelNotuYuzdesi.Value = 60;
        }

        private void Puan_hesapla(object sender, EventArgs e)
        {
            double vizeNotu = 0, odevNotu = 0, finelNotu = 0;
            if (GeçerliMi(VizeNotu, ref vizeNotu))
            {
                HataMsgVizeNotu.Text = "Vize Notunuz yazmadınız";
            }
            else
                HataMsgVizeNotu.Text = "";
            if (GeçerliMi(OdevNotu, ref odevNotu))
            {
                HataMsgOdevNotu.Text = "Odev Notunuz yazmadınız";
            }
            else HataMsgOdevNotu.Text = "";

            if (GeçerliMi(FinelNotu, ref finelNotu))
            {
                HataMsgFinelNotu.Text = "Finel Notunuz yazmadınız";
            }
            else
                HataMsgFinelNotu.Text = "";

            var x = OdevVizeNotuYuzdesi.Value;
            var y = FinelNotuYuzdesi.Value;
            var toplam = (((vizeNotu + odevNotu) / 2) * x + finelNotu * y) / 100;
            HBN.Text = Math.Round(toplam, 2).ToString();
            string harfNotu;
            Color color = new Color();
            if (toplam >= 88 && toplam <= 100)
            {
                color = Color.Green;
                harfNotu = "AA";
                Sonuç.Text = "Mükenmmel";
            }
            else if (toplam >= 80 && toplam < 88)
            {
                harfNotu = "BA";
                Sonuç.Text = "Çok iyi";

            }
            else if (toplam >= 73 && toplam < 80)
            {
                harfNotu = "BB";
                Sonuç.Text = "İyi";

            }
            else if (toplam >= 66 && toplam < 73)
            {
                harfNotu = "CB";
                Sonuç.Text = "Orta";

            }
            else if (toplam >= 60 && toplam < 66)
            {
                harfNotu = "CC";
                Sonuç.Text = "Yeterli";

            }
            else if (toplam >= 55 && toplam < 60)
            {
                harfNotu = "DC";
                Sonuç.Text = "Şartlı başarılı";

            }
            else if (toplam >= 50 && toplam < 55)
            {
                harfNotu = "DD";
                Sonuç.Text = "Şartlı başarılı";

            }
            else if (toplam >= 0 && toplam < 50)
            {
                color = Color.Red;
                harfNotu = "FF";
                Sonuç.Text = "başarısız";

            }
            else
            {
                harfNotu = "--";
                Sonuç.Text = "";

            }
            HarfNotu.TextColor = color;
            HarfNotu.Text = harfNotu;

        }

        private bool GeçerliMi(Entry entry, ref double not)
        {
            return string.IsNullOrWhiteSpace(entry.Text) || !Double.TryParse(VizeNotu.Text, out not);
        }

        private void FinelNotuYuzdesi_ValueChanged(Slider sender, ValueChangedEventArgs e)
        {
            OdevVizeNotuYuzdesi.Value = 100 - sender.Value;
            //Puan_hesapla(this, e);

        }

        private void OdevVizeNotuYuzdesi_ValueChanged(Slider sender, ValueChangedEventArgs e)
        {
            FinelNotuYuzdesi.Value= 100 - sender.Value;
            //Puan_hesapla(this, e);
        }
    }
}
