using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Knotvine_Paladin : Creature
    {

        int countersGained = 0;
        public Knotvine_Paladin() : base ("Knotvine Paladin", "WG", 2, 2, 2, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None }, "Whenever Knotvine Paladin attacks, it gets +1/+1 until end of turn for each untapped creature you control.")
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
            foreach(Card c in Field)
            {
                if (c is Creature)
                {
                    if (c.Tapped == false)
                    {
                        this.powerCounters += 1;
                        this.toughnessCounters += 1;
                        this.Health += 1;
                        this.countersGained += 1;
                    }
                }
            }

            AI.sendDirections(String.Format("{0} gets +1/+1 for each untapped creature you control. this comes to +{1}/+{1}", this.CName, this.countersGained));
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
            
        }

        public override void EndOfTurn()
        {
            
            AI.sendDirections(String.Format("{0} loses {1} counters at end of turn", this.CName, this.countersGained));
            this.powerCounters -= (int)countersGained;
            this.toughnessCounters -= (int)countersGained;
            this.Health -= (int)countersGained;
            countersGained = 0;
        }

        public override void EnterBattlefield()
        {
            SummonSick = true;
        }

        public override void Tap()
        {
            
        }

        public override void Untap()
        {
            
        }
    }
}
