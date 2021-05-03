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

        public int GetPlayerWidth()
        {
            return playerWidth;
        }

        public Bitmap GetCharacterBitmap()
        {
            return characterBitmap;
        }

        public void SetCharacterWalkAnimation(int characterSkinPositionX)
        {
            this.characterSkinPositionX = characterSkinPositionX;
        }

        public int GetPlayerPositionX()
        {
            return playerPositionX;
        }

        public int GetPlayerPositionY()
        {
            return playerPositionY;
        }

        public void GoUp()
        {
            characterSkinPositionY = 0;
            playerPositionY = playerPositionY - characterSpeed;
        }

        public void GoDown()
        {
            characterSkinPositionY = 128;
            playerPositionY = playerPositionY + characterSpeed;
        }

        public void GoLeft()
        {
            characterSkinPositionY = 192;
            playerPositionX = playerPositionX - characterSpeed;
        }

        public void GoRight()
        {
            characterSkinPositionY = 64;
            playerPositionX = playerPositionX + characterSpeed;
        }

        public RectangleF GetCharacterSkin()
        {
            return characterSkin;
        }

        public RectangleF GetCharacterHitbox()
        {
            return characterHitbox;
        }

        public bool IsAlive()
        {
            return alive;
        }

        public void Kill()
        {
            alive = false;
        }
    }
}
