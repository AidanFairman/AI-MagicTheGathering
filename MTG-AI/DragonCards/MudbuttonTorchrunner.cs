using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class MudbuttonTorchrunner: Creature
    {
        public MudbuttonTorchrunner()
            : base("Mudbutton Torchrunner", "2R", 3, 1, 1, manaColor.Red, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None }, "When Mudbotton Torchrunner is put into a graveyard from the battlefield, it deals 3 damage to target creature or player.")
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
           
            Card c = AI.Target(new TargetEffects.Damage(3, TargetEffects.Damage.dmgTarget.Both), AI.getCurrentGameState());
            if (c == null)
            {
                AI.getCurrentGameState().enemyHealth -= 3;
                AI.sendDirections("Deal 3 damage to enemy player");
            }
            else {
                AI.sendDirections(String.Format("Do 3 damamge to {0}", c.CName));
                if (c is Creature)
                {
                    (c as Creature).Health -= 3;
                    if ((c as Creature).Health <= 0)
                    {
                        c.Field.Remove(c);
                        c.Graveyard.Add(c);
                        AI.sendDirections(String.Format("{0} dies", c.CName));
                    }
                }
            }
            
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
