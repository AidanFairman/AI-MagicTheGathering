using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Lionheart_Maverick : Creature

    {
        public Lionheart_Maverick() : base ("Lionheart Maverick", "W", 1, 1, 1, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Vigilance }, "4W: Lionheart Maverick gets +1/+2 until end of turn.")
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
