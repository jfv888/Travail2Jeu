using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Travail_2_Jeu
{
    class Player
    {
        private Image character;
        private Bitmap characterBitmap;
        private int playerWidth;
        private int playerHeight;
        private int characterSkinPositionX;
        private int characterSkinPositionY;
        private int playerPositionX;
        private int playerPositionY;
        private int characterSpeed;
        private RectangleF characterSkin;
        private RectangleF characterHitbox;
        private bool alive;

        public Player(int playerPositionX, int playerPositionY)
        {
            this.character = Image.FromFile("../../Images/fallen_warrior.png");
            this.playerWidth = 47;
            this.playerHeight = 64;
            this.playerPositionX = playerPositionX;
            this.playerPositionY = playerPositionY;
            this.characterSkinPositionX = 48;
            this.characterSkinPositionY = 0;
            this.characterSpeed = 5;
            this.characterBitmap = new Bitmap(character, playerWidth, playerHeight);
            this.characterSkin = new RectangleF(characterSkinPositionX, characterSkinPositionY, playerWidth, playerHeight);
            this.characterHitbox = new RectangleF(playerPositionX, playerPositionY, playerWidth, playerHeight);
            this.alive = true;
        }
    }
}
