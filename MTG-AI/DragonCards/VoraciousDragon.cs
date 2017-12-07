using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class VoraciousDragon : Creature
    {
        public VoraciousDragon()
            : base("Voracious Dragon", "3RR", 5, 4, 4, manaColor.Red, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Flying }, "Devour 1(as this enters the battlefield, you may sacrifice any number of creatures. This creature enters the battlefield with that many +1/+1 counters on it.)  ANNNDD When Vorocious Dragon enters the battlefield, it deals damage to target creature or player equal to twice the number of goblins it devoured.")
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
            Card[] c = AI.Target(new TargetEffects.Devour(), AI.getCurrentGameState());


            Card d = AI.Target(new TargetEffects.Damage((int)(2 * c.Length), TargetEffects.Damage.dmgTarget.Both), AI.getCurrentGameState());
            foreach (Card e in c)
            {
                this.powerCounters += 1;
                this.toughnessCounters += 1;

            }
            foreach(Card e in c)
            {
                AI.sendDirections(String.Format("Devour {0}", e.CName));
            }
            string command;
            if (d != null)
            {
                command = String.Format("Deal {1} damage to {0}, and add {2} +1/+1 counters", d.CName, (2 * c.Length), c.Length);
                if (d is Creature)
                {
                    (d as Creature).Health -= (2 * c.Length);
                    if ((d as Creature).Health <= 0)
                    {
                        d.Field.Remove(d);
                        d.Graveyard.Add(d);
                        command = String.Format("{1}\r\n{0} dies", d.CName, command);
                    }
                }
                

            }
            else
            {
                AI.getCurrentGameState().enemyHealth =- (2 * c.Length);
                command = String.Format("Deal {0} damage to enemy, and add {1} +1/+1 counters", (2 * c.Length), c.Length);
            }
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
