using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Knight_of_the_White_Orchid : Creature
    {
        public Knight_of_the_White_Orchid() : base("Knight of the White Orchid", "WW", 2, 2, 2, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.FirstStrike }, "When Knight of the White Orchid enters the battlefield, if an opponent controls more lands than you, you may search your library for a Plains card, put it onto the battlefield, then shuffle your library.")
        {

        }

        public override void OtherEnterBattlefield(Creature C)
        {
            
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
            int enemyLand = 0;
            int forests = 0;
            int plains = 0;

            foreach (Card l in e_Field)
            {
                if (l is Land)
                {
                    enemyLand++;
                }
            }

            foreach (Card c in Field)
            {
                if (c is KnightCards.Forest || c is KnightCards.Selesnya_Sanctuary || c is KnightCards.Treetop_Village)
                {
                    forests++;
                }else if (c is KnightCards.Plains || c is KnightCards.Sejiri_Steppe)
                {
                    plains++;
                }
            }
            
            if ((forests + plains) < enemyLand)
            {
                Card c = null;
                if ((forests * 2) < plains)
                {
                    foreach(Card ca in Library)
                    {
                        if (ca is Forest)
                        {
                            c = ca;
                        }
                    }
                }
                if (plains >= (forests * 2) || c == null)
                {
                    foreach(Card ca in Library)
                    {
                        if (ca is Plains)
                        {
                            c = ca;
                        }
                    }
                }
                if (c != null)
                {   c.Library.Remove(c);
                    c.Field.Add(c);
                    AI.sendDirections(String.Format("{0}'s effect triggers. play a {1} from your library to the battlefield", CName, c.CName));
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
