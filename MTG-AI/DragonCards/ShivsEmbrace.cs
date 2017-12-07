using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class ShivsEmbrace : ArtifactEnchant
    {
        Card c;

        public ShivsEmbrace()
            : base("Shiv's Embrace", "2RR", 2, "R", SpellType.Aura, "enchant creature, enchanted creature gets +2/+2 and has flying.  AND pay 'R': Enchanted creature gets +1/+0 until end of turn.")
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
           
      
          /* //insert card TargetEffects
            Card c = AI.Target(new TargetEffects.BuffTarget(2,2,new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Flying } ), AI.getCurrentGameState());
            // Card c = AI.Target(new TargetEffects.ReturnToHand(), AI.getCurrentGameState());

            //insert text command and others
            
             string command = String.Format("Enchant {0} +2/+2 and flying.", c.CName);

            AI.sendDirections(command);*/

        }

        public override void EndOfTurn()
        {
           


string command = String.Format("remove enchant and flying", c.CName);
            //

        }
    }
}
