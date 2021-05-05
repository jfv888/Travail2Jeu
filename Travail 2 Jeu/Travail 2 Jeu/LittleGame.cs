using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travail_2_Jeu
{
    public partial class LittleGame : Form
    {
        System.Media.SoundPlayer BackGroundMusic = new System.Media.SoundPlayer();
        private Game game;
        private PlayerInput playerinput;
        private Label Score;
        private int GameDifficulty;

        public LittleGame(int GameDifficulty)
        {
            InitializeComponent();
            BackGroundMusic.SoundLocation = "../../Sounds/BackGroundMusic.wav";
            this.GameDifficulty = GameDifficulty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game();
            playerinput = new PlayerInput();
            SetupGame();
            SetupScoreLabel();
        }

        private void SetupGame()
        {
            DoubleBuffered = true;
            BackgroundImageLayout = ImageLayout.None;           
            Width = game.GetGameWidth();
            Height = game.GetGameHeight();
            GameTimer.Interval = 15;
            EnemiesWalkAnimationTimer.Interval = 250;
            CastCooldown.Interval = 100 * GameDifficulty;
            EnemySpawnTimer.Interval = 500;
            GameTimer.Start();
            EnemiesWalkAnimationTimer.Start();
            CastCooldown.Start();
            EnemySpawnTimer.Start();
            BackGroundMusic.PlayLooping();
        }

        private void SetupScoreLabel()
        {
            Score = new Label();
            Score.Text = game.GetPlayerScore().ToString();
            Score.Location = new Point(0, 0);
            Score.Font = new Font("Calibri", 18);
            Score.ForeColor = Color.Aqua;
            Score.BackColor = Color.Transparent;
            this.Controls.Add(Score);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            

            if (playerinput.GetMoveUp())
            {
                game.PlayerMoveUP();
            }
            else if (playerinput.GetMoveDown())
            {
                game.PlayerMoveDown();
            }
            else if (playerinput.GetMoveLeft())
            {
                game.PlayerMoveLeft();
            }
            else if (playerinput.GetMoveRight())
            {
                game.PlayerMoveRight();
            }
            if (playerinput.GetCastSpell())
            {
                game.CastArcaneBolt();
                if (game.PlayerIsOFFCooldown())
                {
                    CastCooldown = new Timer();
                    CastCooldown.Start();
                }
            }
            
            game.EnemiesMovement();
            game.MoveArcaneBolts();
            game.DisposeOutOffBoundsEnnemies();
            game.KillEnemyHit();
            Score.Text = game.GetPlayerScore().ToString();
            BackgroundImage = game.Draw();
            if (game.GameOver())
            {
                BackGroundMusic.Stop();
                GameOver();
            }

        }

        private void EnemiesWalkAnimationTimer_Tick(object sender, EventArgs e)
        {
            game.EnemiesWalkAnimation();
        }

        private void PlayerWalkAnimationTimer_Tick(object sender, EventArgs e)
        {
            game.PlayerWalkAnimation();
        }

        private void CastCooldown_Tick(object sender, EventArgs e)
        {
            game.SetArcaneBoltOffCooldown();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                playerinput.SetMoveUp(true);
                PlayerWalkAnimationTimer.Start();
            }
            else if (e.KeyCode == Keys.Down)
            {
                playerinput.SetMoveDown(true);
                PlayerWalkAnimationTimer.Start();
            }
            else if (e.KeyCode == Keys.Left)
            {
                playerinput.SetMoveLeft(true);
                PlayerWalkAnimationTimer.Start();
            }
            else if (e.KeyCode == Keys.Right)
            {
                playerinput.SetMoveRight(true);
                PlayerWalkAnimationTimer.Start();
            }
            if(e.KeyCode == Keys.Space)
            {
                playerinput.SetCastSpell(true);               
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                playerinput.SetMoveUp(false);
                PlayerWalkAnimationTimer.Stop();
                game.PlayerStop();
            }
            else if (e.KeyCode == Keys.Down)
            {
                playerinput.SetMoveDown(false);
                PlayerWalkAnimationTimer.Stop();
                game.PlayerStop();
            }
            else if (e.KeyCode == Keys.Left)
            {
                playerinput.SetMoveLeft(false);
                PlayerWalkAnimationTimer.Stop();
                game.PlayerStop();
            }
            else if (e.KeyCode == Keys.Right)
            {
                playerinput.SetMoveRight(false);
                PlayerWalkAnimationTimer.Stop();
                game.PlayerStop();
            }
            if (e.KeyCode == Keys.Space)
            {
                playerinput.SetCastSpell(false);
                game.PlayerStop();
            }
        }

        private void EnemySpawnTimer_Tick(object sender, EventArgs e)
        {
            game.SpawnEnemy(GameDifficulty);
        }

        private void GameOver()
        {            
            this.Hide();
            MessageBox.Show("You Lost ! Your Score Is : " + Score.Text.ToString());
            MyMenu mymenu = new MyMenu(GameDifficulty);
            mymenu.ShowDialog();
            this.Close();           
        }
    }
}
