using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Sigil_Blessing : Spell

    {

        public Sigil_Blessing() : base("Sigil Blessing", "WG", 2, "Until end of turn, target creature you control gets +3/+3 and other creatures you control get +1/+1.", "WG", Spell.spellSpeed.instant)

    {

    }

        public override void Cast()
        {
           /* foreach (Card card in Field)
            {
                if (card is Creature)
                {
                    Card target = AI.Target(new TargetEffects.BuffTarget(3, 3, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None }), AI.getCurrentGameState());
                    AI.sendDirections(String.Format("{0} gets +3/+3.", target.CName));

                    if (card is Creature && card != target)
                    {
                        Card c = AI.Target(new TargetEffects.BuffTarget(1, 1, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None }), AI.getCurrentGameState());
                        AI.sendDirections(String.Format("{0} gets +1/+1.", c.CName));
                    }
                }
                
            }
            */
        }

        public override void EndOfTurn()
        {
            //end of turn
        }
    }
}
