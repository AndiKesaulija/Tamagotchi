using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Newtonsoft.Json;

namespace Tamagotchi
{
    public class LocalCreatureStore : IDataStore<Creature>
    {

        public bool CreateItem(Creature item)
        {
            throw new NotImplementedException();
            
            //JsonConvert.SerializeObject(creature);
            //Preferences.Set("Name", string)
        }

        public bool DeleteItem(Creature item)
        {
            throw new NotImplementedException();
            //Preferences.Remove()

        }

        public Creature ReadItem()
        {
            throw new NotImplementedException();

            //Preferences.Get("Name", "")

        }

        public bool UpdateItem(Creature item)
        {
            if (Preferences.ContainsKey("MyCreature"))
            {
                string json = JsonConvert.SerializeObject(item);
                //Preferences.Set("Name", string)

            }
            throw new NotImplementedException();

        }
    }
}
