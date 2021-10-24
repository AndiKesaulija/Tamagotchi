using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagotchi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class CreateNewCreature : ContentPage
    {


        public CreateNewCreature()
        {
            InitializeComponent();
        }

        public async void CreateCreature(object sender, EventArgs e)
        {
            Creature myCreature = new Creature 
            {
                id = Preferences.Get("MyCreatureID", 0),
                userName = "Andi Kesaulija",
                name = name.Text,
                thirst =1,
                hunger =1,
                boredom =1,
                loneliness =1,
                stimulated =1,
                tired =1
            };

            //Set startTime 
            Preferences.Set("startTime", DateTime.Now.ToShortDateString());

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();

            if(Preferences.Get("MyCreatureID", 0) != 0)
            {
                await creatureDataStore.UpdateItem(myCreature);
            }
            else
            {
                await creatureDataStore.CreateItem(myCreature);
            }
            await Navigation.PopAsync();

        }
    }
}