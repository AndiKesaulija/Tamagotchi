using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tamagotchi
{
    public enum StatType
    {
        thirst,
        hunger,
        boredom,
        loneliness,
        stimulated,
        tired
    }

    public class Creature
    {
        public int id { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public float thirst { get; set; }
        public float hunger { get; set; }
        public float boredom { get; set; }
        public float loneliness { get; set; }
        public float stimulated { get; set; }
        public float tired { get; set; }

        public float status => (thirst + hunger + boredom + loneliness + stimulated + tired) * 0.16f;

        public string statusHappy = "Creature_Happy.jpg";
        public string statusNutural = "Creature_Nutural.jpg";
        public string statusSad = "Creature_Sad.jpg";
        public string errorImg = "TestPng.png";


        public string myStatus => status switch
        {
            >= 0.7f => statusHappy,
            >= 0.4f => statusNutural,
            > 0.0f => statusSad,
            _ => errorImg
        };

        public void ChangeStat(float amount, StatType type, bool increase = false)
        {
            switch (type)
            {
                case StatType.thirst:
                    if (thirst > 0 || increase == true)
                    {
                        thirst += amount;
                        Math.Round(thirst);
                    }
                    break;
                case StatType.hunger:
                    if (hunger > 0 || increase == true)
                    {
                        hunger = hunger + amount;
                    }
                    break;
                case StatType.boredom:
                    if (boredom > 0 || increase == true)
                    {
                        boredom = boredom + amount;
                    }
                    break;
                case StatType.loneliness:
                    if (loneliness > 0 || increase == true)
                    {
                        loneliness = loneliness + amount;
                    }
                    break;
                case StatType.stimulated:
                    if (stimulated > 0 || increase == true)
                    {
                        stimulated = stimulated + amount;
                    }
                    break;
                case StatType.tired:
                    if (tired > 0 || increase == true)
                    {
                        tired = tired + amount;
                    }
                    break;
            }
        }
        public void Reset()
        {
            thirst = 1;
            hunger = 1;
            boredom = 1;
            loneliness = 1;
            stimulated = 1;
            tired = 1;
        }
    }
}
