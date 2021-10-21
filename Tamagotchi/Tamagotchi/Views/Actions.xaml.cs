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
        public enum Stat
        {
            hunger,
            thirst,
            boredom,
            loneliness,
            stimulated,
            tired,
        }
        public Actions()
        {
            InitializeComponent();
        }
        private void Add_Thirst(object sender, EventArgs e)
        {
            Add_Stat(Stat.thirst);

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(App.myCreature);
            Navigation.PopAsync();

        }
        private void Add_Hunger(object sender, EventArgs e)
        {
            Add_Stat(Stat.hunger);

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(App.myCreature);
            Navigation.PopAsync();

        }
        private void Add_Boredom(object sender, EventArgs e)
        {
            Add_Stat(Stat.boredom);

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(App.myCreature);
            Navigation.PopAsync();

        }
        private void Add_Stimulated(object sender, EventArgs e)
        {
            Add_Stat(Stat.stimulated);

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(App.myCreature);
            Navigation.PopAsync();

        }
        private void Add_Tired(object sender, EventArgs e)
        {
            Add_Stat(Stat.tired);

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(App.myCreature);
            Navigation.PopAsync();

        }

        private void ResetCreature(object sender, EventArgs e)
        {
            Add_Stat(Stat.hunger);
            Add_Stat(Stat.thirst);
            Add_Stat(Stat.boredom);
            Add_Stat(Stat.loneliness);
            Add_Stat(Stat.stimulated);
            Add_Stat(Stat.tired);

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(App.myCreature);
            Navigation.PopAsync();

        }
        private void Add_Stat(Stat statType)
        {
            if (App.myCreature != null)
            {
                switch (statType)
                {
                    case Stat.hunger:
                        App.myCreature.hunger = 100;
                        break;
                    case Stat.thirst:
                        App.myCreature.thirst = 100;
                        break;
                    case Stat.boredom:
                        App.myCreature.boredom = 100;
                        break;
                    case Stat.loneliness:
                        App.myCreature.loneliness = 100;
                        break;
                    case Stat.stimulated:
                        App.myCreature.stimulated = 100;
                        break;
                    case Stat.tired:
                        App.myCreature.tired = 100;
                        break;
                }
            }
        }
        
        private void Create_New_Creature(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateNewCreature());

        }
    }
}