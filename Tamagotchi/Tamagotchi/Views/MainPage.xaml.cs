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
      
        //Stats
        public string statHunger { get; set; }
        public string statThirst { get; set; }
        public string statBoredom { get; set; }
        public string statLoneliness { get; set; }
        public string statStimulated { get; set; }
        public string statTired { get; set; }

        public string StatusImage { get; set; }
        public string creatureName { get; set; }


        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
            Timer.Main();

            Timer.timeEvents += Decrease_Stats;
            Timer.timeEvents += UpdateUI;

        }

        protected override async void OnAppearing()
        {
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            App.myCreature = await creatureDataStore.ReadItem();

            if(App.myCreature == null)
            {
                await Navigation.PushAsync(new CreateNewCreature());
            }

            UpdateUI(null, null);

        }

        protected override async void OnDisappearing()
        {
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            await creatureDataStore.UpdateItem(App.myCreature);
            
        }
        private void Decrease_Stats(object sender, EventArgs e)
        {
            if (App.myCreature != null)
            {
                App.myCreature.ChangeStat(-0.1f, StatType.hunger);
                App.myCreature.ChangeStat(-0.1f, StatType.thirst);
                App.myCreature.ChangeStat(-0.1f, StatType.boredom);
                App.myCreature.ChangeStat(-0.1f, StatType.loneliness);
                App.myCreature.ChangeStat(-0.1f, StatType.stimulated);
                App.myCreature.ChangeStat(-0.1f, StatType.tired);
            }
        }
        
        private void UpdateUI(object sender, EventArgs e)
        {
            if (App.myCreature != null)
            {
                StatusImage = App.myCreature.myStatus;
                //creatureName = App.myCreature.name;
                creatureName = App.myCreature.userName;

                statThirst = App.myCreature.thirst.ToString();
                statHunger = App.myCreature.hunger.ToString();
                statBoredom = App.myCreature.boredom.ToString();
                statLoneliness = App.myCreature.loneliness.ToString();
                statStimulated = App.myCreature.stimulated.ToString();
                statTired = App.myCreature.tired.ToString();

                Console.WriteLine(StatusImage);
            }
        }
        private void Create_New_Creature(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateNewCreature());

        }
        private void Push_Actions(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Actions());
        }




    }
}
