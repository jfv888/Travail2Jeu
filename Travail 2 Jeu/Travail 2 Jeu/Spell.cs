using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Travail_2_Jeu
{
    class Spell
    {
        private int spellNumber;
        private Image spell;
        private Bitmap spellBitmap;
        private int spellWidth;
        private int spellHeight;
        private int spellPositionX;
        private int spellPositionY;
        private int spellSpeed;
        private RectangleF spellHitbox;
        private bool onCooldown;
        private bool spellHit;

        public Spell(int spellNumber, int spellPositionX, int spellPositionY)
        {
            this.spellNumber = spellNumber;
            this.spell = Image.FromFile("../../Images/Arcane_Effect.png");
            this.spellWidth = 24;
            this.spellHeight = 32;
            this.spellPositionX = spellPositionX;
            this.spellPositionY = spellPositionY;
            this.spellSpeed = 7;
            this.spellBitmap = new Bitmap(spell, spellWidth, spellHeight);
            this.spellHitbox = new RectangleF(spellPositionX, spellPositionY, spellWidth, spellHeight);
            this.onCooldown = false;
            this.spellHit = false;
        }
    }
}
