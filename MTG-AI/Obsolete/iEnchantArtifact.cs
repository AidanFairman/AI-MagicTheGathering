using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI
{
    interface iEnchantArtifact
    {
        void Cast();
        void EnterBattlefield();
        void Tap();
        void Untap();
        void Ability();
        void EndOfTurn();
    }
}
