using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Reprisal : Spell

    {
        public Reprisal() : base ("Reprisal", "1W", 2, "Destroy target creature with power 4 or greater. It can't be regenerated.", "W", Spell.spellSpeed.instant)
        {

        }

        public override void Cast()
        {
            
            int highest = 0;
            Card hc = null;

            foreach (Card c in e_Field)
            {
                if (c is Creature)
                {
                    Creature card = c as Creature;
                    if (card.Power >= 4)
                    {
                        if (card.Power > highest)
                        {
                            highest = card.Power;
                            hc = card;
                        }

                    }
                }
            }

            hc.Field.Remove(hc);
            hc.Graveyard.Add(hc);
            
            AI.sendDirections(String.Format("Destroy {0}. It can't be regenerated.", hc.CName));
        }

        public override void EndOfTurn()
        {
            
        }
    }
}
