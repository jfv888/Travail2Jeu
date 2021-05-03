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
    public partial class Form1 : Form
    {
        private Game game;
        private PlayerInput playerinput;
        private int EnemySpeed;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnemySpeed = 2;
            game = new Game();
            playerinput = new PlayerInput();
            SetupGame();
        }

        private void SetupGame()
        {
            DoubleBuffered = true;
            BackgroundImageLayout = ImageLayout.None;
            Width = game.GetGameWidth();
            Height = game.GetGameHeight();
            GameTimer.Interval = 15;
            EnemiesWalkAnimationTimer.Interval = 250;
            CastCooldown.Interval = 500;
            EnemySpawnTimer.Interval = 500;
            GameTimer.Start();
            EnemiesWalkAnimationTimer.Start();
            CastCooldown.Start();
            EnemySpawnTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            game.EnemiesMovement();

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

            BackgroundImage = game.Draw();

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
        }

        private void EnemySpawnTimer_Tick(object sender, EventArgs e)
        {
            game.SpawnEnemy(EnemySpeed);
        }
    }
}
