using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Knight_of_Meadowgrain : Creature
    {
        public Knight_of_Meadowgrain() : base("Knight of Meadowgrain", "WW", 2, 2, 2, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.FirstStrike, Creature.CreatureAbilities.LifeLink }, "First strike, lifelink.")
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
            AI.sendDirections(String.Format("{0} will deal damage. Gain {1} life when he does", CName, Power));
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
        }

        public override void Tap()
        {
            
        }

        public override void Untap()
        {
            
        }
    }
}
