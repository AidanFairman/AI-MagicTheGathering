using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class DragonspeakerShaman : Creature
    {


        Card c;
        public DragonspeakerShaman()
            : base("Dragonspeaker Shaman", "1RR", 3, 2, 2, manaColor.Red, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None }, "Dragon spells you cast cost 2colorless less to cast.")
        {
            //foreach (Card c in Field)
            //{
            //    if (c is DragonspeakerShaman)
            //    {
            //        this.ManaByColor[(int)manaColor.Colorless] -= 2;



            //    }


            //}
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
            
        }

        public override void EndOfTurn()
        {
            
        }

        public override void OtherEnterBattlefield(Creature C)
        {
           
        }
    }
}
