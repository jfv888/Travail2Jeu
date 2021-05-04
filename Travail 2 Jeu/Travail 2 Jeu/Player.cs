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
        private bool CastCooldown;

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
            this.characterBitmap = new Bitmap(character, 144, 256);
            this.characterSkin = new RectangleF(characterSkinPositionX, characterSkinPositionY, playerWidth, playerHeight);
            this.characterHitbox = new RectangleF(playerPositionX, playerPositionY, playerWidth, playerHeight);
            this.alive = true;
            this.CastCooldown = false;
        }

        public int GetPlayerWidth()
        {
            return playerWidth;
        }

        public int GetPlayerHeigth()
        {
            return playerHeight;
        }

        public Bitmap GetCharacterBitmap()
        {
            return characterBitmap;
        }

        public void SetCharacterWalkAnimation(int characterSkinPositionX)
        {
            this.characterSkinPositionX = characterSkinPositionX;
        }

        public int GetCharacterWalkAnimation()
        {
            return characterSkinPositionX;
        }

        public int GetPlayerPositionX()
        {
            return playerPositionX;
        }

        public int GetPlayerPositionY()
        {
            return playerPositionY;
        }

        public void Cast()
        {
            characterSkinPositionY = 0;
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
            characterSkin = new RectangleF(characterSkinPositionX, characterSkinPositionY, playerWidth, playerHeight);
            return characterSkin;
        }

        public RectangleF GetCharacterHitbox()
        {
            characterHitbox = new RectangleF(playerPositionX, playerPositionY, playerWidth, playerHeight);
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

        public bool IsOnCooldown()
        {
            return CastCooldown;
        }

        public void SetOnCooldown()
        {
            CastCooldown = true;
        }

        public void SetOffCooldown()
        {
            CastCooldown = false;
        }
    }
}
