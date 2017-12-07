using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class JawsOfStone : Spell
    {
        public JawsOfStone()
            : base("Jaws of Stone", "5R", 6, "Jaws of Stone deals X damage divided as you choose among any number of target creatures and/or players, where X is the number of Mountains you control as you cast Jaws of Stone.", "R", Spell.spellSpeed.sorcery)
        {

        }

        public override void Cast()
        {

            int i = 0;
            foreach (Card c in Field)
            {
                if (c is Mountain)
                {
                    ++i;
                }
            }

          
            Card c1 = AI.Target(new TargetEffects.Damage(i, TargetEffects.Damage.dmgTarget.Both), AI.getCurrentGameState());
            if (c1 == null)
            {
                AI.getCurrentGameState().enemyHealth -= i;
                AI.sendDirections(String.Format("Deal {0} damage to enemy player", i));
            }
            else {
                AI.sendDirections(String.Format(" deal {0} damage to {1}", i, c1.CName));
                if (c1 is Creature)
                {
                    (c1 as Creature).Health -= 2;
                    if ((c1 as Creature).Health <= 0)
                    {
                        c1.Field.Remove(c1);
                        c1.Graveyard.Add(c1);
                        AI.sendDirections(String.Format("{0} dies", c1.CName));
                    }
                }
            }

        }

        public override void EndOfTurn()
        {
           
        }
    }
}
