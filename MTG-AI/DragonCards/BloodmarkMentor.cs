using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class BloodmarkMentor : Creature
    {
        public BloodmarkMentor()
            : base("Bloodmark Mentor", "1R", 2, 1, 1, manaColor.Red, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None }, " Red creatures you control have first strike")
        {

        }

        public override void Cast()
        {
           
        }

        public override void EnterBattlefield()
        {
            SummonSick = true;
            foreach (Card c1 in Field)
            {

                if (c1 is Creature)
                {

                    Creature c = c1 as Creature;
                    c.addAbility(Creature.CreatureAbilities.FirstStrike);
                    
                    string command = String.Format("{0} now has first strike.", c1.CName);
                    // string command = String.Format("Return {0} to your hand", c.CName);

                    AI.sendDirections(command);

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
            foreach (Card c1 in Field)
            {

                if (c1 is Creature)
                {

                    Creature c = c1 as Creature;
                    c.removeAbility(Creature.CreatureAbilities.FirstStrike);


                    string command = String.Format("{0} no longer has first strike from {1}.", c1.CName, CName);
                    // string command = String.Format("Return {0} to your hand", c.CName);

                    AI.sendDirections(command);

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

        public override void OtherEnterBattlefield(Creature C)
        {
            C.addAbility(CreatureAbilities.FirstStrike);
        }
    }
}
