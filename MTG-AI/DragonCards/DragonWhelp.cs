using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class DragonWhelp : Creature
    {
        

        public DragonWhelp()
            : base("Dragon Whelp", "2RR", 4, 2, 3, manaColor.Red, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Flying }, "Pay 'R': Dragon Whelp gets +1/+0 until end of turn. If this ability has been activated four or more time this turn, sacrifice Dragon Whelp at the beginning of the next end step.")
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

        int i = 0;
        public override void Ability()
        {
            //pays 1 mana 

            powerCounters += 1;
            i++;
            // check gamestate if pay for buff


           
        



        }

        public override void EndOfTurn()
        {
            if ( i > 3)
            {
                string command = String.Format("Remove dragon whelp from field");

            } 
        }

        public override void OtherEnterBattlefield(Creature C)
        {
           
        }
    }
}
