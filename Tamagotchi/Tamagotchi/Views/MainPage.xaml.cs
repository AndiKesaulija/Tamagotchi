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
        public string statHunger { get; set; }
        public string statHappyness { get; set; }
        Creature myCreature = new Creature();
        public MainPage()
        {
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();

            BindingContext = this;
            InitializeComponent();
            Timer.Main();

            Timer.timeEvents += Decrease_Hunger;
            Timer.timeEvents += Decrease_Happyness;

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
            myCreature.hunger = 100;
            statHappyness = myCreature.hunger.ToString();


            Console.WriteLine("Add_Hunger: " + statHunger);
        }

        private void Decrease_Hunger(object sender, EventArgs e)
        {
            myCreature.hunger = myCreature.hunger - 10;
            statHunger = myCreature.hunger.ToString();
            //Console.WriteLine("Decrease_Hunger: " + statHunger);
        }
        private void Decrease_Happyness(object sender, EventArgs e)
        {
            myCreature.happyness = myCreature.happyness - 5;
            statHappyness = myCreature.happyness.ToString();
            //Console.WriteLine("Decrease_Hunger: " + statHunger);
        }
        private void Push_Actions(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Actions());
        }




    }
}
