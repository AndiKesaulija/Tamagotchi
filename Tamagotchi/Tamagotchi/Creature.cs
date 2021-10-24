using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
        public string startTime { get { return Preferences.Get("startTime", "null"); }}
        public string endTime { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public float thirst { get; set; }
        public float hunger { get; set; }
        public float boredom { get; set; }
        public float tired { get; set; }

        public float loneliness { get; set; }
        public float stimulated { get; set; }

        public float status => (thirst + hunger + boredom + loneliness + stimulated + tired) * 0.16f;

        public string statusPlayGround => "Content_Background_PlayGround.jpg";

        public string statusHappy = "Content_Background_Happy.jpg";
        public string statusNutural = "Content_Background_Nutural.jpg";
        public string statusSad = "Content_Background_Sad.jpg";
        public string statusDead = "Content_Background_Dead.jpg";

        public string myStatus => status switch
        {
            >= 0.7f => statusHappy,
            >= 0.4f => statusNutural,
            >= 0.2f => statusSad,
            < 0.2f => statusDead,
            _ => statusDead
        };

        public bool atPlayGround { get; set; }
        public bool isAlive
        {
            get
            {
                if(status <= 0.2f)
                {
                    endTime = DateTime.Now.ToShortDateString();
                    return false;
                }
                    return true;

            }
            set
            {

            }
        }

        public void ChangeStat(float amount, StatType type, bool increase = false)
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
