using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class ThunderDragon: Creature
    {
        Card c;
        public ThunderDragon()
            : base("Thunder Dragon", "5RR", 7, 5, 5, manaColor.Red, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Flying }, "When Thunder Dragon enters the battlefield, t deals 3 damage to each creature without flying.")
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
            LinkedList<Card> killed = new LinkedList<Card>();

            foreach (Card c1 in e_Field)
            {
                if (c1 is Creature)
                {
                    Creature nofly = c1 as Creature;

                    if (!nofly.abilities.Contains(CreatureAbilities.Flying))
                    {
                        nofly.Health -= 3;
                        AI.sendDirections(String.Format("{0} deals 3 damage to {1}", this.CName, nofly.CName));
                        if (nofly.Health <= 0)
                        {
                            killed.AddLast(nofly);
                            AI.sendDirections(String.Format("{0} Died", nofly.CName));
                        }
                    }

                }

            }
            foreach (Card c in killed)
            {
                c.Field.Remove(c);
                c.Graveyard.Add(c);
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
    }
}
