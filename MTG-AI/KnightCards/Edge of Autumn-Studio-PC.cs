using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Edge_of_Autumn : Spell

    {
        public Edge_of_Autumn() : base ("Edge of Autumn", "1G", 2, "If you control four or fewer lands, search your library for a basic land card, put it onto the battlefield tapped, then shuffle your library. Cycling - Sacrifice a land (Discard this card: Draw a card.)", "G", Spell.spellSpeed.sorcery)
        {

        }

        public override void Cast()
        {
            int forests = 0;
            int plains = 0;
            foreach (Card c in Field)
            {
                if (c is KnightCards.Forest || c is KnightCards.Selesnya_Sanctuary || c is KnightCards.Treetop_Village)
                {
                    forests++;
                }
                else if (c is KnightCards.Plains || c is KnightCards.Sejiri_Steppe)
                {
                    plains++;
                }
            }

            if ((forests + plains) < 5)
            {
                Card c = null;
                if ((forests * 2) < plains)
                {
                    foreach (Card ca in Library)
                    {
                        if (ca is Forest)
                        {
                            c = ca;
                        }
                    }
                }
                if (plains >= (forests * 2) || c == null)
                {
                    foreach (Card ca in Library)
                    {
                        if (ca is Plains)
                        {
                            c = ca;
                        }
                    }
                }
                if (c != null)
                {
                    c.Tapped = true;
                    c.Library.Remove(c);
                    c.Field.Add(c);
                    AI.sendDirections(String.Format("{0}'s effect triggers. play a {1} from your library to the battlefield tapped", CName, c.CName));
                }

            }



        }

        public override void EndOfTurn()
        {
            
        }
    }
}
