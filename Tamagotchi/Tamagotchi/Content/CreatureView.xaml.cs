using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagotchi.Content
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatureView : ContentView
    {
        public CreatureView()
        {
            InitializeComponent();
        }
    }
}