using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class BogardanHellkite : Creature
    {
        public BogardanHellkite()
            : base("Bogardan Hellkite", "6RR", 8, 5, 5, manaColor.Red, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Flash, Creature.CreatureAbilities.Flying }, "Flash, Flying When Bogarden Hellkite enters the battlefield, it deals 5 damage divided as you choose among any number of target creatures and/or players.")
        {

        }

        public override void Cast()
        {
           
        }

        public override void EnterBattlefield()
        {
            SummonSick = true;   
            Card c = AI.Target(new TargetEffects.Damage(5,TargetEffects.Damage.dmgTarget.Both), AI.getCurrentGameState());
            if (c == null)
            {
                AI.getCurrentGameState().enemyHealth -= 5;
                AI.sendDirections("Deal 5 damage to enemy player");
            }
            else
            {
                AI.sendDirections(String.Format("Deal 5 damage to {0}.", c.CName));
                if (c is Creature)
                {
                    (c as Creature).Health -= 2;
                    if ((c as Creature).Health <= 0)
                    {
                        c.Field.Remove(c);
                        c.Graveyard.Add(c);
                        AI.sendDirections(String.Format("{0} dies", c.CName));
                    }
                }
            }

           
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

        public override void OtherEnterBattlefield(Creature c)
        {
           
        }
    }
}
