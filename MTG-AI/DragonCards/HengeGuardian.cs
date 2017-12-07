using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class HengeGuardian : Creature
    {

        public HengeGuardian()
            : base("Henge Guardian", "5", 5, 3, 4, manaColor.Colorless, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None }, "Pay '2': Henge Guardian gains trample until end of turn.")
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

            //pay 2 gains trample to end of turn

            //insert text command and others
            this.addAbility (CreatureAbilities.Trample);

            //ask about paying for gamestate.

            string command = String.Format("Hengegaurdian gains trample");
            // string command = String.Format("Return {0} to your hand", c.CName);

            AI.sendDirections(command);

        }

        public override void EndOfTurn()
        {
          



        }
    }
}
