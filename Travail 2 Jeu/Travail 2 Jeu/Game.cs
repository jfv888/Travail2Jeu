﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Travail_2_Jeu
{
    class Game
    {
        private Player player;
        private List<Enemy> enemies;
        private List<Spell> spells;
        private Image GameBackground;
        private Bitmap map;
        private Bitmap GameBitmap;
        private int GameWidth;
        private int GameHeight;
        private int Score;
        private int enemyCount;
        private int spellCount;

        public Game()
        {
            this.GameBackground = Image.FromFile("../../Images/Grass_Texture.png");
            this.GameWidth = 500;
            this.GameHeight = 800;
            this.player = new Player(GameWidth / 2, GameHeight - 200);
            this.enemies = new List<Enemy>();
            this.spells = new List<Spell>();
            this.map = new Bitmap(GameBackground, GameWidth, GameHeight);
            this.GameBitmap = new Bitmap(GameWidth, GameHeight);
            this.Score = 0;
            this.enemyCount = 0;
            this.spellCount = 0;
        }

        public int GetGameWidth()
        {
            return GameWidth;
        }

        public int GetGameHeight()
        {
            return GameHeight;
        }

        public Bitmap GetGameBitMap()
        {
            return GameBitmap;
        }

        public Bitmap GetMapBitMap()
        {
            return map;
        }

        public void EnemiesMovement()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Move();
            }
        }

        public void EnemiesWalkAnimation()
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.GetEnenyWalkAnimation() == 0)
                {
                    enemy.SetEnemyWalkAnimation(96);
                }
                else
                {
                    enemy.SetEnemyWalkAnimation(0);
                }
            }
        }

        public void DrawEnemies(Graphics graphics)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.IsAlive())
                {
                    graphics.DrawImage(enemy.GetEnemyBitmap(), enemy.GetEnemyPositionX(), enemy.GetEnemyPositionY(), enemy.GetEnemySkin(), GraphicsUnit.Pixel);
                }
            }
        }

        public void DrawPlayer(Graphics graphics)
        {
            graphics.DrawImage(player.GetCharacterBitmap(), player.GetPlayerPositionX(), player.GetPlayerPositionY(), player.GetCharacterSkin(), GraphicsUnit.Pixel);
        }

        public Bitmap Draw()
        {
            GameBitmap.Dispose();
            GameBitmap = new Bitmap(GameWidth, GameHeight);

            using (Graphics graphics = Graphics.FromImage(GameBitmap))
            {
                graphics.DrawImage(map, 0, 0);
                graphics.DrawImage(player.GetCharacterBitmap(), player.GetPlayerPositionX(), player.GetPlayerPositionY(), player.GetCharacterSkin(), GraphicsUnit.Pixel);
                DrawEnemies(graphics);
            }

            return GameBitmap;
        }

        public void SpawnEnemy(int EnemySpeed)
        {
            Random rng = new Random();
            enemyCount++;
            Enemy enemy = new Enemy(enemyCount, rng.Next(0, GameWidth - player.GetPlayerWidth()), EnemySpeed);
        }
    }
}
