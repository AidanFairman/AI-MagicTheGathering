using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class MordantDragon : Creature
    {
        Card c;

        public MordantDragon()
            : base("Mordant Dragon", "3RRR", 6, 5, 5, manaColor.Red, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Flying }, "Pay '1R':Mordant Dragon gets +1/+0 until end of turn. Whenever Mordant Dragon deals combat damage to a player, you mat have it deal that much damage to target creature that player controls.")
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
            Card c = AI.Target(new TargetEffects.Damage(this.Power, TargetEffects.Damage.dmgTarget.Creature), AI.getCurrentGameState());
            if (c != null)
            {
                AI.sendDirections(String.Format("{0} deals {1} damage to {2}", CName, this.Power, c.CName));
            }
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

            
            /*Card c = AI.Target(new TargetEffects.BuffTarget(1, 0, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None }), AI.getCurrentGameState());
            
            string command = String.Format("give +1/0 buff to mordant drragon.", c.CName);
            
            AI.sendDirections(command);*/


        }

        public override void EndOfTurn()
        {



            /*//insert text command and others
            string command = String.Format("remove +1/0 buff from murdant dragon {0}", c.CName);
            // string command = String.Format("Return {0} to your hand", c.CName);

            AI.sendDirections(command);*/
        }
    }
}
