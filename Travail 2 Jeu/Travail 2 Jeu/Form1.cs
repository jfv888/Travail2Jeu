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
        private Bitmap GameImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game();
            playerinput = new PlayerInput();
            GameImage = new Bitmap(game.GetGameWidth(), game.GetGameHeight());
            SetupGame();
        }

        private void SetupGame()
        {
            DoubleBuffered = true;
            BackgroundImageLayout = ImageLayout.None;
            Width = game.GetGameWidth();
            Height = game.GetGameHeight();
            GameTimer.Start();
            EnemiesWalkAnimationTimer.Start();
            CastCooldown.Start();
            EnemySpawnTimer.Start();
        }

        public void Draw()
        {
            game.GetGameBitMap().Dispose();
            GameImage = new Bitmap(game.GetGameWidth(), game.GetGameHeight());

            using (Graphics graphics = Graphics.FromImage(GameImage))
            {
                graphics.DrawImage(game.GetMapBitMap(), 0, 0);
                game.DrawPlayer(graphics);
                game.DrawEnemies(graphics);
            }

            BackgroundImage = GameImage;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            game.EnemiesMovement();

            Draw();
        }

        private void EnemiesWalkAnimationTimer_Tick(object sender, EventArgs e)
        {
            game.EnemiesWalkAnimation();
        }

        private void PlayerWalkAnimationTimer_Tick(object sender, EventArgs e)
        {

        }

        private void CastCooldown_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void EnemySpawnTimer_Tick(object sender, EventArgs e)
        {
            game.SpawnEnemy(3);
        }
    }
}
