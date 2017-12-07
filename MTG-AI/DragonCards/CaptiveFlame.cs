using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class CaptiveFlame : ArtifactEnchant
    {
        public CaptiveFlame()
            : base("Captive Flame", "2R", 3, "R", SpellType.Enchantment, "Pay 'R': Target creature gets +1/+0 until end of turn.")
        {

        }

        public override void EnterBattlefield()
        {

        }

        public override void Cast()
        {
           
        }

        public override void Tap()
        {
           
        }

        public override void Untap()
        {
           
        }

        public override void Ability()
        {


             
           /* Card c = AI.Target(new TargetEffects.BuffTarget(1, 0, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None }), AI.getCurrentGameState());


            //insert text command and others
            string command = String.Format("Enchant {0} with +1/+0 until end of turn.", c.CName);
            // string command = String.Format("Return {0} to your hand", c.CName);

            AI.sendDirections(command);*/



        }

        public override void EndOfTurn()
        {

           
            
            //insert text command and others
            string command = String.Format("remove enchant.");
            // string command = String.Format("Return {0} to your hand", c.CName);

            AI.sendDirections(command);




        }
    }
}
