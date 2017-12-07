using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Paladin_of_Prahv : Creature
    {
        public Paladin_of_Prahv() : base("Paladin of Prahv", "4WW", 6, 3, 4, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None }, "Whenever Paladin of Prahv deals damage, you gain that much life. Forecast - 1W, reveal Paladin of Prahv from your hand: whenever target creature deals damage this turn, you gain that much life. (Activate this ability only during your upkeep and only once each turn.)")
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
            AI.sendDirections(String.Format("{0} will deal damage. Gain {1} life when he does", CName, Power));
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
