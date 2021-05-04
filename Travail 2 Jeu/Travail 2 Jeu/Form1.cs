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
            

            if (playerinput.GetMoveUp() && game.GetPlayerPositionY() > 0)
            {
                game.PlayerMoveUP();
            }
            else if (playerinput.GetMoveDown() && game.GetPlayerPositionY() < game.GetGameHeight() - game.GetPlayerHeight())
            {
                game.PlayerMoveDown();
            }
            else if (playerinput.GetMoveLeft() && game.GetPlayerPositionX() > 0)
            {
                game.PlayerMoveLeft();
            }
            else if (playerinput.GetMoveRight() && game.GetPlayerPositionX() < game.GetGameWidth() - game.GetPlayerWidth())
            {
                game.PlayerMoveRight();
            }
            if (playerinput.GetCastSpell())
            {
                game.CastArcaneBolt();
            }

            game.EnemiesMovement();
            game.MoveArcaneBolts();
            game.DisposeOutOffBoundsEnnemies();
            game.KillEnemyHit();
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
            game.SpawnEnemy(EnemySpeed);
        }
    }
}
