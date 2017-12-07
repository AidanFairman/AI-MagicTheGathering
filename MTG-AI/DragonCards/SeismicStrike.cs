using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class SeismicStrike : Spell
    {
        public SeismicStrike() : base("Seismic Strike", "2R", 3, "Seismic Strike deals damage to target creature equal to the number of Mountains you control", "R", Spell.spellSpeed.instant)
        {

        }

        public override void EndOfTurn()
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

            //GameState n_state = new GameState(AI.getCurrentGameState(), this);
            Card cc = AI.Target(new TargetEffects.Damage(i, TargetEffects.Damage.dmgTarget.Creature), AI.getCurrentGameState());
            if (cc != null)
            {
                if (cc is Creature)
                {
                    (cc as Creature).Health = ((cc as Creature).Health - i);
                    if ((cc as Creature).Health < 1)
                    {
                        cc.Field.Remove(cc);
                        cc.Graveyard.Add(cc);
                    }
                }
                string command = String.Format(" deal {0} damage to {1}", i, cc.CName);
                AI.sendDirections(command);
            }


        }
    }
}
