using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Reciprocate : Spell
    {

        public Reciprocate() : base("Reciprocate", "W", 1, "Exile target creature that dealt damage to you this turn", "W", Spell.spellSpeed.instant)
        {
         
        }
   
        public override void Cast()
        {
            
            
        }

        public override void EndOfTurn()
        {
            
        }
    }
}
