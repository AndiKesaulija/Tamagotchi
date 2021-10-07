using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tamagotchi.Views
{
    public partial class MainPage : ContentPage
    {
        public string TextFromCode { get; set; }
        public int statHunger = 1000;
        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
            Timer.Main();
            Timer.timeEvents += Decrease_Hunger;
            //Hunger.Text = statHunger.ToString();

        }
        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void PopUp(object sender, EventArgs e)
        {
            //Popup_Stats.IsVisible = !Popup_Stats.IsVisible;
        }

        private void Add_Hunger(object sender, EventArgs e)
        {
            statHunger = 1000;
            TextFromCode = statHunger.ToString();

            //Hunger.Text = statHunger.ToString();

            Console.WriteLine("Add_Hunger: " + statHunger);
        }

        private void Decrease_Hunger(object sender, EventArgs e)
        {
            statHunger = statHunger - 10;
            TextFromCode = statHunger.ToString();
            //Hunger.Text = statHunger.ToString();

            Console.WriteLine("Decrease_Hunger: " + statHunger);
        }
        private void Push_Actions(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Actions());
        }




    }
}
