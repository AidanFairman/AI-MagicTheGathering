using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Kinsbaile_Cavalier : Creature
    {
        public Kinsbaile_Cavalier() : base("Kinsbaile Cavalier", "3W", 4, 2, 2, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.DoubleStrike }, "Knight creatures you control have double strike.")
        {

        }

        public override void OtherEnterBattlefield(Creature C)
        {
            C.addAbility(CreatureAbilities.DoubleStrike);
            AI.sendDirections(String.Format("{0} has double strike.", C.CName));
        }

        public override void Ability()
        {
            
        }

        public override void Attacking()
        {
            
        }

        public override void Cast()
        {
            
        }

        public override void Dead()
        {
            foreach (Card c in Field)
            {
                if (c is Creature)
                {
                    Creature creature = c as Creature;
                    creature.removeAbility(CreatureAbilities.DoubleStrike);

                    AI.sendDirections(String.Format("Creatures lose double strike."));
                }

            }
            resetAbilities();
        }

        public override void Defending()
        {
            
        }

        public override void EndOfTurn()
        {
            
        }

        public override void EnterBattlefield()
        {
            SummonSick = true;
            foreach(Card c in Field)
            {
                if (c is Creature)
                {
                    Creature creature = c as Creature;
                    
                    creature.addAbility(CreatureAbilities.DoubleStrike);
                    AI.sendDirections(String.Format("{0} has double strike.", creature.CName));
                }

            }
            
        }

        public override void Tap()
        {
            
        }

        public override void Untap()
        {
            
        }
    }
}
