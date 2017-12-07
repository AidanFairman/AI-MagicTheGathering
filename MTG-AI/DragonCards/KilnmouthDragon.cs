using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class KilnmouthDragon : Creature 
    {
        public KilnmouthDragon()
            : base("Kilmouth Dragon", "5RR", 7, 5, 5, manaColor.Red, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Flying }, "Amplify 3 As this creature enters the battlefield, put three +1/+1 counters on it for each Dragon card you reveal in your hand.  AANNNDD pay 'tap': Kilnmouth Dragon deals damage equal to the number of +1/+1 counters on it to target creature or player.")
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
          //  "Amplify 3 As this creature enters the battlefield, put three +1/+1 counters on it for each Dragon card you reveal in your hand. 
          //      AANNNDD pay 'tap': Kilnmouth Dragon deals damage equal to the number of +1/+1 counters on it to target creature or player."
           // int i = 0;
            foreach (Card D in Hand)
            {
                if ((D is DragonFodder) || (D is DragonWhelp) || (D is MordantDragon) || (D is ThunderDragon) || (D is VoraciousDragon) || (D is HengeGuardian) || (D is ShivanHellkite) || (D is BogardanHellkite))
                {
                    this.powerCounters+= 3;
                    this.toughnessCounters+= 3;
                    AI.sendDirections(String.Format("Reveal {0}", D.CName));

                }
            }

            //insert text command and others
            string command = String.Format("add three +1/+1 counter for each dragon revealed in hand, for a total of {0}", this.powerCounters);
            // string command = String.Format("Return {0} to your hand", c.CName);

            AI.sendDirections(command);

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
    }
}
