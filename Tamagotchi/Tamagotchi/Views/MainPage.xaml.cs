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
        //Stats
        public string statHunger { get; set; }
        public string statThirst { get; set; }
        public string statBoredom { get; set; }
        public string statLoneliness { get; set; }
        public string statStimulated { get; set; }
        public string statTired { get; set; }
        //public Creature myCreature { get; set; }
        public bool hasCreature = false;

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
            Timer.Main();

            Timer.timeEvents += Decrease_Hunger;
            Timer.timeEvents += Decrease_Thirst;
            Timer.timeEvents += Decrease_Boredom;
            Timer.timeEvents += Decrease_Loneliness;
            Timer.timeEvents += Decrease_Stimulated;
            Timer.timeEvents += Decrease_Tired;

            width = DeviceDisplay.MainDisplayInfo.Width;
            height = DeviceDisplay.MainDisplayInfo.Height;

        }

        protected override async void OnAppearing()
        {
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            App.myCreature = await creatureDataStore.ReadItem();
            
        }

        protected override async void OnDisappearing()
        {
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            await creatureDataStore.UpdateItem(App.myCreature);
            
        }

        private void Decrease_Thirst(object sender, EventArgs e)
        {
            if (App.myCreature != null)
            {
                App.myCreature.thirst = App.myCreature.thirst - 10;
                statThirst = App.myCreature.thirst.ToString();
            }
        }
        private void Decrease_Hunger(object sender, EventArgs e)
        {
            if(App.myCreature != null)
            {
                App.myCreature.hunger = App.myCreature.hunger - 10;
                statHunger = App.myCreature.hunger.ToString();
            }
        }
        private void Decrease_Boredom(object sender, EventArgs e)
        {
            if (App.myCreature != null)
            {
                App.myCreature.boredom = App.myCreature.boredom - 10;
                statBoredom = App.myCreature.boredom.ToString();
            }
        }
        private void Decrease_Loneliness(object sender, EventArgs e)
        {
            if (App.myCreature != null)
            {
                App.myCreature.loneliness = App.myCreature.loneliness - 10;
                statLoneliness = App.myCreature.loneliness.ToString();
            }
        }
        private void Decrease_Stimulated(object sender, EventArgs e)
        {
            if (App.myCreature != null)
            {
                App.myCreature.stimulated = App.myCreature.stimulated - 10;
                statStimulated = App.myCreature.stimulated.ToString();
            }
        }
        private void Decrease_Tired(object sender, EventArgs e)
        {
            if (App.myCreature != null)
            {
                App.myCreature.tired = App.myCreature.tired - 10;
                statTired = App.myCreature.tired.ToString();
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
