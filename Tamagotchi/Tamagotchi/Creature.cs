using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public class Creature : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int id { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public float thirst { get; set; }
        public float hunger { get; set; }
        public float boredom { get; set; }
        public float tired { get; set; }

        public float loneliness { get; set; }
        public float stimulated { get; set; }

        public float status => (thirst + hunger + boredom + loneliness + stimulated + tired) * 0.16f;

        public string statusHappy = "Creature_Happy.jpg";
        public string statusNutural = "Creature_Nutural.jpg";
        public string statusSad = "Creature_Sad.jpg";
        public string statusDead = "Creature_Dead.jpg";
        public string errorImg = "TestPng.png";

        public string myStatus => status switch
        {
            >= 0.7f => statusHappy,
            >= 0.4f => statusNutural,
            >= 0.2f => statusSad,
            < 0.2f => statusDead,
            _ => statusDead
        };

        public bool isAlive { get { return status >= 0.2f; } }

        public void ChangeStat(float amount, StatType type, bool increase = false, bool force = false)
        {
            if (isAlive)
            {
                switch (type)
                {
                    case StatType.thirst:
                        if (thirst > 0 || increase == true)
                        {
                            thirst += amount;
                            if (thirst > 1)
                            {
                                thirst = 1;
                            }
                            thirst = Convert.ToSingle(Math.Round(thirst, 1));
                        }
                        break;
                    case StatType.hunger:
                        if (hunger > 0 || increase == true)
                        {
                            hunger = hunger + amount;
                            if (hunger > 1)
                            {
                                hunger = 1;
                            }
                            hunger = Convert.ToSingle(Math.Round(hunger, 1));
                        }
                        break;
                    case StatType.boredom:
                        if (boredom > 0 || increase == true)
                        {
                            boredom = boredom + amount;
                            if (boredom > 1)
                            {
                                boredom = 1;
                            }
                            boredom = Convert.ToSingle(Math.Round(boredom, 1));
                        }
                        break;
                    case StatType.loneliness:
                        if (loneliness > 0 || increase == true)
                        {
                            loneliness = loneliness + amount;
                            if (loneliness > 1)
                            {
                                loneliness = 1;
                            }
                            loneliness = Convert.ToSingle(Math.Round(loneliness, 1));
                        }
                        break;
                    case StatType.stimulated:
                        if (stimulated > 0 || increase == true)
                        {
                            stimulated = stimulated + amount;
                            if (stimulated > 1)
                            {
                                stimulated = 1;
                            }
                            stimulated = Convert.ToSingle(Math.Round(stimulated, 1));
                        }
                        break;
                    case StatType.tired:
                        if (tired > 0 || increase == true)
                        {
                            tired = tired + amount;
                            if (tired > 1)
                            {
                                tired = 1;
                            }
                            tired = Convert.ToSingle(Math.Round(tired, 1));
                        }
                        break;
                }
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
