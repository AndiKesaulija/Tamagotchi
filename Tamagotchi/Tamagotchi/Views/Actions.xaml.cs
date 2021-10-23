using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagotchi.Views
{
   
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Actions : ContentPage, INotifyPropertyChanged
    {
        public MainPage myMainPage;

        public Actions(MainPage parent)
        {
            BindingContext = parent;
            InitializeComponent();
            myMainPage = parent;
        }

        protected override async void OnDisappearing()
        {
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            await creatureDataStore.UpdateItem(myMainPage.myCreature);

        }

        private  void Add_Thirst(object sender, EventArgs e)
        {
            myMainPage.myCreature.ChangeStat(1, StatType.thirst, true);

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(myMainPage.myCreature);
            Navigation.PopAsync();

        }
        private  void Add_Hunger(object sender, EventArgs e)
        {
            myMainPage.myCreature.ChangeStat(1, StatType.hunger, true);


            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(myMainPage.myCreature);
            Navigation.PopAsync();

        }
        private void Add_Boredom(object sender, EventArgs e)
        {
            myMainPage.myCreature.ChangeStat(1, StatType.boredom, true);


            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(myMainPage.myCreature);
            Navigation.PopAsync();

        }
        private void Add_Stimulated(object sender, EventArgs e)
        {
            myMainPage.myCreature.ChangeStat(1, StatType.stimulated, true);

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(myMainPage.myCreature);
            Navigation.PopAsync();

        }
        private void Add_Tired(object sender, EventArgs e)
        {
            myMainPage.myCreature.ChangeStat(1, StatType.tired, true);

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(myMainPage.myCreature);
            Navigation.PopAsync();

        }

        private void GoTo_Playground(object sender, EventArgs e)
        {
            myMainPage.atPlayGround = true;
            myMainPage.invertedAtPlayGround = !myMainPage.atPlayGround;

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.GoToPlayground(myMainPage.myCreature);
            Navigation.PopAsync();
        }
        private void Leave_Playground(object sender, EventArgs e)
        {
            myMainPage.atPlayGround = false;
            myMainPage.invertedAtPlayGround = !myMainPage.atPlayGround;


            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.LeavePlayground(myMainPage.myCreature);
            Navigation.PopAsync();
        }

        
    }
}