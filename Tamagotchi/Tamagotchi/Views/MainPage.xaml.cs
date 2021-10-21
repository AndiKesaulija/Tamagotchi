using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Tamagotchi.Views
{
    public partial class MainPage : ContentPage
    {
        public double width { get; set; }
        public double height { get; set; }
        public double contentHeight
        {
            get
            {
                return height * 0.2f;
            }
            set
            {
                contentHeight = value;
            }
        }
        public string statHunger { get; set; }
        public string statHappyness { get; set; }
        public Creature myCreature { get; set; }
        public bool hasCreature = false;

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
            Timer.Main();

            Timer.timeEvents += Decrease_Hunger;
            Timer.timeEvents += Decrease_Happyness;

            width = DeviceDisplay.MainDisplayInfo.Width;
            height = DeviceDisplay.MainDisplayInfo.Height;

        }

        protected override async void OnAppearing()
        {
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            myCreature = await creatureDataStore.ReadItem();

            if (myCreature == null)
            {
                hasCreature = true;
            }
            else
            {
                hasCreature = false;
            }
        }
       
        private void Add_Hunger(object sender, EventArgs e)
        {
            if (myCreature != null)
            {
                myCreature.hunger = 100;
                statHappyness = myCreature.hunger.ToString();
                //Console.WriteLine("Add_Hunger: " + statHunger);
            }

        }

        private void Decrease_Hunger(object sender, EventArgs e)
        {
            if(myCreature != null)
            {
                myCreature.hunger = myCreature.hunger - 10;
                statHunger = myCreature.hunger.ToString();
            }
            
        }
        private void Decrease_Happyness(object sender, EventArgs e)
        {
            if(myCreature != null)
            {
                myCreature.happyness = myCreature.happyness - 5;
                statHappyness = myCreature.happyness.ToString();
            }

        }
        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Create_New_Creature(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateNewCreature());

        }

        private void PopUp(object sender, EventArgs e)
        {
            //Popup_Stats.IsVisible = !Popup_Stats.IsVisible;
        }

        
        private void Push_Actions(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Actions());
        }




    }
}
