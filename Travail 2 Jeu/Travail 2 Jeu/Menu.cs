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
    public partial class Menu : Form
    {
        private int GameDifficulty;

        public Menu()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            LittleGame littleGame = new LittleGame();
            littleGame.SetDifficulty(GameDifficulty);
            littleGame.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            GameDifficulty = 3;
        }

        public void SetGameDifficulty(int GameDifficulty)
        {
            this.GameDifficulty = GameDifficulty;
        }
    }
}
