using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Grasslands : Land
    {
        public Grasslands() : base("Grasslands", "WG", new manaColor[] { })
        {

        }

        public override void Cast()
        {
            Tapped = true;
        }

        public override void Tap()
        {
            if (!Tapped)
            {
                //Field.Remove(this);
                //Graveyard.Add(this);

                LinkedList<Land> landList = new LinkedList<Land>();
                int plainsCount = 0;
                int forestCount = 0;
                foreach (Card c in Field)
                {
                    if (c is Land)
                    {
                        landList.AddLast((Land)c);
                    }
                }

                foreach (Land L in landList)
                {
                    if (L is KnightCards.Plains)
                    {
                        ++plainsCount;
                    }
                    else
                    {
                        ++forestCount;
                    }
                }

                if (plainsCount >= forestCount * 2)
                {
                    AI.sendDirections("Put Forest on battlfield from library");
                    Land lan = null;
                    foreach( Card c in Library)
                    {
                        if (c is Forest)
                        {
                            lan = (c as Land);
                        }
                    }
                    if (lan != null)
                    {
                        Library.Remove(lan);
                        Field.Add(lan);
                    }
                }
                else
                {
                    AI.sendDirections("Put Plains on battlfield from library");
                    Land lan = null;
                    foreach (Card c in Library)
                    {
                        if (c is Plains)
                        {
                            lan = (c as Land);
                        }
                    }
                    if (lan != null)
                    {
                        Library.Remove(lan);
                        Field.Add(lan);
                    }
                }

            }
        }

        public override void Untap()
        {
            
        }
    }
}
