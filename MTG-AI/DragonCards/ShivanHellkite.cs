using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class ShivanHellkite: Creature
    {
        public ShivanHellkite()
            : base("Shivan Hellkite", "5RR", 7, 5, 5, manaColor.Red, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Flying }, "Pay '1R': Shivan Hellkite deals 1 damage to target creature or player.")
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
            //pay C+R


            //insert card TargetEffects
            Card c = AI.Target(new TargetEffects.Damage(1, TargetEffects.Damage.dmgTarget.Both), AI.getCurrentGameState());

            // Card c = AI.Target(new TargetEffects.ReturnToHand(), AI.getCurrentGameState());

            //insert text command and others
            string command = String.Format("Do one damamge to {0}", c.CName);
            // string command = String.Format("Return {0} to your hand", c.CName);

            AI.sendDirections(command);

        }

        public override void EndOfTurn()
        {
            
        }
    }
}
