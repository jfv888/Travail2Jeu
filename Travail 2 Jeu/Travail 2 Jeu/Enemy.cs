using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Travail_2_Jeu
{
    class Enemy
    {
        private int enemyNumber;
        private int enemyPointReward;
        private Image enemy;
        private Bitmap enemyBitmap;
        private int enemyWidth;
        private int enemyHeight;
        private int enemySkinPositionX;
        private int enemySkinPositionY;
        private int enemyPositionX;
        private int enemyPositionY;
        private int enemySpeed;
        private RectangleF enemySkin;
        private RectangleF enemyHitbox;
        private bool alive;

        public Enemy(int enemyNumber, int enemyPositionX, int enemySpeed)
        {
            this.enemyNumber = enemyNumber;
            if(enemyNumber % 5 == 0)
            {
                this.enemy = Image.FromFile("../../Images/dead_lich.png");
                this.enemyPointReward = 300;
                this.enemySpeed = enemySpeed * 3 / 2;
            }
            else
            {
                this.enemy = Image.FromFile("../../Images/death_knight.png");
                this.enemyPointReward = 100;
                this.enemySpeed = enemySpeed;
            }
            this.enemyWidth = 47;
            this.enemyHeight = 64;
            this.enemySkinPositionX = 48;
            this.enemySkinPositionY = 128;
            this.enemyPositionX = enemyPositionX;
            this.enemyPositionY = 0;
            this.enemyBitmap = new Bitmap(enemy, 144, 256);
            this.enemySkin = new RectangleF(enemySkinPositionX, enemySkinPositionY, enemyWidth, enemyHeight);
            this.enemyHitbox = new RectangleF(enemyPositionX, enemyPositionY, enemyWidth, enemyHeight);
            this.alive = true;
        }

        public Bitmap GetEnemyBitmap()
        {
            return enemyBitmap;
        }

        public void SetEnemyWalkAnimation(int enemySkinPositionX)
        {
            this.enemySkinPositionX = enemySkinPositionX;
        }

        public int GetEnenyWalkAnimation()
        {
            return enemySkinPositionX;
        }

        public void Move()
        {
            enemyPositionY += enemySpeed;
        }

        public int GetEnemyPositionX()
        {
            return enemyPositionX;
        }

        public int GetEnemyPositionY()
        {
            return enemyPositionY;
        }

        public RectangleF GetEnemySkin()
        {
            enemySkin = new RectangleF(enemySkinPositionX, enemySkinPositionY, enemyWidth, enemyHeight);
            return enemySkin;
        }

        public RectangleF GetEnemyHitbox()
        {
            enemyHitbox = new RectangleF(enemyPositionX, enemyPositionY, enemyWidth, enemyHeight);
            return enemyHitbox;
        }

        public bool IsAlive()
        {
            return alive;
        }

        public void Kill()
        {
            alive = false;
            enemy.Dispose();
            enemyBitmap.Dispose();
        }

        public int GetPointReward()
        {
            return enemyPointReward;
        }
    }
}
