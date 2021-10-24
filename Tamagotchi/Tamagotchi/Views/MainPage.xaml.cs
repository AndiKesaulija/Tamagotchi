using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Timers;


namespace Tamagotchi.Views
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public Creature myCreature { get; set; }
        public double width { get; set; }
        public bool atPlayGround { get; set; }



        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
            Timer.Main();
            Timer.timeEvents += Decrease_Stats;

            width = App.ScreenWidth;
        }
       
        protected override async void OnAppearing()
        {
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            myCreature = await creatureDataStore.ReadItem();

            if(myCreature == null)
            {
               await Navigation.PushAsync(new CreateNewCreature());
            }

            

        }

        protected override async void OnDisappearing()
        {
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            await creatureDataStore.UpdateItem(myCreature);


        }
        private void Decrease_Stats(object sender, EventArgs e)
        {
            myCreature.ChangeStat(-0.1f, StatType.hunger);
            myCreature.ChangeStat(-0.1f, StatType.thirst);
            myCreature.ChangeStat(-0.1f, StatType.boredom);
            myCreature.ChangeStat(-0.1f, StatType.loneliness);
            myCreature.ChangeStat(0.1f, StatType.stimulated, true);
            myCreature.ChangeStat(-0.1f, StatType.tired);
        }
        public void AtPlayground(object sender, EventArgs e)
        {
            myCreature.ChangeStat(0.3f, StatType.loneliness, true);
            myCreature.ChangeStat(-0.3f, StatType.stimulated);
        }

        private void Create_New_Creature(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateNewCreature());

        }
        private async void Push_Actions(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Actions(this));
        }
        private async void Push_Settings(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings(this));
        }
    }
}
