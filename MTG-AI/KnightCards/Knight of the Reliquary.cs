using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Knight_of_the_Reliquary : Creature

    {
        public Knight_of_the_Reliquary() : base("Knight of the Reliquary", "1GW", 3, 2, 2, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None }, "Knight of the Reliquary gets +1/+1 for each land card in your graveyard. Tap, scacrifice a Forest or Plains: Search your library for a land card, put it onto the battlefield, then shuffle your library.")
        {

            
        }

        public override void OtherEnterBattlefield(Creature C)
        {

        }

        public override void Ability()
        {
            

        }

        public override void Attacking()
        {
            int i = 0;
            foreach (Card l in Graveyard)
            {
                if (l is Land)
                {
                    ++i;
                }

            }
            this.toughnessCounters = i;
            this.powerCounters = i;

            AI.sendDirections(String.Format("{0} has +1/+1 for each land card in your graveyard. total {1}", this.CName, i));
        }

        public override void Cast()
        {
            
        }

        public override void Dead()
        {
            resetAbilities();
        }

        public override void Defending()
        {
            Attacking();
        }

        public override void EndOfTurn()
        {
            
        }

        public override void EnterBattlefield()
        {
            SummonSick = true;
            Attacking();
        }

        public override void Tap()
        {
            
        }

        public override void Untap()
        {
            
        }
    }
}
