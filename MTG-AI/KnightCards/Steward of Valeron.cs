using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Steward_of_Valeron : Creature

    {
        public Steward_of_Valeron() : base("Steward of Valeron", "WG", 2, 2, 2, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Vigilance }, "Vigilance. tap, add G to your mana pool.")
        {

        }

        public override void Ability()
        {
            if (!Tapped)
            Tap();
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
            Tapped = true;
            AI.currentGui.manaAvailable[(int)manaColor.Green]++;
            AI.sendDirections("Add G to mana pool");
        }

        public override void Untap()
        {
            
        }
    }
}
