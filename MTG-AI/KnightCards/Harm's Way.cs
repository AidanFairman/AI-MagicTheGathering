using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Harm_s_Way : Spell
    {
        public Harm_s_Way() : base ("Harm's Way","W", 1, "The next 2 damage that a source of your choice would deal to you and/or permanents you control this turn is dealt to target creature or player instead.", "W", Spell.spellSpeed.instant)
        {

        }

        public override void Cast()
        {
            Card c = AI.Target(new TargetEffects.Damage(2, TargetEffects.Damage.dmgTarget.Both), AI.getCurrentGameState());
            if (c != null)
            {
                AI.sendDirections(String.Format("Deal 2 damage to {0}", c.CName));
                if (c is Creature)
                {
                    (c as Creature).Health -= 2;
                    if ((c as Creature).Health <= 0)
                    {
                        c.Field.Remove(c);
                        c.Graveyard.Add(c);
                        AI.sendDirections(String.Format("{0} died", c.CName));
                    }
                }
                
            }
            
        }

        public override void EndOfTurn()
        {
           
        }
    }
}
