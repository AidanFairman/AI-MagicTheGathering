using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Knight_Exemplar : Creature
    {
        public Knight_Exemplar() : base ("Knight Exemplar", "1WW", 3, 2, 2, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.FirstStrike, Creature.CreatureAbilities.Indestructable }, "Other Knight creatures you control get +1/+1 and are indestructible.")
        {

        }

        public override void OtherEnterBattlefield(Creature C)
        {
            C.addAbility(CreatureAbilities.Indestructable);
            C.powerCounters++;
            C.toughnessCounters++;
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
                    creature.powerCounters--;
                    creature.toughnessCounters--;
                    creature.removeAbility(CreatureAbilities.Indestructable);

                    AI.sendDirections(String.Format("creatures you control lose +1/+1 and indestructible."));
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
            foreach (Card c in Field)
            {
                if (c is Creature)
                {
                    Creature creature = c as Creature;
                    creature.powerCounters++;
                    creature.toughnessCounters++;
                    creature.addAbility(CreatureAbilities.Indestructable);

                    AI.sendDirections(String.Format("{0} creatures you control get +1/+1 and are indestructible.", creature.CName));
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
