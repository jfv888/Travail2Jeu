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
            this.enemy = Image.FromFile("../../Images/death_knight.png");
            this.enemyWidth = 47;
            this.enemyHeight = 64;
            this.enemySkinPositionX = 48;
            this.enemySkinPositionY = 128;
            this.enemyPositionX = enemyPositionX;
            this.enemyPositionY = 0;
            this.enemySpeed = enemySpeed;
            this.enemyBitmap = new Bitmap(enemy, enemyWidth, enemyHeight);
            this.enemySkin = new RectangleF(enemySkinPositionX, enemySkinPositionY, enemyWidth, enemyHeight);
            this.enemyHitbox = new RectangleF(enemyPositionX, enemyPositionY, enemyWidth, enemyHeight);
            this.alive = true;
        }
    }
}
