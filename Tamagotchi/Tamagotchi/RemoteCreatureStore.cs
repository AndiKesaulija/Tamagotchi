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

                var response = await client.PostAsync("https://tamagotchi.hku.nl/api/Creatures", new StringContent(creatureAsText, Encoding.UTF8, "aplication/json"));

                if (response.IsSuccessStatusCode)
                {
                    string postedCeatureAsText = await response.Content.ReadAsStringAsync();

                    Creature postedCreature = JsonConvert.DeserializeObject<Creature>(postedCeatureAsText);

                    Preferences.Set("MyCreatureID", postedCreature.id);
                    Console.WriteLine("Creature Created");
                    return true;
                }
                else
                {
                    Console.WriteLine("Try FAILED");

                    return false;
                }

            }
            catch(Exception e)
            {
                Console.WriteLine("FAILED to Create Creature");

                Console.WriteLine(e.Message);
                return false;

            }
        }

        public async Task<bool> DeleteItem(Creature item)
        {
            int creatureID = Preferences.Get("MyCreatureID", 0);
            if (creatureID == 0)
            {
                return false;
            }

            var response = await client.DeleteAsync("https://tamagotchi.hku.nl/api/Creatures/"+ creatureID);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public async Task<Creature> ReadItem()
        {
            int creatureID = Preferences.Get("MyCreatureID", 0);
            if (creatureID == 0)
            {
                return null;
            }

            var response = await client.GetAsync("https://tamagotchi.hku.nl/api/Creatures/" + creatureID);
            if (response.IsSuccessStatusCode)
            {
                string creatureAsText = await response.Content.ReadAsStringAsync();

                Creature creature = JsonConvert.DeserializeObject<Creature>(creatureAsText);

                Preferences.Set("MyCreatureID", creature.id);

                return creature;
            }

            return null;

        }

        public async Task<bool> UpdateItem(Creature item)
        {
            string creatureAsText = JsonConvert.SerializeObject(item);

            int creatureID = Preferences.Get("MyCreatureID", 0);
            if (creatureID == 0)
            {
                return false;
            }
            try
            {
                var response = await client.PutAsync("https://tamagotchi.hku.nl/api/Creatures/" + creatureID, new StringContent(creatureAsText, Encoding.UTF8, "aplication/Json"));

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
