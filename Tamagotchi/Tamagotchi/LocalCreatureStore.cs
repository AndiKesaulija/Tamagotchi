using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Tamagotchi
{
    public class LocalCreatureStore : IDataStore<Creature>
    {
        public Task<bool> CreateItem(Creature item)
        {
            throw new NotImplementedException();
        }

        public bool CreateItemAsync(Creature item)
		{
			string creatureAsText = JsonConvert.SerializeObject(item);

			Preferences.Set("MyCreature", creatureAsText);

			return true;
		}

		public bool DeleteItem(Creature item)
		{
			Preferences.Remove("MyCreature");

			return true;
		}

		public Creature ReadItem()
		{
			string creatureAsText = Preferences.Get("MyCreature", "");

			Creature creatureFromText = JsonConvert.DeserializeObject<Creature>(creatureAsText);

			return creatureFromText;
		}

		public bool UpdateItem(Creature item)
		{
			if (Preferences.ContainsKey("MyCreature"))
			{
				string creatureAsText = JsonConvert.SerializeObject(item);

				Preferences.Set("MyCreature", creatureAsText);

				return true;
			}

			return false;
		}

        Task<bool> IDataStore<Creature>.DeleteItem(Creature item)
        {
            throw new NotImplementedException();
        }

        Task<Creature> IDataStore<Creature>.ReadItem()
        {
            throw new NotImplementedException();
        }

        Task<bool> IDataStore<Creature>.UpdateItem(Creature item)
        {
            throw new NotImplementedException();
        }
    }

}
