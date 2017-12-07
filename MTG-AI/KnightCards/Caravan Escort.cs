using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Caravan_Escort : Creature
    {
        public Caravan_Escort() : base("Caravan Escort", "W", 1, 1, 1, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.LevelUp }, "Level up 2 (2: Put a level counter on this. Level up only as a sorcery.)")
        {

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
