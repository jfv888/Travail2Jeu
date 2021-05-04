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
        int Difficulty;

        public Settings()
        {
            InitializeComponent();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            Difficulty = 3;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            Difficulty = 4;
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            Difficulty = 5;
        }
    }
}
