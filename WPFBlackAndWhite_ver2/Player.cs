using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBlackAndWhite_ver2
{
    class Player : INotifyPropertyChanged
    {        
        string[] hpscreen;


        public int Score { get; set; }
        public int HP { get; set; }
        public int AtkPoint { get; set; }
        public bool Turn { get; set; }
        public bool ShowHP { get; set; }

        public string HpScreen1
        {
            get { return hpscreen[0]; }
            set
            {
                hpscreen[0] = value;
                Notify("HpScreen1");
            }
        }

        public string HpScreen2
        {
            get { return hpscreen[1]; }
            set
            {
                hpscreen[1] = value;
                Notify("HpScreen2");
            }
        }

        public string HpScreen3
        {
            get { return hpscreen[2]; }
            set
            {
                hpscreen[2] = value;
                Notify("HpScreen3");
            }
        }

        public string HpScreen4
        {
            get { return hpscreen[3]; }
            set
            {
                hpscreen[3] = value;
                Notify("HpScreen4");
            }
        }

        public string HpScreen5
        {
            get { return hpscreen[4]; }
            set
            {
                hpscreen[4] = value;
                Notify("HpScreen5");
            }
        }


        public Player()
        {
            Score = 0;
            HP = 99;
            hpscreen = new string[5];

            hpscreen[0] = "80 ~ 99";
            hpscreen[1] = "60 ~ 79";
            hpscreen[2] = "40 ~ 59";
            hpscreen[3] = "20 ~ 39";
            hpscreen[4] = "0 ~ 19";

            Turn = false;
            ShowHP = false;

            AtkPoint = -1;
        }

        public string Status()
        {            
            return "HP : " + HP;
        }

        protected void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
