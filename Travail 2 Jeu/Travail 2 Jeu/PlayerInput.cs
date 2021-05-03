using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_2_Jeu
{
    class PlayerInput
    {
        private bool MoveUp;
        private bool MoveDown;
        private bool MoveLeft;
        private bool MoveRight;
        private bool CastSpell;

        public PlayerInput()
        {
            MoveUp = false;
            MoveDown = false;
            MoveLeft = false;
            MoveRight = false;
            CastSpell = false;
        }

        public bool GetMoveUp()
        {
            return MoveUp;
        }

        public bool GetMoveDown()
        {
            return MoveDown;
        }

        public void SetMoveUp(bool moveup)
        {
            this.MoveUp = moveup;
        }

        public void SetMoveDown(bool movedown)
        {
            this.MoveDown = movedown;
        }

        public bool GetMoveLeft()
        {
            return MoveLeft;
        }

        public void SetMoveLeft(bool MoveLeft)
        {
            this.MoveLeft = MoveLeft;
        }

        public bool GetMoveRight()
        {
            return MoveRight;
        }

        public void SetMoveRight(bool MoveRight)
        {
            this.MoveRight = MoveRight;
        }

        public bool GetCastSpell()
        {
            return CastSpell;
        }

        public void SetCastSpell(bool CastSpell)
        {
            this.CastSpell = CastSpell;
        }
    }
}
