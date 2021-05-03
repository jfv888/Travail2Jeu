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
        private Bitmap GameBitmap;
        private int GameWidth;
        private int GameHeight;
        private int Score;
        private int enemyCount;
        private int spellCount;

        public Game()
        {
            this.GameBackground = Image.FromFile("../../Image/Grass_Texture.png");
            this.GameWidth = 500;
            this.GameHeight = 800;
            this.player = new Player(GameWidth / 2, GameHeight - 200);
            this.enemies = new List<Enemy>();
            this.spells = new List<Spell>();
            this.GameBitmap = new Bitmap(GameBackground, GameWidth, GameHeight);
            this.Score = 0;
            this.enemyCount = 0;
            this.spellCount = 0;
        }
    }
}
