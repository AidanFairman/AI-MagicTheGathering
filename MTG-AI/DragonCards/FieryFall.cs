using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class FieryFall : Spell
    {
        public FieryFall()
            : base("Fiery Fall", "5R", 6, "Fiery Fall deals 5 damage to target creature.  Basic landcycling Pay '1R' and discard this card: Search our library for a basic land card, reveal it, and put it in your hand. Then shuffle your library.", "R", Spell.spellSpeed.instant)
        {

        }

        public override void Cast()
        {
            //insert card TargetEffects
            Card c = AI.Target(new TargetEffects.Damage(5, TargetEffects.Damage.dmgTarget.Both), AI.getCurrentGameState());

            if (c != null)
            {
                AI.sendDirections(String.Format("Do 5 damamge to {0}", c.CName));
                // string command = String.Format("Return {0} to your hand", c.CName);
                if (c is Creature)
                {
                    (c as Creature).Health -= 2;
                    if ((c as Creature).Health <= 0)
                    {
                        c.Field.Remove(c);
                        c.Graveyard.Add(c);
                        AI.sendDirections(String.Format("{0} dies", c.CName));
                    }
                }

            }

        }

        public override void EndOfTurn()
        {
           
        }
    }
}
