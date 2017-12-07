using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class CinderWall : Creature
    {
        public CinderWall() : base("Cinder Wall", "R", 1, 3, 3, manaColor.Red, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Defender }, "When Cinder Wall blocks, destroy it at end of combat.")
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

            string command = String.Format("Destroy {0} at end of combat", this.CName);
            AI.sendDirections(command);
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
           
        }

        public override void EndOfTurn()
        {
         

        }

        public override void OtherEnterBattlefield(Creature C)
        {
           
        }
    }
}
