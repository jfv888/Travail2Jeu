using System;
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
        private Random rng = new Random();
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

        public void PlayerWalkAnimation()
        {
            if (player.GetCharacterWalkAnimation() == 0)
            {
                player.SetCharacterWalkAnimation(96);
            }
            else
            {
                player.SetCharacterWalkAnimation(0);
            }
        }

        public void PlayerStop()
        {
            player.SetCharacterWalkAnimation(48);
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

        public void PlayerMoveUP()
        {
            if (player.GetPlayerPositionY() > 0)
            {
                player.GoUp();
            }
        }

        public void PlayerMoveDown()
        {
            if (player.GetPlayerPositionY() < GameHeight - player.GetPlayerHeigth())
            {
                player.GoDown();
            };
        }

        public void PlayerMoveLeft()
        {
            if (player.GetPlayerPositionX() > 0)
            {
                player.GoLeft();
            }
        }

        public void PlayerMoveRight()
        {
            if (player.GetPlayerPositionX() < GameWidth - player.GetPlayerWidth())
            {
                player.GoRight();
            }
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
                DrawSpells(graphics);
            }

            return GameBitmap;
        }

        public void SpawnEnemy(int EnemySpeed)
        {
            enemyCount++;
            Enemy enemy = new Enemy(enemyCount, rng.Next(0, GameWidth - player.GetPlayerWidth()), EnemySpeed);
            enemies.Add(enemy);
        }

        public void DisposeOutOffBoundsEnnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.GetEnemyPositionY() > GameHeight)
                {
                    enemy.GetEnemyBitmap().Dispose();
                    enemy.Kill();
                }
            }
        }

        public void CastArcaneBolt()
        {
            if (!player.IsOnCooldown())
            {
                spellCount++;
                Spell spell = new Spell(spellCount, player.GetPlayerPositionX(), player.GetPlayerPositionY());
                spells.Add(spell);
                player.SetOnCooldown();
                player.Cast();
            }
        }

        public bool PlayerIsOFFCooldown()
        {
            return !player.IsOnCooldown();
        }

        public void SetArcaneBoltOffCooldown()
        {
            player.SetOffCooldown();
        }

        public void SetArcaneBoltOnCooldown()
        {
            player.SetOnCooldown();
        }

        public void DrawSpells(Graphics graphics)
        {
            foreach (Spell spell in spells)
            {
                if (spell.IsAlive())
                {
                    graphics.DrawImage(spell.GetSpellBitmap(), spell.GetSpellPositionX(), spell.GetSpellPositionY());
                }
            }
        }

        public void KillEnemyHit()
        {
            foreach (Enemy enemy in enemies)
            {
                foreach (Spell spell in spells)
                {
                    if (enemy.GetEnemyHitbox().IntersectsWith(spell.GetSpellHitbox()) && enemy.IsAlive() && spell.IsAlive())
                    {
                        spell.GetSpellBitmap().Dispose();
                        spell.Kill();
                        enemy.GetEnemyBitmap().Dispose();
                        enemy.Kill();
                        Score = Score + 100;
                    }
                }
            }
        }

        public void MoveArcaneBolts()
        {
            foreach (Spell spell in spells)
            {
                spell.Move();
            }
        }

        public int GetPlayerScore()
        {
            return Score;
        }

        public bool GameOver()
        {
            bool gameover = false;
            foreach (Enemy enemy in enemies)
            {
                if (enemy.GetEnemyHitbox().IntersectsWith(player.GetCharacterHitbox()) && enemy.IsAlive())
                {
                    gameover = true;
                }
            }
            return gameover;
        }
    }
}
