using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class SpittingEarth : Spell
    {
        public SpittingEarth()
            : base("Spitting Earth", "1R", 2, "spitting earth deals damage to a target creature equal to the number of Mountains you control", "R,", Spell.spellSpeed.sorcery)
        {

        }

        public override void Cast()
        {

            int i = 0;
            foreach (Card l in Field)
            {
                if (l is Mountain)
                {
                    ++i;
                }
            }
            //insert card TargetEffects
            Card c = AI.Target(new TargetEffects.Damage(i, TargetEffects.Damage.dmgTarget.Creature), AI.getCurrentGameState());
            string command;
            if (c != null) {
                if (c is Creature)
                {
                   command = String.Format("{0} takes {1} damage", c.CName, i);
                    (c as Creature).Health -= (i);
                    if ((c as Creature).Health <= 0)
                    {
                        c.Field.Remove(c);
                        c.Graveyard.Add(c);
                       AI.sendDirections(String.Format("{1}\r\n{0} dies", c.CName, command));
                    }
                    else
                    {
                        AI.sendDirections(command);
                    }
                }
                
                
            }
        }

        public override void EndOfTurn()
        {
            
        }
    }
}
