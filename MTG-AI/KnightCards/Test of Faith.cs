using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Test_of_Faith : Spell
    {
        public Test_of_Faith() : base ("Test of Faith", "1W", 2, "Prevent the next 3 damage that would be dealt to target creature this turn, and put a +1/+1 counter on that creature foor each 1 damage prevented this way.", "W", Spell.spellSpeed.instant)
        {

        } 

        public override void Cast()
        {
            
            //Card target = AI.Target(new TargetEffects.BuffTarget(3, 3, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None}), AI.getCurrentGameState());
            //AI.sendDirections(String.Format("{0} gets +3/+3.", target.CName));
        }

        public override void EndOfTurn()
        {
            
        }
    }
}
