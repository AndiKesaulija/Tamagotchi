using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;


namespace Tamagotchi.Views
{

    class RemoteCreatureStore : IDataStore<Creature>
    {
        private HttpClient client = new HttpClient();
        public async Task<bool> CreateItem(Creature item)
        {
            string creatureAsText = JsonConvert.SerializeObject(item);

            try
            {

                var response = await client.PostAsync("https://tamagotchi.hku.nl/api/Creatures", new StringContent(creatureAsText, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    string postedCeatureAsText = await response.Content.ReadAsStringAsync();

                    Creature postedCreature = JsonConvert.DeserializeObject<Creature>(postedCeatureAsText);

                    Preferences.Set("MyCreatureID", postedCreature.id);
                    Console.WriteLine("[CREATURESTORE]: Creature Created");
                    return true;
                }
                
                return false;

            }
            catch (Exception e)
            {
                Console.WriteLine("[CREATURESTORE]: FAILED to Create Creature");

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
                var response = await client.PutAsync("https://tamagotchi.hku.nl/api/Creatures/" + creatureID, new StringContent(creatureAsText, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("[CREATURESTORE]: Update Creature" );

                    return true;
                }
                else
                {
                    Console.WriteLine("[CREATURESTORE]: Update Creature FAILED - Creatire ID: " + creatureID);

                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> GoToPlayground(Creature item)
        {

            int creatureID = Preferences.Get("MyCreatureID", 0);
            if (creatureID == 0)
            {
                return false;
            }
            try
            {
                var response = await client.PostAsync("https://tamagotchi.hku.nl/api/Playground/" + creatureID, new StringContent(creatureID.ToString(), Encoding.UTF8, "text/plain"));

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("[CREATURESTORE]: Go To PlayGround");

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

        public async Task<bool> LeavePlayground(Creature item)
        {

            int creatureID = Preferences.Get("MyCreatureID", 0);
            if (creatureID == 0)
            {
                return false;
            }
            try
            {
                var response = await client.DeleteAsync("https://tamagotchi.hku.nl/api/Playground/" + creatureID);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("[CREATURESTORE]: Leave PlayGround");

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
