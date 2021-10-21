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

    public partial class CreateNewCreature : ContentPage
    {


        public CreateNewCreature()
        {
            InitializeComponent();
        }

        public async void CreateCreature(object sender, EventArgs e)
        {
            Creature myCreature = new Creature();

            myCreature.userName = name.Text;
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            await creatureDataStore.CreateItem(myCreature);
            //Console.WriteLine("New Creature Created with name: " + myCreature.Name);
        }
    }
}