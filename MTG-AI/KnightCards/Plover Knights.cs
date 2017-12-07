using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Plover_Knights : Creature
    {
        public Plover_Knights() : base("Plover Knights", "3WW", 5, 3, 3, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Flying, Creature.CreatureAbilities.FirstStrike }, "Flying, First Strike")
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
