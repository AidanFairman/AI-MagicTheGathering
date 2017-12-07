using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class SkirkProspector : Creature
    { 
        public SkirkProspector()
            : base("Skirk Prospector", "R", 1, 1, 1, manaColor.Red, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None }, "Sacrifice a goblin: Add 'R' to your mana pool.")
        {

        }

        public override void OtherEnterBattlefield(Creature C)
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

           // "Sacrifice a goblin: Add 'R' to your mana pool."




        }

        public override void EndOfTurn()
        {
           
        }
    }
}
