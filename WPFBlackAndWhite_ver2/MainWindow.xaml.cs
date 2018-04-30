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
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        Player Ateam;
        Player Bteam;
        Dealer dealer;

        private void DataBinding()
        {
            Ascore1.DataContext = Ateam;
            Ascore2.DataContext = Ateam;
            Ascore3.DataContext = Ateam;
            Ascore4.DataContext = Ateam;
            Ascore5.DataContext = Ateam;

            Bscore1.DataContext = Bteam;
            Bscore2.DataContext = Bteam;
            Bscore3.DataContext = Bteam;
            Bscore4.DataContext = Bteam;
            Bscore5.DataContext = Bteam;
        }

        private void ChangeTurn()
        {
            if (dealer.TurnSelect() == 1)
            {
                Ateam.Turn = true;
                Bteam.Turn = false;
            }
            else
            {
                Ateam.Turn = false;
                Bteam.Turn = true;
            }
        }

        public void ShowTurnScreen()
        {
            if (Ateam.Turn && !Bteam.Turn)
                UpdateScreen.Text = dealer.TurnScreen("Ateam", "Bteam");
            else
                UpdateScreen.Text = dealer.TurnScreen("Bteam", "Ateam");
        }        

        public MainWindow()
        {
            InitializeComponent();
            Ateam = new Player();
            Bteam = new Player();
            dealer = new Dealer();

            DataBinding();

            RoundScreen.Text = dealer.PrintNextRound();
            ScoreScreen.Text = dealer.ScoreScreen(Ateam,Bteam);

            ChangeTurn();
            ShowTurnScreen();

        }

        private void BtnAteamATK_Click(object sender, RoutedEventArgs e)
        {
            if(!Ateam.Turn)
            {
                MessageBox.Show("A팀 차례에만 공격할 수 있습니다");
                return;
            }            
            if (!dealer.InputTeamATK(Ateam, TextBoxAteamATK))
                return;
            dealer.HPcheck(Ateam);

            if (Bteam.AtkPoint == -1)
                BlackOrWhiteScreen.Text = dealer.BOWcheck(Ateam.AtkPoint);

            Ateam.Turn = false;
            Bteam.Turn = true;

            dealer.TurnCount++;
        }

        private void BtnBteamATK_Click(object sender, RoutedEventArgs e)
        {
            if(!Bteam.Turn)
            {
                MessageBox.Show("B팀 차례에만 공격할 수 있습니다");
                return;
            }            
            if (!dealer.InputTeamATK(Bteam, TextBoxBteamATK))
                return;
            dealer.HPcheck(Bteam);

            if (Ateam.AtkPoint == -1)
                BlackOrWhiteScreen.Text = dealer.BOWcheck(Bteam.AtkPoint);

            Ateam.Turn = true;
            Bteam.Turn = false;

            dealer.TurnCount++;            
        }

        private void BtnResult_Click(object sender, RoutedEventArgs e)//결과/선공후공출력
        {
            if (dealer.TurnCount != 2)
            {
                MessageBox.Show("아직 턴이 완전히 안끝났습니다");
                return;
            }

            ChangeTurn();
            ShowTurnScreen();

            dealer.TurnCount = 0;

            if (Ateam.AtkPoint > Bteam.AtkPoint)
            {
                Ateam.Score++;
                UpdateScreen.Text = "Ateam Win!";
            }
                
            else if (Bteam.AtkPoint > Ateam.AtkPoint)
            {
                Bteam.Score++;
                UpdateScreen.Text = "Bteam Win!";
            }
            else
            {
                Ateam.Score++;
                Bteam.Score++;
                UpdateScreen.Text = "Draw!";
            }
            
            ScoreScreen.Text = dealer.ScoreScreen(Ateam, Bteam);

            Ateam.Turn = false;
            Bteam.Turn = false;

            if (dealer.Round == 9)
            {
                dealer.ScoreCheck(Ateam.Score, Bteam.Score);
                this.Close();
            }
                

        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)//다음으로넘어감//턴설정
        {
            if(Ateam.Turn || Bteam.Turn)
            {
                MessageBox.Show("아직 다음라운드로 넘어갈 수 없습니다");
                return;
            }

            RoundScreen.Text = dealer.PrintNextRound();

            ChangeTurn();
            ShowTurnScreen();

            Ateam.ShowHP = false;
            Bteam.ShowHP = false;

            Ateam.AtkPoint = -1;
            Bteam.AtkPoint = -1;

            BlackOrWhiteScreen.Text = "선공이라 어쩔 수 없네요ㅜㅜ";
        }

        private void BtnShowAteamHP_Click(object sender, RoutedEventArgs e)
        {
            if (!Ateam.Turn)
            {
                MessageBox.Show("A팀 차례일 때만 볼 수 있습니다");
                return;
            }

            Ateam.ShowHP ^= true;

            if (Ateam.ShowHP)
                UpdateScreen.Text = Ateam.Status();
            else
                ShowTurnScreen();

        }

        private void BtnShowBteamHP_Click(object sender, RoutedEventArgs e)
        {
            if (!Bteam.Turn)
            {
                MessageBox.Show("B팀 차례일 때만 볼 수 있습니다");
                return;
            }

            Bteam.ShowHP ^= true;

            if (Bteam.ShowHP)
                UpdateScreen.Text = Bteam.Status();
            else
                ShowTurnScreen();

        }
    }
}
