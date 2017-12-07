using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class ClawsOfValakut : ArtifactEnchant
    {
        public ClawsOfValakut()
            : base("Claws of Valakut", "1RR", 4, "R", SpellType.Aura, "enchant creature, Enchanted creature gets +1/+0 for each mountain you control and has first strike.")
        {

        }

        public override void Cast()
        {

           /* int i = 0;
            foreach (Card l in Field)
            {
                if (l is Mountain)
                {
                    ++i;
                }
            }


         

           //insert card TargetEffects
            Card c = AI.Target(new TargetEffects.BuffTarget(i, 0, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.FirstStrike }), AI.getCurrentGameState());
            // Card c = AI.Target(new TargetEffects.ReturnToHand(), AI.getCurrentGameState());

            //insert text command and others
            string command = String.Format("Enchant {0} with +{1}/0 and first strike.", c.CName,i);
            // string command = String.Format("Return {0} to your hand", c.CName);

            AI.sendDirections(command);*/
            


        }

        public override void EnterBattlefield()
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
            
        }

        public override void EndOfTurn()
        {
            
        }
    }
}
