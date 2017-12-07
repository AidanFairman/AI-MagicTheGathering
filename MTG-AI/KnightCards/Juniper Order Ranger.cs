using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Juniper_Order_Ranger : Creature
    {
        public Juniper_Order_Ranger() : base("Juniper Order Ranger", "3WG", 5, 2, 4, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None }, "Whenever another creature enters the battlefield under your control, put a +1/+1 counter on that creature and a +1/+1 counter on Juniper Order Ranger.")
        {

        }

        public override void OtherEnterBattlefield(Creature C)
        {
            C.powerCounters++;
            C.toughnessCounters++;
            AI.sendDirections(string.Format("{0} gets a +1/+1 counter", C.CName));
            this.powerCounters += 1;
            this.toughnessCounters += 1;
            AI.sendDirections(String.Format("{0} gets a +1/+1 counter.", this.CName));
        }

        public override void Ability()
        {
            
        }

        public override void Attacking()
        {
            
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
