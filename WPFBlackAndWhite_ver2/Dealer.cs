using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFBlackAndWhite_ver2
{
    class Dealer
    {
        Random TurnRand;       
        public int Round { get; set; }
        public int TurnCount { get; set; }

        public Dealer()
        {
            TurnRand = new Random();
            Round = 0;
            TurnCount = 0;
        }
        
        public string PrintNextRound()
        {            
            Round++;
            return "- " + Round.ToString() + "라운드 -";
        }

        public string ScoreScreen(Player A, Player B)
        {
            return A.Score.ToString() + " : " + B.Score.ToString();
        }
        public string TurnScreen(string First, string Second)
        {
            return First + " 선공 " + Second + " 후공";
        }        
        public int TurnSelect()
        {
            int result = TurnRand.Next(2);
            return result;
        }
        public string BOWcheck(int atk)
        {
            if (atk <= 10)
                return "Black";
            else
                return "White";
        }

        public void HPcheck(Player player)
        {
            if (player.HP < 79)
                player.HpScreen1 = "";
            if (player.HP < 59)
                player.HpScreen2 = "";
            if (player.HP < 39)
                player.HpScreen3 = "";
            if (player.HP < 19)
                player.HpScreen4 = "";
            if (player.HP < 0)
                player.HpScreen5 = "";
        }

        public bool InputTeamATK(Player Team,TextBox InputATK)
        {
            try
            {
                Team.AtkPoint = int.Parse(InputATK.Text);
            }
            catch(Exception e)
            {
                MessageBox.Show("정수만 입력이 가능합니다");
                return false;
            }               
            if (Team.AtkPoint < 0)
            {
                MessageBox.Show("정수만 입력이 가능합니다");
                return false;
            }
                
            if (Team.AtkPoint > Team.HP)
            {
                MessageBox.Show("HP가 부족합니다");
                return false;
            }                
            Team.HP -= Team.AtkPoint;

            return true;
        }

        public void ScoreCheck(int Ascore, int Bscore)
        {
            if(Ascore == Bscore)            
                MessageBox.Show("무승부 입니다!");                
            else if (Ascore>Bscore)
                MessageBox.Show("A팀의 최종승리입니다");             
            else            
                MessageBox.Show("B팀의 최종승리입니다");                            
        }

    }
}
