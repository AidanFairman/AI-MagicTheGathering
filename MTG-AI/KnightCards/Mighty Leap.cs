using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Mighty_Leap : Spell
    {
        public Mighty_Leap() : base("Mighty Leap", "1W", 2, "Target creature gets +2/+2 and gains flying until end of turn.", "W", Spell.spellSpeed.instant)
        {

        }
        public override void Cast()
        {
           /* Card target = AI.Target(new TargetEffects.BuffTarget(2, 2, new Creature.CreatureAbilities[] {Creature.CreatureAbilities.Flying}), AI.getCurrentGameState());
            AI.sendDirections(String.Format("{0} gets +2/+2 and flying until end of turn.", target.CName));
            */
        }

        public override void EndOfTurn()
        {
        
        }
    }
}
