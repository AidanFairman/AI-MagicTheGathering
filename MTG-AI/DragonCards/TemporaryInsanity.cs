using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class TemporaryInsanity : Spell
    {

        Card c;

        public TemporaryInsanity()
            : base("Temporary Insanity", "3R", 4, "Untap target creature with power less than the number of cards in your graveyard and gain control of it until end of turn. That creature gains haste until end of turn.", "R", Spell.spellSpeed.instant)
        {

        }

        public override void Cast()
        {

            Card c = AI.Target(new TargetEffects.GainControl(), AI.getCurrentGameState());
            if (c != null)
            {
                string command = String.Format("gain control of {0} until end of turn", c.CName);
                AI.sendDirections(command);
                addTarget(c);
                hasEndOfTurnTrigger = true;
            }
            
        }

        public override void EndOfTurn()
        {
            if (hasEndOfTurnTrigger)
            {
                Card c = targets.First.Value;
                string command = String.Format("return {0} to opponants field, if able.", c.CName);
                AI.sendDirections(command);
                hasEndOfTurnTrigger = false;
            }
        }
    }
}
