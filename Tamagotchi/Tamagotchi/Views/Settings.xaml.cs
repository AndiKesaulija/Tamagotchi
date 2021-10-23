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
    public partial class Settings : ContentPage
    {
        MainPage myMainPage;
        public Settings(MainPage parrent)
        {
            BindingContext = parrent;
            InitializeComponent();
            myMainPage = parrent;
        }
        private void ResetCreature(object sender, EventArgs e)
        {
            Console.WriteLine(myMainPage.myCreature.myStatus);

            myMainPage.myCreature.Reset();

            //App.myCreature.ChangeStat(1, StatType.thirst, true);
            //App.myCreature.ChangeStat(1, StatType.hunger, true);
            //App.myCreature.ChangeStat(1, StatType.boredom, true);
            //App.myCreature.ChangeStat(1, StatType.loneliness, true);
            //App.myCreature.ChangeStat(1, StatType.tired, true);
            //App.myCreature.ChangeStat(1, StatType.stimulated, true);


            Console.WriteLine(myMainPage.myCreature.myStatus);

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(myMainPage.myCreature);
            Navigation.PopAsync();

        }

        private void Create_New_Creature(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateNewCreature());
        }
    }
}