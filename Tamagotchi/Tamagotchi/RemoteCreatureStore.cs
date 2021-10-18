using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Tamagotchi
{
    class RemoteCreatureStore : IDataStore<Creature>
    {

        private HttpClient client = new HttpClient();
        public async Task<bool> CreateItem(Creature item)
        {
            string creatureAsText = JsonConvert.SerializeObject(item);

            try
            {
                var response = await client.PostAsync("https://tamagotchi.hku.nl/api/Creatures", new StringContent(creatureAsText, Encoding.UTF8, "aplication/Json"));

                if (response.IsSuccessStatusCode)
                {
                    string postedCeatureAsText = await response.Content.ReadAsStringAsync();

                    Creature postedCreature = JsonConvert.DeserializeObject<Creature>(postedCeatureAsText);

                    Preferences.Set("CreatureID", creatureAsText);

                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;

            }
            return Task.FromResult(true);


        }



        public bool DeleteItem(Creature item)
        {
            throw new NotImplementedException();
        }

        public async Task<Creature> ReadItem()
        {
            int ceatureID = Preferences.Get("CreatureID", 0);
            client.GetAsync("http://tamagotchi.hku.nl/app/Creatures/2");
        }

        public bool UpdateItem(Creature item)
        {
            throw new NotImplementedException();
        }

       
    }
}
