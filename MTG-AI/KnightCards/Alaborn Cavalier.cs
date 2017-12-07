using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Alaborn_Cavalier : Creature

    {
        public Alaborn_Cavalier() : base("Alaborn Cavalier", "2WW", 4, 2, 2, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None }, "Whenever Alaborn Cavalier attacks, you may tap target creature.")
        {

        }

        public override void Ability()
        {
            
        }

        public override void Attacking()
        {
            Card c = AI.Target(new TargetEffects.Tap(), AI.getCurrentGameState());
            if (c != null) {
                AI.sendDirections(String.Format("Tap {0}", c.CName));
            }
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
