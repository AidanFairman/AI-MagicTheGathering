using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Heroes_Reunion : Spell

    {
        public Heroes_Reunion()  : base("Heroes' Reunion", "WG", 2, "Target player gains 7 life.", "WG", Spell.spellSpeed.instant)
            {
            
            }

        public override void Cast()
        {
            AI.GainLife(7, AI.getCurrentGameState());
            AI.sendDirections("Gain 7 life");
        }

        public override void EndOfTurn()
        {
            
        }
    }
}
