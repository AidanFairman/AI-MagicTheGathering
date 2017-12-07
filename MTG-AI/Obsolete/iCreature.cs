using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI
{
    interface iCreature
    {
        void Cast();
        void EnterBattlefield();
        void Attacking();
        void Defending();
        void Dead();
        void Tap();
        void Untap();
        void Ability();
        void EndOfTurn();
    }
}
