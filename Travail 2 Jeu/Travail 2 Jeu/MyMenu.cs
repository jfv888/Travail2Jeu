using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travail_2_Jeu
{
    public partial class MyMenu : Form
    {
        private int GameDifficulty;
        LittleGame littleGame;

        public MyMenu(int GameDifficulty)
        {
            InitializeComponent();
            this.GameDifficulty = GameDifficulty;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (littleGame != null)
            {
                littleGame.Close();
                littleGame.Dispose();
            }
            littleGame = new LittleGame(GameDifficulty);
            littleGame.ShowDialog();
            this.Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings settings = new Settings();
            settings.ShowDialog();
            this.Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
