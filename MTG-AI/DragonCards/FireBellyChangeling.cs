using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class FireBellyChangeling : Creature
    {
        public FireBellyChangeling()
            : base("Fire-Belly Changling", "1R", 2, 1, 1, manaColor.Red, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Changeling }, " Pay 'R' Fire-Belly Changeling gets +1/+0 until end of turn. Activate this ability no morethan twice each turn.")
        {

        }

        public override void Cast()
        {
            
        }

        public override void EnterBattlefield()
        {
            SummonSick = true;
        }

        public override void Attacking()
        {
            
        }

        public override void Defending()
        {
            
        }

        public override void Dead()
        {
            resetAbilities();
        }

        public override void Tap()
        {
            
        }

        public override void Untap()
        {
            
        }

        public override void Ability()
        {
            int i = 0;  
            if ( i < 2)
            {
// pay 1 mana here
            powerCounters += 1;
                i++;
                //get game state 


            }

            
            
            
               
        }

        public override void EndOfTurn()
        {
            
        }

        public override void OtherEnterBattlefield(Creature C)
        {
           
        }
    }
}
