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
    public partial class Settings : Form
    {
        int GameDifficulty;

        public Settings()
        {
            InitializeComponent();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            GameDifficulty = 3;
            this.Hide();
            MyMenu mymenu = new MyMenu(GameDifficulty);
            mymenu.ShowDialog();
            this.Close();
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            GameDifficulty = 5;
            this.Hide();
            MyMenu mymenu = new MyMenu(GameDifficulty);
            mymenu.ShowDialog();
            this.Close();
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            GameDifficulty = 7;
            this.Hide();
            MyMenu mymenu = new MyMenu(GameDifficulty);
            mymenu.ShowDialog();
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            GameDifficulty = 4;
        }
    }
}
