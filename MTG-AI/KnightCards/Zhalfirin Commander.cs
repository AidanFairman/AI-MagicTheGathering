using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Zhalfirin_Commander : Creature

    {
        public Zhalfirin_Commander() : base ("Zhalfirin Commander", "2W", 3, 2, 2, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Flanking }, "Flanking (Whenever a creature without flanking blocks this creature, the blocking creature gets -1/-1 until end of turn.) 1WW: Target Knight creature gets +1/+1 until end of turn.")
        {

        }

        public override void Ability()
        {
            this.powerCounters += 1;
            this.toughnessCounters += 1;


            AI.sendDirections(String.Format("{0} gets +1/+1 until end of turn.", this.CName));
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

        public override void OtherEnterBattlefield(Creature C)
        {
           
        }

        public override void Tap()
        {
            
        }

        public override void Untap()
        {
           
        }
    }
}
