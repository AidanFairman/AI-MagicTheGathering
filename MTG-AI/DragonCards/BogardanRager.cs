using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class BogardanRager : Creature
    {
        public BogardanRager()
            : base("Bogarden Rager", "5R", 6, 3, 4, manaColor.Red, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Flash }, "When Bogarden Rager enters the battlefield, target creature gets +4/+0 until end of turn.")
        {


        }

        public override void Cast()
        {
           
        }

        public override void EnterBattlefield()
        {

            SummonSick = true;
            //insert card TargetEffects
            /*Card c = AI.Target(new TargetEffects.BuffTarget(4, 0, new Creature.CreatureAbilities[]{ Creature.CreatureAbilities.None } ),   AI.getCurrentGameState());
         
            //insert text command and others
            if (c == null)
            {
                AI.sendDirections("Don't buff anything");
            }
            else
            {
                AI.sendDirections(String.Format("Enchant {0} with +4/+0 until end of turn.", c.CName));
            }*/
           
            // string command = String.Format("Return {0} to your hand", c.CName);

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
           
        }

        public override void EndOfTurn()
        {
           
        }

        public override void OtherEnterBattlefield(Creature C)
        {
           
        }
    }
}
