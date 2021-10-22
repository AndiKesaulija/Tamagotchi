using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagotchi.Views
{
   
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Actions : ContentPage
    {
        public Actions()
        {
            InitializeComponent();
        }
        private void Add_Thirst(object sender, EventArgs e)
        {
            App.myCreature.ChangeStat(1, StatType.thirst, true);

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(App.myCreature);
            Navigation.PopAsync();

        }
        private void Add_Hunger(object sender, EventArgs e)
        {
            App.myCreature.ChangeStat(1, StatType.hunger, true);


            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(App.myCreature);
            Navigation.PopAsync();

        }
        private void Add_Boredom(object sender, EventArgs e)
        {
            App.myCreature.ChangeStat(1, StatType.boredom, true);


            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(App.myCreature);
            Navigation.PopAsync();

        }
        private void Add_Stimulated(object sender, EventArgs e)
        {
            App.myCreature.ChangeStat(1, StatType.stimulated, true);

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(App.myCreature);
            Navigation.PopAsync();

        }
        private void Add_Tired(object sender, EventArgs e)
        {
            App.myCreature.ChangeStat(1, StatType.tired, true);

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(App.myCreature);
            Navigation.PopAsync();

        }

        private void ResetCreature(object sender, EventArgs e)
        {
            Console.WriteLine(App.myCreature.myStatus);

            App.myCreature.Reset();

            //App.myCreature.ChangeStat(1, StatType.thirst, true);
            //App.myCreature.ChangeStat(1, StatType.hunger, true);
            //App.myCreature.ChangeStat(1, StatType.boredom, true);
            //App.myCreature.ChangeStat(1, StatType.loneliness, true);
            //App.myCreature.ChangeStat(1, StatType.tired, true);
            //App.myCreature.ChangeStat(1, StatType.stimulated, true);


            Console.WriteLine(App.myCreature.myStatus);

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(App.myCreature);
            Navigation.PopAsync();

        }
        
        private void Create_New_Creature(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateNewCreature());

        }
    }
}