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
    }
}
